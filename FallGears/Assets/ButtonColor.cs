using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    // Start is called before the first frame update
    public int ButtonNumber;
    public Image But;
    public AvatarHomeScreen myColor;
    void Start()
    {
        But = GetComponent<Image>();
        But.color = myColor.VehicleColor[ButtonNumber];
    }

}
