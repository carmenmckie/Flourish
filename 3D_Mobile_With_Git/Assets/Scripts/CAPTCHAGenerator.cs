using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// CreateAssetMenu: 
// ScriptableObject types will be available in Assets/Create
// This enables ScriptableObject types to be 
// created and stored as .asset files 
[CreateAssetMenu]

// ScriptableObject: does not receive callbacks
// such as .Update() and .Start()
// ScriptableObjects also cannot be attached to GameObjects
// In the same way MonoBehaviours can be. 
// Instead ScriptableObjects are in Project folders. 
public class CAPTCHAGenerator : ScriptableObject
{
    // Array of CAPTCHA objects within the game: 
    public CAPTCHA[] gameCaptchas; 
    
    // Static so that the index is the same between scenes: 
    public static int captchaIndex = 0; 


    public CAPTCHA generateNextCAPTCHA(){
        // "captchaIndex++ % gameCaptchas.Length"
        // = Make sure the index never is greater than or equal to the array length
        // = When captchaIndex equals the Length, it will jump back to being 0 
        return gameCaptchas[(captchaIndex++ % gameCaptchas.Length)];
    }


    // Method to be called from "Submit" when the user enters their CAPTCHA input
    // Bool returned will highlight whether the CAPTCHA is correct or not 
    public bool checkCAPTCHAInput(string userInput, CAPTCHA captchaObject){
        // Shortcut for, return true if userInput equals the value of that 
        // captchaObject, and false if not. 
        return (userInput == captchaObject.Value); 
    }

}
