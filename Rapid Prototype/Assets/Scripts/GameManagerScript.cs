using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject Playb;
    public GameObject Shopb;
    public GameObject Scoreb;
    public GameObject GameCanvas;
    public GameObject ShopCanvas;
    public GameObject ConstCanvas;
    public GameObject GamePitch;
    PlaneMovement pm;
    public GameObject GameBall;
    Proto bm;
    public bool isPaused = true;
    public Scene shopScene;
    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        ConstCanvas.SetActive(true);
        pm = GamePitch.GetComponent<PlaneMovement>();
        pm.canMove = false;
        bm = GameBall.GetComponent<Proto>();
        bm.canMove = false;

        //Playb.GetComponent<RectTransform>().position = new Vector3(0f, 336.27f, 0f);
        //Shopb.GetComponent<RectTransform>().position = new Vector3(0f, 118.3f, 0f);
        //Scoreb.GetComponent<RectTransform>().position = new Vector3(-103.2f, -170.6f, -50f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        PauseCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        isPaused = false;
        pm.canMove = true;
        bm.canMove = true;
    }

    public void ShopButton()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void GamePause()
    {
        PauseCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        isPaused = true;
        pm.canMove = false;
        bm.canMove = false;
    }
}
