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

}
