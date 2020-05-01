using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
    public float speed=10f;
    public Animator anim;
    public bool up=true;
    public bool down;
    public bool left;
    public bool right;
    public GameObject daggerUp;
    public GameObject daggerRight;
    public GameObject daggerLeft;
    public GameObject daggerDown;
    public Transform top;
    public Transform rightP;
    public Transform leftP;
    public Transform downP;
    public AudioClip walkSound;
    public static int health;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (PV.IsMine)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && transform.position.y < 9f)
            {
                up = true;
                down = false;
                left = false;
                right = false;
                anim.SetBool("WalkUp", true);
                transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);

            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                anim.SetTrigger("IdleUp");
                up = true;
                down = false;
                left = false;
                right = false;
                anim.SetBool("WalkUp", false);
                transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && transform.position.y > -6f)
            {
                anim.SetBool("WalkDown", true);
                transform.position += new Vector3(0.0f, -speed * Time.deltaTime, 0.0f);
                up = false;
                down = true;
                left = false;
                right = false;
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                anim.SetBool("WalkDown", false);
                up = false;
                down = true;
                left = false;
                right = false;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && transform.position.x < 14.5f)
            {
                anim.SetBool("WalkRight", true);
                transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
                up = false;
                down = false;
                left = false;
                right = true;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                anim.SetBool("WalkRight", false);
                anim.SetTrigger("IdleRight");
                transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
                up = false;
                down = false;
                left = false;
                right = true;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -14.5f)
            {
                anim.SetBool("WalkLeft", true);
                transform.position += new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
                up = false;
                down = false;
                left = true;
                right = false;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetBool("WalkLeft", false);
                transform.position += new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
                up = false;
                down = false;
                left = true;
                right = false;
            }
            if (Input.GetKeyDown(KeyCode.Space) && up)
            {
                ThrowDaggeUp();
            }
            if (Input.GetKeyDown(KeyCode.Space) && right)
            {
                ThrowDaggerRight();
            }
            if (Input.GetKeyDown(KeyCode.Space) && left)
            {
                ThrowDaggerLeft();
            }
            if (Input.GetKeyDown(KeyCode.Space) && down)
            {
                ThrowDaggerDown();
            }
        }
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }
    void ThrowDaggeUp()
    {
        Instantiate(daggerUp,top.position, daggerUp.transform.rotation);
    }
    void ThrowDaggerRight()
    {
        Instantiate(daggerRight, rightP.position, daggerRight.transform.rotation);
    }
    void ThrowDaggerLeft()
    {
        Instantiate(daggerLeft, leftP.position, daggerLeft.transform.rotation);
    }
    void ThrowDaggerDown()
    {
        Instantiate(daggerDown, downP.position, daggerDown.transform.rotation);
    }
    public void playWalkSound()
    {
        GetComponent<AudioSource>().PlayOneShot(walkSound);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Fireball"||collision.transform.tag=="Enemy")
        {
            anim.Play("Hit");
            Destroy(collision.gameObject);
            transform.position = new Vector3(0, -4, 0);
            health -= 1;
            ScoreTracker.score -= 100;
        }
    }
}
