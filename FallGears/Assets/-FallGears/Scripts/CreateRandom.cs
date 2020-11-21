using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class CreateRandom : MonoBehaviourPun
{

    public List<GameObject> liGoSpawn = new List<GameObject>();

    
    void Start()
     {
        GameObject goToSpawn = liGoSpawn[Random.Range(0, liGoSpawn.Count)];
        
        if (PhotonNetwork.IsMasterClient)
        {
            
            PhotonNetwork.Instantiate(goToSpawn.name, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    


}
