using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private int speed = 10;
    private PlayerControl playerControlScript;
    

    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
        outOfBound();
        
    }
    void moveLeft()
    {
        if (playerControlScript.gameOver == false )
        {
            if (playerControlScript.doubleSpeed)
            {
                transform.Translate(Vector3.left * (speed * 2) * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            
        }
    }
    void outOfBound()
    {
        if (transform.position.x < -15 && gameObject.CompareTag("Obsticals"))
        {
            Destroy(gameObject);
        }
    }
}
