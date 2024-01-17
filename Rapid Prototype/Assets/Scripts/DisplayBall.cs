using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBall : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer mr;
    public int whichMat;
    public Material currentMat;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    //public Material mat4;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(0f, 1f, 0f);
        mr = this.GetComponent<MeshRenderer>();
        mr.material = currentMat;
    }

    // Update is called once per frame
    void Update()
    {
        switch (whichMat)
        {
            case 0:
                mr.material = currentMat;
                break;
            case 1:
                mr.material = mat1;
                break;
            case 2:
                mr.material = mat2;
                break;
            case 3:
                mr.material = mat3;
                break;
            case 4:
                mr.material = mat4;
                break;
        }
    }
}
