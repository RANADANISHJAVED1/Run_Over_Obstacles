using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerBody;
    private bool isGrounded = true;
    private bool doubleJump = true;
    public int gravityModify;
    public bool gameOver ;
    public ParticleSystem dirt;
    public ParticleSystem explosion;
    private Animator playeranim;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource audioSource;
    public bool doubleSpeed;
    private startAnim startAnimScript;
    
    
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playeranim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModify;
        startAnimScript = GameObject.Find("Main Camera").GetComponent<startAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump && gameOver != true)
        {
            playerBody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            playeranim.SetTrigger("Jump_trig");
            
            if (isGrounded == false && doubleJump == true)
            {
                doubleJump = false;
            }
            isGrounded = false;
            dirt.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            doubleSpeed = true;
            playeranim.SetFloat("Speed_Multiplier", 2.0f);
        }
        else
        {
            doubleSpeed = false;
            playeranim.SetFloat("Speed_Multiplier", 1.0f);
        }
        if (!startAnimScript.dirt)
        {
            dirt.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isGrounded = true;
            doubleJump = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obsticals"))
        {
            gameOver = true;
            Debug.Log("GAME OVER.");
            playeranim.SetBool("Death_b", true);
            playeranim.SetInteger("DeathType_int", 1);
            dirt.Stop();
            explosion.Play();
            audioSource.PlayOneShot(crashSound,1.0f);
        }
    }
}
