using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private PlayerControl playerControlScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControlScript.gameOver)
        {
            if (playerControlScript.doubleSpeed)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log("SCORE = " + score);
        }
    }
}
