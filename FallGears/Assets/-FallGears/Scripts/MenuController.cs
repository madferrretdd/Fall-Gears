﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Auth;

public class MenuController : MonoBehaviour
{
    public AvatarHomeScreen AvatarHomeScreen;
    public TMP_Text Username;

    private void Start()
    {
        Username.text = FirebaseAuth.DefaultInstance.CurrentUser.DisplayName.ToString();
    }
    public void OnClickCharacterPick(int whichCharacter)
    {
        if(PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("MyCharacter", whichCharacter);
        }
        
        AvatarHomeScreen.ChangeVehicle();
        
    }



    public void OnClickColorPick(int whichColor)
    {
        if (PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedColor = whichColor;
            PlayerPrefs.SetInt("MyColor", whichColor);
        }

        AvatarHomeScreen.ChangeColor();
    }


    public void OnClickTexturePick(int whichTexture)
    {
        if (PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedTexture = whichTexture;
            PlayerPrefs.SetInt("MyTexture", whichTexture);
        }

        AvatarHomeScreen.ChangeTexture();
    }

}
