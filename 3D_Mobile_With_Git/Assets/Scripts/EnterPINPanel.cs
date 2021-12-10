using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import necessary to work with buttons
using UnityEngine.UI; 

// Script to control the display of the panel where the user can enter their PIN
public class EnterPINPanel : MonoBehaviour
{
    // At the start of the game, user has 5 chances to guess the PIN. Set to 4 
    // Because it is first displayed as "you have 4 logins left..."  
    // Specific to EnterPINPanel only: 
    private int loginErrorCountdown = 4; 

    // Reference to the successfulLoginPanel so that it can be made visible to the user 
    // If they enter a correct PIN:
    [SerializeField]
    private GameObject successfulPanelTestCalledFromEnterPin; 

    // KeyPad object so user can enter their PIN via the KeyPad buttons: 
    [SerializeField]
    private KeyPad keypadRef = new KeyPad(); 

    // _______ Timer Specific _______

    private bool isTimerStarted = false; 
    // Timer object: 
    private Timer countdownTimer = new Timer(); 
    // Reference to the General KeyPad area (KeypadBackground) which 
    // Contains multiple children objects, (keypad, buttons, pin entered, etc...)
    // To be made not visible when the user is under the countdown time-out: 
    [SerializeField]
    private GameObject keypadBackground; 
    private bool newTimerNeeded = false; 
    private GameObject testTimer; 




    // Method that controls locking the user out of the entering PIN area
    // If they enter the incorrect PIN too many times (5) before
    // showing the PIN again after 60 seconds 
    private void Update() {
        // newTimerNeeded is set to be true from .displayPINError() if the user enters
        // an incorrect PIN over the limit (5 times) 
        if (newTimerNeeded){
            // Debug.Log("Got to section 1"); 
            // testTimer = reference to the object in the Hierarchy with "Timer" tag 
            countdownTimer = testTimer.GetComponent<Timer>();
            // Call the Timer .Restart() method to create a (currently 60 second) Timer:  
            countdownTimer.GetComponent<Timer>().Restart(); 
            // Set bool so this block isn't entered again until called again from .displayPINError() if user
            // incorrectly guesses PIN another 5 times (once this Timer is finished) 
            newTimerNeeded = false; 
        }
        // If an incorrect PIN has been entered too many times, isTimerStarted 
        // is set to true from .displayPINError(), then this code will execute: 
        if(isTimerStarted == true){
            // Debug.Log("Got to Section 2"); 
            // Make the Timer object visible to the Player: 
            testTimer.SetActive(true);
            // Hide the keypad area until Timer finished: 
            keypadBackground.SetActive(false); 
        }
        // If the Timer is complete, reset the locking out features 
// * M? 
        if (countdownTimer.getTimerComplete() == true ) { 
            // Debug.Log("Got to Section 3"); 
            // 1. Make keypad area visible again: 
            keypadBackground.SetActive(true); 
            // 2. Hide Timer as it has now finished: 
            testTimer.SetActive(false); 
            // 3. Reset loginErrorCountdown back to 4 because the user has already faced the countdown: 
            loginErrorCountdown = 4; 
            // 4. Set the Timer's bool back to false:
            testTimer.GetComponent<Timer>().setTimerComplete(false);
            // 5. Set isTimerStarted to false so that this method isn't entered unecessarily
            isTimerStarted = false;
            // Reset pinFeedback to no longer display "wait for timer to be finished..."
            // (Because it's already finished now)
            keypadRef.pinFeedback.text = ""; 
       }
    }



    // Method to display error messages to user: 
    private void displayPINError(){
        // Debug.Log("displayPinError() bug checking ... " + loginErrorCountdown);
        // If the user is not locked out yet 
        if (loginErrorCountdown > 1){
            keypadRef.pinFeedback.text = "PIN is incorrect, please try again. " + loginErrorCountdown-- + " attempts left.";
            // return so it doesn't accidentally fall into a lower if statement once change made 
            return;
        }
        // so when it gets to 1 it doesn't say "attempts" 
        if (loginErrorCountdown == 1){ 
            keypadRef.pinFeedback.text = "PIN is incorrect, please try again. " + loginErrorCountdown-- + " attempt left.";
            return; 
        }
        if (loginErrorCountdown == 0) {
            keypadRef.pinFeedback.text = "Incorrect PIN entered too many times. Please try again when the timer is finished.";
            isTimerStarted = true; 
            newTimerNeeded = true; 
        }
    }



