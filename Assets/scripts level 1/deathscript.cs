using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathscript : MonoBehaviour
{
    public GameObject startFlag;
    public GameObject player;

    
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            player.transform.position = startFlag.transform.position;
        }

    }
}
