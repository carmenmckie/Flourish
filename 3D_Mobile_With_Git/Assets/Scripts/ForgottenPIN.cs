using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To work with UI elements: 
using UnityEngine.UI; 

// Script to control the panel that is displayed when 
// A parent/ guaridan selects "ForgottenPIN" 
// From InitialGuardianLogInPanel 
public class ForgottenPIN : MonoBehaviour
{
    // CSV read to extract the date the PIN
    // was last changed, to notify the user: 
    // HandleCSV csvHandling = new HandleCSV(); // ???? Bug ? 

    // // List<CSVInfo> that will hold a copy of the current 
    // // List<CSVInfo> held by the HandleCSV class, containing
    // // the current CSV data: 
    // private List<CSVInfo> currentCSVCopy = new List<CSVInfo>(); 

    // // Reference to the Text UI element which notifies user
    // // When the PIN was last changed: 
    public Text pinLastChangedText; 

    // Test: CSV Object 
    // public CSVInfo testCSVInfo; 

    // HandleCSV test = new HandleCSV(); 

    // Internal List in ForgottenPIN
    // public List<CSVInfo> internalList = new List<CSVInfo>(); 

    // GameObject to be set not visible if PIN already created 
    // E.g. Text that says "Would you like to reset your PIN? > Yes > No " 
     // GameObject that will be set to true if a PIN is created 
    // This is to control whether the options to reset PIN are displayed to  the user
    // If the user has not already created a PIN, do not display an option 
    // to reset the PIN - doesn't make sense. 
    public GameObject optionsVisibleIfPINCreated; 


private void Start() {
    displayCorrectForgottenPINOutput(); 

}

private void Update() {
        displayCorrectForgottenPINOutput(); 
    }


    // Currently works when there's 
    // 2 lines minimum in CSV (Headers and 1111 test)
    // Any less and it doesn't work. 
    public void displayCorrectForgottenPINOutput(){
        // Error checking, if no date is returned, it means no PIN has been set - update UI accordingly
        // If a PIN has not been created by the user, do not display information about resetting their PIN 
        // Instead display information about CREATING a PIN
        if (CSVInfo.returnLastDate(HandleCSV.currentCSV) == null) {
            pinLastChangedText.text = "No PIN has been created yet. Please go back and choose Create PIN.";
            Debug.Log("GOt here *78787878" + "'" + CSVInfo.returnLastDate(HandleCSV.currentCSV) + "'");
            // Do NOT display resetting PIN options now, as they don't have a PIN to reset 
            optionsVisibleIfPINCreated.SetActive(false); 
            return; 
        }
        // Here to account for the fact a user may then go and make a PIN and come back: 
        // OR have already created a PIN: 
        if (CSVInfo.returnLastDate(HandleCSV.currentCSV) != null) {
            // Else, getting here means the .csv file of the game contains at least one date. 
            // Update the text on the UI to notify the user when their PIN was last changed:  
            pinLastChangedText.text = "Your PIN was last changed on: \n" + CSVInfo.returnLastDate(HandleCSV.currentCSV);
            Debug.Log("Got here (not null) " + CSVInfo.returnLastDate(HandleCSV.currentCSV));
            // Display resetting PIN options now, as they have created a PIN: 
            optionsVisibleIfPINCreated.SetActive(true); 
            return; 
        }
    }

}
