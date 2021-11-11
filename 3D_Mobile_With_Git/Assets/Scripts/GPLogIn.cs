using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// For collecting text from user input:
using UnityEngine.UI; 

// PURELY CONTROLLING DISPLAY OF GPLOGINPANEL (currently) 

// GPLogIn: Guardian / Parental Log-In 
            // Script used to control the "Guardian Log-In" section, activated from the LandingPage 
            // In Freeplay Mode 

// ************** 
// Needs split up into seperate classes when it's all working 
public class GPLogIn : MonoBehaviour
{
    // Used to keep track of whether the Guardian-Login Page is open or not 
    private bool GPLogInIsOpen = false; // default = not open (false)
    // The canvas that contains the logging-in UI content
    public GameObject GPLogInCanvas; 



    // Called when guardian presses "Guardian Log-In" button on the landing page
    // from FreePlay 
    public void controlGuardianLogIn(){
        // If the GPLogInPage is open and the relevant button using .controlGuardianLogIn() is pressed, 
        // It must be to close the page - call .closeGPLogIn() 
        if(GPLogInIsOpen){
            closeGPLogIn(); 
        } else {
            // if GPLogInIsOpen is false, the button pressed must be to open the GPLogIn page - 
            openGPLogIn(); 
        }
    }

    private void closeGPLogIn(){
        // Close the logging-in UI canvas
        GPLogInCanvas.SetActive(false); 
        // Reset bool to show the log-in page is NOT open 
        GPLogInIsOpen = false; 
    }

    private void openGPLogIn(){
        // Set the log-in canvas to be active (visible) 
        GPLogInCanvas.SetActive(true);
        // Reset bool to show the log-in page IS open 
        GPLogInIsOpen = true; 
    }


    // BUTTONS 

    // If create Account Button is pressed 








// ****************************
// ****************************
// ****************************
// ****************************
// ***************************
// Weds 

    private string pin; 

    // WHere the PIN is entered: 
    public GameObject inputField; 

    // The general InputField object that contains the input placeholder, and collects the user input: 
    public InputField generalPINInputField;


     // ***** If incorrect PIN, entered, set this to: PIN is incorrect, please try again.
    public Text PINInputFeedback; 

    // Moved to EnterPinPanel.cs 
    // // At the start of the program, user has 5 chances to guess the PIN 
    // private int loginErrorCountdown = 4; 

    // To try clear the area
    public GameObject pinPlaceholderText; 





    // // Moved A COPY to EnterPINPanel.cs 
    // // CSV should only be read from this class (GPLogin) [and create account when I get to that] 
    HandleCSV csvHandling = new HandleCSV(); 


    // // When login button is clicked 
    // public string loginCheck(string userInput){
    //     string ifError = ""; 
    //     // int num = int.Parse(userInput); 
    //     // Load the CSV file: 
    //      List<CSVInfo> readInInfo = csvHandling.readCSV(); 
    //      // check each entry 
    //      foreach (CSVInfo x in readInInfo){
    //          if (x.pin.Equals(userInput)){
    //              Debug.Log("found pin");
    //              // Open successfulLoginPanel here
    //              controlSuccessfulLoginPanel(); 
    //          } else{
    //              // If PIN is incorrect: 
    //              ifError = displayPINError(); 
    //          }
    //      } return ifError;
    // }


    // Thurs 1.16 before it returned a String 

    // Moved to EnterPINPanel.cs 
    // // When login button is clicked 
    // public void loginCheck(string userInput){
    //     // int num = int.Parse(userInput); 
    //     // Load the CSV file: 
    //      List<CSVInfo> readInInfo = csvHandling.readCSV(); 
    //      // check each entry 
    //      foreach (CSVInfo x in readInInfo){
    //          if (x.pin.Equals(userInput)){
    //              Debug.Log("found pin");
    //              // Open successfulLoginPanel here
    //              controlSuccessfulLoginPanel(); 
    //          } else{
    //              // If PIN is incorrect: 
    //              displayPINError(); 
    //          }
    //      }
    // }
    // *****************************************************


    // *****************************************************
    // Moved to new script, SuccessfulLogin.cs 
    // successfulLoginPanel to be opened when correct PIN entered 
    // Default = not visible 
    // public GameObject successfulLoginPanel; 
    // // Used to control opening / closing of successfulLoginPanel: 
    // private bool isSuccessfulLoginPanelOpen = false; 

