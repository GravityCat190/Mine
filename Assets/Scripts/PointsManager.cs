using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private int score;
    private UIManager UIManager;
    private ComboManager ComboManager;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UIManager = GameObject.Find("Game Manager").GetComponent<UIManager>();
        ComboManager = GameObject.Find("Game Manager").GetComponent<ComboManager>();
    }

    public void UpdateScore(int scoreToAdd)
    {
        int currentCombo = Mathf.Max(ComboManager.GetCurrentCombo(), 1);
        score += scoreToAdd * currentCombo;
        UIManager.UpdateScore(score);
    }
}
