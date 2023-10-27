using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    public Transform pos;
    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos.position = new Vector3(playerPos.position.x + 15.8f, 10.0f, playerPos.position.z);
    }
}
