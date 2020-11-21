using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class LobbyCounter : MonoBehaviour
{

    public Text WaitingFor;
    public bool ready = false;
    public int LevelPick;
    public int maxplayers = 2;
    private IEnumerator coroutine;

    void Start()
    {
       // LevelPick = Random.Range(2, 4);    
    }

    // Update is called once per frame
    void Update()
    {

            GameObject[] Players;
            Players = GameObject.FindGameObjectsWithTag("Playya");

            if (Players.Length == 0)
            {
                WaitingFor.text = "None";
            }
            else
            {
                WaitingFor.text = "Waiting for Players... " + (Players.Length ) + "/" + maxplayers;
            }

            if ((Players.Length ) == maxplayers)
            {
                ready = true;
                Ready();
            }
            else
            {
                ready = false;
            }

    }

    void Ready()
    {
        

        if (ready == true)
        {
            coroutine = WaitAndPrint(2.0f);
            StartCoroutine(coroutine);
        }
            
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(1);
        WaitingFor.text = "Players Ready... " + " Game Starts in 5";
        yield return new WaitForSeconds(1);
        WaitingFor.text = "Players Ready... " + " Game Starts in 4";
        yield return new WaitForSeconds(1);
        WaitingFor.text = "Players Ready... " + " Game Starts in 3";
        yield return new WaitForSeconds(1);
        WaitingFor.text = "Players Ready... " + " Game Starts in 2";
        yield return new WaitForSeconds(1);
        WaitingFor.text = "Players Ready... " + " Game Starts in 1";
        yield return new WaitForSeconds(1);
        Go();
    }

    void Go()
    {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;

            PhotonNetwork.LoadLevel(1);
    }

}
