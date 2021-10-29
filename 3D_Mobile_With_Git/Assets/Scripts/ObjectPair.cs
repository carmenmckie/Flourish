// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ObjectPair : MonoBehaviour
// {

//     // Reference to the Camera used within the scene: 
//     private Camera mainCameraRef; 
//     // Z axis information of the camera 
//     private float cameraZDistance; 
//     // The initial position information held by the **object** 
//     private Vector3 initialPosition; 
//     // Whether the object is connected to the target 
//     // Default false 
//     private bool connectedToTarget = false; 

//     // "const" = constant 
//     // Like "final" in Java kind of
//     // means "the value will not change during the lifetime of the program" - google 
//     // Used to identify the Target: 
//     private const string targetTag = "Target"; 
//     // "value of the worldspace drag distance needed to move the moveable object
//     // out of port" 
//     private const float _dragResponseThreshold = 2; 




//     // Start is called before the first frame update
//     void Start()
//     {
//         // Initialise the mainCameraRef to the Main Camera in the game 
//         // so that the Z axis of the camera can be accessed 
//         mainCameraRef = Camera.main;
//         // *** Calculate Z value of the ame objects 
//         cameraZDistance = mainCameraRef.WorldToScreenPoint(transform.position).z;
//     }


//     // void onMouseDrag(){
//     //     // Variables all the same name .....!
//     //     // "Z axis added to screen point"
//     //     Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZDistance);
//     //     //"Screen point converted to world point" 
//     //     Vector3 newWorldPosition = mainCameraRef.ScreenToWorldPoint(screenPosition); 

//     //     // Check if the GardenObject is not connected 
//     //     if(!connectedToTarget){
//     //         // If it is not connected, it is moved to the newWorldPosition 
//     //         transform.position = newWorldPosition; 
//     //     }
//     //     else if(Vector3.Distance(transform.position, newWorldPosition) > _dragResponseThreshold){
//     //         connectedToTarget = false; 
//     //     }
//     // }

//     // private void onMouseUp(){
//     //     // If the object is not connected to the target, reset it's position back to where it came from 
//     //     if (!connectedToTarget){
//     //         ResetPosition(); 
//     //     }
//     // }

//     // SN 
//     public Vector3 GetPosition(){
//         // Returns position of the GardenObject 
//         return transform.position; 
//     }

//     // SN
//     private void ResetPosition(){
//         // Snaps object back to it's original position 
//         transform.position = initialPosition; 
//     }

//     // SN 
//     public void SetInitialPosition(Vector3 newPosition){
//         initialPosition = newPosition; 
//         transform.position = initialPosition; 
//     }

//     // SN 
//     private void OnTriggerEnter(Collider other){
//         // Check if the object the GardenObject 
//         // has been dragged to has the targetTag
//         // (aka, it has been dragged to the correct place): 
//         if(other.gameObject.tag == targetTag){
//             connectedToTarget = true; 
//             // !!!!Place it on top of the target 
//             transform.position = other.transform.position; 
//         }
//     }





  

//     // // placeholder 
//     // public Vector3 GetPosition(){
//     //     Vector3 test = new Vector3(); 
//     //     return test; 
//     // }

//     // public void SetPosition(Vector3 vector3){
//     //     // 
//     // }
// }
