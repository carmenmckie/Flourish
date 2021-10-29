using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To be able to Shuffle a List: 
using Random = UnityEngine.Random; 


// Aims of this class: 
// 1. Load the four objects (watering can, soil, seed, plant pot) in 
// random order each time the game is loaded (so that there's variation 
// for the user))
public class GameObjectsManager : MonoBehaviour
{
   // Hold reference to the GardenObjects this class manages: 
//    private List<GardenObjects> gardenObjectsInScene; 

                        // // Reference to the Port object 
                        // Port portRef; 


    // *** Made static 
   private static GameObject[] gardenObjectsInScene = new GameObject[4]; 


    // Made instance variable instead 
    // Made static with the hope that it's the same for any GameObjectsManager object
    // Really this class should be some sort of Singleton 
    // Instead of using static methods 
    static List<Vector3> gardenObjectsPositions;








   private List<GameObject> activeGardenObjectsInScene; 

   // *** The number of correct matches so far in the mini-game: 
   private int correctMatchCount; 
   // Number of GardenObjects in the scene: 
   private int numberOfGardenObjects; 

    // ***** May need changed: 
    // Number of matches needed in the scene (4 for beginner purposes rn) 
   private int matchesToWinGame = 4; 


    //Testing ***
    // public List<GardenObjects> getGardenObjectsInScene(){
    //     return gardenObjectsInScene; 
    // }

    // public GameObject[] getGardenObjectsInScene(){
    //     return gardenObjectsInScene; 
    // }
    





   void Start(){
    //    // Store references to the objects in the scene that have the Moveable tag
    //    // in a GameObject[] array: 
    //     gardenObjectsInScene = GameObject.FindGameObjectsWithTag("Moveable");
    //     // int to hold the number of objects in the array: 
    //     numberOfGardenObjects = gardenObjectsInScene.Length;
    //     // Test to make sure it only identifies the corretc objects 
    //    Debug.Log(gardenObjectsInScene.Length + " " + numberOfGardenObjects);
    //    // Randomise the positions so each time the game is loaded, the objects move
    //    // To make it interesting for the player: 
    //    randomiseGardenObjectPositions(); 
    // //    Port.setGameObjectsManagerRef(this); 

    //  void Start(){
     // Store references to the objects in the scene that have the Moveable tag
       // in a GameObject[] array: 
        gardenObjectsInScene[0] = GameObject.FindGameObjectWithTag("Plant Pot");
        gardenObjectsInScene[1] = GameObject.FindGameObjectWithTag("Watering Can"); 
        gardenObjectsInScene[2] = GameObject.FindGameObjectWithTag("Soil"); 
        gardenObjectsInScene[3] = GameObject.FindGameObjectWithTag("Seed"); 
        // int to hold the number of objects in the array: 
        numberOfGardenObjects = gardenObjectsInScene.Length;
       // Randomise the positions so each time the game is loaded, the objects move
       // To make it interesting for the player: 
       randomiseGardenObjectPositions(); 
   }


    // Method that randomises the positions of the garden objects
    // With the goal of making the game more interesting: each time the player 
    // plays, the objects to be dragged aren't always going to be in the same position: 
   void randomiseGardenObjectPositions(){
       // List to store the positions of the GardenObjects: 
       // Stored in a Vector 3 object because it's (x,y,z): 
       List<Vector3> gardenObjectsPositions = new List<Vector3>(); 
       // Loop through GardenObjects in scene and get their Vector3 positions
       for (int i = 0; i < gardenObjectsInScene.Length; i++){
           gardenObjectsPositions.Add(gardenObjectsInScene[i].transform.position);
       }
       // Then randomise the positions of the objects
       Shuffle(gardenObjectsPositions);

       // Now, go through the List<GardenObjects> gardenObjectsInScene
       // And assign each object a random position based off this shuffling: 

        for (int i =0; i < gardenObjectsInScene.Length; i++){
            gardenObjectsInScene[i].transform.position = gardenObjectsPositions[i]; 
        }
   }












//    // Function to Shuffle a List<> 
//    // **************** !!!! 
//    // See if there's better shuffling method 
   public static void Shuffle<T>(IList<T> list){
       int listCount = list.Count; 
       // **** Don't shuffle if there's 1 thing left 
       // List has already been shuffled 
       while (listCount > 1){
           listCount--; 
           // Range between 0 and listCount 
           int randomNumber = Random.Range(0, listCount); 
           T value = list[randomNumber];
           list[randomNumber] = list[listCount];
           list[listCount] = value; 
       }
   }

}
