
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CreateRandomAgain : MonoBehaviour
{

    public List<GameObject> liGoSpawn = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        
            GameObject goToSpawn = liGoSpawn[Random.Range(0, liGoSpawn.Count)];
            PhotonNetwork.Instantiate(goToSpawn.name, transform.position, Quaternion.identity);
            Destroy(gameObject);
       
    }


}
