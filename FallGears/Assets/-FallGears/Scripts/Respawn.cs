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

    public float Strength = 500f;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("-WinScene"))
        {
            destroyable.SetActive(true);
            GetComponent<SphereCollider>().enabled = true;

            UIStuff = destroyable.GetComponentInChildren<MobileControls>();
            UIStuff.vehicle.acceleration = 0;
            UIStuff.ReleaseButton("accelerate");
            UIStuff.ReleaseButton("brake");
            UIStuff.ReleaseButton("left");
            UIStuff.ReleaseButton("right");
            UIStuff.enabled = enabled;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("-Race"))
        {
            vehicleModel = AvatarParent.GetComponentInParent<AvatarSetup>().myCharacter;
            UIStuff = vehicleModel.GetComponentInChildren<MobileControls>();
            UIStuff.enabled = true;
        }
        
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

        if (other.collider.tag == "Player")
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.rigidbody.AddForce(direction * Strength, ForceMode.Impulse);
        }

        if (other.collider.tag == "Win")
        {
            PlayerPrefs.SetInt("PlayerPos", 0);
            authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();

            //Player Won The Race add 1 to wins
            authManager.Wins++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Wins").SetValueAsync(authManager.Wins);

            //Player Gets 10 Coins for Winning the race
            authManager.GearTokens = authManager.GearTokens +10;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("GearTokens").SetValueAsync(authManager.GearTokens);

            //Player Also Completed the Race add 1 to completed
            authManager.Completed++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Completed").SetValueAsync(authManager.Completed);

            //plus 1 gear token for completing the race
            authManager.GearTokens++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("GearTokens").SetValueAsync(authManager.GearTokens);

            //Player Gets 10 Coins for Winning the race
            authManager.Experience = authManager.Experience + 10;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Experience").SetValueAsync(authManager.Experience);

            //Explode on contact with finishline
            Instantiate(Bang, transform.position, transform.rotation);

            //Load Winners scene (position should be fed to GameManager for instantiatingon podeum
            SceneManager.LoadScene(3);
            
        }

        if (other.collider.tag == "second")
        {
            PlayerPrefs.SetInt("PlayerPos", 1);
            authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();

            //Player Gets 10 Coins for Winning the race
            authManager.GearTokens = authManager.GearTokens + 5;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("GearTokens").SetValueAsync(authManager.GearTokens);

            //Player Also Completed the Race add 1 to completed
            authManager.Completed++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Completed").SetValueAsync(authManager.Completed);

            //plus 1 gear token for completing the race
            authManager.GearTokens++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("GearTokens").SetValueAsync(authManager.GearTokens);

            //Player Gets 10 Coins for Winning the race
            authManager.Experience = authManager.Experience + 5;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Experience").SetValueAsync(authManager.Experience);

            //Explode on contact with finishline
            Instantiate(Bang, transform.position, transform.rotation);

            //Load Winners scene (position should be fed to GameManager for instantiatingon podeum
            SceneManager.LoadScene(3);
        }

        if (other.collider.tag == "third")
        {
            PlayerPrefs.SetInt("PlayerPos", 2);
            authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();

            //Player Gets 10 Coins for Winning the race
            authManager.GearTokens = authManager.GearTokens + 2;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("GearTokens").SetValueAsync(authManager.GearTokens);

            //Player Also Completed the Race add 1 to completed
            authManager.Completed++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Completed").SetValueAsync(authManager.Completed);

            //plus 1 gear token for completing the race
            authManager.GearTokens++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("GearTokens").SetValueAsync(authManager.GearTokens);

            //Player Gets 10 Coins for Winning the race
            authManager.Experience = authManager.Experience + 2;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Experience").SetValueAsync(authManager.Experience);

            //Explode on contact with finishline
            Instantiate(Bang, transform.position, transform.rotation);

            //Load Winners scene (position should be fed to GameManager for instantiatingon podeum
            SceneManager.LoadScene(3);
        }

        if (other.collider.tag == "fourth")
        {
            PlayerPrefs.SetInt("PlayerPos", 3);
            authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();

            //Player Also Completed the Race add 1 to completed
            authManager.Completed++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Completed").SetValueAsync(authManager.Completed);

            //plus 1 gear token for completing the race
            authManager.GearTokens++;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("GearTokens").SetValueAsync(authManager.GearTokens);

            //Player Gets 10 Coins for Winning the race
            authManager.Experience = authManager.Experience + 1;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("Experience").SetValueAsync(authManager.Experience);

            //Explode on contact with finishline
            Instantiate(Bang, transform.position, transform.rotation);

            //Load Winners scene (position should be fed to GameManager for instantiatingon podeum
            SceneManager.LoadScene(3);
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
        Instantiate(Pop, transform.position, Quaternion.identity);
        GetComponent<SphereCollider>().enabled = true;

    }
   
}
