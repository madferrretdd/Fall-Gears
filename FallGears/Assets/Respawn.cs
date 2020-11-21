using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{

    private IEnumerator coroutine;

    public ParticleSystem Bang;
    public ParticleSystem Pop;
    public GameObject vehicleModel;
    public GameObject destroyable;
    public GameObject AvatarParent;

    public int Wins;

    public MobileControls UIStuff;

    public Text roomdetails;

    private void Start()
    {

        Wins = PlayerPrefs.GetInt("Wins");
        
        vehicleModel = AvatarParent.GetComponentInParent<AvatarSetup>().myCharacter;
        UIStuff = vehicleModel.GetComponentInChildren<MobileControls>();

    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Delete")
        {
            coroutine = Explode(0f);
            StartCoroutine(coroutine);
            Instantiate(Bang, transform.position, transform.rotation);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            UIStuff = destroyable.GetComponentInChildren<MobileControls>();
            //ar control = UIStuff.GetComponent<MobileControls>();
            UIStuff.ReleaseButton("accelerate");
            UIStuff.ReleaseButton("brake");
            UIStuff.ReleaseButton("left");
            UIStuff.ReleaseButton("right");
            

        }

        if (other.collider.tag == "Win")
        {
            Wins++;
            PlayerPrefs.SetInt("Wins", Wins);

            coroutine = Explode(0f);
            StartCoroutine(coroutine);
            Instantiate(Bang, transform.position, transform.rotation);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            //Photon.Pun.Demo.PunBasics.GameManager.Instance.LeaveRoom();
            SceneManager.LoadScene(2);
            //PhotonNetwork.LeaveRoom(true);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            UIStuff = destroyable.GetComponentInChildren<MobileControls>();
            //ar control = UIStuff.GetComponent<MobileControls>();
            UIStuff.ReleaseButton("accelerate");
            UIStuff.ReleaseButton("brake");
            UIStuff.ReleaseButton("left");
            UIStuff.ReleaseButton("right");
        }

    }

    private void Update()
    {
        //Debug.Log("Player List: " + PhotonNetwork.PlayerList + " --- " + "Current Room:" + PhotonNetwork.CurrentRoom + " ---- " + "Number of Rooms: " + PhotonNetwork.CountOfRooms);
        roomdetails.text = PhotonNetwork.CurrentRoom.ToString();
    }

    private IEnumerator Explode(float waitTime)
    {
        
        yield return new WaitForSeconds(3.0f);

        transform.position = new Vector3(-12, 20, -28);
        destroyable.SetActive(true);
        Instantiate(Pop, transform.position, transform.rotation);
        GetComponent<SphereCollider>().enabled = true;

    }
   
}
