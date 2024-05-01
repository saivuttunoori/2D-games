using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class door2 : MonoBehaviour
{
    private playercontrollerlevel2 thePlayer;

    public SpriteRenderer theSR;
    public Sprite doorOpenSprite;

    public bool doorOpen, waitingToOpen;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<playercontrollerlevel2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingToOpen)
        {
            if (Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                theSR.sprite = doorOpenSprite;

                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;
            }
        }
        if (doorOpen && Vector3.Distance(thePlayer.transform.position, transform.position) < 1f && Input.GetAxis("vertical") > 0.1f)
        {
            SceneManager.LoadScene("3 level");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }

        }
    }
}
