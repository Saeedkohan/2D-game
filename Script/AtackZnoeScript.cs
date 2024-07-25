using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackZnoeScript : MonoBehaviour
{
    public bool enterZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("entr");
            enterZone = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
     Debug.Log("exit");   
     enterZone = false;

    }
}
