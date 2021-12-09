using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To import UI elements, e.g. buttons: 
using UnityEngine.UI; 

// Script used for a guardian / parent to create an account 
// Opened via clicking "Create Account" button on the OverallGuardianLoginPanel 
public class CreateAccount : MonoBehaviour
{

    // Changes to true the first time SUBMIT is entered. 
    // * If the user goes off CreateAccount, changes back to false 
    // * If the user presses submit twice, then changes back to false again 
    private bool firstPINSubmitted = false; 

    // Used to display instructions, e.g. enter your PIN, re-enter your PIN... 
    [SerializeField]
    private Text pinInstructions; 

    // Reference to the General KeyPad area (KeypadBackground) which 
    // Contains multiple children objects, (keypad, buttons, pin entered, etc...)
    // To be made not visible when the user is under the countdown time-out: 
    [SerializeField]
    private GameObject keypadBackground; 

    // Instance variable to hold first entered PIN: 
    private string firstEnteredPIN; 
    // Instance variable to hold second entered PIN: 
    private string secondEnteredPIN; 

    // False until made true if the user incorrectly enters two different PINs: 
    private bool PINsDontMatch = false;

    // Reference to a HandleCSV object so that new information can be appended to the .CSV: 
    private HandleCSV csvHandling = new HandleCSV(); 

    // Reference to the pop-up window that is displayed if a PIN is created successfully: 
    [SerializeField]
    private GameObject popUpWindow; 

    // Reference to a KeyPad object, with methods and functionality: 
    [SerializeField]
    private KeyPad createAccountKeypadRef = new KeyPad(); 

     // Empty GameObject grouping together the gameobjects that 
    // are involved in creating a PIN. 
    // (E.g. KeyPad object, creating PIN instructions)
    // Set to be visible if a user hasn't created a custom PIN yet. 
    // When custom PIN has been created, set to not visible. 
    [SerializeField]
    private GameObject generalCreateAccountArea; 

    // GameObject that will be set to visible if a PIN has already
    // Been created, so the user is informed of the update, and the 
    // fact they have already created a PIN. 
    [SerializeField]
    private GameObject PINAlreadyCreatedText; 





    // Dynamically update UI for user: 
    private void Update() {
        // 1. If a PIN hasn't been entered once, display "Please enter your chosen PIN:" 
         if (firstPINSubmitted){
            pinInstructions.text = "Please re-enter your chosen PIN: "; 
        } 
        // 2. If the error message is displayed "please note that PINs have to be 4 digits long..." 
        // (when a user tries to enter a 4+ digit PIN)
        // But then the user deletes a digit to match this, remove the error message: 
        if (createAccountKeypadRef.digitsEnteredCounter == 6){
            createAccountKeypadRef.pinFeedback.text = ""; 
        }
        // 3. Check if the user has already made a custom PIN. 
        // If they have, do not display the option to create a PIN. 
        // As a design decision for 1 PIN per device was chosen as this makes sense. 
        checkIfPINAlreadyMade(); 
    }




    // Method to decide whether generalCreateAccountArea
    // Should be visible to the user or not. 
    // If the user has not already made a custom PIN, 
    //      it will be visible to the user (ask them
    //      to choose their PIN)
    // If the user has already made a PIN, it will NOT 
    //      be visible to the user, as only one custom PIN 
    //      is to be made per device in this prototype game.
    //      And instead, help them by saying if they have 
    //      forgotten their PIN, they can reset it from 
    //      "Forgotten PIN". 
    private void checkIfPINAlreadyMade(){ 
        // Condition check is less than 2 because 
        // 1st entry = test PIN (1111) 
        // 2nd entry will be filled with custom PIN 
        if (HandleCSV.csvLineCounter < 2){
            // Custom PIN not already made, display option to create a PIN 
            generalCreateAccountArea.SetActive(true); 
            PINAlreadyCreatedText.SetActive(false); 
        } if (HandleCSV.csvLineCounter == 2){
            // If a PIN has already been created, csvLineCounter will be equal
            // to 2.
            // If this is the case, do not display the option to create another PIN: 
            generalCreateAccountArea.SetActive(false); 
            // Notify the user of the update by displaying the explanation Text: 
            PINAlreadyCreatedText.SetActive(true); 
        }    
    }


