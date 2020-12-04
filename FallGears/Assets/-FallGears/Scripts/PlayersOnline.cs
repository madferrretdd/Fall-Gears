using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Database;

public class PlayersOnline : MonoBehaviour
{
    public Text PlayerOnlineText;
    // Update is called once per frame
    void Update()
    {
        PlayerOnlineText.text = "Players Online: " + PhotonNetwork.CountOfPlayers.ToString();
    }
}
