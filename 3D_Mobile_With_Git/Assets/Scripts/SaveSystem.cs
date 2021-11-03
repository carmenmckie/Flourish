// Responsible for actually doing the saving 

// System.IO: Namespace used when working with files on operating system: 
using System.IO; 
// Allow class to access Binary Formatter: 
using System.Runtime.Serialization.Formatters.Binary; 
using UnityEngine;
// 
using System.Runtime.Serialization; 

// Static class = class that can't be instantiated (only ever want ONE SaveSystem)
public static class SaveSystem {  
    
    // Static so if it changes in one place it changes in both 
    // public static string path = Application.persistentDataPath + "/player.fun";

    public static void savePlayerData(Player player){
        BinaryFormatter formatter = new BinaryFormatter(); 
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create); 

        // OG 
        // PlayerData data = new PlayerData(player);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data); 
        stream.Close(); 
    }

    public static PlayerData loadPlayerData(){
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter(); 
            FileStream stream = new FileStream(path, FileMode.Open); 
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close(); 
            return data;  
        } else {
            Debug.Log("Got to : file not found in SaveSystem.loadPlayerData()");
            Debug.LogError("Save file not found in " + path); 
            return null; 
        }

    }
}







































// // __________________________________________


// // Responsible for actually doing the saving 

// // System.IO: Namespace used when working with files on operating system: 
// using System.IO; 
// // Allow class to access Binary Formatter: 
// using System.Runtime.Serialization.Formatters.Binary; 
// using UnityEngine;
// // 
// using System.Runtime.Serialization; 

// // Static class = class that can't be instantiated (only ever want ONE SaveSystem)
// public static class SaveSystem {  
    
//     // Static so if it changes in one place it changes in both 
//     // public static string path = Application.persistentDataPath + "/player.fun";

//     public static void savePlayerData(Player player){
//         BinaryFormatter formatter = new BinaryFormatter(); 
//         string path = Application.persistentDataPath + "/player.fun";
//         FileStream stream = new FileStream(path, FileMode.Create); 

//         // OG 
//         // PlayerData data = new PlayerData(player);
//         PlayerData data = new PlayerData();


//         formatter.Serialize(stream, data); 
//         stream.Close(); 
//     }

//     public static PlayerData loadPlayerData(){
//         string path = Application.persistentDataPath + "/player.fun";
//         if (File.Exists(path)){
//             BinaryFormatter formatter = new BinaryFormatter(); 
//             FileStream stream = new FileStream(path, FileMode.Open); 
//             PlayerData data = formatter.Deserialize(stream) as PlayerData;
//             stream.Close(); 
//             return data;  
//         } else {
//             Debug.Log("Got to : file not found in SaveSystem.loadPlayerData()");
//             Debug.LogError("Save file not found in " + path); 
//             return null; 
//         }

//     }
// }






























// //     // Saving Data -- Weds 3 Nov 
// //     public static void savePlayerData(Player player){
// //         // 1. Create a BinaryFormatter and a FileStream outside try / catch 
// //         BinaryFormatter formatter = new BinaryFormatter(); 
// //         FileStream stream = null; // Has to be null here to work in try / catch 
// //         // string path = Application.persistentDataPath + "/player.fun"; 
// //         PlayerData data = new PlayerData(player); 
// //         // Try instantiate FileStream
// //         try { 
// //             // Save = FileMode.Create 
// //             stream = new FileStream(path, FileMode.Create); 
// //         }
// //         catch (FileNotFoundException e){
// //             Debug.LogError(e.StackTrace); 
// //             throw; 
// //         } finally { 
// //             try { 
// //                 // Write data to the file 
// //                 formatter.Serialize(stream, data); 
// //             }
// //             catch (SerializationException io){
// //                 Debug.LogError(io.StackTrace);
// //                 throw; 
// //             }
// //             finally { 
// //                 stream.Close(); 
// //             }
// //         }
// //     }


