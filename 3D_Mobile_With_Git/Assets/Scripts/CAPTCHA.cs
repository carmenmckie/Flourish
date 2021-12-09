using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

// Look up when it should extend MonoBehavior and when it shouldn't 
[Serializable]

// Class to make a CAPTCHA object: 
public class CAPTCHA
{
    
    // The Image containing the CAPTCHA: 
    private Sprite Image; 
    // The correct value of the CAPTCHA: 
    private string Value; 

    
    public Sprite getImage(){
        return this.Image; 
    }

    public String getValue(){
        return this.Value; 
    }


}
