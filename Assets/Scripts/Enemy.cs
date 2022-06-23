using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public GameObject enemy;
    public GameObject hero;

    public float speed = 3f;
    public float velocity;
    private Vector3 rotation;
    public float links;
    private bool isAttack = false;

    float nextAttackTime = 0f;
    public float attackRate = 2f;

    public Transform attackPointEnemy;
    public float attackRange = 0.5f;
    public LayerMask heroLayers;
    public int attackHero = 35;

    public string hurt;
    public string death;
    public string attack;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        velocity = transform.position.x + velocity;
        links = transform.position.x - links;

    }
    void Update()
    {
        if (isAttack == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < links)
            {
                transform.eulerAngles = rotation - new Vector3(0, 180, 0);
            }

            if (transform.position.x > velocity)
            {
                transform.eulerAngles = rotation;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        Hurt();
        currentHealth -= damage;

        //play hurt animation
        if (currentHealth <= 0)
        {
            die();
        }
    }
    void die()
    {
        Debug.Log("Enemy died");
        // play death animation
        FindObjectOfType<AudioManager>().Play(death);
        animator.SetBool("IsDead", true);
        animator.SetTrigger("Death");
        Invoke("DestroyEnemy", 1);
    }
    void Hurt()
    {
        FindObjectOfType<AudioManager>().Play(hurt);
        animator.SetTrigger("Hurt");
    }
    void DestroyEnemy()
    {
        Destroy(enemy);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        AttackEnemy(other);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isAttack = false;
    }
    void AttackEnemy(Collider2D other)
    {
        if (other.gameObject.tag == "Hero")
        {
            isAttack = true;
            StartCoroutine(AttackEnemy());
            transform.eulerAngles = rotation;
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPointEnemy == null)
            return;

        Gizmos.DrawWireSphere(attackPointEnemy.position, attackRange);
    }
    IEnumerator AttackEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            Attack();
        }
    }
    void Attack()
    {
        FindObjectOfType<AudioManager>().Play(attack);
        animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitHeros = Physics2D.OverlapCircleAll(attackPointEnemy.position, attackRange, heroLayers);

        //Damage them
        foreach (Collider2D hero in hitHeros)
        {
            Debug.Log(hero.name);
            hero.GetComponent<PlayerCombat>().TakeDamageHero(attackHero);
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
}

