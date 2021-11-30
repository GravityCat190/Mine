using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, comboText;
    [SerializeField] GameObject life1, life2, life3;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        UpdateCombo(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateCombo(int combo)
    {
        comboText.text = "Combo: " + combo;
    }


    public void UpdateLife(int currentLife)
    {
        switch (currentLife)
        {
            case 3:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
            case 2:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(false);
                break;
            case 1:
                life1.SetActive(true);
                life2.SetActive(false);
                life3.SetActive(false);
                break;
            case 0:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                break;
        }
    }
}
