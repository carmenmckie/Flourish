using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To use DateTime: 
using System; 

// Not a MonoBehaviour class, purely informational class: 
public class CSVInfo {

    // PIN chosen by user (only saved in hashed form)
    public string pin; 
    // Date PIN was made by the user, so the parent / guardian is made aware when their PIN was changed
    // as a security measure: 
    public string date_created; 

    // Constructor for if an entry is created from the game (date will be generated):
    public CSVInfo(string pin){
        this.pin = pin; 
        // Get the current date (returns string): 
        string date = DateTime.Today.ToString("dd-MM-yyyy");
        this.date_created = date; 
    }

    // Constructor for if an entry is read from the csv file, where the 
    // date is already available / entered: 
    public CSVInfo(string pin, string date_created){
        this.pin = pin; 
        this.date_created = date_created; 
    }


     // Method to return the last CSVInfo's date from a List<CSVInfo>: 
     // Called from ForgottenPIN.cs to update user on when their pin was last changed
    public static string returnLastDate(List<CSVInfo> list){
        // 1. Get how many elements are in the list 
        int length = list.Count; 
        if (length -1 <= 0){
            Debug.Log("Count is <= 0");
            return null; 
        }
        // 2. Find the last element based of this: 
        // And get the last element's date
        // (length - 1 because index will start at 0)
        // count will be one greater than largest index: 
        string lastDate = list[length - 1].date_created;
        // 3. Return this date: 
        return lastDate; 
    }


    // // Only a testing method at the moment 
    // public string printCSVInfo(){
    //     string value = ""; 
    //     value += this.pin + ","; 
    //     value += this.date_created; 
    //     return value; 
    // }

}

