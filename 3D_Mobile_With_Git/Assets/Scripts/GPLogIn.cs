using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// For collecting text from user input:
using UnityEngine.UI; 


// Script to control the opening / closing of the different Log-In 
// panels associated with Guardian / Parent Logging In: 
//  - InitialGuardianLogin
//  - EnterPINPanel 
//  - CreateAccountPanel 
//  - ForgottenPINPanel 
//  - CaptchaPanel 
public class GPLogIn : MonoBehaviour
{ 

    // ____________________________________________
    // Controlling InitialGuardianLogInPanel 
    // ____________________________________________

    // * GeneralPanel, aka the LandingPage of the game 
    [SerializeField]
    private GameObject generalPanel; 
    // when game starts, GeneralPanel is open: 
    private bool isGeneralPanelOpen = true; 

    // * To control the sub-panel, InitialGuardianLogInPanel:
    [SerializeField]
    private GameObject initialGuardianLogInPanel; 
    // When the game starts, it is not open:
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
    // From SuccessfulLoginPanel when the user presses 'Go Back', 
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
    // Controlling EnterPINPanel 
    // ____________________________________________

    // So that enterPINPanel.restart() can be called 
    // when a user leaves enterPINPanel: 
    [SerializeField]
    private GameObject enterPINPanel; 


    // For EnterPINPanel to be visible to the user, 
    // * The panel higher in the hierarchy (initialGuardianLogInPanel) needs 
    // to be set to not active. 
    // * For EnterPINPanel to NOT be visible to the user, since initialGuardianLogInPanel
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
    // Controlling CreateAccountPanel  
    // ____________________________________________


    // Bool to control the opening / closing of the "CreateAccountPanel" 
    // Default is false (Panel not open by default). 
    private bool createAccountPanelOpen = false;

    // Panel to be opened / closed when CreateAccount is pressed
    // ("CreateAccountPanel" in Hierarchy)
    // By default, createAccountPanel is not Visible until user input asks for it to be opened. 
    [SerializeField]
    private GameObject createAccountPanel; 



    // Method to control opening / closing of createAccountPanel 
    // * .onClick() event from InitialGuardianLogInPanel > CreateAccountButton (to open CreateAccountPanel)
    // * .onClick() event from CreateAccountPanel > GoBackButton (to close CreateAccountPanel) 
    public void controlCreateAccountPanel(){
        // If the panel is not open, open it 
        if (!createAccountPanelOpen){
            openCreateAccountPanel();
            return;
        } else {
            // If the panel is open, close it: 
            closeCreateAccountPanel(); 
            // Set back to start values so if user goes back to the CreateAccountPanel, 
            // no remaining error messages etc remain: 
            createAccountPanel.GetComponent<CreateAccount>().restart(); 
            return;
        } 
    }

    // Used to open the createAccountPanel:
    private void openCreateAccountPanel(){
        createAccountPanel.SetActive(true); 
        createAccountPanelOpen = true; 
    }

    // Used to close the createAccountPanel: 
    private void closeCreateAccountPanel(){
        createAccountPanel.SetActive(false); 
        createAccountPanelOpen = false; 
    }






    // ____________________________________________
    // Controlling ForgottenPINPanel 
    // ____________________________________________
 
    // Requirements for ForgottenPINPanel to be visible 
    //      Due to the Unity hierarchy: 
    // 1. Close InitialGuardianLogin
    // 2. Open ForgottenPINPanel 
    [SerializeField]
    private GameObject forgottenPINPanel; 
    // By default, forgottenPINPanel is not open until 
    // User clicks "Forgotten PIN": 
    private bool forgottenPINPanelOpen = false; 

    private void openForgottenPINPanel(){
        forgottenPINPanel.SetActive(true); 
        forgottenPINPanelOpen = true; 
    }

    private void closeForgottenPINPanel(){
        forgottenPINPanel.SetActive(false); 
        forgottenPINPanelOpen = false; 
    }

    // Method used as an onClick() event to 
    // Open 'ForgottenPINPanel': 
    public void controlForgottenPINPanel(){
        // If ForgottenPINPanel is not open, open it: 
        if (!forgottenPINPanelOpen){
            openForgottenPINPanel(); 
            return;
        // If ForgottenPINPanel IS open, close it: 
        } else {
            closeForgottenPINPanel(); 
        }
    }





    // ____________________________________________
    // Controlling CAPTCHAPanel  
    // ____________________________________________

    // Default = it will be closed until opened (if necessary)
    private bool isCAPTCHAPanelOpen = false; 
    // Ref to the Panel GameObject: 
    [SerializeField]
    private GameObject captchaPanel; 

    
    // Method that is used as an onClick() event: 
    // ForgottenPINPanel > YesResetPINButton > To take to CAPTCHAPanel 
    // And 
    // CAPTCHAPanel > GoBack (To go back to ForgottenPINPanel)
    public void controlCAPTCHAPanelOnClick(){
        // If the panel is to be opened: 
        // E.g. "YesResetPINButton" is pressed 
        if (!isCAPTCHAPanelOpen){ 
            // Open CAPTCHAPanel: 
            openCaptchaPanel(); 
            // And also close ForgottenPINPanel:
            closeForgottenPINPanel(); 
            // return so no later blocks are entered as a result of bool changes:
            return; 
        } if (isCAPTCHAPanelOpen){
            // Getting here means CAPTCHAPanel is to be closed: 
            closeCaptchaPanel(); 
            // Also open ForgottenPINPanel 
            openForgottenPINPanel();         
        }
    }

    private void openCaptchaPanel(){
        // Update bool 
        isCAPTCHAPanelOpen = true; 
        // Set CAPTCHAPanel to be active (open it): 
        captchaPanel.SetActive(true); 
    }

    
    private void closeCaptchaPanel(){
        // Update bool 
        isCAPTCHAPanelOpen = false;
        // Set CAPTCHAPanel to not be active (close it): 
        captchaPanel.SetActive(false); 
    }


    // If the user successfully enters the CAPTCHA: 
    // 1. CaptchaPanel needs to close
    // 2. CreateAccountPanel needs to open (as they are
    // directed to create a new PIN):
    public void successfulCaptchaNavigation(){
        // Close CAPTCHA:
        closeCaptchaPanel(); 
        // Open CreateAccountPanel: 
        openCreateAccountPanel(); 
    }

}



