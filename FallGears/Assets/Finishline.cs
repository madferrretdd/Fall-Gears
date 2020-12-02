using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishline : MonoBehaviour
{
    public GameObject Next;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            this.gameObject.SetActive(false);
            Next.gameObject.SetActive(true);
        }
    }

}