// //     // Loading Data 
// //     public static PlayerData loadPlayerData(){
// //         // Check if a file exists in the path 
// //         PlayerData data = new PlayerData(Player.Instance); 
// //         if (File.Exists(path)){
// //             BinaryFormatter formatter = new BinaryFormatter(); 
// //             // Open up FileStream 
// //             FileStream stream = null; 
// //             // PlayerData variable 
// //             try { 
// //                 // Load = FileMode.Open 
// //                 stream = new FileStream(path, FileMode.Open); 
// //             }
// //             catch (FileNotFoundException e){
// //                 Debug.LogError(e.StackTrace); 
// //                 throw; 
// //             } finally { 
// //                 try { 
// //                     // Now DESERIALIZE (change from Binary back to 
// //                     // readable format)
// //                     // Needs to be casted into a PlayerData, without this it is of type
// //                     // "Object" 
// //                     data = formatter.Deserialize(stream) as PlayerData; 
// //                 }
// //                 catch (SerializationException io){
// //                     Debug.LogError(io.StackTrace);
// //                     throw; 
// //                 }
// //                 finally { 
// //                     stream.Close(); 
// //                 }
                
// //             }
// //             // Return the PlayerData object containing the deserialized data: 
// //             // return data; 
// //         }
// //         // If file not found in path: 
// //         else {
// //             // Create a path? 

// //             Debug.LogError("Save file not found in " + path); 
// //             return null; 
// //         }
// //         return data; 

// //     }

// // }
















// // 16.04 weds
// //     // Loading Data 
// //     public static PlayerData loadPlayerData(){
// //         // Check if a file exists in the path 
// //         Player
// //         if (File.Exists(path)){
// //             BinaryFormatter formatter = new BinaryFormatter(); 
// //             // Open up FileStream 
// //             FileStream stream = null; 
// //             // PlayerData variable 
// //             PlayerData data = null; 
// //             try { 
// //                 // Load = FileMode.Open 
// //                 stream = new FileStream(path, FileMode.Open); 
// //             }
// //             catch (FileNotFoundException e){
// //                 Debug.LogError(e.StackTrace); 
// //                 throw; 
// //             } finally { 
// //                 try { 
// //                     // Now DESERIALIZE (change from Binary back to 
// //                     // readable format)
// //                     // Needs to be casted into a PlayerData, without this it is of type
// //                     // "Object" 
// //                     data = formatter.Deserialize(stream) as PlayerData; 
// //                 }
// //                 catch (SerializationException io){
// //                     Debug.LogError(io.StackTrace);
// //                     throw; 
// //                 }
// //                 finally { 
// //                     stream.Close(); 
// //                 }
// //             }
// //             // Return the PlayerData object containing the deserialized data: 
// //             // return data; 
// //         }
// //         // // If file not found in path: 
// //         // else {
// //         //     Debug.LogError("Save file not found in " + path); 
// //         //     // return null; 
// //         // }
// //                     return data; 

// //     }

// // }





//         // try { 
//         //     formatter.Serialize(stream, AudioDataLoadState); 
//         //     formatter = new BinaryFormatter(); 
//         //     // 2. Path to save the Data to 
//         //     // Get a path to a data directory on the operating system 
//         //     // that isn't going to suddenly change 
//         //     // can be any file extension (e.g. .fun)
//         //     string path = Application.persistentDataPath + "/player.fun"; 
//         //     stream = new FileStream(path, FileMode.Create);

//         //     // Pass the player ref from this method to the constructor 
//         //     // of PlayerData 
//         //     PlayerData data = new PlayerData(player); 

//         //     // Insert in file 
//         //     formatter.Serialize(stream, data); 
//         // }
//         // catch (FileNotFoundException io) { 
//         //     Debug.Log(io.StackTrace); 
//         // }
//         // finally { 
//         //     stream.Close(); 
//         // }
//     // }


// // before splitting into try / catch blocks 
//     // public static void savePlayer(Player player){
//     //     // 1. Create a BinaryFormatter and a FileStream outside try / catch 
//     //     BinaryFormatter formatter = new BinaryFormatter(); 
//     //     FileStream stream = null; // Has to be null here to work in try / catch 
//     //     try { 
//     //         formatter = new BinaryFormatter(); 
//     //         // 2. Path to save the Data to 
//     //         // Get a path to a data directory on the operating system 
//     //         // that isn't going to suddenly change 
//     //         // can be any file extension (e.g. .fun)
//     //         string path = Application.persistentDataPath + "/player.fun"; 
//     //         stream = new FileStream(path, FileMode.Create);

//     //         // Pass the player ref from this method to the constructor 
//     //         // of PlayerData 
//     //         PlayerData data = new PlayerData(player); 

//     //         // Insert in file 
//     //         formatter.Serialize(stream, data); 
//     //     }
//     //     catch (FileNotFoundException io) { 
//     //         Debug.Log(io.StackTrace); 
//     //     }
//     //     finally { 
//     //         stream.Close(); 
//     //     }
//     // }

   
// // }
