using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Slider Slider;
    public  float RunSpeed = 0.01f;
    private bool jump;

    private int jump_counter;

    private float Time;

    // Start is called before the first frame update
    private void Start()
    {
        Time = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(jump_counter);
        col.gameObject.GetComponent<SpriteRenderer>();
        GetComponent<Animator>().SetBool("Is Jumping", false);
        jump = false;
        jump_counter = 0;
    }

    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Spike")
    //     {
    //         damgageTime += Time.deltaTime;
    //
    //         if (Math.Round(damgageTime) == 2|| Math.Round(damgageTime) == 0)
    //         {
    //             Slider.value -= 1f;
    //             damgageTime = 1;
    //         }
    //     }
    //
    //         // Debug.Log(damgageTime);
    // }

    // Update is called once per frame
    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;

        transform.localRotation = new Quaternion(0, 0, 0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            transform.position += new Vector3(RunSpeed, 0);
            GetComponent<Animator>().SetBool("Is Runing", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("Is Runing", true);
            transform.position -= new Vector3(RunSpeed, 0);
            transform.localScale = new Vector3(-0.6f, 0.6f, .6f);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) GetComponent<Animator>().SetBool("Is Runing", false);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump == false)
            {
                GetComponent<Animator>().SetBool("Is Jumping", true);
                jump_counter++;

                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7);
                    
                
                if (jump_counter == 2) jump = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) GetComponent<Animator>().SetBool("Is Atacking", true);

        if (Input.GetKeyUp(KeyCode.Mouse0)) GetComponent<Animator>().SetBool("Is Atacking", false);
    }
}