    // // Method called to control the display of successfulLoginPanel: 
    // public void controlSuccessfulLoginPanel(){
    //     // If the panel is not already open yet: 
    //     if (!isSuccessfulLoginPanelOpen){
    //         // open it now: 
    //         successfulLoginPanel.SetActive(true); 
    //         // reset bool 
    //         isSuccessfulLoginPanelOpen = true; 
    //     // Do the opposite if the panel IS open: 
    //     } else {
    //         successfulLoginPanel.SetActive(false); 
    //         isSuccessfulLoginPanelOpen = false; 
    //         // Treat the Overall LogIn panel as if it has been closed 
    //         // Once user enters pin successfully, they can only go back to Home
    //         // Otherwise, login again.
    //         controlGuardianLogIn(); 
    //     }
    // }







// *******************************************************************
// FROM INPUT FIELD ERA      
    // Where the user enters their login info from 
    // // "PINUserInputText" UI object 
    // public void loginButtonCheckInput (){ 
    //     // Collect input:
    //     pin = inputField.GetComponent<Text>().text; 
    //     // Clear the pin entered on the UI once Login is clicked 
    //     // So that it dynamically updates for the user:
    //     generalPINInputField.text = ""; 
    //     // Hash the input: 
    //     string pinHashed = HashClass.toSHA256(pin); 
    //     // Debug.Log(pin); 
    //     // Pass hash to loginCheck, which will check if there's a match: 
    //     loginCheck(pinHashed);
    // }




    // Set character input limit in the InputFields to 4
    // (PIN limit is 4 characters)
    // Called from .Start()
    // and passed the relevant InputFields it applies to
    // (Unity default is infinite characters)
    public void setInputCharacterLimit(params InputField[] input){
        foreach (InputField x in input){
            x.characterLimit = 4; 
        }
    }

    // Moved to EnterPINPanel.cs 
    // public string displayPINError(){
    //     // If the user is not locked out yet 
    //     if (loginErrorCountdown > 1){
    //         string errorMessage = "PIN is incorrect, please try again. " + loginErrorCountdown-- + " attempts left.";
    //         return errorMessage; 
    //     }
    //     // so when it gets to 1 it doesn't say "attempts" 
    //     if (loginErrorCountdown == 1){ 
    //         string errorMessage = "PIN is incorrect, please try again. " + loginErrorCountdown-- + " attempt left.";
    //         return errorMessage; 
    //     }
    //     else {// if (loginErrorCountdown == 0) {
    //         // ????? consequences? timer? 
    //         string errorMessage = "Incorrect PIN entered too many times, please try again later.";
    //         return errorMessage; 
    //         // ****** Needs filled in properly        
    //         }
    //     }





















        // (When it didn't return a String)

        // // Thurs 1.14 
        //   public void displayPINError(){
        // // If the user is not locked out yet 
        // if (loginErrorCountdown > 1){
        //     string errorMessage = "PIN is incorrect, please try again. " + loginErrorCountdown-- + " attempts left.";
        //     // Update UI to display message 
        //     Debug.Log(errorMessage); 
        //     // PINInputFeedback.text = errorMessage; 
        //     return; 
        // }
        // // so when it gets to 1 it doesn't say "attempts" 
        // if (loginErrorCountdown == 1){ 
        //     string errorMessage = "PIN is incorrect, please try again. " + loginErrorCountdown-- + " attempt left.";
        //     // Update UI to display message 
        //     Debug.Log(errorMessage); 

        //     // PINInputFeedback.text = errorMessage; 
        //     return;
        // }
        // else if (loginErrorCountdown == 0) {
        //     // ????? consequences? timer? 
        //     string errorMessage = "Incorrect PIN entered too many times, please try again later.";
        //     // Update UI to display message 
        //     // PINInputFeedback.text = errorMessage; 
        //                 Debug.Log(errorMessage); 

        //     // ****** Needs filled in properly        
        //     }
        //     // loginErrorCountdown = loginErrorCountdown - 1; 
        // }

        // Thurs 1.14 






// WAS USED BY INPUT FIELD WHICH LATER FOUND OUT DOESN'T WORK ON iOS.........
    // Set the character limit for the PIN entry to be 
    // maximum of four at Start(): 
    void Start() {
        // Pass InputFields to be set to max length 4: 
        setInputCharacterLimit(generalPINInputField, firstPINEntry, secondPINEntry);
    }



    // ****************************
    // Creating PIN area

    // 1. Need to retrieve the text from firstPINEntry and secondPINEntry 
    // 2. Check if they match 
    // 3. HASH 
    // 4. Pass hashed PIN to 

     //________________________________
    // Called from CreateAccountPanel 

    // 1st  pin entry general InputField: 
    public InputField firstPINEntry; 
    // 1st pin entry text gathered from InputField: 
    public GameObject firstPINEntryText; 

    // 2nd pin entry general InputField: 
    public InputField secondPINEntry; 
    // 2nd pin entry text gathered from InputField: 
    public GameObject secondPINEntryText; 
    
    // Text to display any error messages to the user 
    public Text pinInputErrorText; 


    // when "CreateAccount" button is pressed 

    // 1. Get the two entered strings 
    // 2. check if they match
    // 3. check they are length 4 (4 digits are required) 
    // 4. hash the PIN if it meets requirements 

