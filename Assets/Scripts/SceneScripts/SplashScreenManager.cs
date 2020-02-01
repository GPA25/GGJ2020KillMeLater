using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string s = PlayerPrefs.GetString("name", "");
        if(s == "")
        {
            MySceneManager.Instance.LoadScene("SignUpScene");
        }
        else
        {
            MySceneManager.Instance.LoadScene("MainMenuScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
