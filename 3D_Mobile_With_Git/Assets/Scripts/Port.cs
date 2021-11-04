// *Need Method for increasing turnRound 
// That also sets all remaining objects back to normal
// i.e. not greyed over, not kinematic



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To change the instructions UI element 
using UnityEngine.UI; 

// ***? Make singleton
public class Port : MonoBehaviour
{
    GardenObject currentObject; 
    // names of the objects in the scene; 
    private string[] namesOfObjects = new string[4]; 

    // Used to determine what instructions are displayed to the player, e.g. "Welcome to the game" or not 
    private bool startOfGame = true; 

    // Reference to a GameObjectsManager object, to be able to access information about the GardenObject objects in the scene: 
    GameObjectsManager gameObjectsManagerRef; 

    // In order to check (in order) whether the correct objects have been 
    // Dragged to the trigger 
    private int currentIndexOfGame = 0; 

    // Made static so that portInstructionsText could use it 
     private static int turnRound = 1; 

    // **** Same thing done in Settings.cs 
    // ***? Does it have to be static? 
    // The text that will be updated by user input and then used to set the 'Text portInstructions'. 
    // It's static so it saves between scenes Based on the user's input. 
     public static string portInstructionsText; //= "Welcome to the game! Step " + turnRound + ": try drag the plant pot to the square!"; 


    // Green banner given as background to text 
    public Image portInstructionsTextBanner; 

    // Used to check whether the star has been added to the Player at the 
    // end of the game 
    bool starAdded = false; 



    // Text changed to display the current instructions
    // The text has to be changed via a static string rather than 
    // making the text field Static otherwise Unity throws an error 
    public Text portInstructions;



    // MN Testing for sound effects 
    public SoundEffects soundEffectsRef; 



    // To double check whether the game is complete to see whether the game complete sequences should begin
    private bool gameComplete = false; 

    public LevelCompleteAnimation levelCompleteAnimation; 











    public bool getIsGameComplete(){
        return gameComplete; 

    }

    // Used to know which way the arrow has to point in GameObjectsManager.cs 
    public int getCurrentIndexOfGame(){
        return currentIndexOfGame; 
    }

    private void Start() {
        // Instantiate the namesOfObjects array 
        namesOfObjects[0] = "Plant Pot"; 
        namesOfObjects[1] = "Soil"; 
        namesOfObjects[2] = "Seed"; 
        namesOfObjects[3] = "Watering Can";
        // At the start of the game, make sure turnRound is equal to 1 
        turnRound = 1;  
        // Set the UI element 'portInstructions' (Text object) to the String in portInstructionsText: 
        portInstructions.text = portInstructionsText;
        gameComplete = false; 
        // Weds 
        starAdded = false; 
    }

    
    // Called once per frame
    // Based on the gameplay, the string 'portInstructionsText' is assigned new values. So, as soon as the text is changed based on the game-play, 
    // Set the Text element on the UI here so that the user Can read the updated text on the Text element: 
    private void Update(){
        portInstructions.text = portInstructionsText;
        // If the game is complete, show the stars from
        // LevelCompleteAnimation.cs 
        if(gameComplete){
            // Second check is needed to make sure this block 
            // isn't entered into twice in the time it takes 
            // to load the code below. 
            // if(!starAdded){
            endOfGame(starAdded); 
        }
    } 


    // Called at the end of the level 
    public void endOfGame(bool starAdded){
        if (starAdded){
            return;
        } else {
            // Adds star, loads back to choose minigame scene 
            levelCompleteAnimation.gameCompleted(); 
        }
        this.starAdded = true; 
    }












