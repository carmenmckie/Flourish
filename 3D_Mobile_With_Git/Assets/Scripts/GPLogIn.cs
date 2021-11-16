using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// For collecting text from user input:
using UnityEngine.UI; 



// GPLogIn: Guardian / Parental Log-In 
// Script used to control the "Guardian Log-In" section, activated from the LandingPage 
// In Freeplay Mode 




// Script to control the opening / closing of the different Log-In panels: 
// - InitialGuardianLogin
// - EnterPINPanel 
// - SuccessfulLoginPanel X
// - CreateAccountPanel X
// - (to be made: forgottenPINpanel?)
public class GPLogIn : MonoBehaviour
{ 
    
    // * GeneralPanel, aka the LandingPage of the game 
    public GameObject generalPanel; 
    // when game starts, GeneralPanel is open 
    private bool isGeneralPanelOpen = true; 


    // * To control the sub-panel, InitialGuardianLogInPanel:
    public GameObject initialGuardianLogInPanel; 
    // When the game starts, it is not open
    private bool isInitialGuardianLogInPanelOpen = false; 
    

    // Method to control the opening of the general log-in page (initialGuardianLoginPanel). 
    // For initialGuardianLoginPanel to be visible -> generalPanel needs to be closed, and 
    // initialGuardianPanel needs to be opened. 
    // For initialGuardianPanel to be closed -> generalPanel needs to be opened again, and 
    // initialGuardianPanel needs to be closed. 
    // This is due to the chosen Unity Hierarchy structure of the UI elements.
    public void controlGuardianOpenTest(){
        if (isGeneralPanelOpen){
            // Close generalPanel: 
            closeGeneralPanel(); 
            // Open initialGuardianLoginPanel:
            openInitialGuardianLoginPanel(); 
            return; 
        } if (!isGeneralPanelOpen){
            openGeneralPanel(); 
            closeInitialGuardianLoginPanel(); 
            return; 
        }
    }

    // * ALSO CALLED FROM SuccessfulLogin.cs / SuccessfulLoginPanel * 
    // Public as it is also used as an onClick event 
    // From SuccessfulLoginPanel when the user presses back, 
    // rather than send the user back to enter PIN again (non user intuitive), 
    // the user goes back to initialGuardianLogIn. 
    public void openInitialGuardianLoginPanel(){
        // Change bool: 
        isInitialGuardianLogInPanelOpen = true; 
        // Make panel visible: 
        initialGuardianLogInPanel.SetActive(true); 
    }


    // Close initialGuardianLoginPanel: 
    public void closeInitialGuardianLoginPanel(){
        // Change bool: 
        isInitialGuardianLogInPanelOpen = false; 
        // Make panel not visible: 
        initialGuardianLogInPanel.SetActive(false); 
    }

    // Open generalPanel: 
    private void openGeneralPanel(){
        isGeneralPanelOpen = true; 
        generalPanel.SetActive(true); 
    }

    // Close generalPanel: 
    private void closeGeneralPanel(){
        isGeneralPanelOpen = false; 
        generalPanel.SetActive(false); 
    }













    // ____________________________________________
    // Controlling EnterPINPanel Below 
    // ____________________________________________

    // So that enterPINPanel.refresh() can be called 
    // when a user leaves enterPINPanel: 
    public GameObject enterPINPanel; 


    // For EnterPINPanel to be visible to the user, 
    // The panel higher in the hierarchy (initialGuardianLogInPanel) needs 
    // to be set to not active. 
    // For EnterPINPanel to NOT be visible to the user, since initialGuardianLogInPanel
    // is higher in the hierarchy to EnterPINPanel, initialGuardianLogInPanel 
    // Needs to be set to ACTIVE so that it hides EnterPINPanel. 

    // * onClick() event from InitialGuardianLogInPanel > EnterPINButton (to open EnterPINPanel)
    // * onClick() event from EnterPINPanel > GoBackButton (to close EnterPINPanel)
    public void makeEnterPINVisibleTest(){
        if(isInitialGuardianLogInPanelOpen){
            closeInitialGuardianLoginPanel(); 
            return; 
        } if (!isInitialGuardianLogInPanelOpen){
            openInitialGuardianLoginPanel(); 
            // Call EnterPINPanel's .restart() method to reset 
            // Any UI updated values to default when the user 
            // leaves the page, as a security measure, no PIN remains: 
            enterPINPanel.GetComponent<EnterPINPanel>().restart(); 
            return; 
        }
    }

    // ____________________________________________
    // Controlling EnterPINPanel Above ^ 
    // ____________________________________________







