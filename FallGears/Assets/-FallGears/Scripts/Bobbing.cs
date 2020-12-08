using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bobbing : MonoBehaviour
{
    float originalY;

    public float floatStrength = 1; // You can change this in the Unity Editor to 
    public float frequency = 1;      // change the range of y positions that are possible.

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            originalY + (((float)Math.Sin(Time.time)*frequency) * floatStrength),
            transform.position.z);
    }
}
