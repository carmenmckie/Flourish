using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

// Class to control the Player object which remains throughout the game
// - Contains the number of stars held by the user
public class Player : MonoBehaviour {
    public int numberOfStars = 0; 

// Testing Monday 15 Nov 
// Testing Monday 15 Nov 
// Testing Monday 15 Nov 
// Testing Monday 15 Nov 
// Testing Monday 15 Nov 
    // By default, goalSet = false, change to true if a guardian / parent 
    // sets a goal from 'SuccessfulLogin.cs' 
    private static bool goalSet = false; 
    public static bool goalAchieved = false; 
    public static int starGoal = 0; 

    public static int targetStars = 0; 

    // Called from SuccessfulLogin.cs when the Parent / Guardian selects the star goal: 
    public void setPlayerGoal(int starGoal){
        LoadPlayer(); 
        goalSet = true; 
        // Calculate how many stars it is until target is reached: 
        targetStars = numberOfStars + starGoal; 
    }

    private void Update() {
        Debug.Log("Number of stars = " + numberOfStars);
        Debug.Log("TargetStars =  " + targetStars); 
        if ((numberOfStars == targetStars) && (goalSet = true)){
            Debug.Log("STAR GOAL REACHED!");
            goalAchieved = true; 

        }
    }


    public void starGoalReached(){
        // Reset bools back to default, so that if the user wants, another goal can be set 
        targetStars = 0; 
        goalSet = false; 
        goalAchieved = false; 
    }


    // From SuccessfulLogin panel, the parent / guardian can set a goal for how many stars
    // To be earned in a playing session. 


// Testing Monday 15 Nov 
// Testing Monday 15 Nov 
// Testing Monday 15 Nov 
// Testing Monday 15 Nov 
// Testing Monday 15 Nov 


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
    // ******
        // Pass this class to SaveSystem.loadPlayerData  to make a file if it doesn't exist? 
        PlayerData data = SaveSystem.loadPlayerData(this); 
    // Original: 
    //    PlayerData data = SaveSystem.loadPlayerData(); 
    //    numberOfTrophies = data.numberOfTrophies; 
       numberOfStars = data.numberOfStars;
            // Tues 9 Nov
                // Made comment while testing the CSV loading 
                // Otherwise this displayed first when game launched 
            // Debug.Log("Player Loaded - called from Player.LoadPlayer() number of stars: " + numberOfStars);
    }



// Testing Methods 

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








































//__________________________________________________
// To be deleted 


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // *** Attached to Player gameObject 


// // To store the number of stars a player has 
// // Time played? 
// public class Player : MonoBehaviour
// {
//     // Start with 0 
//     // If a game is completed, a star is gained 
//     public static int numberOfStars; 
//     public static int numberOfTrophies; 

//     // idea? 
//     public static int level; 

//      // Add star OG
//     // public void addStar(){
//     //     numberOfStars += 1; 
//     //     Debug.Log("number of stars: " + numberOfStars  + " (.addStar())");
//     // }



//     public void addStar(){
//         numberOfStars = numberOfStars + 1; 
//         Debug.Log("number of stars: " + numberOfStars  + " (.addStar())");
//     }


// //  public void addStar(){
// //         numberOfStars = numberOfStars + 1; 
// //         Debug.Log("number of stars: " + Instance.numberOfStars  + " (.addStar())");
// //     }

//     public void addTrophy(){
//         numberOfTrophies += 1; 
//     }

//     // Not sure if these will be needed (game rn only 
//     // one star at a time))
//     public void updateNumberOfStars(int amount){
//         numberOfStars += amount; 
//     }

//     public void updateNumberOfTrophies(int amount){
//         numberOfTrophies += amount; 
//     }

//     // OG 
//     // public void savePlayer(){
//     //     // Pass it the current Player object 
//     //     SaveSystem.savePlayerData(this); 
//     //     Debug.Log("Player saved "); 
//     // }

//      public void savePlayer(){
//         // Pass it the current Player object 
//         SaveSystem.savePlayerData(this); 
//         Debug.Log("Player saved "); 
//     }

//     // public static Player instance; //= null; 
//     // // Swapped to adding GameObject Player in each scene 
//     // public void Awake(){
//     //     if (instance == null) {
//     //         instance = this; 
//     //         DontDestroyOnLoad(transform.gameObject);
//     //     }
//     //     else { 
//     //         // Destroy any duplicates - only want one object
//     //         // playing audio so it can be easily controlled in one place
//     //         Destroy(gameObject);
//     //     }
//     // }

// // Weds Testing 

// // Didn't work 
//     // public static Player Instance;

//     // public Player(){
//     //     if (Instance == null){
//     //         Instance = this; 
//     //     }
//     // }



 
//  // Weds Testing .... Singleton Design ^^^^^^^

//     // Function to reset values (as I'm testing i'm increasing stars etc - needed to set them 
//     // back to 0)
//     public void resetValues(){
//         numberOfStars = 0; 
//         numberOfTrophies = 0; 
//         level = 0; 
//     }
// // ********



//     // Testing if the save system is working 
//     // public void printStars(){
//     //     Debug.Log("Number of stars: " + Instance.numberOfStars + " (.printStars())"); 
//     // }

