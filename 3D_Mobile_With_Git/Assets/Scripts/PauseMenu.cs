using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// In order to go back to Main Menu / Quit Game
using UnityEngine.SceneManagement; 

// Called when the user pauses the game 
public class PauseMenu : MonoBehaviour
{

    // public static so other scripts can access this
    // To know whether the game is paused or not 
    private static bool gameIsPaused = false; 

    // Reference to the Canvas UI object the pause screen 
    // is made up of: 
    [SerializeField]
    private GameObject pauseMenuCanvas; 

    // Reference to a LoadingBar object
    [SerializeField]
    private LoadingBar loadingBar; 
   
    // Used to determine what method is called 
    // E.g. Pause or Resume 
   public void controlPauseOfGame(){
       // If the game is already paused, resume game: 
       if (gameIsPaused){
           Resume(); 
       }
       else {
           Pause(); 
       }
   }

   private void Start() {
       Time.timeScale = 1f; 
       gameIsPaused = false; 
   }

    // Does the opposite of .Pause() to resume the game: 
    public void Resume(){
        // Hide pause canvas again: 
        pauseMenuCanvas.SetActive(false); 
        // Reset time to normal: 
        Time.timeScale = 1f; 
        // Reset boolean because game is no longer paused: 
        gameIsPaused = false; 
    }

    // 1. Show Pause screen 
    // 2. Stop time (so game is paused)
    // 3. Set boolean to true (so upon clicking resume, 
    // the game is unpaused)
    public void Pause(){
        // Display the pause menu: (Otherwise, it is hidden)
        pauseMenuCanvas.SetActive(true); 
        // Set the time to 0 to completely freeze the game: 
        Time.timeScale = 0f; 
        gameIsPaused = true; 
    }

    // **** Create variable name for all scenes 
    public void GoBackToHome(){
        // Reset time back to normal etc by calling Resume(): 
        Resume(); 
        // Go back to the LandingPage: 
        loadingBar.LoadNewScene("NewLandingPage");
    }


}
