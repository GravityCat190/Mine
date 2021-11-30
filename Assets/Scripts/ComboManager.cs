using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public int currentCombo;
    private UIManager UIManager;

    private void Start()
    {
        currentCombo = 0;
        UIManager = GameObject.Find("Game Manager").GetComponent<UIManager>();
    }

    public int GetCurrentCombo()
    {
        return currentCombo;
    }

    public void increaseCombo(int amount)
    {
        currentCombo += amount;
        UIManager.UpdateCombo(currentCombo);
    }

    public void resetCombo()
    {
        currentCombo = 0;
        UIManager.UpdateCombo(currentCombo);
    }
}