    // 1. Get the two entered strings: 
    public void createAccountButtonPressed (){ 
        // Collect 1st PIN:
        string entryOne = firstPINEntryText.GetComponent<Text>().text; 
        // Reset 1st InputField to be clear again so that it dynamically updates for user
        firstPINEntry.text = "";  
        // Collect 2nd PIN: 
        string entryTwo = secondPINEntryText.GetComponent<Text>().text; 
        // Reset 2nd InputField to be clear again so that it dynamically updates for user
        secondPINEntry.text = ""; 
    // 2. Check if they match 
        if (entryOne.Equals(entryTwo)){
            Debug.Log("Yes");
        } else {
            Debug.Log("No");
            // Display error to the user: 
            pinInputErrorText.text = "PINs do not match, please try again.";
            return; 
        }
    // 3. If they match, check the PIN is 4 digits as requested to the user: 
        if (entryOne.Length == 4){
            Debug.Log("Correct Length");
        } else {
            Debug.Log("Wrong length");
             // Display error to the user: 
            pinInputErrorText.text = "Incorrect PIN length - PIN should be 4 digits, please try again.";
            return; 
        }
        if (entryOne.Length == 4 && entryTwo.Length == 4 && entryOne.Equals(entryTwo)){
            // Getting here means user satisfied the requirements, update text accordingly 
            // Change from red text to green (to show it's not an error): 
            pinInputErrorText.GetComponent<Text>().color = Color.green; 
            // Update message to show it was successful: 
            pinInputErrorText.text = "PIN entered successfully, please wait ...";
                            // ^^^^^^ Need to do something here ... new panel or something 
        }
    // Get to here means: PINs match, PINs are the correct length. 
    // 4. Hash the PIN to be stored securely in the CSV (hashing firstPin but doesn't matter, if 
    // Get to here, entryOne and entryTwo are the same)
        string firstHash = HashClass.toSHA256(entryOne); 
    // 5. Now, with this information, an entry can be added the the .csv file
    // 6. Create a new CSVInfo object using the hash 
        CSVInfo newCSVEntry = new CSVInfo(firstHash); 
    // 7. Append to .csv file stored locally in the Unity project: 
        csvHandling.appendToCSV(newCSVEntry); 
    }



























    // Will need to be executed as an onClick "Create New Account" button on createAccountPanel 
                                                                //  public string collectProposedPIN(){ 
                                                                //     // Collect input:
                                                                //     pin = inputField.GetComponent<Text>().text; 
                                                                //     // Clear the pin entered on the UI once Login is clicked 
                                                                //     // So that it dynamically updates for the user:
                                                                //     generalPINInputField.text = ""; 
                                                                //     Debug.Log(pin); 
                                                                //     // Pass input to loginCheck: 
                                                                //             loginCheck(pin);
                                                                //     // return pin; 
                                                                // }  


// ****************************
// ****************************
// ****************************
// ****************************
// ****************************
























}



// Original Method before being changed 
// // When login button is clicked 
//     public void loginCheck(string userInput){
//         // int num = int.Parse(userInput); 
//         // Load the CSV file: 
//          List<CSVInfo> readInInfo = csvHandling.readCSV(); 
//          // check each entry 
//          foreach (CSVInfo x in readInInfo){
//              if (x.pin == num){
//                  Debug.Log("found pin");
//                  // Open successfulLoginPanel here
//                  controlSuccessfulLoginPanel(); 
//              } else{
//                  // If PIN is incorrect: 
//                  displayPINError(); 
//              }
//          }
//     }





















// _________________________________________________
// CODE MADE TRYING TO MAKE IT RE-USABLE

    // // I now need a method for if the PIN is CORRECT 

    // // Called when Login is clicked: 
    // // Login button also calls .clearInputField() 
    // public void loginButtonOnClick(GameObject input){
    //   // Collect user input: 
    //   string pin = collectedUserInput(input);
    //   // Pass to loginCheck: 
    //    loginCheck(pin); 
    // }


    // // RE-USABLE 
    // // Method to clear an InputField
    // // So that it's easier for a user to enter 
    // // another PIN if need be (rather than them having 
    // // to delete the existing characters themselves)
    // public void clearInputField(InputField inputFieldToBeCleared){
    //     inputFieldToBeCleared.text = ""; 
    // }

    // // The reason these two methods aren't combined is onClick methods 
    // // in Unity can only accept one argument per method. 


    // // RE-USABLE 
    // // General method that returns String collected from an InputField 
    // // And resets InputField back to empty again so that it's easier 
    // // for a user to enter another PIN if need be (rather than them having to 
    // // delete the existing characters themselves) )
    // public string collectedUserInput(GameObject input){
    //     // Collect text the user entered:  
    //    string pin = input.GetComponent<Text>().text; 
    //     // return string, that can be passed to loginCheck for example. 
    //     return pin; 
    // }

// _________________________________________________
// CODE MADE TRYING TO MAKE IT RE-USABLE 

