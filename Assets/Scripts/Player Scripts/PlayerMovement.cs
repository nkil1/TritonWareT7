using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    [Header("Movement")]
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 velocity;


    // Attacking
    [Header("Attacking")]
    public Transform attackPosition;
    public GameObject attackSprite;
    public float attackRadius;
    //public float attackDuration; - Might use later if we need attacking to be a longer thing
    //private bool isAttacking = false;
    

    // Sprites and Animation
    [Header("Sprite/Animation")]
    public SpriteRenderer sr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Gets WASD Input
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        // Attacking
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        // Flips Sprite
        if (Input.GetKeyDown(KeyCode.A))
        {
            sr.flipX = true;
            attackPosition.eulerAngles = new Vector3(attackPosition.eulerAngles.x, 180, attackPosition.eulerAngles.z);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            sr.flipX = false;
            attackPosition.eulerAngles = new Vector3(attackPosition.eulerAngles.x, 0, attackPosition.eulerAngles.z);
        }
    }

    private void FixedUpdate()
    {
        // Moves player
        rb.velocity = velocity.normalized * speed;
    }

    private void CheckForFlipping()
    {/*
      * Just put a simplified version in main, could need this later
        bool movingLeft = axisMovement.x < 0;
        bool movingRight= axisMovement.x > 0;
        if (movingLeft)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y);

        }
        if(movingRight)
            transform.localScale = new Vector3(1f, transform.localScale.y);*/
    }

    private void Attack()
    {
        //isAttacking = true;

        // Sets the sword image on
        attackSprite.SetActive(true);

        // Gets all enemies within a certain circle at the attack pos
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPosition.position, attackRadius);

        // Gets their enemy scripts and does damage
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<Enemy>();
            }
        }

        // Sets sword image off
        attackSprite.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        // Draws attack radius
        Gizmos.DrawWireSphere(attackPosition.position, attackRadius);
    }
}
