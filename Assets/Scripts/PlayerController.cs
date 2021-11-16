using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Operators
{
    Minus,
    Plus
}

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

    private List<Operators> operatorInventory = new List<Operators>();

    public GameObject inventory;

    bool isMoving = false;

    AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        if (self == null)
        {
            self = this;
        }

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //input from arrow keys and WASD

        if (canMove)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            if (direction.x > 0)
                transform.localScale = new Vector3(direction.x, transform.localScale.y, transform.localScale.z);
            else if (direction.x < 0)
                transform.localScale = new Vector3(direction.x, transform.localScale.y, transform.localScale.z);
            direction.y = Input.GetAxisRaw("Vertical");
            direction = direction.normalized;
            Move(direction * speed);
        }

        if (rb.velocity != Vector2.zero)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
            if (!audioSrc.isPlaying)
            audioSrc.Play();
        }
        else
            audioSrc.Stop();

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject.Find("Question").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InputManager").GetComponent<InputManager>().SwitchIsPlayer(false);
            GameObject.Find("InputManager").GetComponent<InputManager>().DisplayHighlight();

        }
    }

    public void CollectOperator(Operators op)
    {
        operatorInventory.Add(op);
        inventory.GetComponent<Inventory>().AddOperator(op);

    }

}
