using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To able to switch between Game Scenes: 
using UnityEngine.SceneManagement; 

// Script that is used to navigate throughout the main menu of the game 
public class MainMenu : MonoBehaviour
{
    // Used to save the last visited scene, so the user can go back to 
    // the scene they entered Settings from: 
    private static string previousScene;


    // Temporarily used when testing scenes 
    public void LoadScene(string sceneName){ 
        // Call Unity's in-built method to load the Scene: 
        SceneManager.LoadScene(sceneName);
    }


    

    public void LoadSettings(string previousSceneVisited){
        previousScene = previousSceneVisited;
        // // ***
        // // Get the current scene index: 
        // currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        // // Save the currentSceneIndex using PlayerPrefs: 
        // // Allows to save and hold data between scenes: 
        // PlayerPrefs.SetInt("SavedScene", currentSceneIndex); 
        // ***
        SceneManager.LoadScene("Settings");
    }

    public void LoadPreviousScene() {
        // // ***
        // sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        // SceneManager.LoadScene(sceneToContinue); 
        // ***
        // Load the previous scene which is passed 
        // to this class when the user presses 'Settings'
        // (The going back functionality is only needed
        // in Settings)
        SceneManager.LoadScene(previousScene);
    }

    // Method to change Game Scene / start the game 
    public void StartGame(){ 
        // Load the Game Scene (Start of the game)
        // SceneManager.LoadScene("GameBegin"); 
        // Temporarily changed name of scene:
        SceneManager.LoadScene("TestScene");
        
    }

    // Directs the Player back to the LandingPage
    public void BackToHome(){
        // Load the scene "LandingPage" / the home page 
        SceneManager.LoadScene("LandingPage"); 
    }

    // Directs the Player to the Start Game / Load Game page 
    public void OpenStartGamePage(){
        SceneManager.LoadScene("StartGame"); 
    }

    // Directs the Player to where they can choose the Player
    public void OpenChoosePlayerPage(){
        SceneManager.LoadScene("ChoosePlayer");
    }



    // TEST 
    public void OpenChooseMiniGame(){
        SceneManager.LoadScene("ChooseMiniGame");
    }


}



