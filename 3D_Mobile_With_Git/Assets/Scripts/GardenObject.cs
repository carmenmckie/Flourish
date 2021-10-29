using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Gets informed and informs other classes
public class GardenObject : MonoBehaviour
{
    // public GameObjectsManager gameObjectsManagerRef;

    // Gets set to true if the object gets correctly matched
    // To the port 
    // ***** Not used at the moment 
    private bool isMatchedToPort = false; 

    //x,y,z co-ordinates of the object's original position 
    // ! Has to be non static in order to be used with
    // other.GetComponent<GardenObject>().startPosition in Port.cs 
    public Vector3 startPosition;


    public void Start(){
        // Instantiate the object's original position 
        startPosition = transform.position;
    }


    // Getter for bool isMatchedToPort 
    public bool getIsMatchedToPort(){
        return isMatchedToPort; 
    }


    // Move object back to its original position
    // *********** Needs updated to make the object float back 
    // Rather than instantly teleport back (a bit abrupt) 
    public void moveBackToStartPosition(){
        this.transform.position = startPosition; 
    } 
}


































