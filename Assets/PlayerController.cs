using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController self;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private Vector2 velocity = Vector2.zero;

    public float speed;

    private Vector2 direction;

    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        if (self == null)
        {
            self = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //input from arrow keys and WASD
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction = direction.normalized;
        if (canMove)
        {
            Move(direction * speed);
        }

    }

    public void Move(Vector2 targetVelocity)
    {
        //smooth it out and apply it to the character
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void ToggleMovement()
    {
        canMove = !canMove;
    }
}
