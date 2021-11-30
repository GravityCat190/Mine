using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public int currentCombo;
    [SerializeField] private UIManager UIManager;

    private void Start()
    {
        currentCombo = 0;
    }

    public int GetCurrentCombo()
    {
        return currentCombo;
    }

    public void IncreaseCombo(int amount)
    {
        currentCombo += amount;
        UIManager.UpdateCombo(currentCombo);
    }

    public void ResetCombo()
    {
        currentCombo = 0;
        UIManager.UpdateCombo(currentCombo);
    }
}
