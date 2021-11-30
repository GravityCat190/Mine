using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class NormalTarget : Target
{
    public override void Start()
    {
        base.Start();
        base.SetPoints();
    }
    public override void GetHit()
    {
        PointsManager.UpdateScore(points);
        ComboManager.increaseCombo(1);
        base.Die();
    }
}
