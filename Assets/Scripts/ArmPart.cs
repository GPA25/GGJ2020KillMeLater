using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPart : BasePart
{

    // Dmage the arm will do
    int damage = 1;

    // how long before the attack starts
    float windUpTime = 1.0f;

    // How fast the attack animation will be
    float attackSpeed = 1.0f;

    // How long to finish the attack
    float recoveryTime = 1.0f;

    // How Long before the next attack
    float attackDelay = 1.0f;
}
