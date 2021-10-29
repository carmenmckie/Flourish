using System.Collections;
using UnityEngine;


// ***** Class was originally written for use with Mouse
// Needs changed / updated the fact now touch is being used
// A lot can be deleted from .fixedUpdate() 

public class Dragging : MonoBehaviour {

    public string taggedObject;
    public Camera cameraObject;

    // Private variables for calculations within this class: 
    private Vector3 distanceVector;
    private float posX;
    private float posY;

    private bool objectTouched = false;
    private bool objectIsBeingDragged = false;

// *****
    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private Vector3 previousPosition;

    // FixedUpdate is called at a different rate to .Update(): 
    // Useful in this case where the moving of objects needs
    // to be smooth: 
    // !!! Should be split up into smaller methods 
    // And use a control method such as in Settings 
    void FixedUpdate () {
        
        // If there isn't at least one finger touch on the screen: 
        if (Input.touchCount != 1) {
            objectIsBeingDragged = false;
            objectTouched = false;
            if (toDragRigidbody) {
                objectReleased(toDragRigidbody);
            }
            // exit 
            return;
        }
        
        // If there is at least one touch, get the first (0th) touch:
        Touch fingerTouch = Input.touches[0];
        // Store the position of the touch in a vector: 
        Vector3 positionOfTouch = fingerTouch.position;

        // If the Touch has Began (just started): 
        if (fingerTouch.phase == TouchPhase.Began) {
            RaycastHit hit;
            // Ray calculated from camera with .ScreenPointToRay() method:
            Ray ray = cameraObject.ScreenPointToRay(positionOfTouch);

            // If the Ray hits something that is an object that is correctly tagged 
            // as an object to be dragged (has "Moveable" tag): 
            // *********** ORIGINAL BELOW 
                                // if (Physics.Raycast(ray, out hit) && hit.collider.tag == taggedObject) {
            // *********** ORIGINAL ABOVE 
// **************************************
// Due to only one tag being allowed per object
// Swapped the Draggable check from whether it had a "Moveable" tag to whether it is a 
// GardenObject --> because each GardenObject needs its own tag (e.g. Watering Can, Plant Pot)... 
            // MOVED CHECK FROM WHETHER IT HAD "Moveable" tag to whether it's GardenObject ... 
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<GardenObject>()){
            // .tag == taggedObject) {
                // Indicate transform of hitted object 
                toDrag = hit.transform;
                // Objects position 
                previousPosition = toDrag.position;
                // Object's rigidBody 
                toDragRigidbody = toDrag.GetComponent<Rigidbody>();
                // Calculate backwards from World point to Screen point from previous position
                distanceVector = cameraObject.WorldToScreenPoint(previousPosition);
                // Calculate X position
                posX = Input.GetTouch(0).position.x - distanceVector.x;
                // Calculate Y position 
                posY = Input.GetTouch(0).position.y - distanceVector.y;
                // Pass the RigidBody to draggingObject()
                draggingObject(toDragRigidbody);
                // Set objectTouched bool to true 
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
            // Set the Z value to null, only moving objects on x / y axis 
            worldPosition = new Vector3(worldPosition.x, worldPosition.y, 0.0f);
            // Change the velocity of the object's RigidBody 
            toDragRigidbody.velocity = worldPosition / (Time.deltaTime * 10);
            // Set previousPosition to the new position 
            // So that when FixedUpdate() is called again, it is updated that the object has moved
            previousPosition = toDrag.position;
        }

        // If the Touch is cancelled or ended: 
        if (objectIsBeingDragged && (fingerTouch.phase == TouchPhase.Ended || fingerTouch.phase == TouchPhase.Canceled)) {
            // Reset bools 
            objectIsBeingDragged = false;
            objectTouched = false;
            // Reset position 
            previousPosition = new Vector3(0.0f, 0.0f, 0.0f);
            // Reset gravity 
            objectReleased(toDragRigidbody);
        }
        
    }

        // Takes the Rigidbody that the Ray hit as a parameter 
        private void draggingObject (Rigidbody rb) {
            // Don't use gravity while an object is being dragged: 
            rb.useGravity = false;
            rb.drag = 20;
        }

        // Takes the Rigidbody that the Ray hit as a parameter 
        private void objectReleased (Rigidbody rb) {
            // Set gravity back to normal: 
            rb.useGravity = true;
            rb.drag = 5;
        }
}



























