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
    public Transform attackPivot;
    public Transform attackPos;
    public SpriteRenderer attackSprite;
    public int attackDamage;
    public float attackRadius;
    public float attackDuration;
    private bool isAttacking = false;
    

    // Sprites and Animation
    [Header("Sprite/Animation")]
    public SpriteRenderer sr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackSprite.enabled = false;
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
            attackPivot.eulerAngles = new Vector3(attackPivot.eulerAngles.x, 180, attackPivot.eulerAngles.z);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            sr.flipX = false;
            attackPivot.eulerAngles = new Vector3(attackPivot.eulerAngles.x, 0, attackPivot.eulerAngles.z);
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
        if (!isAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        // Sets the sword image on
        attackSprite.enabled = true;

        // Gets all enemies within a certain circle at the attack pos
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPos.position, attackRadius);

        // Gets their enemy scripts and does damage
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<Health>().Damage(attackDamage);
            }
        }

        // Sets sword image off after attackDuration amt of time
        yield return new WaitForSeconds(attackDuration);
        attackSprite.enabled = false;

        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        // Draws attack radius
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }
}
