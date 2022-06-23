using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField]
    float speed = 4.0f;

    [SerializeField]
    float jumpForce = 7.5f;

    private Animator animator;

    private Rigidbody2D rb;

    private Sensor_Hero GSensor;

    private bool grounded = false;

    private bool combatIdle = false;

    private bool isDead = false;

    public GameObject Camera;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GSensor = transform.Find("GroundSensor").GetComponent<Sensor_Hero>();
    }

    void Update()
    {
        Camera.transform.position = new Vector3(transform.position.x, 0, -10);

        if (!grounded && GSensor.State())
        {
            grounded = true;
            animator.SetBool("Grounded", grounded);
        }

        if (grounded && !GSensor.State())
        {
            grounded = false;
            animator.SetBool("Grounded", grounded);
        }

        float direction = Input.GetAxis("Horizontal");

        if (direction > 0)
            transform.localScale = new Vector3(-2.0f, 2.0f, 2.0f);
        else if (direction < 0)
            transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        animator.SetFloat("AirSpeed", rb.velocity.y);

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        else if (Input.GetKeyDown("f"))
            combatIdle = !combatIdle;
        else if (Input.GetKeyDown("space") && grounded)
        {
            Jump();
        }
        else if (Mathf.Abs(direction) > Mathf.Epsilon)
            AnimState(2);
        else if (combatIdle)
            AnimState(1);
        else
            AnimState(0);
    }

    void Death()
    {
        animator.SetTrigger("Death");
    }

    void Recover()
    {
        animator.SetTrigger("Recover");
        isDead = !isDead;
    }

    void Hurt()
    {
        FindObjectOfType<AudioManager>().Play("HurtHero");
        animator.SetTrigger("Hurt");
    }

    void Attack()
    {
        FindObjectOfType<AudioManager>().Play("Attack");
        animator.SetTrigger("Attack");
    }

    void Jump()
    {
        FindObjectOfType<AudioManager>().Play("JumpHero");
        animator.SetTrigger("Jump");
        grounded = false;
        animator.SetBool("Grounded", grounded);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        GSensor.Disable(0.2f);
    }

    void AnimState(int state)
    {
        animator.SetInteger("AnimState", state);
    }
}
