using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneManager : MonoBehaviour
{
    public Character AIPrefab;

    public GameObject player;

    public List<Transform> l_SpawnPoint;

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
                PlayerData.Instance.EarnCurrency(100);
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                PlayerData.Instance.EarnCurrency(10);
                SceneManager.LoadScene("LoseScene");
            }
        }
    }

    void SpawnAI()
    {
        for (int i = 0; i < 3; ++i)
        {
            Character charac = Instantiate(AIPrefab);
            charac.InitRandom();
            Transform spawnPosition = l_SpawnPoint[Random.Range(0, l_SpawnPoint.Count)];
            charac.transform.root.position = spawnPosition.position;
            l_SpawnPoint.Remove(spawnPosition);
        }

        Character playerAI = Instantiate(AIPrefab);
        string[] equippedLimbs = { PlayerData.instance.equipmentSlot[2], PlayerData.instance.equipmentSlot[3], PlayerData.instance.equipmentSlot[4], PlayerData.instance.equipmentSlot[5] };
        playerAI.Init(PlayerData.instance.equipmentSlot[0], PlayerData.instance.equipmentSlot[1], equippedLimbs);
        player = playerAI.gameObject;

        player.transform.root.position = l_SpawnPoint[0].position;
    }
}
