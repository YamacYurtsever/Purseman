using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purseman : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;

    string direction;
    float newXVelocity, newYVelocity;
    float deltaX, deltaY;
    Collider2D rightDetection1, leftDetection1, upDetection1, downDetection1;
    Collider2D rightDetection2, leftDetection2, upDetection2, downDetection2;
    Rigidbody2D rigidBody;
    Vector2 positiveScale, negativeScale;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        positiveScale = gameObject.transform.localScale;
        negativeScale = new Vector2(positiveScale.x * -1, positiveScale.y);
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        rightDetection1 = Physics2D.OverlapPoint(new Vector2(transform.position.x + 1.5f, transform.position.y + 0.5f));
        rightDetection2 = Physics2D.OverlapPoint(new Vector2(transform.position.x + 1.5f, transform.position.y - 0.5f));
        leftDetection1 = Physics2D.OverlapPoint(new Vector2(transform.position.x - 1.5f, transform.position.y + 0.5f));
        leftDetection2 = Physics2D.OverlapPoint(new Vector2(transform.position.x - 1.5f, transform.position.y - 0.5f));
        upDetection1 = Physics2D.OverlapPoint(new Vector2(transform.position.x + 0.5f, transform.position.y + 1.5f));
        upDetection2 = Physics2D.OverlapPoint(new Vector2(transform.position.x - 0.5f, transform.position.y + 1.5f));
        downDetection1 = Physics2D.OverlapPoint(new Vector2(transform.position.x + 0.5f, transform.position.y - 1.5f));
        downDetection2 = Physics2D.OverlapPoint(new Vector2(transform.position.x - 0.5f, transform.position.y - 1.5f));

        deltaX = Input.GetAxisRaw("Horizontal");
        deltaY = Input.GetAxisRaw("Vertical");

        if (deltaX == 1)
        {
            if (rightDetection1 == null & rightDetection2 == null)
            {
                direction = "right";
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                transform.localScale = positiveScale;
            }
        }
        if (deltaX == -1)
        {
            if (leftDetection1 == null & leftDetection2 == null)
            {
                direction = "left";
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                transform.localScale = negativeScale;
            }
        }
        if (deltaY == 1)
        {
            if (upDetection1 == null & upDetection2 == null)
            {
                direction = "up";
                transform.localScale = positiveScale;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
            }
        }
        if (deltaY == -1)
        {
            if (downDetection1 == null & downDetection2 == null)
            {
                direction = "down";
                transform.localScale = positiveScale;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90);
            }
        }

        switch (direction)
        {
            case "right":
                newXVelocity = 1 * Time.deltaTime * moveSpeed;
                rigidBody.velocity = new Vector2(newXVelocity, 0);
                break;

            case "left":
                newXVelocity = -1 * Time.deltaTime * moveSpeed;
                rigidBody.velocity = new Vector2(newXVelocity, 0);
                break;

            case "up":
                newYVelocity = 1 * Time.deltaTime * moveSpeed;
                rigidBody.velocity = new Vector2(0, newYVelocity);
                break;

            case "down":
                newYVelocity = -1 * Time.deltaTime * moveSpeed;
                rigidBody.velocity = new Vector2(0, newYVelocity);
                break;

            default:
                break;
        }
    }
}