// Responsible for actually doing the saving 

// System.IO: Namespace used when working with files on operating system: 
using System.IO; 
// Allow class to access Binary Formatter: 
using System.Runtime.Serialization.Formatters.Binary; 
using UnityEngine;
// To throw a SerializationException (if necessary): 
using System.Runtime.Serialization; 

// Static class = class that can't be instantiated (only ever want ONE SaveSystem)
public static class SaveSystem {  

    // Path to save to: 
    private static string path = Application.persistentDataPath + "/player.fun";

    // Called when data needs to be saved 
    // E.g. when a player earns a new star 
    public static void savePlayerData(Player player){
        // 1. Create a BinaryFormatter and a FileStream outside try / catch 
        BinaryFormatter formatter = new BinaryFormatter(); 
        FileStream stream = null; // Has to be null here to work in try / catch 
        // string path = Application.persistentDataPath + "/player.fun"; 
        PlayerData data = new PlayerData(player); 
        // Try instantiate FileStream
        try { 
            // Save = FileMode.Create 
            stream = new FileStream(path, FileMode.Create); 
        }
        catch (FileNotFoundException e){
            Debug.LogError(e.StackTrace); 
            throw; 
        } finally { 
            try { 
                // Write data to the file 
                formatter.Serialize(stream, data); 
            }
            catch (SerializationException io){
                Debug.LogError(io.StackTrace);
                throw; 
            }
            finally { 
                stream.Close(); 
            }
        }
    }




//*** Try / catch block? 
     public static PlayerData loadPlayerData(Player player){
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter(); 
            FileStream stream = new FileStream(path, FileMode.Open); 
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close(); 
            return data;  
        } else {
            // Getting here means a file doesn't exist 
            // (e.g. first time game is opened on a device)
            // So create a new PlayerData object:
            PlayerData data = new PlayerData(player); 
            // And save it to file: 
            // (So that next time, it can be loaded) 
            savePlayerData(player);
            Debug.Log("Got to : file not found in SaveSystem.loadPlayerData()");
            Debug.LogError("Save file not found in " + path); 
            return null; 
        }

    }

}
