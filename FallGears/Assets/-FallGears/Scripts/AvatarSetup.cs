using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviourPun
{
   // private PhotonView PV;
    public int characterValue; 
    public int colorValue;
    public int textureValue;

    public GameObject myCharacter;

    public Material VehicleMat;

    public Color[] VehicleColor;

    public GameObject[] CharacterSelect;
    public Texture[] TextureSelect;

    // Start is called before the first frame update
    void Start()
    {
        // PV = GetComponent<PhotonView>();

        if (this.photonView.IsMine)
        {
            this.photonView.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedCharacter);

            this.photonView.RPC("RPC_AddColor", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedColor);

            this.photonView.RPC("RPC_ChangeTexture", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedTexture);
            //nametag - this.photonView.RPC("RPC_Nametag", RpcTarget.AllBuffered, PhotonNetwork.NickName);
        }
    }

    [PunRPC]
    void RPC_AddCharacter(int whichCharacter)
    {
        Debug.Log("Called: RPC_AddCharacter: " + whichCharacter);
        characterValue = whichCharacter;

        CharacterSelect[whichCharacter].SetActive(true);

        
    }

    [PunRPC]
    void RPC_AddColor(int whichColor)
    {
        
            colorValue = whichColor;

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

                        mat.SetColor("Color_F689E8B9", VehicleColor[whichColor]);
                        mat.SetColor("Color_28180829", VehicleColor[whichColor +1]);

                    }
                }

            }


        
        //}

    }

    [PunRPC]
    void RPC_ChangeTexture(int whichTexture)
    {
        textureValue = whichTexture;

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
                    mat.SetTexture("Texture2D_66F4ED44", TextureSelect[whichTexture]);


                }
            }

        }
    }

}
