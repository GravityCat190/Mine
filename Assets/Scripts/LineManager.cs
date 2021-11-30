using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private ComboManager ComboManager;
    [SerializeField] private LifeManager LifeManager;
    [SerializeField] private PointsManager PointsManager;

    public void ResetCombo()
    {
        ComboManager.ResetCombo();
    }

    public void IncreaseCombo(int amount)
    {
        ComboManager.IncreaseCombo(amount);
    }

    public void LoseLife()
    {
        LifeManager.LoseLife();
    }

    public void GetLife()
    {
        LifeManager.GetLife();
    }

    public void UpdateScore(int points)
    {
        PointsManager.UpdateScore(points);
    }
}
