using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import necessary to work with buttons
using UnityEngine.UI; 

// Script to control the display of the panel where the user can enter
// their PIN 
public class EnterPINPanel : MonoBehaviour
{
    // private bool isEnterPINPanelOpen = false; 
    // // Ref to the EnterPINPanel UI Object 
    // public GameObject enterPINPanel; 
    // References to the digit buttons used on the keypad 
    // button1 = button with value 1, button2 = button with value 2, ... 
    public Button button1; 
    public Button button2; 
    public Button button3; 
    public Button button4; 
    public Button button5; 
    public Button button6;    
    public Button button7;
    public Button button8; 
    public Button button9;
    public Button button0; 
 
    // Reference to the Text UI object which updates for the user on 
    // The digits they have entered 
    public Text enteredDigits; 

    // 7 digits MAX so length six 
    private string[] digitsEntered = new string[7];
    private int digitsEnteredCounter = 0; 

    // Used to display feedback to the user (whether their pin is correct / incorrect): 
    public Text pinFeedback; 

    // Reference to GPLogin so that GPLogin.loginCheck() can be used
    GPLogIn loginSystem = new GPLogIn(); 

    // At the start of the program, user has 5 chances to guess the PIN. Set to 4 
    // Because it is first displayed as "you have 4 logins left..."  
    private int loginErrorCountdown = 4; 


    // CSV read to check if hash matches the hash in the CSV 
    HandleCSV csvHandling = new HandleCSV(); 

    // Reference to the SuccessfulLoginPanel object so that it can be opened
    // If PIN entered successfully 
    public GameObject successfulLoginPanel; 

     // Reference to the successfulLoginPanel so that it can be made visible to the user 
    // If they enter a correct PIN:
    public GameObject successfulPanelTestCalledFromEnterPin; 













    // ******************************
    // ******************************
    // ******************************
    // ******************************
    // ******************************
    // Timer relevant below 
    private bool isTimerStarted = false; 




    // Test- refer to it as a  Timer rather than a GameObject 
    public Timer countdownTimer; 


    // Reference to the General KeyPad area (KeypadBackground) which 
    // Contains multiple children objects, (keypad, buttons, pin entered, etc...)
    // To be made not visible when the user is under the countdown time-out 
    public GameObject keypadBackground; 


    /// test 
    private bool newTimerNeeded = false; 
    
    private GameObject testTimer; 


    // Method that controls locking the user out of the entering PIN area
    // If they enter the incorrect PIN too many times (5) before
    // showing the PIN again after (currently 10) seconds 
    private void Update() {
        // newTimerNeeded is set to be true from .displayPINError() if the user enters
        // an incorrect PIN over the limit (5 times) 
        if (newTimerNeeded){
            // Debug.Log("Got to Section 1"); 
            // Set countdownTimer = testTimer 
            // testTimer = reference to the object in the Hierarchy with "Timer" tag 
            countdownTimer = testTimer.GetComponent<Timer>();
            // Call the Timer .Restart() method to create a (currently 10 second) Timer:  
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
            // Hide the keypad area until timer finished: 
            keypadBackground.SetActive(false); 
        }
        // If the Timer is complete, reset the locking out features 
        // Resetting of locking out features could be made into a method ....
        if (countdownTimer.getTimerComplete() == true ) { 
            Debug.Log("Got to Section 3"); 
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
            pinFeedback.text = ""; 
       }
    }




