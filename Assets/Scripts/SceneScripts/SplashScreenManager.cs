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
            PlayerData.Instance.equippedHead = "TestHead";
            PlayerData.Instance.equippedTorso = "TestTorso";
            PlayerData.Instance.equippedLeftArm = "TestArm";
            PlayerData.Instance.equippedRightArm = "TestArm";
            PlayerData.Instance.equippedLeftLeg = "TestLeg";
            PlayerData.Instance.equippedRightLeg = "TestLeg";

            PlayerPrefs.SetString("equippedHead", "TestHead");
            PlayerPrefs.SetString("equippedTorso", "TestTorso");
            PlayerPrefs.SetString("equippedLeftArm", "TestArm");
            PlayerPrefs.SetString("equippedRightArm", "TestArm");
            PlayerPrefs.SetString("equippedLeftLeg", "TestLeg");
            PlayerPrefs.SetString("equippedRightLeg", "TestLeg");

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
