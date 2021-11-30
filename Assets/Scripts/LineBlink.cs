using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBlink : MonoBehaviour
{
    [SerializeField] float changetime;
    [SerializeField] Color temporarilyColor;
    private Color currentColor;
    private SpriteRenderer lineSpriteRenderer;

    private void Start()
    {
        lineSpriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = lineSpriteRenderer.color;
    }

    public void TemporarilyChangeColor()
    {
        StopAllCoroutines();
        Blink(currentColor, temporarilyColor, changetime);
    }

    private void Blink(Color orginalColor, Color newColor, float time)
    {
        lineSpriteRenderer.color = newColor;
        StartCoroutine(ChangeToOrginalColor(orginalColor, time));
        StartCoroutine(ChangeToTemporarilyColor(newColor, time * 2));
        StartCoroutine(ChangeToOrginalColor(orginalColor, time * 3));
    }

    private IEnumerator ChangeToOrginalColor(Color orginalColor, float time)
    {
        yield return new WaitForSeconds(time);
        lineSpriteRenderer.color = orginalColor;
    }

    private IEnumerator ChangeToTemporarilyColor(Color newColor, float time)
    {
        yield return new WaitForSeconds(time);
        lineSpriteRenderer.color = newColor;
    }
}
