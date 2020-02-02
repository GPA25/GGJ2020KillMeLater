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

    public void SaveNewPlayer()
    {
        PlayerData.Instance.equippedHead = "Base Head";
        PlayerData.Instance.equippedTorso = "Base Torso";
        PlayerData.Instance.equippedLeftArm = "Base Arm";
        PlayerData.Instance.equippedRightArm = "Base Arm";
        PlayerData.Instance.equippedLeftLeg = "Base Arm";
        PlayerData.Instance.equippedRightLeg = "Base Arm";

        PlayerPrefs.SetString("equippedHead", "Base Head");
        PlayerPrefs.SetString("equippedTorso", "Base Torso");
        PlayerPrefs.SetString("equippedLeftArm", "Base Arm");
        PlayerPrefs.SetString("equippedRightArm", "Base Arm");
        PlayerPrefs.SetString("equippedLeftLeg", "Base Leg");
        PlayerPrefs.SetString("equippedRightLeg", "Base Leg");

        PlayerPrefs.SetString("name", nameInputField.text);

        PlayerPrefs.Save();

        PlayerData.Instance.name = nameInputField.text;
    }
}
