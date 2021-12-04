using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// For testing purposes: 
using NUnit.Framework; 


// Arrange = preconditions and inputs
// Act = call method and test 
// Assert = say expectations 


// Class for testing the HashClass used to hash the user's PIN to SHA256 
// Before being stored in PGInfo.csv 
public class HashTest {
 
 
 // Test to confirm the correct SHA256 value is generated for '1111': 
 [Test]
 public void confirm_1111_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output 
     string expected1111Hash = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c";
     string testHashInput = "1111"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected1111Hash)); 
    }


// Test to confirm the correct SHA256 value is generated for '2222': 
[Test]
 public void confirm_2222_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output 
     string expected2222Hash = "edee29f882543b956620b26d0ee0e7e950399b1c4222f5de05e06425b4c995e9";
     string testHashInput = "2222"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected2222Hash)); 
    }


// Test to confirm the correct SHA256 value is generated for '3333': 
[Test]
 public void confirm_3333_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output for "1111" 
     string expected3333Hash = "318aee3fed8c9d040d35a7fc1fa776fb31303833aa2de885354ddf3d44d8fb69";
     string testHashInput = "3333"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected3333Hash)); 
    }


// Test to confirm the correct SHA256 value is generated for '4444': 
[Test]
 public void confirm_4444_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output for "1111" 
     string expected4444Hash = "79f06f8fde333461739f220090a23cb2a79f6d714bee100d0e4b4af249294619";
     string testHashInput = "4444"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected4444Hash)); 
    }


// Test to confirm the correct SHA256 value is generated for '5555': 
[Test]
 public void confirm_5555_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output for "1111" 
     string expected5555Hash = "c1f330d0aff31c1c87403f1e4347bcc21aff7c179908723535f2b31723702525";
     string testHashInput = "5555"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected5555Hash)); 
    }


// Test to confirm the correct SHA256 value is generated for '7777': 
[Test]
 public void confirm_7777_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output for "1111" 
     string expected7777Hash = "41c991eb6a66242c0454191244278183ce58cf4a6bcd372f799e4b9cc01886af";
     string testHashInput = "7777"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected7777Hash)); 
    }

// Test to confirm the correct SHA256 value is generated for '8888': 
[Test]
 public void confirm_8888_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output for "1111" 
     string expected8888Hash = "2926a2731f4b312c08982cacf8061eb14bf65c1a87cc5d70e864e079c6220731";
     string testHashInput = "8888"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected8888Hash)); 
    }

// Test to confirm the correct SHA256 value is generated for '9999': 
[Test]
 public void confirm_9999_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output for "1111" 
     string expected9999Hash = "888df25ae35772424a560c7152a1de794440e0ea5cfee62828333a456a506e05";
     string testHashInput = "9999"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected9999Hash)); 
    }

    // Test to confirm the correct SHA256 value is generated for '1082': 
[Test]
 public void confirm_1082_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output for "1111" 
     string expected1082Hash = "3ef58410b868298fcca4ee41144221bf86bc94e810dfdac6f4b502ce5fcd75c6";
     string testHashInput = "1082"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected1082Hash)); 
    }



    // Test to confirm the correct SHA256 value is generated for '4534': 
[Test]
 public void confirm_4534_Hash_Test(){ 
     // ARRANGE 
     // Expected SHA256 hash output for "1111" 
     string expected4534Hash = "1edbf99ceb74ae073c5faca96afdd9f212b62f207efcbd2b00e41d6b6df46ab6";
     string testHashInput = "4534"; 
     // ACT 
    var actualOutput = HashClass.toSHA256(testHashInput); 
    // ASSERT 
    // Assert that the correct output for 1111 in the toSHA256 crypto algorithm is returned"
    Assert.That(actualOutput, Is.EqualTo(expected4534Hash)); 
    }


}


