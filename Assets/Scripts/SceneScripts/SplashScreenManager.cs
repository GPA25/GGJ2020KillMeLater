using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
    [SerializeField]
    private MySceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        string s = PlayerPrefs.GetString("name", "");
        if(s == "")
        {
            sceneManager.LoadScene("SignUpScene");
        }
        else
        {
            sceneManager.LoadScene("MainMenuScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
