using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to control the opening / closing of 'SuccessfulLoginPanel' 
// Aka if the correct PIN was entered by the user
// Can only be called from EnterPINPanel if PIN entered was correct 
public class SuccessfulLogin : MonoBehaviour
{
    // 'SuccessfulLoginPanel' object in Unity hierarchy, to be opened / closed: 
    public GameObject successfulLoginPanel; 
    // Used to control opening / closing of successfulLoginPanel: 
    private bool isSuccessfulLoginPanelOpen = false; 

    // Holds reference to the number of stars selected by the parent / guardian 
    public int numberOfStarsSelected = 0; 

    private GPLogIn loginRef = new GPLogIn(); 



    // Method called to control the display of successfulLoginPanel: 
    public void controlSuccessfulLoginPanelTest(){
        // If the panel is not already open yet: 
        if (!isSuccessfulLoginPanelOpen){
            // open it now: 
            successfulLoginPanel.SetActive(true); 
            // reset bool 
            isSuccessfulLoginPanelOpen = true; 
        // Do the opposite if the panel IS open: 
        } else {
            successfulLoginPanel.SetActive(false); 
            isSuccessfulLoginPanelOpen = false; 
            // // Treat the Overall LogIn panel as if it has been closed 
            // // Once user enters pin successfully, they can only go back to Home
            // // Otherwise, login again.
            // controlGuardianLogIn(); 
        }
    }

    // Added in Monday: 

    // Each drop down choice has an index (first = 0, second = 1)
    // This can then be used to handle the user's choice: 
    public void setNumberOfStars(int dropDownChoiceIndex){
        // Because the first index (0) In Unity is a choice saying "choose" 
        // The arguments begin at 1 to avoid 0 ("Choose"): 
        switch(dropDownChoiceIndex){
            // Case 1 is actually option 2, but option 1 is "choose..." 
            case 1:
                // 1 star 
                Debug.Log("1 star"); 
                numberOfStarsSelected = 1; 
                // Repeat the process for all other drop-down choices:  
                Debug.Log("From .setNumberOfStars() ... numberOfStars = " + numberOfStarsSelected);
                break; 
            case 2: 
            // 2 stars 
                numberOfStarsSelected = 2; 
                Debug.Log("2 stars");
                                Debug.Log("From .setNumberOfStars() ... numberOfStars = " + numberOfStarsSelected);

                break; 
            case 3: 
            // 3 stars 
                numberOfStarsSelected = 3; 
                Debug.Log("3 stars");
                                Debug.Log("From .setNumberOfStars() ... numberOfStars = " + numberOfStarsSelected);

                break;
            case 4: 
            // 4 stars 
                numberOfStarsSelected = 4; 
                Debug.Log("4 stars");
                                Debug.Log("From .setNumberOfStars() ... numberOfStars = " + numberOfStarsSelected);

                break;
            case 5: 
            // 5 stars 
                Debug.Log("5 stars");
                numberOfStarsSelected = 5;
                                Debug.Log("From .setNumberOfStars() ... numberOfStars = " + numberOfStarsSelected);
 
                break;
        }        
    }


    // onClickEvent for "Save and Exit" 
    // 1. Take the star entered by the user 
    // 2. If this variable is 0, do nothing because it means the user didn't pick a goal 
    // 3. Add this to Player.cs - will need to have a static instance variable 
    //      in Player that then waits until the goal is reached 
    public void saveAndExitOnClicked(){ 
        // if the numberOfStarsSelected is 0, do nothing - no goal has been set 
        if (numberOfStarsSelected == 0){
            Debug.Log("1st ... numberOfStarsSelected = " + numberOfStarsSelected);
            controlSuccessfulLoginPanelTest(); 
            // loginRef.openInitialGuardianLoginPanel(); 
            return; 
        } else {
            Player playerRef = new Player(); 
            // Pass the number of stars selected by the user to the Player class: 
            playerRef.setPlayerGoal(numberOfStarsSelected); 
            // Navigate back off SuccessfulLogin.cs 
            controlSuccessfulLoginPanelTest(); 
            // loginRef.openInitialGuardianLoginPanel(); 
            Debug.Log("2nd ... numberOfStarsSelected = " + numberOfStarsSelected);
            // Reset values in this page, so if a user comes back on this page 
            // and presses save and exit, no effect they didn't intend occurs 
            numberOfStarsSelected = 0; 
            return; 
        }
    }










// _______________________________________________________
// To be deleted if it's no longer neeedded 

    // // // // Test on Friday since reshuffling hierarchy 
    // // // public GameObject successPanelTest; 

    // // // So that if successful Panel is reached, going back sends them back to general 
    // // // Loogin, rather than pinpad again (doesn't happen in other apps) 
    // // // public GameObject initialPanelTest; 
    // // private bool isSuccessOpenTest = false; // default = not open until PIN is correct  

    // // Needs to be called by EnterPinPanel's .loginCheck()' if the PIN is correct 
    // public void fridayOpenSuccessPanelTest(){ 
    //     if (isSuccessOpenTest == false){
    //         successPanelTest.SetActive(true); 
    //         isSuccessOpenTest = true; 
    //         return;
    //     } if (isSuccessOpenTest){
    //         successPanelTest.SetActive(false); 
    //         isSuccessOpenTest = false; 
    //         return; 
    //     }
    // }
}
