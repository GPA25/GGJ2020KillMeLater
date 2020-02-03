using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyDisplay : MonoBehaviour
{
    [SerializeField]
    private Text currencyText;

    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = PlayerData.Instance.currency.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
