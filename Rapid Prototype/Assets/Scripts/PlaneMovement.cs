using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    Vector3 rot;
    public bool canMove;

    public Mesh mesh1;
    public Mesh mesh2;
    MeshFilter mf;
    MeshCollider mc;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;

        mf = this.GetComponent<MeshFilter>();
        mc = this.GetComponent<MeshCollider>();
        int chosenField = PlayerPrefs.GetInt("chosenField");
        if (chosenField == 2)
        {
            mf.mesh = mesh2;
            mc.sharedMesh = mesh2;
        }
        else
        {
            mf.mesh = mesh1;
            mc.sharedMesh = mesh1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rot.x = -Input.gyro.rotationRateUnbiased.x;
        //Debug.Log(transform.rotation.x);

        if (((rot.x > 0 && transform.rotation.x < 0.15f) || (rot.x < 0 && transform.rotation.x > -0.15f)) && canMove == true)
        {
            transform.Rotate(rot / 5f);
        }

        //rot.x = 0.0f;

        //rot.z = -Input.gyro.rotationRate.z;
        //transform.Rotate(rot / 5f);

    }
}
