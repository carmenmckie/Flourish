using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour deleted because PlayerData is not going to act as a component in the game 
public class PlayerData {
    public int numberOfStars; 
    public int numberOfTrophies; 
    
    // Take data from Player script 
    public PlayerData(Player player){
        numberOfStars = player.numberOfStars; 
        numberOfTrophies = player.numberOfTrophies;
    }
}
