using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proto : MonoBehaviour
{
    public Transform playerball;
    public Rigidbody playerRB;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    MeshRenderer mr;
    Vector2 touchStart;
    Vector2 touchEnd;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        mr = this.GetComponent<MeshRenderer>();

        int chosenBall = PlayerPrefs.GetInt("chosenBall");
        if (chosenBall == 2)
        {
            mr.material = mat2;
        }
        else if (chosenBall == 3)
        {
            mr.material = mat3;
        }
        else
        {
            mr.material = mat1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("w"))
        //{
        //    playerball.Translate(-0.1f, 0.0f, 0.0f);
        //}
        //if (Input.GetKey("a"))
        //{
        //    playerball.Translate(0.0f, 0.0f, -0.1f);
        //}
        //if (Input.GetKey("s"))
        //{
        //    playerball.Translate(0.1f, 0.0f, 0.0f);
        //}
        //if (Input.GetKey("d"))
        //{
        //    playerball.Translate(0.0f, 0.0f, 0.1f);
        //}
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchStart = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended && canMove == true)
            {
                touchEnd = Input.GetTouch(0).position;
                if (touchStart.x < touchEnd.x && touchEnd.x - touchStart.x > 20)
                {
                    //Debug.Log(touchStart.x + "   " + touchEnd.x);
                    playerRB.AddForce(0.0f, 0.0f, 10.0f, ForceMode.Impulse);
                }

                if (touchStart.x > touchEnd.x && touchStart.x - touchEnd.x > 20)
                {
                    //Debug.Log("Left");
                    playerRB.AddForce(0.0f, 0.0f, -10.0f, ForceMode.Impulse);
                }

                if (touchStart.y < touchEnd.y && touchEnd.y - touchStart.y > 20)
                {
                    playerRB.AddForce(-10.0f, 0.0f, 0.0f, ForceMode.Impulse);
                }

                if (touchStart.y > touchEnd.y && touchStart.y - touchEnd.y > 20)
                {
                    playerRB.AddForce(10.0f, 0.0f, 0.0f, ForceMode.Impulse);
                }
            }
        }

        //touchStart = new Vector2(0, 0);
        //touchEnd = new Vector2(0, 0);

        if (canMove == false)
        {
            playerRB.velocity = Vector3.zero;
            playerRB.angularVelocity = Vector3.zero;
        }

    }

    public void buttonForward()
    {
        playerball.Translate(-1f, 0.0f, 0.0f);
    }
}
