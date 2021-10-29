// ************
// ObjectPair.cs and MatchTarget.cs Currently not in use anymore .... 
// May be deleted 
// *************




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // 'port' 
// public class MatchTarget : MonoBehaviour
// {
//     // Reference to GardenObject parent 
//     // SN 
//     public GardenObjects _ownerMatchEntity; 

//     private void OnTriggerEnter(Collider other){
//         // If the gameObject has a target behaviour, match the objects 
//         // Set it's reference to CollidedMoveable 
//         //          *** Changes its reference to 'CollidedMoveable' I think?????
//         if(other.gameObject.TryGetComponent(out ObjectPair CollidedMoveable)){
//             // If 'other' has GardenObjects behaviour, 
//             // Inform the GardenObjects _ownerMatchEntity 
//             // That a GardenObject has entered the Target
//             // And it's ObjectPair component is called 'CollidedMoveable'
//                         // ***** Shouldn't hardcode 'true'  
//             _ownerMatchEntity.objectDraggedToTarget(true, CollidedMoveable);
//         }
//     }

//     // When gameObject exits Target 
//     private void OnTriggerExit(Collider other){
//         if(other.gameObject.TryGetComponent(out ObjectPair CollidedMoveable)){
//                                     // ***** Shouldn't hardcode 'false'  
//             // Informing _ownerMatchEntity that a gameObject 
//             // left the target 
//             _ownerMatchEntity.objectDraggedToTarget(false, CollidedMoveable); 
//         }
//     }


//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
