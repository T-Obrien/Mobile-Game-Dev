using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    Scoreboard sb;
    public GameObject scoreBoard;
    public PlaneMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        sb = scoreBoard.GetComponent<Scoreboard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(UnityEngine.Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Score!");
            collision.transform.position = new Vector3(0.0f, -11.0f, 0.0f);
            sb.score += pm.fieldScore;
            Handheld.Vibrate();
            //Scoreboard.SetText("Score: " + Score);
        }
    }
}
