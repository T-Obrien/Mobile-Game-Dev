using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipBackZone : MonoBehaviour
{
    public Transform playerBall;
    Vector3 pos; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos.x = -(pos.x - playerBall.position.x);
        pos.z = -(pos.z - playerBall.position.z);
        transform.Translate(pos);
        pos.x = playerBall.position.x;
        pos.z = playerBall.position.z;
    }
}
