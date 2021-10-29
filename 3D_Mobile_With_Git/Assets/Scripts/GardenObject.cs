using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Gets informed and informs other classes
public class GardenObject : MonoBehaviour
{
    // public GameObjectsManager gameObjectsManagerRef;

    // Gets set to true if the object gets correctly matched
    // To the port 
    private bool isMatchedToPort = false; 



    // Getter for bool isMatchedToPort 
    public bool getIsMatchedToPort(){
        return isMatchedToPort; 
    }

}























//     // public GameFeedback gameFeedbackRef; 
//     public ObjectPair objectPairRef; 

//     // The same, change .... 
//     private bool _matched; 




//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     // Need to properly write a ToList() function for GardenObjects 
//     // THIS CLASS SHOULD MAYBE INHERIT FROM GAMEOBJECTMANAGER? OR IMPLEMENT? 
//     // ************ TEST 
//     public List<GardenObjects> ToList(){
//         List<GardenObjects> test = new List<GardenObjects>(); 
//         return test; 
//     }

//     //************* TEST 
//     public Vector3 getGardenObjectPosition(){
//         return objectPairRef.GetPosition(); 
//     }

//     //************* TEST 
//     public void setGardenObjectPosition(Vector3 vector3){
//         objectPairRef.SetInitialPosition(vector3); 
       
//     }

//     // Method to detect if an Object is correctly dragged to the target 
//     // ********* May need adapted to be in order 
//     public void objectDraggedToTarget(bool targetTouched, ObjectPair objectPair){
//         // If an object is dragged to the target and another object
//         // Is not already there
//         if (targetTouched && !_matched){
//             // Set _matched to true if 'objectPair' and 'objectPairRef' are the 
//             // same ObjectPair object 
//             _matched = (objectPair == objectPairRef); 
//             // if _matched is true
//             if (_matched){
//                 // Update the GameObjectsManager that a new match has been made
//                 gameObjectsManagerRef.trackNumberOfMatches(_matched); 
//                 // Update GameFeedback object 
//                     // gameFeedbackRef.ChangeMaterialWithMatch(_matched);  
//             }
//             else if (!targetTouched && _matched){
//                 // _matched starts as true, change to false 
//                 _matched = !(objectPair == objectPairRef);
//                     if(!_matched){
//                         gameObjectsManagerRef.trackNumberOfMatches(_matched); 
//                         // gameFeedbackRef.ChangeMaterialWithMatch(_matched); 
//                     }
//                 }
//             }

//         }
//     }