    // Working solution for testing if the objects have been dragged in the correct order;
     private void OnTriggerEnter(Collider other) {
        // If the game is finished, don't begin the game again 
        // currentIndexOfGame must only be LESS than the array count 
         if (currentIndexOfGame >= namesOfObjects.Length){
             portInstructionsTextBanner.gameObject.SetActive(false); 
                portInstructionsText = "";
                // Deactivate the text banner as there are no more instructions: 
                //  portInstructionsTextBanner.enabled = false;                      

                                // portInstructionsText = "Well done, the game is already finished!";
                return; 
        }
        // Get here if the game is not finished yet AND
        // IF THE INCORRECT OBJECT HAS BEEN DRAGGED TO THE PORT: 
        if (!(other.tag == namesOfObjects[currentIndexOfGame])){
            // To fix bug where it automatically started with "Woops, that's not a plant pot, try again"
            // If it is the very start of the game: 
            if(currentIndexOfGame == 0){
                if(startOfGame){ 
                    portInstructionsText = "Welcome to the game! Step " + turnRound + ", try drag the plant pot to the flowerbed!";
                    startOfGame = false; 
                    return; 
                }
            }
            // If the currentIndexOfaGame = 0 BUT it startOfGame = false
            // For example, if an incorrect object has been dragged to the Port while currentIndexOfGame is still 0. 
            if (!startOfGame) { 
                portInstructionsText = "Woops, that's not a " + namesOfObjects[currentIndexOfGame] + " let's try again!"; 
            }
        }
        // IF THE CORRECT OBJECT HAS BEEN DRAGGED TO THE PORT 
        if (other.tag == namesOfObjects[currentIndexOfGame]){
            // If the correct object has been dragged to the port, set it's matchedToPort bool as true 
            other.GetComponent<GardenObject>().objectIsMatchedToPort(); 
            // If it was the last object to be dragged to the port, the game is complete: 
            if (currentIndexOfGame >= namesOfObjects.Length){
                portInstructionsTextBanner.gameObject.SetActive(false); 
                gameComplete = true; 
                // Call SoundEffects.playGameFinishedSound to play the relevant sound effect (it won't 
                // play if the user has turned off sound effects in Settings)
                soundEffectsRef.playGameFinishedSound();
                                    // portInstructionsText = "Yay you did it! The game is finished!";
                                            //  // Deactivate the text banner as there are no more instructions: 
                                            // portInstructionsTextBanner.enabled = false;                      
                portInstructionsText = ""; 
                return; 
            }
            // Only incrememt the index if the correct object was found and it is within the limits of the array 
            else {
                // IF the index is less than the Length minus one
                // E.g. if it's list[2] where the Length is [4] 
                // It can go up to list[3] (that will be the final slot in the array)
                // Needs to check it's less than the Length minus one because "less than the Length" is too much, it throws an error because for example
                // a[3] is less than a[4] but then incrementing a[3] to be a[4] will be IndexOutOfBoundsException 
                if (currentIndexOfGame < namesOfObjects.Length - 1){
                    // Call SoundEffects.playCorrectChoiceSound to play the relevant sound effect (it won't 
                    // play if the user has turned off sound effects in Settings)
                    soundEffectsRef.playCorrectChoiceSound();
                    // Communicate to the user they have made a correct choice, and increment currentIndexOfGame so user knows next object to drag: 
                    portInstructionsText = "Yay! You did it! Now step " + ++turnRound +  " to find the " + namesOfObjects[++currentIndexOfGame];
                    // NOTE: object's are destroyed from GardenObject's .Update() method, where if iMatchedToPort is true, the object is destroyed (hidden)
                } else {
                    portInstructionsTextBanner.gameObject.SetActive(false); 
                    // Increment the game index 
                    currentIndexOfGame++;
                    gameComplete = true; 
                    // Update the user that the game is finished 
                                    // portInstructionsText = "Well done! The game is finished";
                    portInstructionsText = "";
                                    // // Deactivate the text banner as there are no more instructions: 
                                    // portInstructionsTextBanner.enabled = false;                      
                    // Call SoundEffects.playGameFinishedSound to play the relevant sound effect (it won't 
                    // play if the user has turned off sound effects in Settings)
                    soundEffectsRef.playGameFinishedSound();
                }
            }
        }
     }
}












