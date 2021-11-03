using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// To store the number of stars a player has 
// Time played? 
public class Player : MonoBehaviour
{
    // Start with 0 
    // If a game is completed, a star is gained 
    public int numberOfStars; 
    public int numberOfTrophies; 

    // idea? 
    public int level; 

     // Add star 
    public void addStar(){
        numberOfStars += 1; 
    }

    public void addTrophy(){
        numberOfTrophies += 1; 
    }

    // Not sure if these will be needed (game rn only 
    // one star at a time))
    public void updateNumberOfStars(int amount){
        numberOfStars += amount; 
    }

    public void updateNumberOfTrophies(int amount){
        numberOfTrophies += amount; 
    }

    public void savePlayer(){
        // Pass it the current Player object 
        SaveSystem.savePlayerData(this); 
    }

    public void loadPlayer(){
        // SaveSystem.loadPlayerData() outputs Player Data 
        // Save this in a PlayerData variable equal to this 
        PlayerData data = SaveSystem.loadPlayerData(); 
        // Get the variables saved in this: 
        level = data.level; 
        numberOfStars = data.level; 
        numberOfTrophies = data.level; 
    }

}
