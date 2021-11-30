using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    private Collider2D[] overlapedCollider;
    private Vector2 overlapBoxPoint;
    private Vector2 overlapBoxSize;
    private float overlapBoxAngle = 0;
    private int targetLayer = 1 << 10; //Layer 10: Target
    private SpriteRenderer lineSpriteRenderer;

    [SerializeField] MoveLine moveLineScript;
    [SerializeField] LineBlink lineBlinkScript;
    [SerializeField] private LineManager LineManager;

    private void Start()
    {
        lineSpriteRenderer = GetComponent<SpriteRenderer>();
        float playerWidth = lineSpriteRenderer.bounds.size.x;
        float playerHeight = lineSpriteRenderer.bounds.size.y;
        overlapBoxSize = new Vector2(playerWidth, playerHeight);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HitAction();
        }
    }

    void HitAction()
    {
        overlapBoxPoint = new Vector2(transform.position.x, transform.position.y);
        overlapedCollider = Physics2D.OverlapBoxAll(overlapBoxPoint, overlapBoxSize, overlapBoxAngle, targetLayer);

        if (overlapedCollider.Length == 0)
        {
            MissTarget();
        }
        else
        {
            moveLineScript.ChangeDirection();
            foreach (Collider2D box in overlapedCollider)
            {
                HitTarget(box.gameObject);
            }
        }
    }

    void HitTarget(GameObject target)
    {
        target.GetComponent<Target>().GetHit();
    }

    public void MissTarget()
    {
        Debug.Log("Miss");
        lineBlinkScript.TemporarilyChangeColor();
        LineManager.LoseLife();
    }
}
