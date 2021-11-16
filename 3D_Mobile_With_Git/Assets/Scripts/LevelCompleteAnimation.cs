using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

// To display stars for a short period when a level is complete 
// Only display animations for a short period 
// as per ASD research suggests to only show feedback for a short time to avoid visual stress 
public class LevelCompleteAnimation : MonoBehaviour
{

    // "SerializeField" = visible in Inspector without making it a public variable 
    [SerializeField] private Image starImage1; 

    // The 'GameCompletePanel' UI Panel that will show the stars upon game completion 
    public GameObject gameCompleteCanvas; 

    public bool animationFinished = false; 

    public Player player; 
    public LoadingBar loading; 

    // Reference to the GameObject to be displayed if the user meets their
    // Star goal: 
    public GameObject starGoalReached; 



    // Called from Port in .Update() 
    // if Port's bool gameComplete is true 
    public void gameCompleted(){
        gameCompleteCanvas.SetActive(true); 
        StartCoroutine(displayStars());
        player.LoadPlayer(); 
        player.addStar(); 
        player.SavePlayer(); 
        // // Go back to area where users can choose mini game 
        // loading.LoadNewScene("ChooseMiniGame");
    }

  // Turned Method into INemurator 
  // "You cannot stall the calling function unless it is an IEnumerator itself" 
  // "WaitForSeconds() only works from within the coroutine" 
  // https://answers.unity.com/questions/1497296/waitforseconds-not-working-13.html
   public IEnumerator displayStars() { 
            yield return new WaitForSeconds(0.2f);
            // Get the position of the original Star image: 
            float starXpos = starImage1.transform.position.x;
            float starYpos = starImage1.transform.position.y;
            float starZpos = starImage1.transform.position.z; 
            // Rotation info 
            float starRotationX = starImage1.transform.rotation.x; 
            float starRotationY = starImage1.transform.rotation.y; 
            float starRotationZ = starImage1.transform.rotation.z; 
            // Scale info 
            float starScaleX = starImage1.transform.localScale.x; 
            float starScaleY = starImage1.transform.localScale.y; 
            float starScaleZ = starImage1.transform.localScale.z; 
// Code is being repeated, make it into some sort of loop instead 
            if(!animationFinished){
                // yield return new WaitForSeconds(0.2f); 
                starImage1.gameObject.SetActive(true); 
                yield return new WaitForSeconds(0.2f); 
                // gameCompleteCanvas.SetActive(true); 
                // Top right 
                Image topRightStar = Instantiate(starImage1, new Vector3(starXpos -57, starYpos + 68, starZpos), Quaternion.identity);
                topRightStar.transform.SetParent(gameCompleteCanvas.transform); 
                topRightStar.transform.localScale = new Vector3(starScaleX * 0.5f, starScaleY * 0.5f, starScaleZ * 0.5f);
                // Rotates slightly to the left: 
                topRightStar.rectTransform.Rotate( new Vector3( 0, 0, 45 ) );
                Destroy(topRightStar, 0.5f);
                yield return new WaitForSeconds(0.2f); 
                // Top left 
                Image topLeftStar = Instantiate(starImage1, new Vector3(starXpos + 57, starYpos + 68, starZpos), Quaternion.identity);
                topLeftStar.transform.SetParent(gameCompleteCanvas.transform); 
                topLeftStar.transform.localScale = new Vector3(starScaleX * 0.5f, starScaleY * 0.5f, starScaleZ * 0.5f); 
                // Rotates slightly to the right: 
                topLeftStar.rectTransform.Rotate( new Vector3( 0, 0, -45 ) );
                Destroy(topLeftStar, 0.5f);
                yield return new WaitForSeconds(0.2f); 
                // Bottom right 
                Image bottomRightStar = Instantiate(starImage1, new Vector3(starXpos + 57, starYpos - 68, starZpos), Quaternion.identity);
                bottomRightStar.transform.SetParent(gameCompleteCanvas.transform); 
                bottomRightStar.transform.localScale = new Vector3(starScaleX * 0.5f, starScaleY * 0.5f, starScaleZ * 0.5f); 
                // Rotates slightly to the left: 
                bottomRightStar.rectTransform.Rotate( new Vector3( 0, 0, 45 ) );
                Destroy(bottomRightStar, 0.5f);
                yield return new WaitForSeconds(0.2f); 
                // Bottom left 
                Image bottomLeftStar = Instantiate(starImage1, new Vector3(starXpos - 57, starYpos - 68, starZpos), Quaternion.identity);
                bottomLeftStar.transform.SetParent(gameCompleteCanvas.transform); 
                bottomLeftStar.transform.localScale = new Vector3(starScaleX * 0.5f, starScaleY * 0.5f, starScaleZ * 0.5f); 
                // Rotates slightly to the right: 
                bottomLeftStar.rectTransform.Rotate( new Vector3( 0, 0, -45 ) );
                Destroy(bottomLeftStar, 0.5f);
                // yield return new WaitForSeconds(0.2f); 
                yield return new WaitForSeconds(3f); 
                animationFinished = true; 
                Debug.Log("You have won a new star!");

                // If the user has met their star goal target: 
                if (Player.goalAchieved){
                    // Display the gameobject saying "Congratulations, you have reached your star goal!" 
                    starGoalReached.SetActive(true); 
                    yield return new WaitForSeconds(3f); 
                    // Reset values, to reflect the goal has been achieved: 
                    player.starGoalReached(); 
                }
                gameCompleteCanvas.SetActive(false); 

                 // Go back to area where users can choose mini game 
                loading.LoadNewScene("ChooseMiniGame");
            }             
    }


}

        
