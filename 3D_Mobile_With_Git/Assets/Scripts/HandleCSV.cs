using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Needed to use File class methods: 
using System.IO; 

// Class to load PGInfo.csv (which will contain the parental / guardian info to adjust 
// user settings and set goals for stars)
public class HandleCSV : MonoBehaviour
{

    // ________________
    // FROM VIDEO ONE
    // _________________
    // Can reference PGInfo.csv as a TextAsset: 
    TextAsset pgInfo; 
    // "pgInfo" will be how Unity will now reference the information 
    // contained in PGInfo.csv 

// ********* 10 Nov - changed it to .readCSV returning a List<CSVInfo> instead 
                        // // To store the CSV information after being parsed: 
                        // List<CSVInfo> csvReadInfo = new List<CSVInfo>(); 

    private void Start() {
        // readCSV(); 
        // appendToCSV(); 
        // readCSV(); 
    }

// Could be static? 
    public List<CSVInfo> readCSV(){ 
        // 10 Nov: moved here 
         List<CSVInfo> csvReadInfo = new List<CSVInfo>(); 

        // Upon Start, initialize pgInfo to be from PGInfo.csv
        // Location is: /Assets/Resources/CSVResources/PGInfo.csv 
        // Resources.Load assumes location is within /Assets/Resources/... 
        // So just add the last half pf the extension 
        pgInfo = Resources.Load<TextAsset>("CSVResources/PGInfo");
                                                // Debug.Log("RIGHT NOW" + pgInfo); 
        // TextAsset class automatically loads the text from the .csv file 
        // into this TextAsset object 'pgInfo.text' 
        
        // Each line on CSV = new entry 
        // First row on CSV can be ignored as it's human information (columns)
        // To split this data, we can use an array 
            // Splitting on newline: 
            // Creates an array of the elements from the .csv 
        string[] csvData = pgInfo.text.Split(new char[] { '\n' });
        // // Testing - added LoadCSV.cs to MainCamera for now (as a test)
                        // Debug.Log(csvData.Length); // Printed 4, which is correct (considering top column headers counts as one)

        // Now, ignoring the first line as it's column headers, split the csv file on commas:
        // int i = 1 (ignoring the 0th entry)


// *****************
// i < csvData.Length - 1 gets rid of OutOfBoundsException but causes a blank line at the end of the csv file 
// *****************        
        for(int i = 1; i < csvData.Length; i++){
            // Going to create an array for each one of these column values 
            string[] row = csvData[i].Split(new char[] { ',' } );

            // This showed it was 4 which is correct 
            Debug.Log("**** " + csvData.Length);

            // If the number of items on the row is correct, then proceed: 
            // (This will help if the CSV file is developed further with a database, ensuring 
            // that the data has the correct number of fields)
                                                    // if (row.Length == csvData.Length){
                // If there is an empty row, no point parsing it (empty user slot)
                // If row[1] (username) is empty, don't parse it (no point) 
                // So only include those that are NOT empty: 
                // if(row[1] != ""){

                    // Fill in the instance variables of the csvInfo object with those from the array: 
                    // TryParse is used to try parse as int 
                    // If there's no data there, instead of causing exception, it will just leave default value 
                    // If there is data, it will fill out csvInfo.account_id with it 
                    // int.TryParse(row[0], out int pinEntry); <--- original before changing to string 
                    
                    string pinEntry = row[0]; 
                     // Create a new CSVInfo object 
                    string dateCreatedEntry = row[1]; // username is a string anyway - no conversion needed
                    CSVInfo csvInfo = new CSVInfo(pinEntry, dateCreatedEntry); 

    

                    // Add to the List<CSVInfo> csvReadInfo for reference: 
                    csvReadInfo.Add(csvInfo); 
                                                        // }
            // }
        }
 // *** WHAT WAS PRINTING THE HASH IN THE CONSOLE:        
        // // To test it worked
        // foreach (CSVInfo z in csvReadInfo){
        //     Debug.Log(z.pin); 
        // }
        // May need to check when receiving this that it's not null 
        return csvReadInfo; 
    }

