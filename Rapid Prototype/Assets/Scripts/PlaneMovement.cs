using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneMovement : MonoBehaviour
{
    Vector3 rot;
    public bool canMove;

    public Mesh mesh1;
    public MeshCollider collider1;
    public Mesh mesh2;
    public MeshCollider collider2;
    public Mesh mesh3;
    public MeshCollider collider3;
    public Mesh mesh4;
    public MeshCollider collider4;
    public Mesh mesh5;
    public MeshCollider collider5;
    public int fieldScore;
    MeshFilter mf;
    MeshCollider mc;
    int chosenField;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;

        mf = this.GetComponent<MeshFilter>();
        mc = this.GetComponent<MeshCollider>();

        chosenField = PlayerPrefs.GetInt("chosenField");

        mc.enabled = false;
        collider1.enabled = false;
        collider2.enabled = false;
        collider3.enabled = false;
        collider4.enabled = false;
        collider5.enabled = false;
        switch (chosenField)
        {
            case 0 or 1:
                mf.mesh = mesh1;
                //mc.sharedMesh = mesh1;
                collider1.enabled = true;
                chosenField = 1;
                break;
            case 2:
                mf.mesh = mesh2;
                //mc.sharedMesh = mesh2;
                collider2.enabled = true;
                break;
            case 3:
                mf.mesh = mesh3;
                //mc.sharedMesh = mesh3;
                collider3.enabled = true;
                break;
            case 4:
                mf.mesh = mesh4;
                //mc.sharedMesh = mesh4;
                collider4.enabled = true;
                break;
            case 5:
                mf.mesh = mesh5;
                //mc.sharedMesh = mesh5;
                collider5.enabled = true;
                break;

            default:
                mf.mesh = mesh1;
                collider1.enabled = true;
                chosenField = 1;
                break;
        }
        fieldScore = chosenField;
    }

    // Update is called once per frame
    void Update()
    {
        rot.x = -Input.gyro.rotationRateUnbiased.x;
        //Debug.Log(transform.rotation.x);

        if (((rot.x > 0 && transform.rotation.x < 0.3f) || (rot.x < 0 && transform.rotation.x > -0.3f)) && canMove == true)
        {
            transform.Rotate(rot / 5f);
        }

        //switch (chosenField)
        //{
        //    case 1:
        //        mf.mesh = mesh1;
        //        mc.sharedMesh = mesh1;
        //        break;
        //    case 2:
        //        mf.mesh = mesh2;
        //        mc.sharedMesh = mesh2;
        //        break;
        //    case 3:
        //        mf.mesh = mesh3;
        //        mc.sharedMesh = mesh3;
        //        break;
        //    case 4:
        //        mf.mesh = mesh4;
        //        mc.sharedMesh = mesh4;
        //        break;
        //    case 5:
        //        mf.mesh = mesh5;
        //        mc.sharedMesh = mesh5;
        //        break;

        //    default:
        //        mf.mesh = defaultMesh;
        //        mc.sharedMesh = defaultMesh;
        //        chosenField = 1;
        //        break;
        //}
        //rot.x = 0.0f;

        //rot.z = -Input.gyro.rotationRate.z;
        //transform.Rotate(rot / 5f);

    }
}
