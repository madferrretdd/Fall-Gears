using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModelRotate : MonoBehaviour
{
    public Vector3 rotationSpeed;
    public GameObject vehicle;
    public Button btn;

    public bool Go;
    // Start is called before the first frame update
    void Start()
    {
       btn = GetComponent<Button>();
        Go = false;
    }

    public void SetGo()
    {
        if (Go == true)
        {
            Go = false;
        }
        else if (Go == false)
        {
            Go = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Go)
        {
            vehicle.transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
        }
            
        
    }
        
    
}
