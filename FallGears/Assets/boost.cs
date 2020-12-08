using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour
{
    public float Strength = 1000;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            collision.rigidbody.AddForce(transform.forward * Strength, ForceMode.Impulse);
        }
    }
}
