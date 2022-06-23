using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public LayerMask enemyLayers;
    public int attackDamage = 100;

    public Animator Animator;

    public int maxHealth = 100;
    public int currentHealth;

    public int level;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Background");
        currentHealth = maxHealth;
        Animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Death")
        {
            FindObjectOfType<AudioManager>().Play("DeathHero");
            FindObjectOfType<AudioManager>().Stop("Background");
            Invoke("LoadScene", 1);
        }
        if (other.gameObject.tag == "Finish")
        {
            FindObjectOfType<AudioManager>().Play("Finish");
            FindObjectOfType<AudioManager>().Stop("Background");
            PlayerPrefs.SetInt("Levels", level);
            if(level != 5)
            {
                Invoke("LoadScene", 1);
            }
            else
            {
                Invoke("LoadSceneWin", 1);
            }
            
        }
    }
    void Attack()
    {
        FindObjectOfType<AudioManager>().Play("Attack");
        //Play an attack animation
        Animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    public void TakeDamageHero(int DamageHero)
    {
        Hurt();
        currentHealth -= DamageHero;
        Debug.Log(currentHealth);

        //play hurt animation
        if (currentHealth <= 0)
        {
            die();
        }
    }
    public void Hurt()
    {
        FindObjectOfType<AudioManager>().Play("HurtHero");
        Animator.SetTrigger("Hurt");
    }
    public void die()
    {
        Debug.Log("Hero died");
        // play death animation
        FindObjectOfType<AudioManager>().Play("DeathHero");
        Animator.SetBool("IsDead", true);
        Animator.SetTrigger("Death");
        FindObjectOfType<AudioManager>().Stop("Background");
        Invoke("LoadScene", 2);
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Levels");
    }
    void LoadSceneWin()
    {
        SceneManager.LoadScene("Win");
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
