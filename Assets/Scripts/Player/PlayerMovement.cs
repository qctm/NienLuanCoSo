using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    //them double jump
    private bool doubleJump;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementSate { idle, running, jumping, falling}
    // Hieu ung am thanh
    [SerializeField] private AudioSource jumpSE;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSE.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        
        //Update
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }
        }
        UpdateAnimationUpdate();
        //update 10.11
        
        if (Input.GetKey(KeyCode.RightShift))
            if (m_TempCooldown <= 0)
            {
                Fire();
                m_TempCooldown = m_FiringCooldown;
            }
        m_TempCooldown -= Time.deltaTime;
    }

    private void UpdateAnimationUpdate()
    {
        MovementSate state;
        if (dirX > 0f)
        {
            state = MovementSate.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementSate.running;
            sprite.flipX= true;
        }
        else
        {
            state = MovementSate.idle;
        }
        if(rb.velocity.y > 1f)
        {
            state = MovementSate.jumping;
        }
        if(rb.velocity.y < -.1f)
        {
            state = MovementSate.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    
    //Ban dan
    [SerializeField] private ProjectitleController m_ProjectitleController;
    [SerializeField] private Transform m_FiringPoint;
    [SerializeField] private float m_FiringCooldown;
    private float m_TempCooldown;

    public void Fire()
    {
        ProjectitleController projectitle = Instantiate(m_ProjectitleController, m_FiringPoint.position, Quaternion.identity, null);
        projectitle.Fire();
    }

 
}
