using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To able to switch between Game Scenes: 
using UnityEngine.SceneManagement; 

// Script that is used to navigate throughout scenes
// Different from GPLogin that is to open / close
// Login specific canvases and panels. 
public class SceneNavigation : MonoBehaviour
{
    // Constants declared because the names of the scenes
    // Will not change for the life of the program: 
    private const string ChooseMiniGame = "ChooseMiniGame";
    private const string NewLandingPage = "NewLandingPage"; 


    // Used to open ChooseMiniGame, called from 
    // NewLandingPage: 
    public void OpenChooseMiniGame(){
        SceneManager.LoadScene(ChooseMiniGame);
    }


    // Used to open NewLandingPage, called
    // as an onClick from "Back to Home" 
    // Button from ChooseMiniGame
    public void backToHome(){
        SceneManager.LoadScene(NewLandingPage);
    }

}