    // Timer ^ 
    // ******************************
    // ******************************
    // ******************************
    // ******************************
    // ******************************
    // *******************************













// __________________________________________
// ______ EnterPINPanel.cs Specific _________
// __________________________________________







    
   private void Start() {
        // At the start of the script, fill enteredDigits
        // with a string array 
        // So that it looks like - - - - 
        // Until the user enters their digits 
       setDigitsEntered(); 
       // Initially, pinFeedback is set to display nothing (""), 
       // Only update with errors when applicable from .displayPINError()
       pinFeedback.text = ""; 
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
     

    // Fill digitsEntered with this pattern '- - - -' 
    public void setDigitsEntered(){
        // As this method is also called to clear the PIN entry field if 
        // an incorrect PIN is entered, the counter needs to be reset to 
        // it's default value: 
        digitsEnteredCounter = 0; 
        for(int i = 0; i < digitsEntered.Length; i++){
            if(i % 2 == 0){
                digitsEntered[i] = "-"; 
            } else {
                digitsEntered[i] = " "; 
            }
        } 
        enteredDigits.text = arrayToString(digitsEntered);
    } 



    // Method to convert a string[] to a single string to be displayed on the UI 
    public string arrayToString(string[] array){
        string value = ""; 
        for(int i = 0; i < array.Length; i++){
            value += array[i]; 
        }
        return value; 
    }



    // Update digitsEntered (displayed originally like '- - - -' to the user)
    // With their button clicks. 
        // void for now but make it return string   
    public void updateDigitsEntered(string value){
        // If 4 digits have already been entered 
        // Tell user their PIN is already required length
        // digitsEnteredCounter starts at 0 but each time a user
        // enters a digit via a button, it increments by 2
        // so 0,2,4,6 <-- being the last entry 
        // this is due to spaces being between the dashes '- - - -' 
        if(digitsEnteredCounter > 6){
            pinFeedback.text = "Please note that PINs can only be 4 digits long.";
            // exit 
            return; 
        }
        // Otherwise, add the value to the appropriate position in the array: 
        else {
            digitsEntered[digitsEnteredCounter] = value; 
            // And then increment the counter by 2 
            digitsEnteredCounter += 2; 
        }

    }



    // Called when user presses the "Undo" button 
    // (To delete the last entered digit) 
    public void undoLastDigit(){ 
        // If the digitsEnteredCounter has got to 0, don't 
        // decrease it anymore to avoid IndexOutOfRangeException
        if (digitsEnteredCounter <= 0){
            return; 
        }
        // Decrement counter by 2 to access the last entered digit 
        digitsEnteredCounter -= 2; 
        // Access the element in the array and change it back to a '-' 
        digitsEntered[digitsEnteredCounter] = "-"; 
        // Update changes on UI 
        enteredDigits.text = arrayToString(digitsEntered);
    }


    // * EnterPINPanel.cs specific* 
    // I the same way as controlButtonPress, could do controlSubmitButtonPress 
    // Called from "Submit" button as an onClick event
    public void submitPIN(){
        Debug.Log(digitsEnteredCounter); 
        // 1. Need to check PIN is long enough before going any further
        //***6 digits means the counter is at 8 
        if (digitsEnteredCounter != 8){
            // Tell user the PIN isn't long enough
            pinFeedback.text = "Please note that PINs have to be 4 digits long, please enter your 4-digit PIN.";
        } else {
            Debug.Log("Correct amount :P "); 
            // extract PIN, hash it, check if this hash appears in the .csv file which contains the users PIN. 
            string hashed = HashClass.toSHA256(extractPIN()); 
            // If any negative feedback is returned (e.g. your PIN is wrong, collect it and 
            // display on UI)
    // *************
    // *************
    // *************        
            loginCheck(HashClass.toSHA256(extractPIN())); 
        }
    }


     // * EnterPINPanel.cs specific* 
     public void loginCheck(string userInput){
         bool PINfound = false; 
        // Re-set pattern back to '- - - -' so that 
        // the user doesn't have to delete the digits themselves 
        // as they re-enter the PIN, AND so that if the PIN is 
        // correct, it's erased after entered for security reasons. 
        setDigitsEntered();
        // int num = int.Parse(userInput); 
        // Load the CSV file: 
         // check each entry 
         foreach (CSVInfo x in HandleCSV.currentCSV){
             if (x.pin.Equals(userInput)){
                 Debug.Log("found pin");
                 // Clear any existing error messages: 
                 pinFeedback.text = ""; 
                 // Reset loginErrorCountdown back to 4 again: 
                 loginErrorCountdown = 4; 
                // Open successfulLoginPanel here because the conditions have been 
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



    // * EnterPINPanel.cs specific* 
    // // Moved here from GPLogin.cs 
    public void displayPINError(){
        Debug.Log("displayPinError() bug checking ... " + loginErrorCountdown);
        // If the user is not locked out yet 
        if (loginErrorCountdown > 1){
            pinFeedback.text = "PIN is incorrect, please try again. " + loginErrorCountdown-- + " attempts left.";
            // return so it doesn't accidentally fall into a lower if statement once change made 
            return;
        }
        // so when it gets to 1 it doesn't say "attempts" 
        if (loginErrorCountdown == 1){ 
            pinFeedback.text = "PIN is incorrect, please try again. " + loginErrorCountdown-- + " attempt left.";
            return; 
        }
        if (loginErrorCountdown == 0) {
            pinFeedback.text = "Incorrect PIN entered too many times. Please try again when the timer is finished.";
            isTimerStarted = true; 
            newTimerNeeded = true; 
            // ******* Start a Timer 
            // ******************************
            // ******************************
            // ******************************
            // ******************************
            // ****************************** 
            }
    }




    // Method used to extract the entered values from the PIN 
    // E.g. '2-3-4-2', this will return '2342' which is then passed
    // to HashClass.toSHA256() to return the hashed string value, and
    // then this is passed to GPLogin.loginCheck() to check if this
    // Hashed value exists in the .csv file. 
    public string extractPIN(){ 
        string extractedPin = ""; 
        // Double check it's the right length (shouldn't ever get here though...)
        if (digitsEnteredCounter != 8){
            Debug.Log("Array not correct length");
            return null; 
        } // Else if the array IS the correct length, extract string value 
        // from the pattern 'digit-digit-digit-digit'
        for (int i = 0; i < digitsEntered.Length; i++){
            // '- - - -' pattern <-- numbers entered in even pattern 
            // So add even entries, ignore odd (they contain - dashes)
            if (i % 2 == 0){
                extractedPin += digitsEntered[i]; 
            }
        }
        // Debug.Log(extractedPin); 
        return extractedPin; 
    }
    



// ********* Attach to buttons when ready 
    // Attached as an onClick method for the keypad buttons: 
    public void controlButtonPress(Button buttonPressed){
        // Pass to kepadButtonPressed which returns the String 
        // representation of the button pressed: 
        string value = keypadButtonPressed(buttonPressed); 
        // Pass this value to updateDigitsEntered(): 
        updateDigitsEntered(value); 
        // ^ This updates the instance variable digitsEntered (string[] )
        // Now call array to string to set the UI element of the updated 
        // value to the user
         enteredDigits.text = arrayToString(digitsEntered); 
    }

















    // Method to control output based on a button click 
    // void for now but change this to int / or string 
    // Attached as an onClick() event for each button, 
    // Where the button passes itself as the buttonPressed argument 
    public string keypadButtonPressed(Button buttonPressed){
        if (buttonPressed == button1){
            Debug.Log("1"); 
            return "1"; 
        }
         if (buttonPressed == button2){
            Debug.Log("2"); 
            return "2"; 
        }
         if (buttonPressed == button3){
            Debug.Log("3"); 
            return "3"; 
        }
         if (buttonPressed == button4){
            Debug.Log("4"); 
            return "4"; 
        }
         if (buttonPressed == button5){
            Debug.Log("5");
            return "5";  
        }
         if (buttonPressed == button6){
            Debug.Log("6"); 
            return "6"; 
        }
         if (buttonPressed == button7){
            Debug.Log("7"); 
            return "7"; 
        }
         if (buttonPressed == button8){
            Debug.Log("8"); 
            return "8"; 
        }
         if (buttonPressed == button9){
            Debug.Log("9"); 
            return "9"; 
        }
        // Last button left has to be 0
         else { 
            Debug.Log("0"); 
            return "0"; 
        }
    }
}











// __________________________________________
// ____________ Generic KeyPad  _____________
// __________________________________________



