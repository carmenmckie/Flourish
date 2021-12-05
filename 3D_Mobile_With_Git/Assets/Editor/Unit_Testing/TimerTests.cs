using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework; 


// Class to Unit Test Timer functionality 
public class TimerTests {
    

// Test to check that the Timer returns the correct value 
// for secondsLeft - checking the functionality fully stops 
// after it is finished correctly resets back to normal 
[Test]
public void confirm_no_seconds_left_TEST(){
    // ARRANGE
    Timer testTimer = new Timer(); 
    int expectedResult = 0; 
    // ACT 
    int actualResult = testTimer.getSecondsLeft(); 
    // ASSERT
    Assert.That(expectedResult, Is.EqualTo(actualResult)); 
}


// Confirm that timerComplete is false on start 
// Should be false because no timer has ran yet
// When a timer has ran, it then is true 
[Test]
public void confirm_timer_complete_TEST(){
    // ARRANGE
    Timer testTimer = new Timer(); 
    bool expectedResult = testTimer.getTimerComplete(); 
    // ACT 
    bool actualResult = testTimer.getTimerComplete(); 
    // ASSERT 
    Assert.That(actualResult, Is.EqualTo(expectedResult)); 
}

}
