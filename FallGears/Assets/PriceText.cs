using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PriceText : MonoBehaviour
{
    public VehicleLocked Button;

    // Start is called before the first frame update
    void Start()
    {
        string text = transform.GetComponent<TMP_Text>().text;
        int price = Button.GetComponent<VehicleLocked>().price;


        text = "<sprite name='smiley'>" + price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
