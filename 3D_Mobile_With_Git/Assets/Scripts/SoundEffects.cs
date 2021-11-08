using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    // By default, turn sound effects on at the start of the game
    // They can be turned off by the Player if desired: 
    // Static as this bool is accessed from various scenes - it cannot go back to its default value when a
    // scene is reloaded!
    public static bool areSoundEffectsOn = true; 
    public AudioSource gameFinishedSound; 
    public AudioSource correctChoiceSound; 

    
    public void playGameFinishedSound(){
        // if sound effects haven't been turned off, play the relevant sound: 
        if(areSoundEffectsOn){
            gameFinishedSound.Play(); 
        } else {
            Debug.Log("'areSoundEffectsOn is false!");
        }
    }

      public void playCorrectChoiceSound(){
        // if sound effects haven't been turned off, play the relevant sound: 
        if(areSoundEffectsOn){
            correctChoiceSound.Play(); 
        } else {
            Debug.Log("'areSoundEffectsOn is false!");
        }
    }


    // Getter for areSoundEffectsOn - used to control whether
    // Sound effects are played, as the user has the option to turn them off. 
    public void setAreSoundEffectsOn(bool value){ 
        areSoundEffectsOn = value; 
    }

}
