using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework; 

public class GardenObjectTests
{
    
    // Check bool at start is not matched to port 
    [Test]
    public void confirm_not_matched_to_port_on_start_TEST(){
        // ARRANGE
        GardenObject gardenObjectTest = new GardenObject(); 
        bool expectedResult = false; 
        // ACT 
        bool actualResult = gardenObjectTest.getIsMatchedToPort(); 
        // ASSERT 
        Assert.That(expectedResult, Is.EqualTo(actualResult)); 
    }


}
