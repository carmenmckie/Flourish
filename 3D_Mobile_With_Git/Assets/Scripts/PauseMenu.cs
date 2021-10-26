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
    public static bool gameIsPaused = false; 

    // Reference to the Canvas UI object the pause screen 
    // is made up of: 
    public GameObject pauseMenuCanvas; 
   
    // *** Attach this to onClickEvent of button? 
    // His video is based on pressing a key down 
    // He also does it from .Update()
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
    //   Resume(); 
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
        // Display the pause menu: 
        // (Otherwise, it is hidden)
        pauseMenuCanvas.SetActive(true); 
        // Set the time to 0 to completely freeze the game: 
        Time.timeScale = 0f; 
        gameIsPaused = true; 
    }

    // **** Create variable name for all scenes 
    public void GoBackToHome(){
        // Resume(); 
        SceneManager.LoadScene("LandingPage");
        // Call Resume() - if 'Go to Home' was pressed
        // from Pause, the game will still 
        // technically be paused. This resets: 
        // Debug.Log("Loading menu"); 
    }

    // *** Need to add a Quit Game scene 
    public void QuitGame(){
        Debug.Log("Quitting game");
        // Application.Quit(); 
    }












    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
