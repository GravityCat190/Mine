using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LifeTarget : Target
{
    public override void Start()
    {
        base.Start();
    }
    public override void GetHit()
    {
        Debug.Log("Extra Life!");
        LifeManager.GetLife();
        base.Die();
    }
}