    // ____________________________________________
    // Controlling CreateAccountPanel Below 
    // ____________________________________________


    // Bool to control the opening / closing of the "CreateAccountPanel" 
    // Default is false (Panel not open by default). 
    private bool createAccountPanelOpen = false;

    // Panel to be opened / closed when CreateAccount is pressed
    // ("CreateAccountPanel" in Hierarchy)
    // By default, createAccountPanel is not Visible until user input asks for it to be opened. 
    public GameObject createAccountPanel; 



    // Method to control opening / closing of createAccountPanel 
    // * .onClick() event from InitialGuardianLogInPanel > CreateAccountButton (to open CreateAccountPanel)
    // * .onClick() event from CreateAccountPanel > GoBackButton (to close CreateAccountPanel) 
    public void controlCreateAccountPanel(){
        // If the panel is not open, open it 
        if (!createAccountPanelOpen){
            openCreateAccountPanel();
            // Monday - wasn't needed after all 
            // closeInitialGuardianLoginPanel(); 
            return;
        } else {
            // If the panel is open, close it: 
            closeCreateAccountPanel(); 
            // Set back to start values so if user goes back to the CreateAccountPanel, 
            // no remaining error messages etc remain: 
            createAccountPanel.GetComponent<CreateAccount>().restart(); 
            // Monday - wasn't needed after all 
            // openInitialGuardianLoginPanel(); 
            return;
        } 
    }

    // Used to open the createAccountPanel
    private void openCreateAccountPanel(){
        createAccountPanel.SetActive(true); 
        createAccountPanelOpen = true; 
    }

    // Used to close the createAccountPanel 
    private void closeCreateAccountPanel(){
        createAccountPanel.SetActive(false); 
        createAccountPanelOpen = false; 
    }