     // Method to check whether the PIN entered by the user is valid: 
     // string userInput that is passed is the HASHED version of what the user entered 
     private void loginCheck(string userInput){
         bool PINfound = false; 
        // Re-set pattern back to '- - - -' so that 
        // the user doesn't have to delete the digits themselves 
        // if they re-enter the PIN, AND so that if the PIN is 
        // correct, it's erased after entered for security reasons. 
        keypadRef.setDigitsEntered();
        // Check the copy of the .csv file held in HandleCSV's internal memory collection 
        // To see if this hash (userInput) matches any hashes in the .csv: 
         foreach (CSVInfo x in HandleCSV.currentCSV){
             if (x.getPin().Equals(userInput)){
                 Debug.Log("found pin");
                 // Clear any existing error messages: 
                 keypadRef.pinFeedback.text = ""; 
                 // Reset loginErrorCountdown back to 4 again: 
                 loginErrorCountdown = 4; 
                 // Open successfulLoginPanel here because the conditions have been met (correct PIN): 
                 successfulPanelTestCalledFromEnterPin.GetComponent<SuccessfulLogin>().controlSuccessfulLoginPanelTest(); 
                 // Set bool to true to show the PIN has been found: 
                 PINfound = true; 
                 return; 
             } 
        }
        // If the PIN is not found in the List, call displayPINError(): 
        // (This will display a message, e.g. "incorrect PIN entered, 4 attempts left...)
        if (PINfound == false){
            displayPINError(); 
            return; 
        }
    }


    // Called from "Submit" button as an onClick event
    private void submitPIN(){
        Debug.Log(keypadRef.digitsEnteredCounter); 
        // 1. Need to check PIN is long enough before going any further
        //***6 digits means the counter is at 8 
        if (keypadRef.digitsEnteredCounter != 8){
            // Tell user the PIN isn't long enough
            keypadRef.pinFeedback.text = "Please note that PINs have to be 4 digits long, please enter your 4-digit PIN.";
        } else {
            Debug.Log("Correct amount"); 
            // extract PIN, hash it, check if this hash appears in the .csv file which contains the users PIN. 
            string hashed = HashClass.toSHA256(keypadRef.extractPIN()); 
            loginCheck(HashClass.toSHA256(keypadRef.extractPIN())); 
        }
    }


    
   private void Start() {
       // Method called to reset all values: 
       restart(); 
       // Work-around for the fact that .FindGameObjectsWithTag() does not 
       // work with inactive game objects. 
       // So, find the "Timer" object, then instantly make it inactive 
       // This is because as soon as it is made active, the timer will begin. 
       // Timer should only start and be active if the user has guessed PIN too many times. 
       // So, Timer is .SetActive() again, if applicable, from .displayPINError() changing 
       // a bool that then has a sequence of events in .Update() 
       testTimer = GameObject.FindGameObjectWithTag("Timer"); 
       testTimer.SetActive(false); 

   }

    // Method to be called when this script is first loaded
    // And also if the user ever leaves the page, and comes back. 
    // * Security measure: if a PIN was not fully entered, erase it 
    //      So someone else viewing this page doesn't see the incomplete
    //      pin previously entered (security issue)
    // * Usability measure: if an error message was displayed, erase it 
    //      so that if the user comes back, the error isn't still displayed
    //      as this could confuse the user. 
   public void restart(){
        // At the start of the script, (and if EnterPINPanel
        // is entered again), fill enteredDigits
        // with a string array 
        // So that it looks like - - - - 
        // Until the user enters their digits 
       keypadRef.setDigitsEntered(); 
       // Initially, pinFeedback is set to display nothing (""), 
       // Only update with errors when applicable from .displayPINError()
       keypadRef.pinFeedback.text = ""; 

   }
}