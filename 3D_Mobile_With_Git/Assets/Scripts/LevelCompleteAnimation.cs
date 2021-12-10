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
    [SerializeField]
    private GameObject gameCompleteCanvas; 

    private bool animationFinished = false; 
    public Player player; 
    [SerializeField]
    private LoadingBar loading; 

    // Reference to the GameObject to be displayed if the user meets their star goal: 
    [SerializeField]
    private GameObject starGoalReached; 



    // Called from Port in .Update() if Port's bool gameComplete is true 
    public void gameCompleted(){
        gameCompleteCanvas.SetActive(true); 
        StartCoroutine(displayStars());
        player.LoadPlayer(); 
        player.addStar(); 
        player.SavePlayer(); 
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
// !* M?  
            if(!animationFinished){
                starImage1.gameObject.SetActive(true); 
                yield return new WaitForSeconds(0.2f); 
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
                // Down right 
                Image downRightStar = Instantiate(starImage1, new Vector3(starXpos + 57, starYpos - 68, starZpos), Quaternion.identity);
                downRightStar.transform.SetParent(gameCompleteCanvas.transform); 
                downRightStar.transform.localScale = new Vector3(starScaleX * 0.5f, starScaleY * 0.5f, starScaleZ * 0.5f); 
                // Rotates slightly to the left: 
                downRightStar.rectTransform.Rotate( new Vector3( 0, 0, 45 ) );
                Destroy(downRightStar, 0.5f);
                yield return new WaitForSeconds(0.2f); 
                // Down left 
                Image downLeftStar = Instantiate(starImage1, new Vector3(starXpos - 57, starYpos - 68, starZpos), Quaternion.identity);
                downLeftStar.transform.SetParent(gameCompleteCanvas.transform); 
                downLeftStar.transform.localScale = new Vector3(starScaleX * 0.5f, starScaleY * 0.5f, starScaleZ * 0.5f); 
                // Rotates slightly to the right: 
                downLeftStar.rectTransform.Rotate( new Vector3( 0, 0, -45 ) );
                Destroy(downLeftStar, 0.5f);
                // So that there's enough time to view the stars: 
                yield return new WaitForSeconds(3f); 
                animationFinished = true; 
                Debug.Log("You have won a new star!");
                // If the user has met their star goal target: 
                if (Player.goalAchieved){
                    // Display the gameobject saying "Congratulations, you have reached your star goal!" 
                    starGoalReached.SetActive(true); 
                    // Wait for 3 seconds: 
                    yield return new WaitForSeconds(3f); 
                    // Reset values, to reflect the goal has been achieved: 
                    player.starGoalReached(); 
                }
                // Hide gameCompleteCanvas again so when user restarts game, it's back to normal 
                gameCompleteCanvas.SetActive(false); 
                 // Go back to area where users can choose mini game: 
                loading.LoadNewScene("ChooseMiniGame");
            }             
    }
}

        
