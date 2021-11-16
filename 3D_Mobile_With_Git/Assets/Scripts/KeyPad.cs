using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To import buttons:
using UnityEngine.UI; 

// Class used to create a keypad object
// This is to have re-usable code, because 
// a Keypad is needed in EnterPINPanel.cs and CreateAccount.cs 
// This avoids code reptition and makes reusable / maintainable code. 
public class KeyPad : MonoBehaviour
{

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

    // 7 digits MAX:
    private string[] digitsEntered = new string[7];
    // Make private again when everything working: 
    public int digitsEnteredCounter = 0; 

    // Used to display feedback to the user (whether their pin is correct / incorrect): 
    public Text pinFeedback; 




    
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


    // Update the digits displayed to the user 
    // Based on what they have entered: 
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






