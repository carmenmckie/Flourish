using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To import UI elements, e.g. buttons: 
using UnityEngine.UI; 

// PURELY CONTROLLING DISPLAY OF GPCREATEACCOUNT PANEL (currently) 


// Script used for a guardian / parent to create an account 
// Opened via clicking "Create Account" button on the OverallGuardianLoginPanel 
public class CreateAccount : MonoBehaviour
{

    // 1. Bool to check what condition is satisifed when 
    // the "Submit" button is pressed
    // e.g. if it's the first time being entered, 
    // show pinpad again and ask for another PIN 
    // If it's the second time being entered, 
    // Add to CSV 

    // Change this to true the first time SUBMIT is entered 
    // * If the user goes off CreateAccount, change this back to false 
    // * If the user presses submit twice, then change it back to false again 
    private bool firstPINSubmitted = false; 

    // Instance variables related to the keypad: 
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


    // Working
    // 1. If a PIN hasn't been entered once, display "Please enter your chosen PIN:" 
    private void Update() {
         if (firstPINSubmitted){
            pinInstructions.text = "Please re-enter your chosen PIN: "; 
        } 
        if (PINsDontMatch) {
            pinFeedback.text = "Both PINs do not match. Please start again.";
            restart(); 
        }
        // If the error message is displayed "please note that PINs have to be 4 digits long..." 
        // But then the user deletes a digit to match this, remove the error message: 
        if (digitsEnteredCounter == 6){
            pinFeedback.text = ""; 
        }    
    }
    
   
    // Method to be called from .Start() (whenevr the class is loaded)
    // Written as a method in case it needs called again 
    // e.g. if a user enters two PINs that don't match, and the process needs repeated
    public void restart(){
        if(!firstPINSubmitted){
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



    // * CreateAccount.cs specific* 
    // Called from "Submit" button as an onClick event
    public void submitPIN(){
        // If this is the first time submitPIN() has been called
        // from this session of CreateAccount.cs being opened, 
        // reset the boool, which will update the UI text for the user
        // from .Update() 
        if (!firstPINSubmitted){
            // Debug.Log("Not long enough"); 
            // If the PIN isn't long enough: 
            if (digitsEnteredCounter != 8){
                Debug.Log("Not long enough"); 
                // Tell user the PIN isn't long enough
                pinFeedback.text = "Please note that PINs have to be 4 digits long, please enter your 4-digit PIN.";
                return;
            } else {
                // Debug.Log("Correct amount :P "); 
                 // Store the first PIN entered by the user, to be compared later
                firstEnteredPIN = extractPIN(); 
                // Clear the PinPad again (so it's '- - - -')
                setDigitsEntered(); 
                // Reset the bool so next time submitPIN() is called, 
                // it enters the relevant code-block
                firstPINSubmitted = true; 
                return; 
            }
        } if (firstPINSubmitted){
            Debug.Log("Mwahahahaaaa");
            // Debug.Log("Not long enough"); 
            // If the PIN isn't long enough: 
            if (digitsEnteredCounter != 8){
                Debug.Log("Not long enough"); 
                // Tell user the PIN isn't long enough
                pinFeedback.text = "Please note that PINs have to be 4 digits long, please enter your 4-digit PIN.";
                return;
            }
              else {
                Debug.Log("Correct amount :P "); 
                 // Store the first PIN entered by the user, to be compared later
                secondEnteredPIN = extractPIN(); 
                // Clear the PinPad again (so it's '- - - -')
                setDigitsEntered(); 
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


    


    IEnumerator displayPopUpWindow() 
    {
        popUpWindow.SetActive(true); 
        // Show for 3 seconds
        yield return new WaitForSeconds(3); //this is were the wait will happen. so position it in your func where you want to wait.
        // Then disable pop-up window again: 
        popUpWindow.SetActive(false); 
    }





// Working 
private void Start() {
        restart(); 
        // At the start of the script, fill enteredDigits
        // with a string array 
        // So that it looks like - - - - 
        // Until the user enters their digits 
       setDigitsEntered(); 
       // Make sure firstEnteredPIN and secondEnteredPIN are null 
       // to begin with, e.g. doesn't remember a PIN 
       // previously entered, for security reasons
       firstEnteredPIN = null; 
       secondEnteredPIN = null; 
   }



// WORKING atm 
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






