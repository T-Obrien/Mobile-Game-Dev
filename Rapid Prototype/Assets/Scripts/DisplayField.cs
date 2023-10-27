using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayField : MonoBehaviour
{
    Rigidbody rb;
    MeshFilter mf;
    public int whichMesh;
    public Mesh currentMesh;
    public Mesh mesh1;
    public Mesh mesh2;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(0f, 1f, 0f);
        mf = GetComponent<MeshFilter>();
        mf.mesh = currentMesh;
    }

    // Update is called once per frame
    void Update()
    {
        switch (whichMesh)
        {
            case 0:
                mf.mesh = currentMesh;
                break;
            case 1:
                mf.mesh = mesh1;
                break;
            case 2:
                mf.mesh = mesh2;
                break;
        }
    }
}
