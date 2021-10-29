using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Could make this a Singleton? 
public class Port : MonoBehaviour
{
    GardenObject currentObject; 
    // namesOfObjects at the start of the scene 
                private string[] namesOfObjects = new string[4]; 

    // Try make it List instead of array 
    // private List<string> namesOfObjects = new List<string>(); 

    GameObjectsManager gameObjectsManagerRef; 

    // In order to check (in order) whether the correct objects have been 
    // Dragged to the trigger s
    private int currentIndexOfGame = 0; 

    // Start at 1 so it makes more sense to the player
    // Rather then Step 0, say Step 1 
    private int turnRound = 1; 

    private void Start() {
        // Instantiate the namesOfObjects array 
        namesOfObjects[0] = "Plant Pot"; 
        namesOfObjects[1] = "Soil"; 
        namesOfObjects[2] = "Seed"; 
        namesOfObjects[3] = "Watering Can"; 
        // namesOfObjects.Add("Plant Pot"); 
        // namesOfObjects.Add("Soil"); 
        // namesOfObjects.Add("Seed"); 
        // namesOfObjects.Add("Watering Can"); 
        // Debug.Log("Step one: drag the plant pot to the square!");
    }


    // Working solution for testing the objects are being dragged in the correct order
     private void OnTriggerEnter(Collider other) {
        // If the game is finished, don't begin the game again 
        // currentIndexOfGame can only be LESS than the array count 
         if (currentIndexOfGame >= namesOfObjects.Length){
                Debug.Log("Well done, the game is already finished!");
                return; 
                // Could make a panel visible that says you've completed the game? 
        }
        // Get here if the game is not finished yet 
        if (!(other.tag == namesOfObjects[currentIndexOfGame])){
              Debug.Log("Woops, that's not a " + namesOfObjects[currentIndexOfGame] + " try again!" );
        }
        if (other.tag == namesOfObjects[currentIndexOfGame]){
            if (currentIndexOfGame >= namesOfObjects.Length){
                Debug.Log("Yay you did it! The game is finished!");
                return; 
            }
            // Only incrememt the index if the correct object was found 
            else {
                // IF the index is less than the Length minus one
                // E.g. if it's list[2] where the Length is [4] 
                // It can go up to list[3] (that will be the final slot in the array)
                // Need to check it's less than the Length minus one because 
                // "less than the Length" is too much, it throws an error because for example
                // a[3] is less than a[4] 
                // but then incrementing a[3] to be a[4] will be IndexOutOfBoundsException 
                if (currentIndexOfGame < namesOfObjects.Length - 1){
                  Debug.Log("Yay! You did it! Now step " + ++turnRound +  " to find the " + namesOfObjects[++currentIndexOfGame]);
                } else {
                    Debug.Log("Well done! The game is finished");
                }
            }
        }
     }
}


















// Friday 29 October 2021 - 11.54 
// private void OnTriggerEnter(Collider other) {
//          // Didn't work, still displaying "woops... that's not a plant pot" at the start of the game 
//         // Debug.Log("Step " + turnRound + ": drag the plant pot to the square!");

//          // Need to put this array check here 
//          // Otherwise line 40 will throw IndexOutOfBoundsException
//          if (currentIndexOfGame >= namesOfObjects.Count){
//                 Debug.Log("Game finished");
//                 return; 
//                 // Could make a panel visible that says you've completed the game? 
//         }
//         // Check it's not the object first (before incrementing the currentIndexOfGame): 
//         if (!(other.tag == namesOfObjects[currentIndexOfGame])){
//             if (currentIndexOfGame < namesOfObjects.Count){
//               Debug.Log("Woops, that's not a " + namesOfObjects[currentIndexOfGame] + " try again!" );
//             }
//         }
//         if (other.tag == namesOfObjects[currentIndexOfGame]){
//             if (currentIndexOfGame >= namesOfObjects.Count){
//                 Debug.Log("Yay you did it! The game is finished!");
//                 return; 
//             }
//             // Only incrememt the index if the correct object was found 
//             else {
//                 if (currentIndexOfGame < namesOfObjects.Count){
//                   // THIS is the problem ? "namesOfObjects[++currentIndexOfGame]" 
//                   Debug.Log("Yay! You did it! Now step " + ++turnRound +  " to find the " + namesOfObjects[++currentIndexOfGame]);
//                 } else {
//                     Debug.Log("Test2: game is finished");
//                 }
//             }
//         }
//      }
// }
























