using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class RandomColour : MonoBehaviour
{
    public Material Main;
    public Material Secondary;
    public Material Obstacles;

    public ColorPallete[] Pallettes;
    public int WhichPallette;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {

        
        WhichPallette = Random.Range(0, Pallettes.Length);

        Main.SetColor("Color_F689E8B9", Pallettes[WhichPallette].Main);
        Main.SetColor("Color_28180829", Pallettes[WhichPallette].MainDark);
        Main.SetColor("Color_57D43A16", Pallettes[WhichPallette].MainHighlight);
        Secondary.SetColor("Color_F689E8B9", Pallettes[WhichPallette].Secondary);
        Secondary.SetColor("Color_28180829", Pallettes[WhichPallette].SecondaryDark);
        Secondary.SetColor("Color_57D43A16", Pallettes[WhichPallette].SecondaryHighlight);
        Obstacles.SetColor("Color_F689E8B9", Pallettes[WhichPallette].Obstacles);
        Obstacles.SetColor("Color_28180829", Pallettes[WhichPallette].ObstaclesDark);
        Obstacles.SetColor("Color_57D43A16", Pallettes[WhichPallette].ObstaclesHighlight);
        }

    }

}
