using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import .Audio since audio is being adjusted: 
using UnityEngine.Audio; 
// To alter the text field on the canvas based on 
// What the user inputs: 
// **** 
using UnityEngine.UI; 

public class SettingsMenu : MonoBehaviour
{
    // To change volume, need a reference to the main AudioMixer:
    public AudioMixer audioMixer; 

    // ***** Text i want to change: 
    public Text currentResolution;
    
    // public method so it can be triggered from Slider object: 
    public void AdjustVolume(float volume){
        // Set the "Volume" audioMixer to the 'volume' 
        // Attribute passed to this method: 
        audioMixer.SetFloat("Volume", volume); 
        // Debug.Log(volume); 
    }

    // Each drop down choice has an index (first = 0, second = 1)
    // This can then be used to handle the user's choice: 
    public void setResolutionQuality(int dropDownChoiceIndex){
        // Because the first index (0) is a choice saying "choose" 
        // the indexes are not a direct match to the argument passed
        // to QualitySettings.SetQualityLevel()
        switch(dropDownChoiceIndex){
            case 1:
                QualitySettings.SetQualityLevel(0);
                currentResolution.text = "The current resolution is: Very Low"; 
                break; 
            case 2: 
                QualitySettings.SetQualityLevel(1);
                currentResolution.text = "The current resolution is: Low"; 
                break; 
            case 3: 
                QualitySettings.SetQualityLevel(2);
                currentResolution.text = "The current resolution is: Medium"; 
                break;
            case 4: 
                QualitySettings.SetQualityLevel(3);
                currentResolution.text = "The current resolution is: High"; 
                break;
            case 5: 
                QualitySettings.SetQualityLevel(4);
                currentResolution.text = "The current resolution is: Very High"; 
                break;
            case 6: 
                QualitySettings.SetQualityLevel(5);
                currentResolution.text = "The current resolution is: Ultra"; 
                break;
        }
        // QualitySettings.SetQualityLevel(dropDownChoiceIndex);

        
    }
    
    
}
