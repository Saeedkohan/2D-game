using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    public float Speed=1;
    private float distance;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.localRotation = new Quaternion(0, 0, 0, 0);
    
        distance = Vector2.Distance(transform.position, Target.transform.position);
        float xDistance = Target.transform.position.x - transform.position.x;
        Vector3 newPosition = new Vector3(Target.transform.position.x, transform.position.y, transform.position.z);
        rb.MovePosition(Vector2.MoveTowards(this.transform.position, newPosition, Speed * Time.deltaTime));

        if (Speed!=0)
        {
            GetComponent<Animator>().SetBool("IsRuning", true);
            
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRuning", false);
            
        }


        if (GameObject.Find("AtackZone").GetComponent<AtackZnoeScript>().enterZone == true)
        {
            GetComponent<Animator>().SetBool("IsRuning", false);

            GetComponent<Animator>().SetBool("IsAtacking", true);
            
            if (GameObject.Find("Player").transform.position.x>transform.position.x )
            {
                transform.localScale = new Vector3(0.5f, 0.5f);

            }
            if (GameObject.Find("Player").transform.position.x<transform.position.x )
            {

                transform.localScale = new Vector3(-0.5f, 0.5f);
            }
        
        }
        
        if (GameObject.Find("AtackZone").GetComponent<AtackZnoeScript>().enterZone == false)
        {
            GetComponent<Animator>().SetBool("IsAtacking", false);
        
        }
    }
}
