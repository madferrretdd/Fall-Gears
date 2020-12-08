using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mysterbox : MonoBehaviour
{
    public ParticleSystem pop;

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            pop.Play(true);
        }
    }
}