    // Method to be called from .Start() (whenever the class is loaded)
    // Written as a method in case it needs called again 
    // e.g. also called if a user enters two PINs that don't match, and the values
    // need reset so that the user can begin creating a PIN from start again:
    public void restart(){
        if (!PINsDontMatch){
            createAccountKeypadRef.pinFeedback.text = ""; 
        }
        if (PINsDontMatch) {
            // 1. If a user enters two PINs that don't match, display relevant error message, 
            // and call .restart() to reset the process so user can begin the entering PIN 
            // process again: 
            createAccountKeypadRef.pinFeedback.text = "Both PINs do not match. Please start again.";
            PINsDontMatch = false; 
        }
        if(!firstPINSubmitted){
            // At the start of the script, fill enteredDigits
            // with a string array 
            // So that it looks like - - - - 
            // Until the user enters their digits: 
            createAccountKeypadRef.setDigitsEntered(); 
            pinInstructions.text = "Please enter your chosen PIN"; 
            // Reset bools
            // firstPINSubmitted = false; 
            // Make PINsDontMatch false because
            // it's starting again with two new PINs, 
            // It hasn't checked yet if they match 
            PINsDontMatch = false; 
            // clear the PINs so no remaining values are left: 
            firstEnteredPIN = null; 
            secondEnteredPIN = null; 
        }

    }


    // Called from "Submit" button as an onClick event
    private void submitPIN(){
        // If this is the first time submitPIN() has been called
        // from this session:
        if (!firstPINSubmitted){
            // If the PIN isn't long enough: 
            if (createAccountKeypadRef.digitsEnteredCounter != 8){
                Debug.Log("Incorrect amount"); 
                // Tell user the PIN isn't long enough
                createAccountKeypadRef.pinFeedback.text = "Please note that PINs have to be 4 digits long, please enter your 4-digit PIN.";
                return;
            } else {
                // Store the first PIN entered by the user, to be compared later
                firstEnteredPIN = createAccountKeypadRef.extractPIN(); 
                // Clear the PinPad again (so it's '- - - -')
                createAccountKeypadRef.setDigitsEntered(); 
                // Reset the bool so next time submitPIN() is called, 
                // it enters the relevant code-block:
                firstPINSubmitted = true; 
                return; 
            }
        // If this is the second time submitPIN() has been called from this session:     
        } if (firstPINSubmitted){
            // If the PIN isn't long enough: 
            if (createAccountKeypadRef.digitsEnteredCounter != 8){
                Debug.Log("Incorrect amount"); 
                // Tell user the PIN isn't long enough
                createAccountKeypadRef.pinFeedback.text = "Please note that PINs have to be 4 digits long, please enter your 4-digit PIN.";
                return;
            }
              else {
                Debug.Log("Correct amount"); 
                 // Store the first PIN entered by the user, to be compared later
                secondEnteredPIN = createAccountKeypadRef.extractPIN(); 
                // Clear the PinPad again (so it's '- - - -')
                createAccountKeypadRef.setDigitsEntered(); 
                // Reset the bool to reflect that two PINs have been entered, 
                // Set it back to false so if required, the user can repeat this process 
                firstPINSubmitted = false; 
                // Check if the two entered PINs match: 
                if (firstEnteredPIN.Equals(secondEnteredPIN)){
                    Debug.Log("Match");
                    // Since the PINs match, call savePIN(): 
                    savePIN(); 
                    // Notify the user by showing the pop-up window, that their PIN was successful: 
                    StartCoroutine(displayPopUpWindow());
                } // If the PINs don't match, alert the user so they can 
                // repeat the process again: 
                if (!(firstEnteredPIN.Equals(secondEnteredPIN))) {
                    Debug.Log("No Match");
                    PINsDontMatch = true; 
                    // Call restart() to reset the bools so the process can be repeated: 
                    restart(); 
                }
            }
        } 
    }



    // Co-Routine to display a pop-up window
    // Alerting the user that creating their PIN 
    // was successful, called only if their PIN meets 
    // the requirements: 
    private IEnumerator displayPopUpWindow() 
    {
        popUpWindow.SetActive(true); 
        // Show for 3 seconds
        yield return new WaitForSeconds(3); 
        // Then disable pop-up window again: 
        popUpWindow.SetActive(false); 
    }


    // .Start() method to run when this script is first loaded: 
    private void Start() {
        restart(); 
        // Call .checkIfPINAlreadyMade() to know whether the option 
        // To create a PIN should be displayed to the user, or whether 
        // It should be communicated to the user that they have already made a PIN. 
        checkIfPINAlreadyMade(); 
        // Make sure firstEnteredPIN and secondEnteredPIN are null 
        // to begin with, e.g. doesn't remember a PIN 
        // previously entered, for security reasons
        firstEnteredPIN = null; 
        secondEnteredPIN = null; 
    }


    // Method that is only called if the PINs meet the requirements of: 
    // - Being the correct length (4 digits)
    // - PINs are identical 
    private void savePIN(){
        // Since both PINs are the same, just hash the first one cuz the second will be the same value
        string hashed = HashClass.toSHA256(firstEnteredPIN); 
        // Create a new CSVInfo object with the hashed PIN 
        // that can then be passed to the HandleCSV object to 
        // append to the CSV file: 
        CSVInfo newPINEntry = new CSVInfo(hashed); 
        // Append to CSV: 
        csvHandling.appendToCSV(newPINEntry); 
        // Add this CSVInfo object to the internal memory of HandleCSV 
        HandleCSV.currentCSV.Add(newPINEntry);
    }

}
