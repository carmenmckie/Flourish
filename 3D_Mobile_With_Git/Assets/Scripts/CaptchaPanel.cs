using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To deal with Image objects: 
using UnityEngine.UI; 

public class CaptchaPanel : MonoBehaviour
{
    
    // Reference to a KeyPad object needed so the user can enter input: 
    public KeyPad keypadRef; 

    // Reference to the CAPTCHA object that will be displayed on the UI 
    // To the user
    public Image captchaImage; 

    // * ___ uiErrorsText set to KeyPad.pinFeedback 

        // Button to refresh the CAPTCHA displayed to the user 
        public Button refreshCAPTCHAButton; 

        // Submit button on KeyPad UI 
        public Button submitCAPTCHAButton; 

    // Reference to a CAPTCHAGenerator object so that 
    // .generateCAPTCHA() and .checkCAPTCHAInput() can be called: 
   public CAPTCHAGenerator captchaGeneratorRef; 

   private CAPTCHA currentCAPTCHA; 

   // Reference to a GPLogIn object so that .successfulCaptchaNavigation() can 
   // be called: 
   public GPLogIn gpLogInRef; 

   // Reference to a HandleCSV object so that .appendCSV() can be called
   HandleCSV csvHandling = new HandleCSV(); 

    private void Start() {
        generateCAPTCHA(); 
        // Display - - - - pattern on the KeyPad: 
        keypadRef.setDigitsEntered(); 


        // Buttons: 
        // Call .generateCAPTCHA() when refreshCAPTCHAButton is clicked: 
        refreshCAPTCHAButton.onClick.AddListener(generateCAPTCHA); 
        // For Submit button on the keyboard: 
        // submitCAPTCHAButton.onClick.AddListener(Submit); 
    }

    // Change name 
    private void generateCAPTCHA(){
        currentCAPTCHA = captchaGeneratorRef.generateCAPTCHA(); 

        // Update UI for user: 
        captchaImage.sprite = currentCAPTCHA.Image; 
        // *____ uiErrorsText.gameObject.SetActive(false);
    }

    // **** Will also need to call KeyPad to extract the text entered by the user...
    // Change back to public 
    public void Submit(){
        // Get the input entered by the user on the keypad object: 
        string enteredText = keypadRef.extractPIN(); 
        // Update UI to remove the digits entered by the user: 
        // Useful if they need to enter the CAPTCHA again: 
        keypadRef.setDigitsEntered(); 
        Debug.Log(enteredText + " IS <----"); 
        // Pass the text entered by the user to .checkCAPTCHAInput to 
        // check whether it's correct or not: 
        if (captchaGeneratorRef.checkCAPTCHAInput(enteredText, currentCAPTCHA)){
            // Valid 
            Debug.Log("<color=green>Valid</color>");
            // Erase any previous error messages
            keypadRef.pinFeedback.text = ""; 
            // Remove their PIN from the .csv file: 
            csvHandling.removeLastPIN(); 
            // Now Take the user to CreateAccount.cs 
            gpLogInRef.successfulCaptchaNavigation(); 
            return;
        } else if (!(captchaGeneratorRef.checkCAPTCHAInput(enteredText, currentCAPTCHA))) { 
            // Not correct 
            keypadRef.pinFeedback.text = "Incorrect CAPTCHA. Please try again.";
            Debug.Log("<color=red>Invalid</color>");
        }
    }


    // // Method to remove the PIN previously entered by the user 
    // //  As they have asked for it to be reset. 
    // // 1. Remove the last element in HandleCSV's currentCSV
    // // 2. Append this new version of currentCSV to the CSV file 
    // // After this, the user can go to CreateAccount to create a new
    // //  PIN, because the csvLineCounter will be decreased
    // //  Due to this last PIN being deleted. And therefore the 
    // //  options to reset the PIN will be visible again. 
    // public void removePIN(){
    //     //1. Remove the last element in HandleCSV's currentCSV 
    //     HandleCSV.currentCSV.RemoveAt(HandleCSV.currentCSV.Count - 1);
    //     // 2. Append this new version of currentCSV to the CSV file 
    //}


    


}
