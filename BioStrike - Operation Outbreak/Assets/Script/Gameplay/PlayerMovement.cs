using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float JumpPower;

    [SerializeField]
    private int totalJump;

    Rigidbody2D rb;

    public bool isGrounded;

    public int airCount;

    private Animator animator;

    public bool isJump;

    public static PlayerMovement instance;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Jump();

        Shoot();
    }


    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(x, 0);

        if (x != 0 && isGrounded)
        {
            SetAnimParam(true, false);
        }

        if (x == 0 && isGrounded)
        {
            SetAnimParam(false, false);
        }
        transform.Translate(direction * Time.deltaTime * speed);

    }

    private void Jump()
    {
        //single jump
        /*
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector2 direction = new Vector2(0, 1);
            rb.velocity = direction * JumpPower;
        }*/


        //double jump
        if (Input.GetKeyDown(KeyCode.W) && airCount < totalJump)
        {
            SetAnimParam(false, true);
            AudioManagerLevel1.instance.PlaySFX("Jump");
            Vector2 direction = new Vector2(0, 1);
            rb.velocity = direction * JumpPower;
            airCount += 1;
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Time.deltaTime * bulletSpeed * transform.right);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
            AudioManagerLevel1.instance.PlaySFX("Gun");
        }
    }

    private void Facing(bool isFacingRight)
    {
        if (isFacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
            return;
        }
        if (!isFacingRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }
    }


    private void SetAnimParam(bool isRunning, bool isJumping)
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }
}
