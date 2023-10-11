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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        //Jump Button
       if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * playerMoveSpeed * Time.deltaTime;
            Debug.Log("Up");

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
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isJumping = false;
            }
        }

    private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isJumping = true;
            }
        }
}