// Friday 29 Oct 11.47 
//   private void OnTriggerEnter(Collider other) {
//          // Need to put this array check here 
//          // Otherwise line 40 will throw IndexOutOfBoundsException
//          if (currentIndexOfGame >= namesOfObjects.Count){
//                 Debug.Log("Game finished");
//                 return; 
//                 // Could make a panel visible that says you've completed the game? 
//         }
//         // Check it's not the object first (before incrementing the currentIndexOfGame): 
//         if (!(other.tag == namesOfObjects[currentIndexOfGame])){
//             Debug.Log("Woops, that's not a " + namesOfObjects[currentIndexOfGame] + " try again!" );
//         }
//         if (other.tag == namesOfObjects[currentIndexOfGame]){
//             if (currentIndexOfGame >= namesOfObjects.Count){
//                 Debug.Log("Yay you did it! The game is finished!");
//                 return; 
//             }
//             // Only incrememt the index if the correct object was found 
//             else {
//                 Debug.Log("Yay! You did it! Now step " + ++turnRound + " to find the " + namesOfObjects[++currentIndexOfGame]);
//             }
//         }
//      }
// }



//         // E.g. if it equals "Plant Pot" 
//        else if(other.tag == namesOfObjects[currentIndexOfGame]){
//             // Debug.Log(++currentIndexOfGame);
//             Debug.Log("Yay! You did it! Now step " + ++turnRound + " to find the " + namesOfObjects[currentIndexOfGame]);
//             // if(currentIndexOfGame > namesOfObjects.Count){
//             //     Debug.Log("STOP"); 
//             //     return;
//             // // } else {
//             // //     currentIndexOfGame++; 
//             // // }
//             // }
//        }
//         else {
//             Debug.Log("Woops, that's not a " + namesOfObjects[currentIndexOfGame] + " try again!" );
//         }
//         currentIndexOfGame++; 
//         }
// }

     

    //     private void OnTriggerEnter(Collider other) {
    //      // Need to put this array check here 
    //      // Otherwise line 40 will throw IndexOutOfBoundsException
    //      if (currentIndexOfGame >= namesOfObjects.Count){
    //             Debug.Log("Game finished");
    //             return; 
    //             // Could make a panel visible that says you've completed the game? 
    //         }
    //     // E.g. if it equals "Plant Pot" 
    //    else if(other.tag == namesOfObjects[currentIndexOfGame]){
    //         // Debug.Log(++currentIndexOfGame);
    //         Debug.Log("Yay! You did it! Now step " + ++turnRound + " to find the " + namesOfObjects[++currentIndexOfGame]);
    //     }
    //     else {
    //         Debug.Log("Woops, that's not a " + namesOfObjects[currentIndexOfGame] + " try again!" );
    //     }
    //  }




    //  private void OnTriggerEnter(Collider other) {
    //      // Need to put this array check here 
    //      // Otherwise line 40 will throw IndexOutOfBoundsException
    //      if (currentIndexOfGame > namesOfObjects.Count){
    //             Debug.Log("Game finished");
    //             return; 
    //             else if ()
                
    //             // Could make a panel visible that says you've completed the game? 
    //         }
    //     // E.g. if it equals "Plant Pot" 
    //    else if(other.tag == namesOfObjects[currentIndexOfGame]){
    //         // Debug.Log(++currentIndexOfGame);
    //         Debug.Log("Yay! You did it! Now step " + ++turnRound + " to find the " + namesOfObjects[currentIndexOfGame]);
    //         if(currentIndexOfGame > namesOfObjects.Count){
    //             Debug.Log("STOP"); 
    //             return;
    //         } else {
    //             currentIndexOfGame++; 
    //         }
    //     }
    //     else {
    //         Debug.Log("Woops, that's not a " + namesOfObjects[currentIndexOfGame] + " try again!" );
    //     }




















            // Debug.Log("Woop"); 

            // How to convert Collider to GardenObject? 
            // if(other is GardenObject) {

            // }

            // if (other.GetType == UnityEngine.GardenObject){

            // }
        //     if (other.gameObject.GetComponent<GardenObject>()){
        //         Debug.Log("Garden object"); 
        //         // currentObject = other;
        //     }
        //     else {
        //         Debug.Log("Not a garden object");
        //     }

        //     // GameObject currentObject = other.gameObject; 
        //     // // check if the object is a GardenObject 
        //     // // if(currentObject is GardenObject){} 
        //     // currentObject.getIsMatchedToPort() 
        // }

    
    // private void OnTriggerEnter(Collider other) {
    //     // currentObject = new GardenObject(); 

    //     if(other.tag == "Moveable"){
    //         // Debug.Log("Woop"); 

    //         // How to convert Collider to GardenObject? 
    //         // if(other is GardenObject) {

    //         // }

    //         // if (other.GetType == UnityEngine.GardenObject){

    //         // }
    //         if (other.gameObject.GetComponent<GardenObject>()){
    //             Debug.Log("Garden object"); 
    //             // currentObject = other;
    //         }
    //         else {
    //             Debug.Log("Not a garden object");
    //         }

    //         // GameObject currentObject = other.gameObject; 
    //         // // check if the object is a GardenObject 
    //         // // if(currentObject is GardenObject){} 
    //         // currentObject.getIsMatchedToPort() 
    //     }
    // }


    // public void setGameObjectsManagerRef(GameObjectsManager gameObjectsManagerRef){
    //     this.gameObjectsManagerRef = gameObjectsManagerRef; 
    // }


