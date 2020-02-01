using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUpManager : MonoBehaviour
{
    [SerializeField]
    private InputField nameInputField;
    [SerializeField]
    private GameObject nextSceneButton;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneButton.SetActive(false);
    }

    public void OnTyping()
    {
        nextSceneButton.SetActive(nameInputField.text.Length != 0);
    }

    public void LoadNextScene(string sceneName)
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

        PlayerPrefs.SetString("name", nameInputField.text);

        PlayerPrefs.Save();

        PlayerData.Instance.name = nameInputField.text;
        MySceneManager.Instance.LoadScene(sceneName);
    }
}
