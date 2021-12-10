using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import .Audio since audio is being adjusted: 
using UnityEngine.Audio; 
// To alter the text field on the canvas based on user input: 
using UnityEngine.UI; 

public class SettingsMenu : MonoBehaviour
{
    // To change volume, need a reference to the main AudioMixer:
    public AudioMixer audioMixer; 

    // Text changed to display the current resolution 
    // Setting to the user: 
    // The text has to be changed via a static string rather than 
    // making the text field Static otherwise Unity throws an error 
    [SerializeField]
    private Text currentResolution;

    // Reference to the Canvas UI object the gameplay Settings screen 
    // is made up of: 
    [SerializeField]
    private GameObject settingsMenuCanvas; 

    // The text that will be updated by user input and then used to set 
    // the 'Text currentResolution'. Static so it saves between scenes 
    // Based on the user's input
    //  By default at the start of the game, resolution is medium: 
     private static string resolutionText = "The current resolution is: Medium";

     // ****
     // public static so other scripts can access this
    // To know whether the game has Settings open or not 
    private static bool settingsOpen = false;

    // Reference to Slider so that if the user presses "music on" / "music off"
    // The slider updates so that the change is visible to the user
    // And the slider doesn't represent an old value 
    [SerializeField]
    private Slider musicSlider;


    // Reference to SoundEffects class in order to change the bool areSoundEffectsOn, which is a condition check before 
    // sound effects are played 
    [SerializeField]
    private SoundEffects soundEffectsRef; 


    // Ticks to show which button is active  
    // At this point, music ON and sfx ON are default when the game begins 
    // So by default, musicOnTick and sfxOnTick are VISIBLE  
    [SerializeField]
    private GameObject musicOnTick; 
    [SerializeField]
    private GameObject musicOffTick; 
    [SerializeField]
    private GameObject sfxOnTick; 
    [SerializeField]
    private GameObject sfxOffTick; 






   
    // Update resolutionText & soundSettingsText every frame, so the user's choice updates the field. 
    // Then, apply this text to Text UI elements
    // It has to be done in this way because Unity doesn't allow static GameObjects
    // (e.g. Text currentResolution itself cannot be static)
    public void Update(){
        currentResolution.text = resolutionText; 
        // Dynamically update the musicSlider to display the current volume
        // Of the Audio Mixer (so it doesn't reset between scenes)
        float value; 
        bool result = audioMixer.GetFloat("Volume", out value); 
        if (result){
            // Update musicSlider to display value 
            musicSlider.value = value; 
        } else {
            return; 
        }
    }

    
    // public method so it can be triggered from Slider object: 
    public void AdjustVolume(float volume){
        // Set the "Volume" audioMixer to the 'volume' 
        // Attribute passed to this method: 
        audioMixer.SetFloat("Volume", volume); 
        // If the user slides the slider to be less than 0 (-80), 
        // update the tick to show that music is ON 
        if (volume > -80){
            musicOnTick.SetActive(true); 
            musicOffTick.SetActive(false); 
        }
        // If the user slides the slider to the lowest value (-80), 
        // update the tick to show that music is OFF 
        if (volume == -80){
            musicOnTick.SetActive(false); 
            musicOffTick.SetActive(true); 
        }
        // Debug.Log(volume); 
    }

    // To be called when the user presses "Music Off" 
    public void musicOff(){
        // Set audioMixer's level to -80 
        // In Unity, audio levels go from (-80 -> +20) 
        // Rather than 0 - 100 
        audioMixer.SetFloat("Volume", -80); 
        // Update slider to display new change: 
        musicSlider.value = -80; 
        // Reset ticks 
        musicOnTick.SetActive(false); 
        musicOffTick.SetActive(true); 
    }

    // To be called when the user presses "Sounds Off" 
    public void soundsOff(){ 
        // Sets an instance variable 'areSoundsEffectsOn' to be false
        // Which then is checked from the methods in SoundEffects 
        // to decide whether a sound is to be played or not 
        soundEffectsRef.setAreSoundEffectsOn(false); 
        sfxOnTick.SetActive(false); 
        sfxOffTick.SetActive(true); 
    }

    // To be called when the user presses "Sounds On" 
    public void soundsOn(){ 
        // Set the bool areSoundEffectsOn to be true
        soundEffectsRef.setAreSoundEffectsOn(true); 
        sfxOffTick.SetActive(false); 
        sfxOnTick.SetActive(true); 
    }


    // To be called when user presses "Music On" 
    public void musicOn(){
        // If the music is already on, do nothing
        if (musicSlider.value > -80){ 
            Debug.Log("Music is already on");
            return; 
        }
        // Upon clicking "musicOn" - put music 
        // To be half-way. Not full volume because 
        // This could be alarming for the user 
        // (Halfway between (-80 -> +20) is -30 
        audioMixer.SetFloat("Volume", -30);
        // Update slider to display new change: 
        musicSlider.value = -30; 
        Debug.Log("Music now turned on"); 
        musicOffTick.SetActive(false); 
        musicOnTick.SetActive(true); 
    }


    // Each drop down choice has an index (first = 0, second = 1)
    // This can then be used to handle the user's choice: 
    public void setResolutionQuality(int dropDownChoiceIndex){
        // Because the first index (0) is a choice saying "choose" 
        // the indexes are not a direct match to the argument passed
        // to QualitySettings.SetQualityLevel()
        // This workaround is due to Unity making the label
        // the first drop-down choice by default in Unity
        switch(dropDownChoiceIndex){
            case 1:
                // Second drop-down choice (index 1) is "Very Low"
                // Which in an argument form is '0': 
                QualitySettings.SetQualityLevel(0);
                // Update the text so the user knows their current resolution:
                resolutionText = "The current resolution is: Very Low";
                // Repeat the process for all other drop-down choices:  
                break; 
            case 2: 
                QualitySettings.SetQualityLevel(1);
                resolutionText = "The current resolution is: Low"; 
                break; 
            case 3: 
                QualitySettings.SetQualityLevel(2);
                resolutionText = "The current resolution is: Medium"; 
                break;
            case 4: 
                QualitySettings.SetQualityLevel(3);
                resolutionText = "The current resolution is: High"; 
                break;
            case 5: 
                QualitySettings.SetQualityLevel(4);
                resolutionText = "The current resolution is: Very High"; 
                break;
            case 6: 
                QualitySettings.SetQualityLevel(5);
                resolutionText = "The current resolution is: Ultra"; 
                break;
        }        
    }

    // Called when the player clicks the button to open settings
     public void controlSettingsDuringGamePlay(){
       // If the game is already paused, resume game: 
       if (settingsOpen){
           CloseSettings(); 
       }
       else {
           OpenSettings(); 
       }
     }


    // Does the opposite of .OpenSettings() to resume the game: 
    public void CloseSettings(){
        // Hide pause canvas again: 
        settingsMenuCanvas.SetActive(false); 
        // Reset time to normal: 
        Time.timeScale = 1f; 
        // Reset boolean because game is no longer paused: 
        settingsOpen = false; 
    }

    // 1. Show Settings  
    // 2. Stop time (so game is paused)
    // 3. Set boolean to true (so upon clicking resume, 
    // Settings are closed and game is resumed)
    public void OpenSettings(){
        // Display the Settings menu: 
        // (Otherwise, it is hidden)
        settingsMenuCanvas.SetActive(true); 
        // Set the time to 0 to completely freeze the game: 
        Time.timeScale = 0f; 
        settingsOpen = true; 
    }

}
