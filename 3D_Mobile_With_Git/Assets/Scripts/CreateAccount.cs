using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To import UI elements, e.g. buttons: 
using UnityEngine.UI; 

// Script used for a guardian / parent to create an account 
// Opened via clicking "Create Account" button on the OverallGuardianLoginPanel 
public class CreateAccount : MonoBehaviour
{

    // Change this to true the first time SUBMIT is entered 
    // * If the user goes off CreateAccount, change this back to false 
    // * If the user presses submit twice, then change it back to false again 
    private bool firstPINSubmitted = false; 

    // Used to display instructions, e.g. enter your PIN, re-enter your PIN... 
    public Text pinInstructions; 

    // Reference to the General KeyPad area (KeypadBackground) which 
    // Contains multiple children objects, (keypad, buttons, pin entered, etc...)
    // To be made not visible when the user is under the countdown time-out 
    public GameObject keypadBackground; 

    // Instance variable to hold first entered PIN 
    private string firstEnteredPIN; 
    private string secondEnteredPIN; 

    // False until made true 
    private bool PINsDontMatch = false;

    // Reference to a HandleCSV object so that 
    // New information can be appended to the .CSV 
    HandleCSV csvHandling = new HandleCSV(); 

    // Reference to the pop-up window that is displayed if a PIN is entered successfully 
    public GameObject popUpWindow; 

    // Reference to a KeyPad object, with methods and functionality: 
    public KeyPad createAccountKeypadRef = new KeyPad(); 



// __________________________________________
// ______ CreateAccount.cs Methods __________
// __________________________________________


    // Called once per frame: 
    // 1. If a PIN hasn't been entered once, display "Please enter your chosen PIN:" 
    private void Update() {
         if (firstPINSubmitted){
            pinInstructions.text = "Please re-enter your chosen PIN: "; 
        } 
        if (PINsDontMatch) {
            // 2. If a user enters two PINs that don't match, display relevant error message, 
            // and call .restart() to reset the process so user can begin entering PIN 
            // process again: 
            createAccountKeypadRef.pinFeedback.text = "Both PINs do not match. Please start again.";
            restart(); 
        }
        // 3. If the error message is displayed "please note that PINs have to be 4 digits long..." 
        // But then the user deletes a digit to match this, remove the error message: 
        if (createAccountKeypadRef.digitsEnteredCounter == 6){
            createAccountKeypadRef.pinFeedback.text = ""; 
        }    
    }
    
   
    // Method to be called from .Start() (whenevr the class is loaded)
    // Written as a method in case it needs called again 
    // e.g. if a user enters two PINs that don't match, and the values
    // need reset so that the user can begin creating a PIN from start again
    public void restart(){
        if(!firstPINSubmitted){
            // At the start of the script, fill enteredDigits
            // with a string array 
            // So that it looks like - - - - 
            // Until the user enters their digits 
            createAccountKeypadRef.setDigitsEntered(); 
            pinInstructions.text = "Please enter your chosen PIN"; 
            // Reset bools
            firstPINSubmitted = false; 
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
    public void submitPIN(){
        // If this is the first time submitPIN() has been called
        // from this session of CreateAccount.cs being opened, 
        // reset the boool, which will update the UI text for the user
        // from .Update() 
        if (!firstPINSubmitted){
            // Debug.Log("Not long enough"); 
            // If the PIN isn't long enough: 
            if (createAccountKeypadRef.digitsEnteredCounter != 8){
                Debug.Log("Not long enough"); 
                // Tell user the PIN isn't long enough
                createAccountKeypadRef.pinFeedback.text = "Please note that PINs have to be 4 digits long, please enter your 4-digit PIN.";
                return;
            } else {
                // Debug.Log("Correct amount :P "); 
                 // Store the first PIN entered by the user, to be compared later
                firstEnteredPIN = createAccountKeypadRef.extractPIN(); 
                // Clear the PinPad again (so it's '- - - -')
                createAccountKeypadRef.setDigitsEntered(); 
                // Reset the bool so next time submitPIN() is called, 
                // it enters the relevant code-block
                firstPINSubmitted = true; 
                return; 
            }
        } if (firstPINSubmitted){
            // Debug.Log("Not long enough"); 
            // If the PIN isn't long enough: 
            if (createAccountKeypadRef.digitsEnteredCounter != 8){
                Debug.Log("Not long enough"); 
                // Tell user the PIN isn't long enough
                createAccountKeypadRef.pinFeedback.text = "Please note that PINs have to be 4 digits long, please enter your 4-digit PIN.";
                return;
            }
              else {
                Debug.Log("Correct amount :P "); 
                 // Store the first PIN entered by the user, to be compared later
                secondEnteredPIN = createAccountKeypadRef.extractPIN(); 
                // Clear the PinPad again (so it's '- - - -')
                createAccountKeypadRef.setDigitsEntered(); 
                // Reset the bool to reflect that two PINs have been entered, 
                // Set it back to false so if required, the user can repeat this process 
                firstPINSubmitted = false; 
                // Now check if the two entered PINs match: 
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
                    // restart(); 
                }
            }
        } 
    }



    // Co-Routine to display a pop-up window
    // Alerting the user that creating their PIN 
    // was successful, if their PIN meets 
    // the requirements: 
    IEnumerator displayPopUpWindow() 
    {
        popUpWindow.SetActive(true); 
        // Show for 3 seconds
        yield return new WaitForSeconds(3); //this is were the wait will happen. so position it in your func where you want to wait.
        // Then disable pop-up window again: 
        popUpWindow.SetActive(false); 
    }




    // .Start() method to run when this script is first loaded: 
    private void Start() {
        restart(); 
        // Make sure firstEnteredPIN and secondEnteredPIN are null 
        // to begin with, e.g. doesn't remember a PIN 
        // previously entered, for security reasons
        firstEnteredPIN = null; 
        secondEnteredPIN = null; 
    }


    // Method that is only called if the PINs meet the requirements of: 
    // - Being the correct length (4 digits)
    // - PINs are identical 
    public void savePIN(){
        // Since both PINs are the same, just hash the first one and the second will be the same value
        string hashed = HashClass.toSHA256(firstEnteredPIN); 
        // Create a new CSVInfo object with the hashed PIN 
        // that can then be passed to the HandleCSV object to 
        // append to the CSV file: 
        CSVInfo newPINEntry = new CSVInfo(hashed); 
        // Append to CSV: 
        csvHandling.appendToCSV(newPINEntry); 
        // Add this CSVInfo object to the internal memory
        // ************ STAR 
        HandleCSV.currentCSV.Add(newPINEntry);
        // ************

        // Update UI for user so they can see it has been successful: 
        // pinInstructions.text = "PIN successfully saved. Please go back and choose the option to login.";
    }
}
