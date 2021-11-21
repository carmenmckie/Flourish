using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

// Class to control the Player object which remains throughout the game
// - Contains the number of stars held by the user
public class Player : MonoBehaviour {
    public int numberOfStars = 0; 
    // By default, goalSet = false, changes to true if a guardian / parent 
    // sets a goal from 'SuccessfulLogin.cs' 
    private static bool goalSet = false; 
    public static bool goalAchieved = false; 
    public static int targetStars = 0; 

    // Called from SuccessfulLogin.cs when the Parent / Guardian selects the star goal: 
    // From SuccessfulLogin panel, the parent / guardian can set a goal for how many stars
    // To be earned in a playing session. 
    public void setPlayerGoal(int starGoal){
        LoadPlayer(); 
        goalSet = true; 
        // Calculate how many stars it is until target is reached: 
        // numberOfStars = current stars
        // starGoal = goal set by parent / guardian 
        // targetStars will be the sum of these two numbers, 
        //  when the number of stars held by the user meets targetStars, this 
        // is when the user is notified that they have reached their goal. 
        targetStars = numberOfStars + starGoal; 
    }

    // .Update() method will detect when the starGoal has been reached 
    private void Update() {
        // Debug.Log("Number of stars = " + numberOfStars);
        // Debug.Log("TargetStars =  " + targetStars); 
        if ((numberOfStars == targetStars) && (goalSet = true)){
            Debug.Log("STAR GOAL REACHED!");
            goalAchieved = true; 

        }
    }

    // Called from LevelCompleteAnimation.cs 
    // After the user has been notified that they have reached the star goal:
    public void starGoalReached(){
        // Reset bools back to default, so that if the user wants, another goal can be set 
        targetStars = 0; 
        goalSet = false; 
        goalAchieved = false; 
    }


    // Any Scene that uses the Player.cs script 
    // Will load the player info at the start 
    // This is so each scene has access to the correct number of stars the player has
    // Number of stars can only increase at the END of a scene 
    private void Start() {
        LoadPlayer(); 
    }



    public void SavePlayer(){
        SaveSystem.savePlayerData(this); 
        Debug.Log("Player Saved - called from Player.SavePlayer() number of stars: " + numberOfStars);
    }


    public void LoadPlayer(){
//*** ???? Pass this class to SaveSystem.loadPlayerData to make a file if it doesn't exist? 
        PlayerData data = SaveSystem.loadPlayerData(this); 
       numberOfStars = data.numberOfStars;
    }



//__________________
// Testing Methods 
//__________________

    public void addStar(){
            numberOfStars += 1; 
            Debug.Log("number of stars: " + numberOfStars  + " Printed from(.addStar())");
    }

    // Testing if the save system is working 
    public void printStars(){
        Debug.Log("Number of stars: " + numberOfStars + " Printed from (.printStars())"); 
    }
    
    public void resetStars(){
        numberOfStars = 0; 
        Debug.Log("Stars Reset to 0");
    }


}

