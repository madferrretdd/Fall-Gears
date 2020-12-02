using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformCheck : MonoBehaviour
{

    public Sprite MobileIcon;
    public Sprite DesktopIcon;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            gameObject.GetComponent<Image>().sprite = MobileIcon;
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            gameObject.GetComponent<Image>().sprite = DesktopIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
