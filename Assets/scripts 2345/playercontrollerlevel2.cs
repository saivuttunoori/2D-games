using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrollerlevel2 : MonoBehaviour
{
    public float speed;
    private float Move;

    public float jump;

    public bool isJumping;

    public Transform keyfollowpoint;

    public key2 followingKey;
    public key2 key;
    public GameObject other;


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (other.gameObject.CompareTag("Border"))
        {
            SceneManager.LoadScene("Retry 1");
        }
        if (other.gameObject.CompareTag("Border2"))
        {
            SceneManager.LoadScene("Retry 2");
        }
        if (other.gameObject.CompareTag("Border3"))
        {
            SceneManager.LoadScene("Retry 3");
        }


        if (other.gameObject.CompareTag("door") && key.keyCollected == true)
        {
            SceneManager.LoadScene("3 level");
        }

        if (other.gameObject.CompareTag("door2") && key.keyCollected == true)
        {
            SceneManager.LoadScene("4 level");
        }
        if (other.gameObject.CompareTag("door3") && key.keyCollected == true)
        {
            SceneManager.LoadScene("Ending");
        }



    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("powerup"))
        {
            other.SetActive(false);
        }
    }




}
