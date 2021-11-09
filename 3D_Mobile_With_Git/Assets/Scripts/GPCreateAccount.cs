using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script used for a guardian / parent to create an account 
// Opened via clicking "Create Account" button on the OverallGuardianLoginPanel 
public class GPCreateAccount : MonoBehaviour
{

    // Bool to control the opening / closing of the "CreateAccountPanel" 
    // Default is false. 
    private bool GPLogInIsOpen = false;

    // Panel to be opened / closed when CreateAccount is pressed
    // ("CreateAccountPanel" in Hierarchy)
    // By default, createAccountPanel is not Visible until user input asks for it to be opened 
    public GameObject createAccountPanel; 


    // Method to control opening / closing of createAccountPanel 
    // Method used by "CreateAccount" button from GuardianLogInCanvas
    // And "GoBackButton" from CreateAccountPanel 
    public void controlCreateAccountPanel(){
        // If the panel is not open, open it 
        if (!GPLogInIsOpen){
            openCreateAccountPanel();
        } else {
            closeCreateAccountPanel(); 
        }
    }

    // Used to open the createAccountPanel
    public void openCreateAccountPanel(){
        createAccountPanel.SetActive(true); 
        GPLogInIsOpen = true; 
    }

    // Used to close the createAccountPanel 
    public void closeCreateAccountPanel(){
        createAccountPanel.SetActive(false); 
        GPLogInIsOpen = false; 
    }


}
