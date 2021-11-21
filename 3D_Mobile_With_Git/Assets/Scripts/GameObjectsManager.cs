using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To be able to Shuffle a List: 
using Random = UnityEngine.Random; 
// To be able to access UI elements (e.g. Image)
using UnityEngine.UI; 


// Aims of this class: 
// 1. Load the four objects (watering can, soil, seed, plant pot) in 
// random order each time the game is loaded (so that there's variation 
// for the user))
public class GameObjectsManager : MonoBehaviour
{
    // The arrow in the game pointing from the target object to the Port: 
    public Transform arrowBackground; 
    public Transform arrow; 
    // Port = target area for the user to drag the object to: 
    public Port objective; 
    
    // ***? Does it have to be static 
    private static GameObject[] gardenObjectsInScene = new GameObject[4]; 

    // ***? Does it have to be static 
    static List<Vector3> gardenObjectsPositions;

    // Method to deactivate the arrow when the game is complete - no more objects to be dragged 
    public void deActivateArrow(){ 
        arrowBackground.gameObject.SetActive(false); 
    }

    // Getter 
    public GameObject[] getGardenObjectsInScene(){
        return gardenObjectsInScene; 
    }



    private void Update() {
        // Get the current target object 
        int currentTargetObject = objective.getCurrentIndexOfGame(); 
        // If all the objects have been successfully found, remove the arrow
        // So it's clear the user doesn't have to drag anything else 
        if (currentTargetObject == gardenObjectsInScene.Length){
            deActivateArrow(); 
            return;
        }
        // If the object has already been Destroyed (due to being successfully dragged to Port) don't access it again 
        if (gardenObjectsInScene[currentTargetObject] == null){
            return; 
        }
        // Calculate the direction the arrow should be pointing in 
        // (Arrow should point from current object needed to the Port)
        // This is to help guide the user 
        Vector3 direction = gardenObjectsInScene[currentTargetObject].transform.position; 
        float a = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; 
        // Due to the arrow sprite facing a different direction, change 90 on z axis 
        a += 90; 
        arrowBackground.transform.localEulerAngles = new Vector3(0,0,a); 
        // Changing Arrow's Direction Based off Target Object to Guide User 
        // Get index position of the current target object: 
        int index = objective.getCurrentIndexOfGame(); 
        // Access this element in the array to get position information about it: 
        // (If the object has been destroyed (already dragged to target), then skip): 
        if (gardenObjectsInScene[index] == null){
            return; 
        }
        float targetXpos = gardenObjectsInScene[index].transform.position.x; 
        float targetYpos = gardenObjectsInScene[index].transform.position.y; 
        // Update arrows position based off this to guide user what object to drag: 
        arrow.localPosition = new Vector3(targetXpos, targetYpos, -20); 
        arrowBackground.localPosition = new Vector3(targetXpos, targetYpos, -20);  
    }


   void Start(){
        // Store references to the objects in the scene in a GameObject[] 
// ***? Search GardenObject type rather than manually checking tags? 
        gardenObjectsInScene[0] = GameObject.FindGameObjectWithTag("Plant Pot");
        gardenObjectsInScene[1] = GameObject.FindGameObjectWithTag("Soil"); 
        gardenObjectsInScene[2] = GameObject.FindGameObjectWithTag("Seed"); 
        gardenObjectsInScene[3] = GameObject.FindGameObjectWithTag("Watering Can"); 
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
            // Update the Position attribute of the GardenObject to be the new position: 
            gardenObjectsInScene[i].GetComponent<GardenObject>().setPosition(); 
        }
   }



    // Method to Shuffle a List<> 
   public static void Shuffle<T>(IList<T> list){
       int listCount = list.Count; 
       // Don't shuffle if there's 1 thing left - nothing left to shuffle 
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






