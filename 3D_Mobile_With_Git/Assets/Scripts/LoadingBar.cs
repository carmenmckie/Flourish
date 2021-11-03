using System.Collections;
using UnityEngine;
// Import SceneManagement so that a game scene can be loaded: 
using UnityEngine.SceneManagement; 
// To access Progress Slider (It's a UI element):
using UnityEngine.UI; 

// Script to display a loading bar to the user between scenes
public class LoadingBar : MonoBehaviour {

    // Reference to LoadingScreen
    public GameObject loadingScreen;
    // Reference to Progress Slider 
    public Slider sliderBar; 
    // Reference to the text on the slider bar:
    public Text progressPercentage; 

  // Weds 3 Nov 
  public void LoadDragDropTest(){
    StartCoroutine(LoadAsynchronously("DragDropTest"));
  }




  // Weds 3 Nov 


   public void LoadNewScene(string sceneName){
     StartCoroutine(LoadAsynchronously(sceneName));
   }

    // Whenever this CoRoutine is called: 
    // 1. Load a scene asynchronously
    // 2. Store status of operation in the AsyncOperation object 'operation'
    // 3. Start a while loop that will run until the process is done
    // 4. Print a debug statement about current progress
    // 5. Wait a frame until we print another statement, using 'yield return null' 
    IEnumerator LoadAsynchronously(string sceneName){
      // Weds 
      yield return new WaitForSeconds(2); 



      // Weds 
       // The other Unity method 'SceneManager.LoadScene()' pauses
       // The entire game while loading a new scene. 
       // '.LoadSceneAsync' loads the scene asynchronously in 
       // The background. So we can get information about the 
       // Progress of the operation while it's loading 
       // This 'AsyncOperation' object returns information about the progress
       // of the operation 
       AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
       // While loading, activate loadingScreen: 
       loadingScreen.SetActive(true); 

       // While the scene is still loading: 
       while (operation.isDone == false){
           // Clamps the value between 0 and 1 
           // Loading values in Unity go from 0 - 0.9
           // This converts it so the loading goes from 0 - 1 
           // So it's easier to understand for the user: 
           float progress = Mathf.Clamp01(operation.progress / 0.9f);
           Debug.Log("Progress is: " + progress);

           // Set the sliderBar element to display the current loading progress: 
          sliderBar.value = progress; 
          // Update the text on the slider bar
           // (Multiplying by 100 so it's displayed as a percentage):
           progressPercentage.text = progress * 100f + "%"; 
           // Wait until the next frame before continuing: 
           yield return null; 
       }
    }


    // // Whenever this CoRoutine is called: 
    // // 1. Load a scene asynchronously
    // // 2. Store status of operation in the AsyncOperation object 'operation'
    // // 3. Start a while loop that will run until the process is done
    // // 4. Print a debug statement about current progress
    // // 5. Wait a frame until we print another statement, using 'yield return null' 
    // IEnumerator LoadAsynchronously (int sceneNumber){
    //    // The other Unity method 'SceneManager.LoadScene()' pauses
    //    // The entire game while loading a new scene. 
    //    // '.LoadSceneAsync' loads the scene asynchronously in 
    //    // The background. So we can get information about the 
    //    // Progress of the operation while it's loading 
    //    // This 'AsyncOperation' object returns information about the progress
    //    // of the operation 
    //    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNumber);
    //    // While the scene is still loading: 
    //    while (operation.isDone == false){
    //        Debug.Log(operation.progress); 
    //        // Wait until the next frame before continuing: 
    //        yield return null; 
    //    }
    // }
}
