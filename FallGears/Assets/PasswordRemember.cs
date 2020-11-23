using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordRemember : MonoBehaviour
{
    const string playerNamePrefKey = "Password";
    public int BoxTickedInt;

    public Toggle toggleBox;
    public AuthManager AuthMan;
    // Start is called before the first frame update
    void Start()
    {
        string defaultName = string.Empty;
        InputField _inputField = this.GetComponent<InputField>();

        BoxTickedInt = PlayerPrefs.GetInt("BoxTicked");

            if (PlayerPrefs.GetInt("BoxTicked") == 1 && PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    toggleBox.isOn = true;
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                    PlayerPrefs.SetInt("BoxTicked", 1);
            }
            else if (PlayerPrefs.GetInt("BoxTicked") == 0)
            {
                toggleBox.isOn = false;
            }
    }


    public void Ticked()
    {
        if (PlayerPrefs.GetInt("BoxTicked") == 1)
        {
            PlayerPrefs.SetInt("BoxTicked", 0);
        }
        else if (PlayerPrefs.GetInt("BoxTicked") == 0)
        {
            PlayerPrefs.SetInt("BoxTicked", 1);
        }
    }

    public void SetPassword(string value)
    {
        // #Important
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Password is null or empty");
            return;
        }

            PlayerPrefs.SetString(playerNamePrefKey, value);
            PlayerPrefs.SetInt("BoxTicked", BoxTickedInt);

    }
}
