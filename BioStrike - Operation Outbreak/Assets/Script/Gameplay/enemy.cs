using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public int enemyHP = 100;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x > transform.position.x)
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
