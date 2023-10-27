using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipZone : MonoBehaviour
{
    public Transform ClipBackPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(UnityEngine.Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit!");
            collision.gameObject.transform.position = new Vector3(ClipBackPosition.position.x, ClipBackPosition.position.y, ClipBackPosition.position.z);
        }
    }
}
