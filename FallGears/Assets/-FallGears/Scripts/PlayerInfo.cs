
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public int PlayerPosition;
    public static PlayerInfo PI;

    public int mySelectedCharacter;
    public int mySelectedColor;
    public int mySelectedTexture;

    public Text WinsText;
    public Text CompletedText;
    public Text TokensText;
    public Text XPText;
    public Text Level;
    //public Text Ranking;

    public int NextLevel = 100;
    public int MyLevel = 1;

    public AuthManager authManager;

    private void OnEnable()
    {
        if (PlayerInfo.PI == null)
        {
            PlayerInfo.PI = this;
        }
        else
        {
            if(PlayerInfo.PI != this)
            {
                Destroy(PlayerInfo.PI.gameObject);
                PlayerInfo.PI = this;
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
      
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            mySelectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);
        }

        if (PlayerPrefs.HasKey("MyColor"))
        {
            mySelectedColor = PlayerPrefs.GetInt("MyColor");
        }
        else
        {
            mySelectedColor = 0;
            PlayerPrefs.SetInt("MyColor", mySelectedColor);
        }

        if (PlayerPrefs.HasKey("MyTexture"))
        {
            mySelectedTexture = PlayerPrefs.GetInt("MyTexture");
        }
        else
        {
            mySelectedTexture = 0;
            PlayerPrefs.SetInt("MyTexture", mySelectedTexture);
        }

        
            InvokeRepeating("UpdateUI", 0, 1);
        
    }

    public void UpdateUI()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("-MainMenu"))
        {
            authManager = GameObject.FindWithTag("AuthTag").GetComponent<AuthManager>();
            WinsText.text = "Total Wins: " + authManager.Wins.ToString();
            CompletedText.text = "Races Completed: " + authManager.Completed.ToString();
            TokensText.text = "Gear Tokens: " + authManager.GearTokens.ToString();
            XPText.text = "XP: " + authManager.Experience.ToString() + "/" + NextLevel.ToString();
            Level.text = "Level: " + MyLevel;

            if (authManager.Experience >= NextLevel)
            {
                NextLevel = NextLevel * 2;
                MyLevel++;
            }
        }
    }


}
