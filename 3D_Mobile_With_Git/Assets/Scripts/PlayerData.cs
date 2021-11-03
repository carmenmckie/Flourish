using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'MonoBehaviour' removed because PlayerData is not going to act as a component in the game 

// [System.Serializable] = means we can save it in a file 
[System.Serializable]
public class PlayerData {
    public int numberOfStars; 
    public int numberOfTrophies; 

    public int level; 
    
    // Take data from Player script 
    // and store it in the variables: 
    public PlayerData(Player player){
        numberOfStars = player.numberOfStars; 
        numberOfTrophies = player.numberOfTrophies;
        level = player.level; 
    }
}
