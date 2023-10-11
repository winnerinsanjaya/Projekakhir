using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public int enemyHP = 100;

    private Rigidbody2D rb;
    public float KecepatanGerak;
    public bool berbalik;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        berbalik = true;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        posisi();
        Enemyrotasi();
    }

    private void Enemyrotasi()
    {
        if (berbalik)
        {
            rb.velocity = new Vector2(KecepatanGerak, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-KecepatanGerak, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Balik"))
        {
            berbalik =! berbalik;
        }
    }

    private void posisi()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if (enemyHP>0)
        {
            Debug.Log("Hit");
        }
        else
        {
            Debug.Log("enemy destroyed");
            Destroy(gameObject);
        }
    }
}
