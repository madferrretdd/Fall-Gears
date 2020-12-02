using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class basicRotate : MonoBehaviour
{
    public Vector3 rotationSpeed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }


}
