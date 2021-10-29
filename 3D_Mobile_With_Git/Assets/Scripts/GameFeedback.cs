// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GameFeedback : MonoBehaviour
// {
//     // ******Maybe I could make them disappear? 
//     // Or use the colour aspect to make them grey and immobile if a wrong choice is made? 
//     // *SN 
//     public Material _matchMaterial; 
//     public Material _misMatchMaterial; 
//     public Renderer _renderer; 






//     // Start is called before the first frame update
//     void Start()
//     {
//         // Get the renderer 
//         _renderer = GetComponent<Renderer>(); 
//     }

//     // SN 
//     public void changeMaterialWithMatch(bool isCorrectMatch){
//         // Check if it is a correct match 
//         // If so, make the game object disappear 
//         if(isCorrectMatch){
//             // _renderer.material = _matchMaterial; 
//             Debug.Log("Change colour");
//         }
//         else {
//             // TURN OBJECT GREY ... AND IMMOBILISE IT 
//             _renderer.material = _misMatchMaterial;
//              Debug.Log("Don't change colour");
//         }
//     }



//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
