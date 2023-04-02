using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private AudioSource deathSE;
    [SerializeField] private AudioSource hurtSE;
    public float currentHealth { get; private set; }
    private Animator anim;
    private Rigidbody2D rb;
    private bool dead;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
            hurtSE.Play();
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("death");
                deathSE.Play();
                rb.bodyType = RigidbodyType2D.Static;
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }

    public void addHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
