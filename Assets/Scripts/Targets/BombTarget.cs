using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BombTarget : Target
{
    public override void Start()
    {
        base.Start();
    }
    public override void GetHit()
    {
        Debug.Log("Bomb!");
        LineManager.LoseLife();
        LineManager.ResetCombo();
        base.Die();
    }
}
