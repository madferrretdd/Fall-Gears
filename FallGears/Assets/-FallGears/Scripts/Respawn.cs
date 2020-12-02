using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase.Database;
public class Respawn : MonoBehaviour
{

    private IEnumerator coroutine;

    public ParticleSystem Bang;
    public ParticleSystem Pop;
    public GameObject vehicleModel;
    public GameObject destroyable;
    public GameObject AvatarParent;
    public AuthManager authManager;
    //public int Wins;

    public MobileControls UIStuff;

    public Text roomdetails;

    private void Start()
    {
        
        //Wins = PlayerPrefs.GetInt("Wins");
        
        vehicleModel = AvatarParent.GetComponentInParent<AvatarSetup>().myCharacter;
        UIStuff = vehicleModel.GetComponentInChildren<MobileControls>();
        UIStuff.enabled = true;
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
            
            authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();
            authManager.Completed++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Completed").SetValueAsync(authManager.Completed);
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("position").SetValueAsync(1);
            coroutine = Explode(0f);
            StartCoroutine(coroutine);
            Instantiate(Bang, transform.position, transform.rotation);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            //Photon.Pun.Demo.PunBasics.GameManager.Instance.LeaveRoom();
            SceneManager.LoadScene(3);
            //PhotonNetwork.LeaveRoom(true);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            UIStuff = destroyable.GetComponentInChildren<MobileControls>();
            //ar control = UIStuff.GetComponent<MobileControls>();
            UIStuff.ReleaseButton("accelerate");
            UIStuff.ReleaseButton("brake");
            UIStuff.ReleaseButton("left");
            UIStuff.ReleaseButton("right");
            UIStuff.enabled = false;
        }

        if (other.collider.tag == "second")
        {

            authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();
            authManager.Completed++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Completed").SetValueAsync(authManager.Completed);
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("position").SetValueAsync(2);
            coroutine = Explode(0f);
            StartCoroutine(coroutine);
            Instantiate(Bang, transform.position, transform.rotation);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            //Photon.Pun.Demo.PunBasics.GameManager.Instance.LeaveRoom();
            SceneManager.LoadScene(3);
            //PhotonNetwork.LeaveRoom(true);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            UIStuff = destroyable.GetComponentInChildren<MobileControls>();
            //ar control = UIStuff.GetComponent<MobileControls>();
            UIStuff.ReleaseButton("accelerate");
            UIStuff.ReleaseButton("brake");
            UIStuff.ReleaseButton("left");
            UIStuff.ReleaseButton("right");
            UIStuff.enabled = false;
        }

        if (other.collider.tag == "third")
        {

            authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();
            authManager.Completed++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Completed").SetValueAsync(authManager.Completed);
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("position").SetValueAsync(3);
            coroutine = Explode(0f);
            StartCoroutine(coroutine);
            Instantiate(Bang, transform.position, transform.rotation);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            //Photon.Pun.Demo.PunBasics.GameManager.Instance.LeaveRoom();
            SceneManager.LoadScene(3);
            //PhotonNetwork.LeaveRoom(true);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            UIStuff = destroyable.GetComponentInChildren<MobileControls>();
            //ar control = UIStuff.GetComponent<MobileControls>();
            UIStuff.ReleaseButton("accelerate");
            UIStuff.ReleaseButton("brake");
            UIStuff.ReleaseButton("left");
            UIStuff.ReleaseButton("right");
            UIStuff.enabled = false;
        }

        if (other.collider.tag == "fourth")
        {

            authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();
            authManager.Completed++;

            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Completed").SetValueAsync(authManager.Completed);
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("position").SetValueAsync(4);

            coroutine = Explode(0f);
            StartCoroutine(coroutine);
            Instantiate(Bang, transform.position, transform.rotation);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            //Photon.Pun.Demo.PunBasics.GameManager.Instance.LeaveRoom();
            SceneManager.LoadScene(3);
            //PhotonNetwork.LeaveRoom(true);

            destroyable.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;

            UIStuff = destroyable.GetComponentInChildren<MobileControls>();
            //ar control = UIStuff.GetComponent<MobileControls>();
            UIStuff.ReleaseButton("accelerate");
            UIStuff.ReleaseButton("brake");
            UIStuff.ReleaseButton("left");
            UIStuff.ReleaseButton("right");
            UIStuff.enabled = false;
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
