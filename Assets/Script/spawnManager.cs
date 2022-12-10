using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] SpawnObsticals;
    private PlayerControl playerControlScript;

    void Start()
    {
        InvokeRepeating("createObsticals", 2, 2);
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void createObsticals()
    {
        if(playerControlScript.gameOver == false)
        {
            int index = Random.Range(0, SpawnObsticals.Length);
            Instantiate(SpawnObsticals[index], new Vector3(25, 0, 0), SpawnObsticals[index].transform.rotation);
        }
        
    }
}
