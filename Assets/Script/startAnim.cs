using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnim : MonoBehaviour
{
    private Vector3 startpos;
    private int speed = 1;
    private PlayerControl playerControlScript;
    private Animator playeranim;
    private bool animend;
    public bool dirt;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();
        playerControlScript.gameOver = true;
        playeranim = GameObject.Find("Player").GetComponent<Animator>();
        animend = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > startpos.x && !animend)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            playeranim.SetFloat("Speed_f", 0.4f);
            dirt = false;
            
        }
        else if (transform.position.x <= startpos.x && !animend)
        {

            playerControlScript.gameOver = false;
            playeranim.SetFloat("Speed_f", 1);
            animend = true;
            dirt = true;
            playerControlScript.dirt.Play();
        }
    }
}
