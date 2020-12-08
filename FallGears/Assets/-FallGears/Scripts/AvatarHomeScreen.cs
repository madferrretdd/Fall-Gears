using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarHomeScreen : MonoBehaviourPun
{
    // private PhotonView PV;
    public int characterValue;
    public int colorValue;
    public int textureValue;

    public GameObject myCharacter;

    public PlayerInfo PI;
    public Material VehicleMat;

    public Color[] VehicleColor;

    public GameObject[] CharacterSelect;

    public Texture[] TextureSelect;

    public ParticleSystem Spray;

    // Start is called before the first frame update
    private void Start()
    {
        CharacterSelect[characterValue].SetActive(true);
        //ChangeColor(int whichColor);
        ChangeVehicle();
        ChangeTexture();
        ChangeColor();

    }

    public void ChangeVehicle()
    {
        characterValue = PI.mySelectedCharacter;


        foreach (var obj in CharacterSelect)
        {
            obj.SetActive(false);
        }

        ChangeVehicle2();


    }

    public void ChangeVehicle2()
    {
        CharacterSelect[characterValue].SetActive(true);
    }

    public void ChangeColor()
    {

        colorValue = PI.mySelectedColor;
        Material spraymat = Spray.GetComponent<Renderer>().material;
        spraymat.SetColor("Color_F689E8B9", VehicleColor[PI.mySelectedColor]);
        spraymat.SetColor("Color_28180829", VehicleColor[PI.mySelectedColor + 1]);
        Spray.Play();
        //    if (this.photonView.IsMine)
        //{

        MeshRenderer[] myRenderers = transform.GetComponentsInChildren<MeshRenderer>(true);

        foreach (MeshRenderer item in myRenderers)
        {
            //Debug.Log("Found Renderer: " + item.name);

            foreach (Material mat in item.materials)
            {

                //Debug.Log("Found Material: " + mat.name );

                if (mat.name == "VehicleMaterial (Instance)")
                {

                    // Debug.Log("Found Material and Replaced: " + mat.name );
                    
                    mat.SetColor("Color_F689E8B9", VehicleColor[PI.mySelectedColor]);
                    mat.SetColor("Color_28180829", VehicleColor[PI.mySelectedColor + 1]);

                }
            }

        }



        //}

    }

    public void ChangeTexture()
    {
        textureValue = PI.mySelectedTexture;

        MeshRenderer[] myRenderers = transform.GetComponentsInChildren<MeshRenderer>(true);

        foreach (MeshRenderer item in myRenderers)
        {
            //Debug.Log("Found Renderer: " + item.name);

            foreach (Material mat in item.materials)
            {

                //Debug.Log("Found Material: " + mat.name );

                if (mat.name == "VehicleMaterial (Instance)")
                {

                    // Debug.Log("Found Material and Replaced: " + mat.name );
                    mat.SetTexture("Texture2D_66F4ED44", TextureSelect[PI.mySelectedTexture]);


                }
            }

        }
    }
}
