using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public Character characterPrefab;

    public GameObject characterPlacement1;
    public GameObject characterPlacement2;
    // Start is called before the first frame update
    void Start()
    {
        Character charac = Instantiate(characterPrefab);
        charac.InitRandom();
        charac.transform.parent = characterPlacement1.transform;
        charac.transform.localScale = new Vector3(1, 1, 1);
        charac.transform.localPosition = new Vector3(0, 0, 0);

        charac = Instantiate(characterPrefab);
        charac.InitRandom();
        charac.transform.parent = characterPlacement2.transform;
        charac.transform.localScale = new Vector3(1, 1, 1);
        charac.transform.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
