using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To work with UI elements: 
using UnityEngine.UI; 

// Script to control the panel that is displayed when a parent/ guaridan clicks "ForgottenPIN?" from InitialGuardianLogInPanel 
public class ForgottenPIN : MonoBehaviour {

    // Reference to the Text UI element which notifies user when the PIN was last changed: 
    [SerializeField]
    private Text pinLastChangedText; 

    // PIN NOT already created? = GameObject set to not visible
    //      E.g. Text that says "Would you like to reset your PIN? > Yes > No" 
    //      If the user has not already created a PIN, do not display an option 
    //      to reset the PIN - doesn't make sense. 
    // PIN already created? = Display the option to reset their PIN. 
    [SerializeField]
    private GameObject optionsVisibleIfPINCreated; 


    private void Start() {
        displayCorrectForgottenPINOutput(); 

    }

    private void Update() {
            displayCorrectForgottenPINOutput(); 
        }


    // Checks whether the option to reset a PIN is displayed to the user (if they have created a PIN)
    // Or not (if they haven't created a PIN already - no point asking to reset a PIN if they don't have one)
    private void displayCorrectForgottenPINOutput(){
        // Error checking, if no date is returned, it means no PIN has been set - update UI accordingly
        if (CSVInfo.returnLastDate(HandleCSV.currentCSV) == null) {
            // If a PIN has not been created by the user, do not display information about resetting their PIN 
            // Instead display information about CREATING a PIN
            pinLastChangedText.text = "No PIN has been created yet. Please go back and choose Create PIN.";
            Debug.Log("First if statement in displayCorrectForgottenPINOutput() " + CSVInfo.returnLastDate(HandleCSV.currentCSV));
            // Do NOT display resetting PIN options now, as they don't have a PIN to reset 
            optionsVisibleIfPINCreated.SetActive(false); 
            // Exit 
            return; 
        }
        // Here to account for the fact a user may then go and make a PIN and come back: 
        // OR have already created a PIN: 
        if (CSVInfo.returnLastDate(HandleCSV.currentCSV) != null) {
            // Getting here means the .csv file of the game contains at least one date. 
            // Update the text on the UI to notify the user when their PIN was last changed:  
            pinLastChangedText.text = "Your PIN was last changed on: \n" + CSVInfo.returnLastDate(HandleCSV.currentCSV);
            Debug.Log("Second if statement in displayCorrectForgottenPINOutput() " + CSVInfo.returnLastDate(HandleCSV.currentCSV));
            // Display resetting PIN options now, as they have created a PIN: 
            optionsVisibleIfPINCreated.SetActive(true); 
            return; 
        }
    }

}
