using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    private int life;
    private int maxLife = 3;
    private int minLife = 0;

    [SerializeField]  private UIManager UIManager;
    [SerializeField] private ComboManager ComboManager;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
    }
    public void LoseLife()
    {
        life = life - 1;
        ComboManager.ResetCombo();
        UIManager.UpdateLife(life);
        if (life == minLife)
        {
            GameOver();
        }
    }

    public void GetLife()
    {
        life = Mathf.Min(maxLife, life + 1);
        UIManager.UpdateLife(life);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
