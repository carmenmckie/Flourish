using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'MonoBehaviour' removed because PlayerData is not going to act as a component in the game 

// [System.Serializable] = means it can be saved in a file 
[System.Serializable]
public class PlayerData {
    public int numberOfStars; 
    public int numberOfTrophies; 

    public int level; 


    // Take data from Player object 
    // And store it in the variables of PlayerData 
    public PlayerData(Player player){
        numberOfStars = player.numberOfStars; 
        numberOfTrophies = player.numberOfTrophies;
    }
}
























// _____________ To be deleted ___________________




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // 'MonoBehaviour' removed because PlayerData is not going to act as a component in the game 

// // [System.Serializable] = means we can save it in a file 
// [System.Serializable]
// public class PlayerData {
//     public int numberOfStars; 
//     public int numberOfTrophies; 

//     public int level; 
//     // OG 
//     // Take data from Player script 
//     // and store it in the variables: 
//     // public PlayerData(Player player){
//     //     numberOfStars = player.numberOfStars; 
//     //     numberOfTrophies = player.numberOfTrophies;
//     //     level = player.level; 
//     // }


//     public PlayerData(){
//         numberOfStars = Player.numberOfStars; 
//         numberOfTrophies = Player.numberOfTrophies;
//         level = Player.level; 
//     }
// }
