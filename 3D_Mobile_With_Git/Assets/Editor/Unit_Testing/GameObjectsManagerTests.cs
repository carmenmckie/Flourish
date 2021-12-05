using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework; 

// Class to test the GameObjectsManager functionality works 
// Such as the correct objects within the scene 
public class GameObjectsManagerTests {

    [Test]
    public void check_correct_number_of_game_objects_TEST(){
        // ARRANGE
        GameObjectsManager refTest = new GameObjectsManager(); 
        // There should be four game objects within the scene:
        int expectedOutput = 4; 
        // ACT 
        int actualOutput = refTest.getGardenObjectsInScene().Length; 
        // ASSERT 
        Assert.That(expectedOutput, Is.EqualTo(actualOutput)); 

    }

    // Test to check the algorithm used to shuffle the positions of objects
    // Upon initialization 
    [Test]
    public void check_randomize_position_algorithm_TEST(){
        // ARRANGE 
        // Create a test List<T> list 
        List<int> testList = new List<int>();  
        // Fill with test values
        for(int i =0; i < 5; i++){
            testList.Add(i); 
        }
        int firstValue = testList[0]; 
        // ACT 
        // Call the shuffling method
        GameObjectsManager.Shuffle(testList); 
        // Get the new first object 
        int newFirstValue = testList[0];
        // ASSERT
        // Assert that the two first values have now been changed 
        Assert.That(firstValue, Is.Not.EqualTo(newFirstValue)); 
    }


}
