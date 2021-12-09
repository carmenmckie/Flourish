using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to play the background audio throughout the game. Attached to 'BackgroundAudio' Game Object 
public class GameAudio : MonoBehaviour
{
    // Make one static instance so that multiple objects 
    // Playing the same audio aren't created (for example if 
    // the game restarts)
    private static GameAudio instance; 
    
    // So audio is carried through between scenes (rather than turning on and off between scenes)
    private void Awake(){
        if (instance == null) {
            instance = this; 
            DontDestroyOnLoad(transform.gameObject);
        }
        else { 
            // Destroy any duplicates - only want one object
            // playing audio so it can be easily controlled in one place
            Destroy(gameObject);
        }
    }
}
