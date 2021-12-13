using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

// Serializable class: 
[Serializable]

// Class to make a CAPTCHA object: 
public class CAPTCHA
{
    
    // The Image containing the CAPTCHA: 
    public Sprite Image; 
    // The correct value of the CAPTCHA: 
    public string Value; 

    
    public Sprite getImage(){
        return this.Image; 
    }

    public String getValue(){
        return this.Value; 
    }


}