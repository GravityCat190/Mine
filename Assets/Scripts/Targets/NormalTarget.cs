using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class NormalTarget : Target
{
    public void Start()
    {
        base.Start();
        base.SetPoints();
    }
    public override void GetHit()
    {
        LineManager.UpdateScore(points);
        LineManager.IncreaseCombo(1);
        base.Die();
    }
}
