using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss : MonoBehaviour
{
    private SpriteRenderer lineSpriteRenderer;

    [SerializeField] float changetime;
    [SerializeField] Color temporarilyColor;
    private Color currentColor;
    private ComboManager ComboManager;

    private LifeManager LifeManager;

    // Start is called before the first frame update
    void Start()
    {
        lineSpriteRenderer = GetComponent<SpriteRenderer>();
        LifeManager = GameObject.Find("Game Manager").GetComponent<LifeManager>();
        ComboManager = GameObject.Find("Game Manager").GetComponent<ComboManager>();
        currentColor = lineSpriteRenderer.color;
    }

    public void MissTarget()
    {
        Debug.Log("Miss");
        TemporarilyChangeColor();
        ComboManager.resetCombo();
        LifeManager.LoseLife();
    }

    void TemporarilyChangeColor()
    {
        StopAllCoroutines();
        LineBlink(currentColor, temporarilyColor, changetime);
    }

    void LineBlink(Color orginalColor, Color newColor, float time)
    {
        lineSpriteRenderer.color = newColor;
        StartCoroutine(ChangeToOrginalColor(orginalColor, time));
        StartCoroutine(ChangeToTemporarilyColor(newColor, time * 2));
        StartCoroutine(ChangeToOrginalColor(orginalColor, time * 3));
    }

    IEnumerator ChangeToOrginalColor(Color orginalColor, float time)
    {
        yield return new WaitForSeconds(time);
        lineSpriteRenderer.color = orginalColor;
    }

    IEnumerator ChangeToTemporarilyColor(Color newColor, float time)
    {
        yield return new WaitForSeconds(time);
        lineSpriteRenderer.color = newColor;
    }
}
