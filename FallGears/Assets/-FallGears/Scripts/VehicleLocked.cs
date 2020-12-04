using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine.UI;
using TMPro;

public class VehicleLocked : MonoBehaviour
{

    public AuthManager authManager;
    public PlayerInfo playerInfo;

    public bool isLocked;
    public GameObject LockedButton;
    public GameObject UnlockedButton;

    public int price;
    public int Tokens;

    public TMP_Text PriceText;

    private void Start()
    {

        
        
        InvokeRepeating("check", 0, 1);
    }

    public void check()
        {
        authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();
        playerInfo = GameObject.FindWithTag("PlayerInfTag").GetComponent<PlayerInfo>();
        allUpdate();
        getUnlocked();
        }


    public void BuyItem()
    {
        Tokens = int.Parse(authManager.GearTokens.ToString());
        if (Tokens >= price)
        {
            LockedButton.GetComponent<Button>().interactable = true;
            int newTokens = Tokens - price;
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child("GearTokens").SetValueAsync(newTokens);
            isLocked = false;
            allUpdate();
            authManager.reference.Child("Users").Child(authManager.User.UserId).Child(UnlockedButton.name).SetValueAsync(true);
        }
        else if (Tokens < price)
        {
            LockedButton.GetComponent<Button>().interactable = false;
        }
    }

    public void getUnlocked()
    {
        //Gets Vehicles
        

        authManager.reference.Child("Users").Child(authManager.User.UserId).Child(UnlockedButton.name).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Vehicle fault");
            }
            else if (task.IsCompleted)
            {

                DataSnapshot snapshot = task.Result;
                //Debug.Log(snapshot.ToString());
                if (snapshot.Value.ToString() == "True")
                {
                    isLocked = false;
                    allUpdate();
                }

            }
        });
    }

    public void allUpdate()
    {        
        

        playerInfo.UpdateUI();
        authManager.getFromDB();
        //unlockcheck();
    }

    public void Update()
    {


        if (isLocked == true)
        {
            LockedButton.SetActive(true);
            UnlockedButton.SetActive(false);
            string cog = "cog-icon";
             PriceText.text = "<sprite name=" + cog + ">" + price;
        }
        else if (isLocked == false)
        {
            LockedButton.SetActive(false);
            UnlockedButton.SetActive(true);
        }
    }
}
