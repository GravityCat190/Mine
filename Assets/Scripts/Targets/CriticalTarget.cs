using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CriticalTarget : Target
{
    public void Start()
    {
        base.Start();
        base.SetPoints();
    }
    public override void GetHit()
    {
        points = points * 2;
        Debug.Log("Critical!");
        LineManager.UpdateScore(points);
        LineManager.IncreaseCombo(2);
        base.Die();
    }
}
