using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotate : MonoBehaviour {

    public float speed = 100f;          //default speed is 100
    
    
    void Update ()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);           //auto rotate the coins and fuel tanks
    }
}