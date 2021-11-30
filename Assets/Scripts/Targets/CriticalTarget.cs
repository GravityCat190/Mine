using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CriticalTarget : Target
{
    public override void Start()
    {
        base.Start();
        base.SetPoints();
    }
    public override void GetHit()
    {
        points = points * 2;
        Debug.Log("Critical!");
        PointsManager.UpdateScore(points);
        ComboManager.increaseCombo(2);
        base.Die();
    }
}
