using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Needed to use File class methods: 
using System.IO; 


// Class to load PGInfo.csv (which will contain the parental / guardian info to adjust 
// user settings and set goals for stars)
public class HandleCSV : MonoBehaviour
{

    // Could be made non public with getter 
    public static List<CSVInfo> currentCSV = new List<CSVInfo>(); 
    // To keep track of how many lines are in the CSV file 
    // There should only be max 2
    // (1st line on .csv is not added to List - data columns / human readible info)
    // 2nd = PIN for testing purposes (1111) (wouldn't be there in a real life app) 
    // 3rd = PIN set by the user <-- this is the one rewritten if the user forgets their PIN 
// ? Does it need to be static? 
    public static int csvLineCounter = 0; 
    // Can reference PGInfo.csv as a TextAsset: 
    // "pgInfo" will be how Unity will now reference the information 
    // contained in PGInfo.csv 
    TextAsset pgInfo; 

    private void Start() {
        // Fill the internal memory collection (currentCSV) 
        // With the contents from the CSV file 
        // So the CSV information can be accessed in real time 
        // Workaround for the fact that in Unity, a file that is written to 
        // Cannot then be read from, until the game is finished
        // SO instead, read from and write to the internal List 
        // That then is appended to the CSV when the game is closed and then
        // can be read from when the game is opened again. 
        currentCSV.AddRange(readCSV(1)); 
    }

    // Method to fill the internal memory collection (currentCSV) with contents from the
    // .csv file; 
    public List<CSVInfo> readCSV(int indexToReadFrom){ 
        // List to be filled with the information from the .csv file: 
         List<CSVInfo> csvReadInfo = new List<CSVInfo>(); 
        // Upon Start, initialize pgInfo to be from PGInfo.csv
        // Location is: /Assets/Resources/CSVResources/PGInfo.csv 
        // Resources.Load assumes location is within /Assets/Resources/... 
        // So just add the last half pf the extension 
        pgInfo = Resources.Load<TextAsset>("CSVResources/PGInfo");                                    
        // TextAsset class automatically loads the text from the .csv file 
        // into this TextAsset object 'pgInfo.text'.
        // Each line on CSV = new entry 
        // First row on CSV can be ignored as it's human information (columns headers)
        // To split this data, use an array 
        // Splitting on newline: 
        // Creates an array of the elements from the .csv 
        string[] csvData = pgInfo.text.Split(new char[] { '\n' });
        // LoadCSV.cs added to MainCamera so it is called when game started 
        // indexToReadFrom will either be 0 (to include column headers when rewritting the .csv when a PIN 
        // Is reset)
        // or 1 = to ignore the first column headers if only searching if the PIN exists from EnterPinPanel.cs 
        for(int i = indexToReadFrom; i < csvData.Length; i++){
            // Initialise csvLineCounter to how many PINs are stored: 
            csvLineCounter = csvData.Length; 
            Debug.Log("<color=red> csvLineCounter = " + csvLineCounter + "</color>");
            // Create an array for each one of these column values: 
            string[] row = csvData[i].Split(new char[] { ',' } );
            // Fill in the instance variables of the csvInfo object with those from the array: 
            string pinEntry = row[0]; 
            string dateCreatedEntry = row[1]; 
            // Create a new CSVInfo object using these values: 
            CSVInfo csvInfo = new CSVInfo(pinEntry, dateCreatedEntry); 
            // Add to the List<CSVInfo> csvReadInfo for reference: 
            csvReadInfo.Add(csvInfo); 
        }
        // Return the List<CSVInfo> representing a copy of the .csv file contents: 
        return csvReadInfo; 
    }





    // Method to take a CSVInfo object and append it to the csv file: 
    public void appendToCSV(CSVInfo newCSVEntry){
        // Using string interpolation to save to the CSV file in the Resources folder: 
        // *** Adds to a new line ($"\n....)
        File.AppendAllText("Assets/Resources/CSVResources/PGInfo.csv", $"\n{newCSVEntry.pin},{newCSVEntry.date_created}");
    }





    // Called from CaptchaPanel.cs when a user 
    // wants to reset their PIN. 
    // What it does is create a temporary .csv file 
    // With the contents of the original .csv file (MINUS THE PIN 
    // BEING RESET), and then 
    // replace the old CSV file with this new updated 
    // CSV file. The internal memory collection List<CSVInfo> currentCSV
    // Which other classes access as a copy of the .csv file contents
    // is also updated to reflect the changes  
    public void removeLastPIN(){
        // 1. Get a copy of the current CSV: 
        List<CSVInfo> oldCSV =  readCSV(0); 
        // 2. Make a filePath to a temporary file: 
        string temporaryFile = Application.dataPath + "/Resources/CSVResources/Test.csv";
        // 3. If the file doesn't already exist
        // (it shouldn't, but just in case) 
        if(!File.Exists(temporaryFile)){
            // Add the column headings to the .csv file (pin, date_created): 
            File.WriteAllText(temporaryFile, $"{oldCSV[0].pin},{oldCSV[0].date_created}\n");
        }
        // 4. Append the test PIN (1111) to this file. The user's custom PIN is not entered
        // Because they have asked for it to be reset so it is removed: 
        File.AppendAllText(temporaryFile, $"{oldCSV[1].pin},{oldCSV[1].date_created}");
        // 5. Delete the existing csv file (PGInfo.cs)
        string originalFilePath = Application.dataPath + "/Resources/CSVResources/PGInfo.csv";
        File.Delete(originalFilePath); 
        // 6. Move new file to where this old CSV file was: 
        System.IO.File.Move(temporaryFile, originalFilePath); 
        // 7. Update the internal memory collection of HandleCSV to contain the updated 
        // CSV copy with this PIN entry deleted. Custom PIN is always last entry, 
        // so delete the last entry in the List<CSVInfo>: 
        HandleCSV.currentCSV.RemoveAt(currentCSV.Count - 1); 
    }

        



    
    private void Update() {
        // Set csvLineCounter to be equal to the length of the internal copy of the csv file 
        // So that the program will behave dynamically for the user, e.g. if a PIN is already
        // created, next time the user goes to "CreateAccount", don't show the option to 
        // create a PIN, as there already is a PIN. 
        csvLineCounter = currentCSV.Count; 
    }
}



