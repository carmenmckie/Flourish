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
