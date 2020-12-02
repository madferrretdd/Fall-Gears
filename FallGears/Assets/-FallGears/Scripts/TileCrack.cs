using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileCrack : MonoBehaviour
{
    float originalY;
    float originalX;
    float originalZ;
    public float floatStrength = 0.05f;
    public Rigidbody rb;

        private void Start()
    {
        this.originalY = this.transform.position.y; 
        this.originalX = this.transform.position.x;
        this.originalZ = this.transform.position.z;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Delete")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine("Fall");
        }
    }

    IEnumerator Fall()
    {
        //transform.position = new Vector3(originalX + ((float)Math.Sin(Time.time) * floatStrength), transform.position.y, originalZ + ((float)Math.Sin(Time.time) * floatStrength));
        yield return new WaitForSeconds(1);
        rb.isKinematic = false;
        rb.useGravity = true;
        yield return new WaitForSeconds(1f); 
    }

}
