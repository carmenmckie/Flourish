using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To deal with Image objects: 
using UnityEngine.UI; 

// Class controlling CAPTCHAPanel  
public class CaptchaPanel : MonoBehaviour
{   
   
    // Reference to a KeyPad object needed so the user can enter input: 
    [SerializeField]
    private KeyPad keypadRef; 

    // Reference to the CAPTCHA object that will be displayed on the UI to the user
    [SerializeField]
    private Image captchaImage; 

    // Button to refresh the CAPTCHA displayed to the user
    [SerializeField] 
    private Button refreshCAPTCHAButton; 

    // Submit button on KeyPad UI 
    [SerializeField]
    private Button submitCAPTCHAButton; 

    // Reference to a CAPTCHAGenerator object so that 
    // .generateCAPTCHA() and .checkCAPTCHAInput() can be called: 
    [SerializeField]
   private CAPTCHAGenerator captchaGeneratorRef; 

    // Reference to the currentCAPTCHA object, used to check if the user 
    // Entered the correct matching string value for the CAPTCHA 
   private CAPTCHA currentCAPTCHA; 

   // Reference to a GPLogIn object so that .successfulCaptchaNavigation() can be called: 
   [SerializeField]
   private GPLogIn gpLogInRef; 

   // Reference to a HandleCSV object so that .appendCSV() can be called:
   private HandleCSV csvHandling = new HandleCSV(); 

    private void Start() {
        // Updates UI so CAPTCHA displaeyd to user: 
        generateCAPTCHA(); 
        // Display - - - - pattern on the KeyPad: 
        keypadRef.setDigitsEntered(); 
        // Buttons: 
        // Call .generateCAPTCHA() when refreshCAPTCHAButton is clicked: 
        refreshCAPTCHAButton.onClick.AddListener(generateCAPTCHA); 
        // For Submit button on the keyboard: 
        submitCAPTCHAButton.onClick.AddListener(Submit); 
    }

    // Take a CAPTCHA from CAPTCHAGenerator.cs' array of CAPTCHA 
    // Objects, and add it to the UI: 
    private void generateCAPTCHA(){
        currentCAPTCHA = captchaGeneratorRef.generateNextCAPTCHA(); 
        // Update UI for user: 
        captchaImage.sprite = currentCAPTCHA.getImage(); 
    }

   // Clicked by the user when they want to submit their CAPTCHA they enter
   // via the KeyPad: 
    public void Submit(){
        // Get the input entered by the user on the keypad object: 
        string enteredText = keypadRef.extractPIN(); 
        // Update UI to remove the digits entered by the user: 
        // (Useful if they need to enter the CAPTCHA again): 
        keypadRef.setDigitsEntered(); 
        Debug.Log("Called from CaptchaPanel, enteredText is: " + enteredText); 
        // Pass the text entered by the user to .checkCAPTCHAInput to 
        // check whether it's correct or not: 
        if (captchaGeneratorRef.checkCAPTCHAInput(enteredText, currentCAPTCHA)){
            // If correct / valid: 
            Debug.Log("<color=green>Valid</color>");
            // Erase any previous error messages
            keypadRef.pinFeedback.text = ""; 
            // Remove their PIN from the .csv file as it is now being reset: 
            csvHandling.removeLastPIN(); 
            // Now Take the user to CreateAccount.cs to choose their new PIN:  
            gpLogInRef.successfulCaptchaNavigation(); 
            // Exit 
            return;
            // If their input is not the correct CAPTCHA value: 
        } else if (!(captchaGeneratorRef.checkCAPTCHAInput(enteredText, currentCAPTCHA))) { 
            // Show error message to user: 
            keypadRef.pinFeedback.text = "Incorrect CAPTCHA. Please try again.";
            Debug.Log("<color=red>Invalid</color>");
        }
    }
}
