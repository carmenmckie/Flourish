using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework; 

// Class to test the functionality of the KeyPad object 
// created to handle user input for PIN functionality 
public class KeyPadTests {


    // Test to confirm that the starting digits of the KeyPad are 0
    // To confirm that between PINs being entered, previous PIN values
    // are not stored in the KeyPad - should refresh each use 
    [Test]
    public void confirm_default_start_digits_TEST(){
    // ARRANGE
    KeyPad testKeyPad = new KeyPad();
    int expectedResult = 0; 
    // ACT 
    int actualResult = testKeyPad.getDigitsEnteredCounter(); 
    // ASSERT 
    Assert.That(expectedResult, Is.EqualTo(actualResult)); 
    }

    // Test to confirm KeyPad's arrayToString()
    // Method produces the correct output 
    [Test]
    public void confirm_array_to_string_output_TEST(){
        // ARRANGE
        KeyPad testKeyPad = new KeyPad(); 
        // Test array to input into the method to check output 
        string[] testArray = new string[4]; 
        // Fill array with test values 
        for(int i = 0; i < testArray.Length; i++){
            testArray[i] = i.ToString(); 
        }
        // ACT 
        string outputResult = testKeyPad.arrayToString(testArray); 
        string expectedResult = "0123";
        // ASSERT 
        Assert.That(outputResult, Is.EqualTo(expectedResult)); 
    }
    

}
