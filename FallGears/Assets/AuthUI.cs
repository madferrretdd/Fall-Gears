using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthUI : MonoBehaviour
{

    public static AuthUI instance;

    public GameObject loginUI;
    public GameObject registerUI;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("instance already exists, destroying object!");
            Destroy(this);
        }
    }



    public void LoginScreen()
    {
        loginUI.SetActive(true);
        registerUI.SetActive(false);
    }

    public void RegisterScreen()
    {
        loginUI.SetActive(false);
        registerUI.SetActive(true);
    }

}
