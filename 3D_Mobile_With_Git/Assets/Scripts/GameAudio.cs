using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to play the background audio throughout the game. 
// Attached to 'BackgroundAudio' Game Object 
public class GameAudio : MonoBehaviour
{
    
    // So audio is carried through between scenes (rather than 
    // turning on and off between scenes)
    public void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }


}
