using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float Strength = -500;
    public Material mat;
    public Color normColor;
    public Color FlashColor;

    private void Start()
    {
        normColor = mat.GetColor("Color_F689E8B9");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 direction = (transform.position - collision.transform.position).normalized;
            collision.rigidbody.AddForce(direction * Strength, ForceMode.Impulse);
            

            mat.SetColor("Color_F689E8B9", FlashColor);
            mat.SetColor("Color_28180829", FlashColor);
            normal();
        }
    }

    private void normal()
    {

        mat.SetColor("Color_F689E8B9", normColor);
        mat.SetColor("Color_28180829", normColor);
    }
}
