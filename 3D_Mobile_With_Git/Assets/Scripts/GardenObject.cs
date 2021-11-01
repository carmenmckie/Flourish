using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Gets informed and informs other classes
public class GardenObject : MonoBehaviour
{
   
    private bool isMatchedToPort = false; 

    //x,y,z co-ordinates of the object's original position 
    // ! Has to be non static in order to be used with
    // other.GetComponent<GardenObject>().startPosition in Port.cs 
    public Vector3 startPosition;


    public void Start(){
        // Instantiate the object's original position 
        setPosition(); 
    }

    private void Update() {
        // If the object is matched to the port, hide the object 
        if (isMatchedToPort){
            // this.GetComponent<GameObject>().SetActive(false); 
            Destroy(this.gameObject, 1f); 
        }
    }


    // Getter for bool isMatchedToPort 
    public bool getIsMatchedToPort(){
        return isMatchedToPort; 
    }

    // Setter for bool isMatchedToPort
    public void objectIsMatchedToPort(){
        isMatchedToPort = true; 
    }

    // Method to set the object's position
    public void setPosition(){
        startPosition = transform.position; 
    }


    // Move object back to its original position
        public void moveBackToStartPosition(){
        this.transform.position = startPosition; 
    } 
}


































