using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import necessary to use Cryptography methods: 
using System.Security.Cryptography; 
// Import necessary to use Encoding.UTF8.GetBytes(): 
using System.Text; 


// Class designed to contain a method that can hash 
// a PIN entered by the user.  
public static class HashClass {

    // Static method able to be called from any class in this game, to hash a String using 
    // SHA256. 
    public static string toSHA256(string toBeHashed){
        using var sha256 = SHA256.Create(); 
        byte[] wordToBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(toBeHashed));
        // Make StringBuilder object: 
        var stringBuilder = new StringBuilder(); 
        // Loop through and convert byte array back to string: 
        for(int i = 0; i < wordToBytes.Length; i++){
            // "x2" is a "format string" that says the String should be formatted using Hexadecimal 
            stringBuilder.Append(wordToBytes[i].ToString("x2"));
        }
        return stringBuilder.ToString(); 
    }
    
}
