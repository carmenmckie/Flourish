// *Need Method for increasing turnRound 
// That also sets all remaining objects back to normal
// i.e. not greyed over, not kinematic



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To change the instructions UI element 
using UnityEngine.UI; 

// Could make this a Singleton? 
public class Port : MonoBehaviour
{
    GardenObject currentObject; 
    // namesOfObjects at the start of the scene 
    // Changed to string[] = faster than List<string> 
    private string[] namesOfObjects = new string[4]; 

    //*** Test
    private bool startOfGame = true; 


    GameObjectsManager gameObjectsManagerRef; 

    // In order to check (in order) whether the correct objects have been 
    // Dragged to the trigger s
    private int currentIndexOfGame = 0; 

    // Start at 1 so it makes more sense to the player
    // Rather then Step 0, say Step 1 
    // FRI 13.25 made static so that portInstructionsText could use it 
     private static int turnRound = 1; 

    // **** Same ting done in Settings.cs 
    // The text that will be updated by user input and then used to set 
    // the 'Text portInstructions'. 
    // It's static so it saves between scenes 
    // Based on the user's input
    //  By default at the start of the game, instructions are: 
     public static string portInstructionsText = "Welcome to the game! Step " + turnRound + ": try drag the plant pot to the square!"; 


    // Text changed to display the current instructions
    // The text has to be changed via a static string rather than 
    // making the text field Static otherwise Unity throws an error 
    public Text portInstructions;

    private void Start() {
        // Instantiate the namesOfObjects array 
        namesOfObjects[0] = "Plant Pot"; 
        namesOfObjects[1] = "Soil"; 
        namesOfObjects[2] = "Seed"; 
        namesOfObjects[3] = "Watering Can";
        // At the start of the game, make sure turnRound is equal to 1 
        // More commonsensical to say Turn 1 rather than Turn 0 
        turnRound = 1;  
        // Set the UI element 'portInstructions' (Text object) to the String in portInstructionsText: 
        portInstructions.text = portInstructionsText;
        // Debug.Log("Step one: drag the plant pot to the square!");
    }

    // Called once per frame
    // Based on the gameplay, the string 'portInstructionsText' is assigned new 
    // values. So, as soon as the text is changed based on the game-play, 
    // Set the Text element on the UI here so that the user 
    // Can read the updated text on the Text element: 
    private void Update(){
        portInstructions.text = portInstructionsText; 
    }


    // Working solution for testing the objects are being dragged in the correct order
     private void OnTriggerEnter(Collider other) {
        // If the game is finished, don't begin the game again 
        // currentIndexOfGame can only be LESS than the array count 
         if (currentIndexOfGame >= namesOfObjects.Length){
                portInstructionsText = "Well done, the game is already finished!";
                    // Debug.Log("Well done, the game is already finished!");
                return; 
                // Could make a panel visible that says you've completed the game? 
        }
        // Get here if the game is not finished yet 
        if (!(other.tag == namesOfObjects[currentIndexOfGame])){
            // To fix bug where it automatically started with "woops, that's not a plant pot, try again"
            if(currentIndexOfGame == 0){
                if(startOfGame){ 
                    Debug.Log("got here");
                    portInstructionsText = "Welcome to the game! Step " + turnRound + ", try drag the plant pot to the square!";
                    // Debug.Log("Welcome to the game! Step " + turnRound + ", try drag the plant pot to the square!"); 
                    startOfGame = false; 
                    return; 
                }
            }
            if (!startOfGame) { 
                portInstructionsText = "Woops, that's not a " + namesOfObjects[currentIndexOfGame] + " let's try again!"; 
                                        
                                        // *Testing* - Didn't work 
                                            // float hoverForce = 15f; 
                                            // other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);

                if(other.GetComponent<GardenObject>()){
                // *****************************************
                    // Next: Try to get the object to slowly move back to original place
                    // Currently .moveBackToStartPosition() instantly teleports the object back 
                // **********************************************************
                    // ****** Test 
                    // other.GetComponent<GardenObject>().transform.position = other.GetComponent<GardenObject>().startPosition; 
                    // **** Working ... shows the correct positions 
                        Debug.Log(other.GetComponent<GardenObject>().startPosition + ", " + other.GetComponent<GardenObject>().transform.position);
                    // Call method here 
                    other.GetComponent<GardenObject>().moveBackToStartPosition(); 
                }
            //   Debug.Log("Woops, that's not a " + namesOfObjects[currentIndexOfGame] + " let's try again!" );
            }
        }
        if (other.tag == namesOfObjects[currentIndexOfGame]){
            if (currentIndexOfGame >= namesOfObjects.Length){
                portInstructionsText = "Yay you did it! The game is finished!"; 
                // Debug.Log("Yay you did it! The game is finished!");
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
                    // Destroy (hide) the object 1 second after it touching the port 
                    // So that the user sees the number of objects going down 
                    // Hide object as it's already been used 
                    Destroy(other.gameObject,1f); 
                    portInstructionsText = "Yay! You did it! Now step " + ++turnRound +  " to find the " + namesOfObjects[++currentIndexOfGame];
                //   Debug.Log("Yay! You did it! Now step " + ++turnRound +  " to find the " + namesOfObjects[++currentIndexOfGame]);
                } else {
                    portInstructionsText = "Well done! The game is finished";
                    // Debug.Log("Well done! The game is finished");
                }
            }
        }
     }
}

