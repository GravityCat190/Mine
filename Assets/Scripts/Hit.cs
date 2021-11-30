using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour
{
    private Collider2D[] overlapedCollider;
    private Vector2 overlapBoxPoint;
    private Vector2 overlapBoxSize;
    private float overlapBoxAngle = 0;
    private int targetLayer = 1 << 10; //Layer 10: Target
    private SpriteRenderer lineSpriteRenderer;

    private MoveLine moveLineScript;
    private Miss missScript;

    private void Start()
    {
        lineSpriteRenderer = GetComponent<SpriteRenderer>();
        float playerWidth = lineSpriteRenderer.bounds.size.x;
        float playerHeight = lineSpriteRenderer.bounds.size.y;
        overlapBoxSize = new Vector2(playerWidth, playerHeight);
        moveLineScript = GameObject.Find("Line").GetComponent<MoveLine>();
        missScript = GameObject.Find("Line").GetComponent<Miss>();
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
            missScript.MissTarget();
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
}
