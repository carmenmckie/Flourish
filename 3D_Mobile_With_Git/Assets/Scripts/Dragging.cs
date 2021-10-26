using System.Collections;
using UnityEngine;

public class Dragging : MonoBehaviour {

    // Objects that are tagged 'Moveable' can be dragged.
    // This is to prevent non-tagged objects from being moved in game scenes. 
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
    void FixedUpdate () {
        
        // If there isn't at least one finger touch on the screen: 
        if (Input.touchCount != 1) {
            objectIsBeingDragged = false;
            objectTouched = false;
            if (toDragRigidbody) {
                objectReleased(toDragRigidbody);
            }
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
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == taggedObject) {
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





























// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// // Script to enable the user to move 3D objects
// public class Dragging : MonoBehaviour {
//     private Touch touch; 
//     // So the object isn't moved TOO fast 
//     private float speedModifier; 
//     // Start is called before the first frame update
//     void Start()
//     {
//         speedModifier = 0.01f;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // If at least one finger has touched the screen: 
//         if (Input.touchCount > 0){
//             // Get the first finger's touch: 
//             touch = Input.GetTouch(0);

//             if (touch.phase == TouchPhase.Moved){

//                 // Touch Position is calculated every frame 
//                 transform.position = new Vector3(
//                     transform.position.x + touch.deltaPosition.x * speedModifier, 
//                     transform.position.y + touch.deltaPosition.y * speedModifier, 
//                     transform.position.z + touch.deltaPosition.y * speedModifier); 
                    
//                  }

//                 //   // Touch Position is calculated every frame 
//                 // transform.position = new Vector3(
//                 //     transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, 
//                 //     transform.position.z + touch.deltaPosition.y * speedModifier); 
//                 //  }
                
//             }
//         }
// }




// //          private float distance; 
// //         // By default, we are not dragging any object 
// //         private bool dragging = false; 
// //         private Vector3 offset; 
// //         // The object to drag: 
// //         private Transform toDrag; 

// //         // Update method is called once per frame
// //         void Update(){
// //             // Make a local variable
// //             Vector3 localVector; 
// //             // If there isn't at least one finger touch, 
// //             // exit the method 
// //             if(Input.touchCount != 1){
// //                 dragging = false; 
// //                 return;
// //             }

// //             // Get the first touch:
// //             Touch fingerTouch = Input.touches[0];
// //             Vector3 touchPosition = fingerTouch.position;

// //             // If the touch has began on the screen, the event 
// //             // has been triggered: 
// //             if(fingerTouch.phase == TouchPhase.Began){
// //                 Ray touchRay = Camera.main.ScreenPointToRay(touchPosition); 
// //                 RaycastHit hit; 

// //                 if (Physics.Raycast(touchRay, out hit)){
// //                     if(hit.collider.tag == "cube"){
// //                         toDrag = hit.transform; 
// //                         distance = hit.transform.position.z - Camera.main.transform.position.z; 
// //                         localVector = new Vector3(touchPosition.x, touchPosition.y, distance);
// //                         // To convert the pixels to Unity units so they can be viewed within screen: 
// //                         localVector = Camera.main.ScreenToViewportPoint(localVector);
// //                         // Get the offset between the two values: 
// //                         offset = toDrag.position - localVector; 
// //                         dragging = true; 
// //                     }
// //                 }
// //             }

// //             if (dragging && fingerTouch.phase == TouchPhase.Moved){
// //                 localVector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
// //                 localVector = Camera.main.ScreenToViewportPoint(localVector);
// //                 toDrag.position = localVector + offset;  
// //             }

// //             // If the user ended the touch, or the touch is cancelled, cancel the movement: 
// //             if(dragging && (fingerTouch.phase == TouchPhase.Ended || fingerTouch.phase == TouchPhase.Canceled)){
// //                 dragging = false; 
// //             }


// //         }






// // }


// // //     // the RigidBody that will be set to 
// // //     // the RigidBody of the GameObject this script is attached to: 
// // //     Rigidbody rigidBodyRef; 

// // //     // Method to instantiate rigidBodyRef at the start of the scene: 
// // //     void Start()
// // //     {
// // //         // Instantiate rigidBodyRef to that of the GameObject using this
// // //         // script: 
// // //         rigidBodyRef = GetComponent<Rigidbody>(); 
// // //     }

// // //     // Currently set to mouse!
// // //     private void onTouchDrag(){
// // //         // By setting the z axis to the camera's negative Z position + the 
// // //         // objects Z position, it means the object doesn't teleport 
// // //         Vector3 touchPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
// // //         -Camera.main.transform.position.z + transform.position.z);

// // //         Vector3 objectPosition = Camera.main.ScreenToWorldPoint(touchPosition);

// // //         // Update the object's position to match the new position:
// // //         transform.position = objectPosition;
// // //         // "is kinematic" means the object won't move until it is then set to 
// // //         // false again. E.g. it won't be affected by gravity / move if there's a collusion 
// // //         // with another object
// // //         rigidBodyRef.isKinematic = true; 
// // //     }

// // //     private void whileBeingDragged(){
// // //         // Reset the kinematic element: 
// // //         rigidBodyRef.isKinematic = false; 
// // //     }
    
// // // }
