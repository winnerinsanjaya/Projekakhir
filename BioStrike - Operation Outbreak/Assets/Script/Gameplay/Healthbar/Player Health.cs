using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;

    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        //healthBar = GetComponent<FloatingHealthBar>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        healthbar.SetMaXHealth(maxHealth);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        //healthBar.UpdateHealthBar(currentHealth, maxHealth);
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        healthbar.SetHealth(currentHealth);
    }

}
