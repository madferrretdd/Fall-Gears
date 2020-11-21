
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{

    public static PlayerInfo PI;

    public int mySelectedCharacter;
    public int mySelectedColor;
    public int mySelectedTexture;
    public Text Wins;

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
        Wins.text = "TOTAL WINS: " + PlayerPrefs.GetInt("Wins").ToString();

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

    }

}
