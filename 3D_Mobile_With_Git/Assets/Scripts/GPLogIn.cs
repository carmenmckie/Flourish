using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GPLogIn: Guardian / Parental Log-In 
            // Script used to control the "Guardian Log-In" section, activated from the LandingPage 
            // In Freeplay Mode 
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

    // Create Account Button 
    







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
