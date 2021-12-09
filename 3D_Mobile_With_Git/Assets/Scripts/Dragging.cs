using System.Collections;
using UnityEngine;

// Class written to enable touch as an input throughout the game
public class Dragging : MonoBehaviour {

    private GameObjectsManager gameObjectsManager = new GameObjectsManager(); 

    [SerializeField]
    private Camera cameraObject;

    // Private variables for calculations within this class: 
    private Vector3 distanceVector;
    private float posX;
    private float posY;

    private bool objectTouched = false;
    private bool objectIsBeingDragged = false;

    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private Vector3 previousPosition;

    //To store references to all the GameObject objects in the scene: 
    private GameObject[] gardenObjectsInScene = new GameObject[4]; 

    private void Start() {
        // Store a reference in this class to the GardenObjects in the scene 
        // From GameObjectsManager
        // This is so that other objects can be made non-moveable when 
        // one object is being moved, to avoid objects being able to bump into each other
        // and fly off screen: 
        gardenObjectsInScene = gameObjectsManager.getGardenObjectsInScene();
    }


// *** Could be split up into smaller methods 
    // FixedUpdate is called at a different rate to .Update(): 
    // Useful in this case where the moving of objects needs
    // to be smooth: 
    void FixedUpdate () {
        // If there isn't at least one finger touch on the screen: 
        if (Input.touchCount != 1) {
            objectIsBeingDragged = false;
            objectTouched = false;
            if (toDragRigidbody) {
                // Call .objectReleased just to make sure that no changes were made to any object 
                objectReleased(toDragRigidbody);
            }
            // exit - touchinput not valid 
            return;
        }
        // If there is at least one touch, get the first (0th) touch:
        Touch fingerTouch = Input.touches[0];
        // Store the position of the touch in a 3D vector: 
        Vector3 positionOfTouch = fingerTouch.position;
        // If the Touch has just started): 
        if (fingerTouch.phase == TouchPhase.Began) {
            RaycastHit hit;
            // Ray calculated from camera with .ScreenPointToRay() method:
            Ray ray = cameraObject.ScreenPointToRay(positionOfTouch);
            // If the Ray hits something that is a GardenObject: 
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<GardenObject>()){
                // Indicate transform of hitted object: 
                toDrag = hit.transform;
                // Get the object's position: 
                previousPosition = toDrag.position;
                // Get the object's rigidBody:
                toDragRigidbody = toDrag.GetComponent<Rigidbody>();
                // Calculate backwards from World point to Screen point from previous position:
                distanceVector = cameraObject.WorldToScreenPoint(previousPosition);
                // Calculate X position:
                posX = Input.GetTouch(0).position.x - distanceVector.x;
                // Calculate Y position: 
                posY = Input.GetTouch(0).position.y - distanceVector.y;
                // Pass the RigidBody to draggingObject():
                draggingObject(toDragRigidbody);
                // Set objectTouched bool to true:
                objectTouched = true;
            }
        }
        // If the Touch has moved (e.g. user has touched and now dragged): 
        if (objectTouched && fingerTouch.phase == TouchPhase.Moved) {
            objectIsBeingDragged = true;
            // Calculate the updated x / positions based on the touch input: 
            float updatedXPos = Input.GetTouch(0).position.x - posX;
            float updatedYPos = Input.GetTouch(0).position.y - posY;
            // Combine these to make a new Vector: 
            Vector3 updatedPositionVector = new Vector3(updatedXPos, updatedYPos, distanceVector.z);
            // Calculate 'World Position' = the difference between .screenToWorldPoint() of this new
            // Vector position (minus) the position where the touch first started (previousPosition): 
            Vector3 worldPosition = cameraObject.ScreenToWorldPoint(updatedPositionVector) - previousPosition;
            // Set the Z value to null - only want to move objects on x / y axis 
            worldPosition = new Vector3(worldPosition.x, worldPosition.y, 0.0f);
            // Change the velocity of the object's RigidBody 
            toDragRigidbody.velocity = worldPosition / (Time.deltaTime * 10);
            // Set previousPosition to the new position 
            // So that when FixedUpdate() is called again, it is updated that the object has moved
            previousPosition = toDrag.position;
        }
        // If the Touch is cancelled or ended: 
        if (objectIsBeingDragged && (fingerTouch.phase == TouchPhase.Ended || fingerTouch.phase == TouchPhase.Canceled)) {
            // Reset bools so that when this method is called again, the appropriate section of this method can be executed
            objectIsBeingDragged = false;
            objectTouched = false;
            // Reset position 
            previousPosition = new Vector3(0.0f, 0.0f, 0.0f);
             // Reset all object settings within .objectReleased() 
            StartCoroutine(objectReleased(toDragRigidbody));
        }
    }

        // Takes the Rigidbody that the Ray hit as a parameter 
        private void draggingObject (Rigidbody rb) {
            // Make sure gravity is not being used: 
            rb.useGravity = false; 
            // Loop through the GardenObjects
            for(int i=0; i < gardenObjectsInScene.Length; i++ ){
                // Find the objects that are NOT this object 
                // currently being dragged: 
                // (will be null if Destroyed, e.g. if already dragged to Port by user): 
                if (gardenObjectsInScene[i] == null){
                    continue; 
                }
                // freeze the other objects that don't have the applicable tag: 
                else if(rb.tag != gardenObjectsInScene[i].tag)  {
                    // This is to rectify the issue that if dragging an object, and it bumped into 
                    // another object, that other object might fly off the screen and be irretrievable due to the collision
                    gardenObjectsInScene[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
        }    


    // Changed .objectReleased() to be a CoRoutine instead
    // So that there could be a pause (yield return new WaitForSeconds(1))
    // Before snapping the object back to it's original position 
    // (this pause would account for the fact the object may be really near 
    // the Port target, by waiting 1 second, it may float to the area and 
    // then activate the trigger)
    IEnumerator objectReleased(Rigidbody rb){ 
            // To fix "MissingReferenceException" (if the Rigidbody has already been destroyed)
            if (rb == null || rb.GetComponent<GardenObject>() == null){
                yield break; 
            }
            rb.drag = 2;
            rb.useGravity = false;
            // Wait 1 second
            yield return new WaitForSeconds(1); 
            // To fix "MissingReferenceException" 
            if (rb == null || rb.GetComponent<GardenObject>() == null){
                yield break; 
            }
            // When an object enters the port successfully, .getIsMatchedToPort() 
            // will return true 
            // Without this check, an object may snap back to its original position 
            // before it is Destroyed by the Port. 
            if (!rb.GetComponent<GardenObject>().getIsMatchedToPort()){
                rb.GetComponent<GardenObject>().moveBackToStartPosition(); 
            }
            // Reset the constraints for each object in the game back to normal 
            // (other objects are frozen when one object is being dragged, now the object 
            // is released, constraints can go back to normal)
            foreach (GameObject obj in gardenObjectsInScene){
                // (an object will be null if it has been destroyed) 
                if (obj == null){
                    continue; 
                }
                // Clear all previous constraints
                obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; 
                // Add back only Rotation freezing (this is to stop objects rotating in weird ways within the game)
                obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; 
            }
        }

}