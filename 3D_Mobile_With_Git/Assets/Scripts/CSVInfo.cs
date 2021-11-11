using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To use DateTime: 
using System; 

// Not a MonoBehaviour class, purely informational class 
public class CSVInfo {

    // SE said not to: control (?) coupling 
    // public CSVInfo(int account_id, string username, string password

// From video two .... mucked up the initial code 
//     public int accountNumber { get; set; }
//     public string username { get; set; }
//     public string password { get; set; }
//     public int date_created { get; set; }


    // _______________
    // From Video One 
    // _______________
    // // The information in the csv files column headers as instance variables:
    // // (column headers for PGInfo.csv are: account_id,username,password,date_created)
    // // Since this is a general information class, need to be public: 
    

    // Keeping it as a string BECAUSE someone might want to include letters / characters
    // in their pin, not just numbers. and doesn't matter if they do 
    public string pin; 
    public string date_created; 

    // Constructor for if an entry is created 
    // From the game (date will be generated):
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


    // Only a testing method at the moment - isn't used properly anywhere 
    public string printCSVInfo(){
        string value = ""; 
        value += this.pin + ","; 
        value += this.date_created; 
        return value; 
    }

        // toString method needed? 
}


































// ************************
// Before changing to just two values 
 
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // Not a MonoBehaviour class, purely informational class 
// public class CSVInfo {

//     // SE said not to: control (?) coupling 
//     // public CSVInfo(int account_id, string username, string password

// // From video two .... mucked up the initial code 
// //     public int accountNumber { get; set; }
// //     public string username { get; set; }
// //     public string password { get; set; }
// //     public int date_created { get; set; }


//     // _______________
//     // From Video One 
//     // _______________
//     // // The information in the csv files column headers as instance variables:
//     // // (column headers for PGInfo.csv are: account_id,username,password,date_created)
//     // // Since this is a general information class, need to be public: 
//     public int account_id; 
//     public string username; 
//     public string password; 
//     public int date_created; 



//     public string printCSVInfo(){
//         string value = ""; 
//         value += this.account_id + "- "; 
//         value += this.username + "- ";
//         value += this.password + "- "; 
//         value += this.date_created + "- "; 
//         return value; 
//     }

//         // toString method needed? 
// }
