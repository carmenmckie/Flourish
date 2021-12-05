using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// For testing
using NUnit.Framework; 

public class PlayerTest {

    

    // Test to check that when the app is downloaded for the first 
    // time (and so a new Player object is created) 
    // That the star values are 0 
    [Test]
    public void confirm_new_player_0_stars_test(){
        // ARRANGE 
        Player testPlayer = new Player(); 
        int expectedStars = 0; 
        // ACT 
        int actualStars = testPlayer.returnStars(); 
        // ASSERT 
        Assert.That(expectedStars, Is.EqualTo(actualStars)); 
    }



    // Test to check that the adding star functionality works 
    // When called 10 times in a row 
    [Test]
    public void adding_10_stars_test(){
        // ARRANGE 
        Player testPlayer = new Player(); 
        int expectedStars = 10; 
        // ACT 
        for (int i = 0; i < expectedStars; i++){
            testPlayer.addStar(); 
        }
        int actualStars = testPlayer.returnStars(); 
        Debug.Log("actualStars = " + actualStars);
        // ASSERT 
        Assert.That(expectedStars, Is.EqualTo(actualStars)); 
    }



}
