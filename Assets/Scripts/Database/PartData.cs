﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PartsListData
{
    public PartData[] data;
}


[System.Serializable]
public class PartData
{
    // BasePart
    public string name;
    public string fileName; // relative directory in Resources/Textures
    public int price;
    public int rarity;  // enum
    public string flavorText;
    public int partType;    // enum

    // Torso
    public float moveSpeedMult;
    public float attackSpeedMult;
    public float mass;

    // Leg
    public float moveSpeed;

    // Arm
    public float windupTime;
    public float attackSpeed;
    public float recoveryTime;
    public float armAttackDelay;
    public float knockbackStrength;
}
