using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float playerMoveSpeed = 0f;
    private float Move;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float jump;
    public bool isJumping;
    public Animator animator;



    [SerializeField]
    private int totalJump;

    public int airCount;

    private Rigidbody2D rb;

    [SerializeField]
    private float JumpPower;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        //Jump Button
       if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && airCount < totalJump)
        {
            Vector2 direction = new Vector2(0, 1);
            rb.velocity = direction * JumpPower;
            airCount += 1;
            Debug.Log("Up");
            AudioManagerLevel1.instance.PlaySFX("Jump");
        }
        //Move Left Button
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * playerMoveSpeed * Time.deltaTime;
            Debug.Log("Left");
            
        }
        //Down Button
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * playerMoveSpeed * Time.deltaTime;
            Debug.Log("Down");

        }
        //Move Right Button
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * playerMoveSpeed * Time.deltaTime;
            Debug.Log("Right");
            
        }
        //Shooting Button
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Time.deltaTime*bulletSpeed*transform.right);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
            AudioManagerLevel1.instance.PlaySFX("Gun");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
        {
            
        }

    private void OnCollisionExit2D(Collision2D other)
        {
            
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            airCount = 0;
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }
}
