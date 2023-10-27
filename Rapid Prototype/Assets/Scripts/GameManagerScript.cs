using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject PauseCanvas;
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
