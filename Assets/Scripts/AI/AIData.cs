using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIData
{
    private static AIData _instance = null;

    public static AIData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AIData();
                _instance.Start();
            }

            return _instance;
        }
    }

    // List of other AIs
    public List<BaseAI> l_AllAI = new List<BaseAI>();

    private void Start()
    {
        StoreOtherAIInList();
    }

    public void StoreOtherAIInList()
    {
        foreach (BaseAI go in GameObject.FindObjectsOfType<BaseAI>())
        {
            l_AllAI.Add(go);
        }
    }

    public GameObject GetNearestTarget(GameObject _obj)
    {
        GameObject nearestTarget = null;

        float currShortestDistance = float.MaxValue;

        foreach (BaseAI go in l_AllAI)
        {
            if (go.gameObject == _obj || !go.isAlive)
                continue;

            float currDist = Vector2.Distance(_obj.transform.position, go.transform.position);

            if (currDist < currShortestDistance)
            {
                currShortestDistance = currDist;
                nearestTarget = go.gameObject;
            }
        }

        return nearestTarget;
    }

    public Vector2 GetAveragePositionOfAllOtherPlayers(GameObject _obj)
    {
        int numberOfEnemies = 0;
        Vector2 avgPos = new Vector2();

        foreach (BaseAI go in l_AllAI)
        {
            if (go == _obj)
                continue;

            avgPos += new Vector2(go.transform.position.x, go.transform.position.y);
            ++numberOfEnemies;
        }

        if (numberOfEnemies == 0)
            return avgPos;

        return avgPos /= numberOfEnemies;
    }

    public float GetMovementSpeed(GameObject _go)
    {
        float movementSpeed = 1.0f;

        int numLegs = 0;

        foreach (LegPart go in _go.GetComponents<LegPart>())
        {
            movementSpeed += go.moveSpd;
            ++numLegs;
        }

        BaseTorso torso = _go.GetComponent<BaseTorso>();

        if (torso && numLegs >= 2)
            return movementSpeed / numLegs * torso.movespdMult;
        else
            return 1;
    }
}
