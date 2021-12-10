using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// *** Gets informed and informs other classes
public class GardenObject : MonoBehaviour
{
    // False until the object is correctly dragged to the Port 
    private bool isMatchedToPort = false; 

    //x,y,z co-ordinates of the object's original position 
    // Has to be non static in order to be used with
    // other.GetComponent<GardenObject>().startPosition in Port.cs 
    private Vector3 startPosition;


    private void Start(){
        // Set position of the GardenObject based on where they got shuffled to: 
        setPosition(); 
    }

    private void Update() {
        // If the object is matched to the port, hide ('Destroy') the object in 1 second
        if (isMatchedToPort){
            Destroy(this.gameObject, 1f); 
        }
    }

    // Getter for bool isMatchedToPort: 
    public bool getIsMatchedToPort(){
        return isMatchedToPort; 
    }

    // Setter for bool isMatchedToPort:
    public void objectIsMatchedToPort(){
        isMatchedToPort = true; 
    }

    // Method to set the object's position:
    public void setPosition(){
        startPosition = transform.position; 
    }


    // Move object back to its original position
    // (Called if a user moves an object somewhere that isn't the Port, 
    // The GardenObject then snaps back to its OG position): 
    public void moveBackToStartPosition(){
        this.transform.position = startPosition; 
    } 
}


































