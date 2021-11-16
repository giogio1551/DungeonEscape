using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    //always make startPosition up and/or right compared to endPosition
    public float speed;
    public bool movingRight, movingDown;
    public Vector2 startPosition;
    public Vector2 endPosition;
    private Vector2 direction;
    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        movingRight = startPosition.x < endPosition.x;
        movingDown = startPosition.y > endPosition.y;
        transform.position = startPosition;

    }

    // Update is called once per frame
    void Update()
    {

        if (movingDown)
        {
            Vector2 origin = new Vector2(transform.position.x - 1f, transform.position.y);
            hit = Physics2D.Raycast(origin, Vector2.down, Math.Abs(endPosition.y - transform.position.y));
        }
        else
        {

            Vector2 origin = new Vector2(transform.position.x + 1f, transform.position.y);
            hit = Physics2D.Raycast(origin, Vector2.up, Math.Abs(startPosition.y - transform.position.y));
        }

        if (hit.collider != null)
        {
            //something hit the raycast, so can't go straight up/down
            MoveHorizontally();
        }
        else
        {
            //nothing hit the raycast, so move vertically first if needed
            if ((movingDown && transform.position.y > endPosition.y) || (!movingDown && transform.position.y < startPosition.y))
            {
                MoveVertically();
            }
            else
            {
                MoveHorizontally();
            }
        }

    }

    private void MoveVertically()
    {
        if (movingDown)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    private void MoveHorizontally()
    {
        if (movingRight && transform.position.x < endPosition.x)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (movingRight && IsAtDestination())
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            TurnAround();
        }
        else if (transform.position.x > startPosition.x)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (IsAtDestination())
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            TurnAround();
        }
    }

    private bool IsAtDestination()
    {
        if (movingRight && transform.position.x < endPosition.x)
        {
            return false;
        }
        if (movingDown && transform.position.y > endPosition.x)
        {
            return false;
        }
        if (!movingRight && transform.position.x > startPosition.x)
        {
            return false;
        }
        if (!movingDown && transform.position.y < startPosition.y)
        {
            return false;
        }
        return true;
    }

    private void TurnAround()
    {
        movingDown = !movingDown;
        movingRight = !movingRight;
    }
}