 // Could be static?    
    // Method to take a CSVInfo object and add it to the csv file 
    public void appendToCSV(CSVInfo newCSVEntry){
        // Using string interpolation to save to the CSV file in the Resources folder: 
        // *** Adds to a new line ($"\n....)
        File.AppendAllText("Assets/Resources/CSVResources/PGInfo.csv", $"\n{newCSVEntry.pin},{newCSVEntry.date_created}");
    }





// //     // Test method to see if writing to the csv works 
// //     // Could pass it a CSVInfo object 
//     public void appendToCSV(){ 
// // Could maybe be split into two methods  
// // 1. Get the info to be added to the CSV:    
//         // Need to make a new CSVInfo object 
//         // Containing the values 
//        CSVInfo newInfo = new CSVInfo(); 
//        newInfo.account_id = 4; 
//        newInfo.username = "testUsername"; 
//        newInfo.password = "testPassword"; 
//        // Non-sensical test: 
//        newInfo.date_created = 09112021; 
// // 2. Save to the CSV 
//         // Using string interpolation
//         // pgInfo upon .Start() is initialised to path of the .csv file: 
//                         //    File.AppendAllText(pgInfo.text, $"{newInfo.account_id},{newInfo.username},{newInfo.password},{newInfo.date_created}\n");
//                         //    Debug.Log("Done now");
//     // ********************
//     // \n before the values needed to print this on a new line 
//     // ******************** TAKING AWAY \n from ...crated}\n"); <-- stopped a blank line being printed at the end of a new CSV entry 
//          File.AppendAllText("Assets/Resources/CSVResources/PGInfo.csv", $"\n{newInfo.account_id},{newInfo.username},{newInfo.password},{newInfo.date_created}");
//        Debug.Log("Done now"); 

// //     }
   




}




























// // Original Methods, before being changed 10 Nov 
// public void readCSV(){ 
//         // Upon Start, initialize pgInfo to be from PGInfo.csv
//         // Location is: /Assets/Resources/CSVResources/PGInfo.csv 
//         // Resources.Load assumes location is within /Assets/Resources/... 
//         // So just add the last half pf the extension 
//         pgInfo = Resources.Load<TextAsset>("CSVResources/PGInfo");
//                                                 // Debug.Log("RIGHT NOW" + pgInfo); 
//         // TextAsset class automatically loads the text from the .csv file 
//         // into this TextAsset object 'pgInfo.text' 
        
//         // Each line on CSV = new entry 
//         // First row on CSV can be ignored as it's human information (columns)
//         // To split this data, we can use an array 
//             // Splitting on newline: 
//             // Creates an array of the elements from the .csv 
//         string[] csvData = pgInfo.text.Split(new char[] { '\n' });
//         // // Testing - added LoadCSV.cs to MainCamera for now (as a test)
//                         // Debug.Log(csvData.Length); // Printed 4, which is correct (considering top column headers counts as one)

//         // Now, ignoring the first line as it's column headers, split the csv file on commas:
//         // int i = 1 (ignoring the 0th entry)


// // *****************
// // i < csvData.Length - 1 gets rid of OutOfBoundsException but causes a blank line at the end of the csv file 
// // *****************        
//         for(int i = 1; i < csvData.Length; i++){
//             // Going to create an array for each one of these column values 
//             string[] row = csvData[i].Split(new char[] { ',' } );
//             // Create a new CSVInfo object 
//             CSVInfo csvInfo = new CSVInfo(); 

//             // This showed it was 4 which is correct 
//             Debug.Log("**** " + csvData.Length);

//             // If the number of items on the row is correct, then proceed: 
//             // (This will help if the CSV file is developed further with a database, ensuring 
//             // that the data has the correct number of fields)
//                                                     // if (row.Length == csvData.Length){
//                 // If there is an empty row, no point parsing it (empty user slot)
//                 // If row[1] (username) is empty, don't parse it (no point) 
//                 // So only include those that are NOT empty: 
//                 // if(row[1] != ""){

//                     // Fill in the instance variables of the csvInfo object with those from the array: 
//                     // TryParse is used to try parse as int 
//                     // If there's no data there, instead of causing exception, it will just leave default value 
//                     // If there is data, it will fill out csvInfo.account_id with it 
//                     int.TryParse(row[0], out csvInfo.account_id); 
//                     csvInfo.username = row[1]; // username is a string anyway - no conversion needed
//                     // MIGHT CHANGE TO PIN: 
//                     csvInfo.password = row[2]; // username is a string anyway - no conversion needed
//                     // csvInfo.date_created is an int, so use int.TryParse: 
//                     int.TryParse(row[3], out csvInfo.date_created); 

//                     // Add to the List<CSVInfo> csvReadInfo for reference: 
//                     csvReadInfo.Add(csvInfo); 
//                                                         // }
//             // }
//         }
//         // To test it worked
//         foreach (CSVInfo z in csvReadInfo){
//             Debug.Log(z.account_id); 
//         }
//     }























// ____________________________-
// 10 Nov, 2.40pm 

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// // Needed to use File class methods: 
// using System.IO; 

// // Class to load PGInfo.csv (which will contain the parental / guardian info to adjust 
// // user settings and set goals for stars)
// public class HandleCSV : MonoBehaviour
// {

//     // ________________
//     // FROM VIDEO ONE
//     // _________________
//     // Can reference PGInfo.csv as a TextAsset: 
//     TextAsset pgInfo; 
//     // "pgInfo" will be how Unity will now reference the information 
//     // contained in PGInfo.csv 

// // ********* 10 Nov - changed it to .readCSV returning a List<CSVInfo> instead 
//                         // // To store the CSV information after being parsed: 
//                         // List<CSVInfo> csvReadInfo = new List<CSVInfo>(); 