    // ____________________________________________
    // Controlling CreateAccountPanel Above ^  
    // ____________________________________________ 


 




















//     // __________________________________________________________



//     // __________________________________________________________
//     // Code written when InputField was used as opposed to keypad below 
//     // __________________________________________________________

//     private string pin; 

//     // WHere the PIN is entered: 
//     public GameObject inputField; 

//     // The general InputField object that contains the input placeholder, and collects the user input: 
//     public InputField generalPINInputField;


//      // ***** If incorrect PIN, entered, set this to: PIN is incorrect, please try again.
//     public Text PINInputFeedback; 


//     // To try clear the area
//     public GameObject pinPlaceholderText; 


//     // // Moved A COPY to EnterPINPanel.cs 
//     // // CSV should only be read from this class (GPLogin) [and create account when I get to that] 
//     HandleCSV csvHandling = new HandleCSV(); 


//     // // Set character input limit in the InputFields to 4
//     // // (PIN limit is 4 characters)
//     // // Called from .Start()
//     // // and passed the relevant InputFields it applies to
//     // // (Unity default is infinite characters)
//     // public void setInputCharacterLimit(params InputField[] input){
//     //     foreach (InputField x in input){
//     //         x.characterLimit = 4; 
//     //     }
//     // }


//     // // WAS USED BY INPUT FIELD WHICH LATER FOUND OUT DOESN'T WORK ON iOS.........
//     // // Set the character limit for the PIN entry to be 
//     // // maximum of four at Start(): 
//     // void Start() {
//     //     // Pass InputFields to be set to max length 4: 
//     //     setInputCharacterLimit(generalPINInputField, firstPINEntry, secondPINEntry);
//   //  }

//     // // ****************************
//     // // Creating PIN area

//     // // 1. Need to retrieve the text from firstPINEntry and secondPINEntry 
//     // // 2. Check if they match 
//     // // 3. HASH 
//     // // 4. Pass hashed PIN to 

//     //  //________________________________
//     // // Called from CreateAccountPanel 

//     // // 1st  pin entry general InputField: 
//     // public InputField firstPINEntry; 
//     // // 1st pin entry text gathered from InputField: 
//     // public GameObject firstPINEntryText; 

//     // // 2nd pin entry general InputField: 
//     // public InputField secondPINEntry; 
//     // // 2nd pin entry text gathered from InputField: 
//     // public GameObject secondPINEntryText; 
    
//     // // Text to display any error messages to the user 
//     // public Text pinInputErrorText; 


//     // // when "CreateAccount" button is pressed 

//     // // 1. Get the two entered strings 
//     // // 2. check if they match
//     // // 3. check they are length 4 (4 digits are required) 
//     // // 4. hash the PIN if it meets requirements 

//     // // 1. Get the two entered strings: 
//     // public void createAccountButtonPressed (){ 
//     //     // Collect 1st PIN:
//     //     string entryOne = firstPINEntryText.GetComponent<Text>().text; 
//     //     // Reset 1st InputField to be clear again so that it dynamically updates for user
//     //     firstPINEntry.text = "";  
//     //     // Collect 2nd PIN: 
//     //     string entryTwo = secondPINEntryText.GetComponent<Text>().text; 
//     //     // Reset 2nd InputField to be clear again so that it dynamically updates for user
//     //     secondPINEntry.text = ""; 
//     // // 2. Check if they match 
//     //     if (entryOne.Equals(entryTwo)){
//     //         Debug.Log("Yes");
//     //     } else {
//     //         Debug.Log("No");
//     //         // Display error to the user: 
//     //         pinInputErrorText.text = "PINs do not match, please try again.";
//     //         return; 
//     //     }
//     // // 3. If they match, check the PIN is 4 digits as requested to the user: 
//     //     if (entryOne.Length == 4){
//     //         Debug.Log("Correct Length");
//     //     } else {
//     //         Debug.Log("Wrong length");
//     //          // Display error to the user: 
//     //         pinInputErrorText.text = "Incorrect PIN length - PIN should be 4 digits, please try again.";
//     //         return; 
//     //     }
//     //     if (entryOne.Length == 4 && entryTwo.Length == 4 && entryOne.Equals(entryTwo)){
//     //         // Getting here means user satisfied the requirements, update text accordingly 
//     //         // Change from red text to green (to show it's not an error): 
//     //         pinInputErrorText.GetComponent<Text>().color = Color.green; 
//     //         // Update message to show it was successful: 
//     //         pinInputErrorText.text = "PIN entered successfully, please wait ...";
//     //                         // ^^^^^^ Need to do something here ... new panel or something 
//     //     }
//     // // Get to here means: PINs match, PINs are the correct length. 
//     // // 4. Hash the PIN to be stored securely in the CSV (hashing firstPin but doesn't matter, if 
//     // // Get to here, entryOne and entryTwo are the same)
//     //     string firstHash = HashClass.toSHA256(entryOne); 
//     // // 5. Now, with this information, an entry can be added the the .csv file
//     // // 6. Create a new CSVInfo object using the hash 
//     //     CSVInfo newCSVEntry = new CSVInfo(firstHash); 
//     // // 7. Append to .csv file stored locally in the Unity project: 
//     //     csvHandling.appendToCSV(newCSVEntry); 
//     // }



//     // __________________________________________________________
//     // Code written when InputField was used as opposed to keypad ^^^^ 
//     // __________________________________________________________






































// ********************************************************************************************************
// ********************************************************************************************************
// ********************************************************************************************************
// ********************************************************************************************************
// ********************************************************************************************************
// ********************************************************************************************************
// ********************************************************************************************************
// Code to be deleted below (if it is definitely no longer needed)




// Moved to EnterPinPanel.cs 
// // At the start of the program, user has 5 chances to guess the PIN 
// private int loginErrorCountdown = 4; 


// DEL 
    // // Called when guardian presses "Guardian Log-In" button on the landing page
    // // from FreePlay 
    // // *** Used to open / close the overall Canvas UI element, which in itself 
    // // Contains different sub-panels 
    // public void controlGuardianCanvas(){
    //     // If the GPLogInPage is open and the relevant button using .controlGuardianCanvas() is pressed, 
    //     // It must be to close the page - call .closeGPLogIn() 
    //     if(GPLogInCanvasIsOpen){
    //         closeOverallGuardianCanvas(); 
    //     } else {
    //         // if GPLogInIsOpen is false, the button pressed must be to open the GPLogIn page - 
    //         openOverallGuardianCanvas(); 
    //     }
    // }

    // DEL 
    // // Control visibility of GuardianLoginCanvas (overall canvas) 
    // private void closeOverallGuardianCanvas(){
    //     // Close the logging-in UI canvas
    //     GPLogInCanvas.SetActive(false); 
    //     // Reset bool to show the log-in page is NOT open 
    //     GPLogInCanvasIsOpen = false; 
    // }

    //// DEL 
    // // Control visibility of GuardianLoginCanvas (overall canvas) 
    // private void openOverallGuardianCanvas(){
    //     // Set the log-in canvas to be active (visible) 
    //     GPLogInCanvas.SetActive(true);
    //     // Reset bool to show the log-in page IS open 
    //     GPLogInCanvasIsOpen = true; 
    // }



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

