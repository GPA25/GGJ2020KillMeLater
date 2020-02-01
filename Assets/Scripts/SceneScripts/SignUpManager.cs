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

    public void SaveNameToPlayerData()
    {

    }
}
