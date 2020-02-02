using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneUpdates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AIData.Instance.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (AIData.Instance.IsGameEnded())
        {
            PlayerData.Instance.currency += 100;

        }
    }
}