//     private void Start() {
//         // readCSV(); 
//         // appendToCSV(); 
//         // readCSV(); 
//     }


//     public List<CSVInfo> readCSV(){ 
//         // 10 Nov: moved here 
//          List<CSVInfo> csvReadInfo = new List<CSVInfo>(); 

//         // Upon Start, initialize pgInfo to be from PGInfo.csv
//         // Location is: /Assets/Resources/CSVResources/PGInfo.csv 
//         // Resources.Load assumes location is within /Assets/Resources/... 
//         // So just add the last half pf the extension 
//         pgInfo = Resources.Load<TextAsset>("CSVResources/PGInfo");
//                                                 // Debug.Log("RIGHT NOW" + pgInfo); 
//         // TextAsset class automatically loads the text from the .csv file 
//         // into this TextAsset object 'pgInfo.text' 
        
//         // Each line on CSV = new entry 
//         // First row on CSV can be ignored as it's human information (columns)
//         // To split this data, we can use an array 
//             // Splitting on newline: 
//             // Creates an array of the elements from the .csv 
//         string[] csvData = pgInfo.text.Split(new char[] { '\n' });
//         // // Testing - added LoadCSV.cs to MainCamera for now (as a test)
//                         // Debug.Log(csvData.Length); // Printed 4, which is correct (considering top column headers counts as one)

//         // Now, ignoring the first line as it's column headers, split the csv file on commas:
//         // int i = 1 (ignoring the 0th entry)


// // *****************
// // i < csvData.Length - 1 gets rid of OutOfBoundsException but causes a blank line at the end of the csv file 
// // *****************        
//         for(int i = 1; i < csvData.Length; i++){
//             // Going to create an array for each one of these column values 
//             string[] row = csvData[i].Split(new char[] { ',' } );
//             // Create a new CSVInfo object 
//             CSVInfo csvInfo = new CSVInfo(); 

//             // This showed it was 4 which is correct 
//             Debug.Log("**** " + csvData.Length);

//             // If the number of items on the row is correct, then proceed: 
//             // (This will help if the CSV file is developed further with a database, ensuring 
//             // that the data has the correct number of fields)
//                                                     // if (row.Length == csvData.Length){
//                 // If there is an empty row, no point parsing it (empty user slot)
//                 // If row[1] (username) is empty, don't parse it (no point) 
//                 // So only include those that are NOT empty: 
//                 // if(row[1] != ""){

//                     // Fill in the instance variables of the csvInfo object with those from the array: 
//                     // TryParse is used to try parse as int 
//                     // If there's no data there, instead of causing exception, it will just leave default value 
//                     // If there is data, it will fill out csvInfo.account_id with it 
//                     int.TryParse(row[0], out csvInfo.account_id); 
//                     csvInfo.username = row[1]; // username is a string anyway - no conversion needed
//                     // MIGHT CHANGE TO PIN: 
//                     csvInfo.password = row[2]; // username is a string anyway - no conversion needed
//                     // csvInfo.date_created is an int, so use int.TryParse: 
//                     int.TryParse(row[3], out csvInfo.date_created); 

//                     // Add to the List<CSVInfo> csvReadInfo for reference: 
//                     csvReadInfo.Add(csvInfo); 
//                                                         // }
//             // }
//         }
//         // To test it worked
//         foreach (CSVInfo z in csvReadInfo){
//             Debug.Log(z.account_id); 
//         }
//         // May need to check when receiving this that it's not null 
//         return csvReadInfo; 
//     }





//     // Test method to see if writing to the csv works 
//     // Could pass it a CSVInfo object 
//     public void appendToCSV(){ 
// // Could maybe be split into two methods  
// // 1. Get the info to be added to the CSV:    
//         // Need to make a new CSVInfo object 
//         // Containing the values 
//        CSVInfo newInfo = new CSVInfo(); 
//        newInfo.account_id = 4; 
//        newInfo.username = "testUsername"; 
//        newInfo.password = "testPassword"; 
//        // Non-sensical test: 
//        newInfo.date_created = 09112021; 
// // 2. Save to the CSV 
//         // Using string interpolation
//         // pgInfo upon .Start() is initialised to path of the .csv file: 
//                         //    File.AppendAllText(pgInfo.text, $"{newInfo.account_id},{newInfo.username},{newInfo.password},{newInfo.date_created}\n");
//                         //    Debug.Log("Done now");
//     // ********************
//     // \n before the values needed to print this on a new line 
//     // ******************** TAKING AWAY \n from ...crated}\n"); <-- stopped a blank line being printed at the end of a new CSV entry 
//          File.AppendAllText("Assets/Resources/CSVResources/PGInfo.csv", $"\n{newInfo.account_id},{newInfo.username},{newInfo.password},{newInfo.date_created}");
//        Debug.Log("Done now"); 

//     }
   




// }
