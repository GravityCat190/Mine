using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private int score;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private ComboManager ComboManager;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void UpdateScore(int scoreToAdd)
    {
        int currentCombo = Mathf.Max(ComboManager.GetCurrentCombo(), 1);
        score += scoreToAdd * currentCombo;
        UIManager.UpdateScore(score);
    }
}
