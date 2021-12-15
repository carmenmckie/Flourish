using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'MonoBehaviour' removed because PlayerData is not going to act as a component in the game 

// [System.Serializable] = means it can be saved in a file 
[System.Serializable]
public class PlayerData {
    public int numberOfStars;  


    // Take data from Player object 
    // And store it in the variables of PlayerData 
    public PlayerData(Player player){
        numberOfStars = player.numberOfStars; 
    }
}
