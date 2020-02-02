using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneManager : MonoBehaviour
{
    public Character AIPrefab;

    public GameObject player;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;

    // Start is called before the first frame update
    void Start()
    {
        AIData.Instance.Init();
        SpawnAI();
    }

    // Update is called once per frame
    void Update()
    {
        if (AIData.Instance.IsGameEnded())
        {
            if (player != null && player.GetComponent<BaseAI>().isAlive)
            {
                PlayerData.instance.currency += 100;
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                SceneManager.LoadScene("LoseScene");
                PlayerData.instance.currency += 10;
            }
        }
    }

    void SpawnAI()
    {
        Character playerAI = Instantiate(AIPrefab);
        string[] equippedLimbs = { PlayerData.instance.equipmentSlot[2], PlayerData.instance.equipmentSlot[3], PlayerData.instance.equipmentSlot[4], PlayerData.instance.equipmentSlot[5] };
        playerAI.Init(PlayerData.instance.equipmentSlot[0], PlayerData.instance.equipmentSlot[1], equippedLimbs);
        player = playerAI.gameObject;

        player.transform.root.position = spawnPoint4.position;

        for (int i = 0; i < 3; ++i)
        {
            Character charac = Instantiate(AIPrefab);
            charac.InitRandom();

            switch (i)
            {
                case 0:
                    charac.transform.root.position = spawnPoint1.position;
                    break;
                case 1:
                    charac.transform.root.position = spawnPoint2.position;
                    break;
                case 2:
                    charac.transform.root.position = spawnPoint3.position;
                    break;
            }

        }

    }
}
