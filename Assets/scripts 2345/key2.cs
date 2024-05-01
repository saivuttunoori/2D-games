using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class key2 : MonoBehaviour
{
    private bool isFollowing;

    public float followSpeed;

    public Transform followTarget;

    public bool keyCollected = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playercontrollerlevel2 thePlayer = FindObjectOfType<playercontrollerlevel2>();

            followTarget = thePlayer.keyfollowpoint;

            isFollowing = true;

            thePlayer.followingKey = this;
            keyCollected = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("door"))
        {
            SceneManager.LoadScene("3 level");
        }

        if (collision.gameObject.CompareTag("door2"))
        {
            SceneManager.LoadScene("4 level");
        }
        if (collision.gameObject.CompareTag("door3"))
        {
            SceneManager.LoadScene("Main Ui");
        }
    }


}
