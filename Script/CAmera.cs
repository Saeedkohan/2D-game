using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAmera : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float YOfsset = 1f;
    public float XOfsset = 1f;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.transform.position.x+XOfsset, target.transform.position.y+YOfsset);
        transform.position = Vector3.Lerp(transform.position, newPos, FollowSpeed);
    }
}
