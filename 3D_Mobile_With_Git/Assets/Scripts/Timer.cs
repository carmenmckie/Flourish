using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To access the UI elements
using UnityEngine.UI; 

// Class designed to be passed any value in seconds
// and it will create a Timer object
// Which begins countdown for that amount 
public class Timer : MonoBehaviour { 

    // Text to display the countdown: 
    public GameObject textDisplayingCountdown; 
    // Countdown amount in seconds, only used when PIN is maxed out at
    // 60 seconds 
    private int secondsLeft; 
    public bool takingAwaySecond = false; 

    public bool timerComplete = false; 

    public bool timerStillRunning = true; 


    // Need a Co-Routine to detect when a second has passed using
    // yield return new WaitForSeconds(...); 
    // Need this rather than .Update() (once per frame, which can 
    // sometimes be twice per second etc)
    IEnumerator timerTakeAway(){
        // Start taking away second process; 
        takingAwaySecond = true; 
        // Wait a second: 
        yield return new WaitForSeconds(1); 
        // Take one away from the timer amount because 
        // a second has passed 
        secondsLeft -= 1; 
        if (secondsLeft < 10){
            // if the countdown gets into single digits, add an extra 0 
            // so that it doesn't say 00:3, 00:2, etc. Now says 00.03, 00.02... 
            textDisplayingCountdown.GetComponent<Text>().text = "00:0" + secondsLeft; 
        }
        else { 
            textDisplayingCountdown.GetComponent<Text>().text = "00:" + secondsLeft; 
        }
        // Bool reset because 1 second has been taken away from the required countdown amount: 
        // Taking away second process finished: 
        takingAwaySecond = false; 
    }



    void Start() {
        Restart(); 
    }



    // Method created to 'restart' a Timer object 
    public void Restart(){ 
        this.secondsLeft = 10; 
        takingAwaySecond = false;
        timerStillRunning = true; 
        if (secondsLeft < 10){
            // if the countdown gets into single digits, add an extra 0 
            // so that it doesn't say 00:3, 00:2, etc. Now says 00.03, 00.02... 
            textDisplayingCountdown.GetComponent<Text>().text = "00:0" + secondsLeft; 
        }
        else { 
            textDisplayingCountdown.GetComponent<Text>().text = "00:" + secondsLeft; 
        }
        timerComplete = false; 
    }





    void Update() {
        if (timerStillRunning){ 
            Debug.Log("Got under timerStillRunning"); 
            timerComplete = false; 
            // ^^^^^ Don't think it made a difference 
            Debug.Log("TimerComplete: " + timerComplete); 
            // If there is still at least 1 second left 
            if (takingAwaySecond == false && secondsLeft > 0){
                StartCoroutine(timerTakeAway());
                Debug.Log("Got under startCoroutine"); 

            } if (secondsLeft <= 0) { 
                Debug.Log("Got under secondsLeft <= 0"); 

                // When timer is complete, set bool to true 
                timerComplete = true; 
                timerStillRunning = false;
                Debug.Log("Got to timerComplete being made true");
                // Test below: 
                takingAwaySecond = false; 
                this.setSecondsLeft(5); 
            }
        }
    }


    // getter for the bool timerComplete
    public bool getTimerComplete(){
        return this.timerComplete; 
    }

    // Setter for the bool timerComplete: 
    public void setTimerComplete(bool val){
        this.timerComplete = val; 
    }

    // Setter for secondsLeft for a Timer: 
    public void setSecondsLeft(int seconds){
        this.secondsLeft = seconds; 
    }

    // Getter for secondsLeft for a Timer: 
    public int getSecondsLeft(){
        return this.secondsLeft;
    }

}























