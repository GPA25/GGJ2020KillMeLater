﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnEnd()
    {
        stateEnd = true;
    }
}
