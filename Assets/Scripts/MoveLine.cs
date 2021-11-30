using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLine : MonoBehaviour
{
    bool isMovingRight = true;
    public float speed;
    [SerializeField] private LineManager LineManager;

    // Update is called once per frame
    void Update()
    {
        if (isMovingRight == true)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    public void ChangeDirection()
    {
        isMovingRight = !isMovingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundry"))
        {
            LineManager.ResetCombo();
            ChangeDirection();
        }    
    }
}
