using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To alter the text field on the canvas based on user input: 
using UnityEngine.UI; 


// The ability for the player to view how many stars they have during the game 
// By clicking the 'View Stars' button 
public class ViewStars : MonoBehaviour
{
    // In order to access how many stars they have 
    // Player script handles loading and saving stars 
    public Player player; 
    // The text element on the ViewStars Panel that will display the number of stars
    // to the user
    public Text numberOfStarsText; 
    // String to set numberOfStarsText.text 
    private string numberOfStarsString; 
    // Used with controlViewStars() 
    private bool viewStarsOpen = false; 
    // Panel to be displayed when ViewStars is clicked 
    public GameObject viewStarsPanel; 
    
    void Update()
    { // Update the text with the number of stars held by the player 
        numberOfStarsString = "You currently have " + player.numberOfStars + " stars!";
        // Apply this to the Text element 
        numberOfStarsText.text = numberOfStarsString; 
    }

    // Used to determine what method is called 
    // E.g. openViewStars() or closeViewStars()
   public void controlViewStars(){
       // If the game is already paused, resume game: 
       if (viewStarsOpen){
           closeViewStars(); 
       }
       else {
           openViewStars(); 
       }
   }

    // When the "View Stars" button is pressed
    public void openViewStars(){
        // Display the ViewStars canvas:
        viewStarsPanel.SetActive(true); 
        // Set the time to 0 to completely freeze the game: 
        Time.timeScale = 0f; 
        viewStarsOpen = true; 
    }



    // When the "Close" button is pressed 
    public void closeViewStars(){
         // Hide pause canvas again: 
        viewStarsPanel.SetActive(false); 
        // Reset time to normal: 
        Time.timeScale = 1f; 
        // Reset boolean because game is no longer paused: 
        viewStarsOpen = false; 
    }
}