//     // Didn't work 
//      public void printStars(){
//         Debug.Log("Number of stars: " + numberOfStars + " (.printStars())"); 
//     }


// // Original method (that is resetting stars to 0....!!!!!!)
// // Weds 3 Nov 16.08 
//     // public void loadPlayer(){
//     //     Debug.Log("FIRST DEBUG STATEMENT");
//     //     // ****
//     //     // If there IS data to be loaded 
//     //     if (SaveSystem.loadPlayerData() != null){
//     //         // Set the PlayerData to this
//     //         PlayerData data = SaveSystem.loadPlayerData(); 
//     //         level = data.level; 
//     //         numberOfStars = data.level; 
//     //         numberOfTrophies = data.level; 
//     //         Debug.Log("number of stars: " + numberOfStars); 
//     //         Debug.Log("Data already there .... 1");
//     //         return; 
//     //     } 
//     //     // If data is null, it means the game is being opened for 
//     //     // the first time - there is no path made yet 
//     //     if (SaveSystem.loadPlayerData() == null){
//     //         Debug.Log("Null data"); 
//     //         // Create a path / save the game 
//     //         SaveSystem.savePlayerData(this); 
//     //         // Try load again 
//     //         PlayerData data = SaveSystem.loadPlayerData(); 
//     //         level = data.level; 
//     //         numberOfStars = data.level; 
//     //         numberOfTrophies = data.level; 
//     //         Debug.Log("Data made and now loaded .....2");
//     //         return; 
//     //     }
        
//     // }

//     // OG 
//     // public void loadPlayer(){
//     //         Debug.Log("FIRST DEBUG STATEMENT");
//     //         // ****
//     //             PlayerData data = SaveSystem.loadPlayerData(); 
//     //             Instance.level = data.level; 
//     //             Instance.numberOfStars = data.level; 
//     //             Instance.numberOfTrophies = data.level; 
//     //             Debug.Log(".loadPlayer() number of stars: " + data.numberOfStars); 
//     //             Debug.Log("LoadPlayer finished .... ");
//     //         }
            
//     //     }


//         // // Didn't work 
//         // public void loadPlayer(){
//         //     Debug.Log("FIRST DEBUG STATEMENT");
//         //     // ****
//         //         PlayerData data = SaveSystem.loadPlayerData(); 
//         //         this.level = data.level; 
//         //         this.numberOfStars = data.level; 
//         //         this.numberOfTrophies = data.level; 
//         //         // Data.numberOfStars displayed the correct amount, but it doesn't translate 
//         //         // to then this class 
//         //         Debug.Log(".loadPlayer() number of stars: " + this.numberOfStars); 
//         //         Debug.Log("LoadPlayer finished .... ");
//         //     }
            
//         // }

//           // Didn't work 
//         public void loadPlayer(){
//             Debug.Log("FIRST DEBUG STATEMENT");
//             // ****
//                 PlayerData data = SaveSystem.loadPlayerData(); 
//                 level = data.level; 
//                 numberOfStars = data.level; 
//                 numberOfTrophies = data.level; 
//                 // Data.numberOfStars displayed the correct amount, but it doesn't translate 
//                 // to then this class 
//                 Debug.Log(".loadPlayer() number of stars: " + numberOfStars); 
//                 Debug.Log("LoadPlayer finished .... ");
//             }
            
//         }


























// //     // 1. If the game has already been played before, 
// //     //      loads the game file. 
// //     // 2. If it is the first time playing the game, 
// //     //      file path is created, and then this new 
// //     //      file path is loaded. 
// //     public void loadPlayer(){
// //         Debug.Log("FIRST DEBUG STATEMENT");
// //         // SaveSystem.loadPlayerData() outputs Player Data 
// //         // Save this in a PlayerData variable equal to this 
// //         // Make reference to PlayerData 
// //         // *****
// //         PlayerData data = new PlayerData(this); 
// //         // ****
// //         // If there IS data to be loaded 
// //         if (SaveSystem.loadPlayerData() != null){
// //             // Set the PlayerData to this
// //             data = SaveSystem.loadPlayerData(); 
// //             Debug.Log("Data already there .... 1");
// //             // return; 
// //         } 
// //         // If data is null, it means the game is being opened for 
// //         // the first time - there is no path made yet 
// //         if (SaveSystem.loadPlayerData() == null){
// //             Debug.Log("Null data"); 
// //             // Create a path / save the game 
// //             SaveSystem.savePlayerData(this); 
// //             // Try load again 
// //             data = SaveSystem.loadPlayerData(); 
// //             Debug.Log("Data made and now loaded .....2");
// //             // return; 
// //         }
// //         level = data.level; 
// //         numberOfStars = data.level; 
// //         numberOfTrophies = data.level; 
// //         Debug.Log("number of stars: " + numberOfStars); 
// //     }
// // }






// //         // Weds trial and error




// //         // Get the variables saved in this: 
// //         level = data.level; 
// //         numberOfStars = data.level; 
// //         numberOfTrophies = data.level; 
// //         Debug.Log("Number of stars = " + numberOfStars);
// //     }

// // }
