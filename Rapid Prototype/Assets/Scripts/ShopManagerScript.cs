using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject ConstCanvas;
    public GameObject FieldCanvas;
    public GameObject BallCanvas;
    public GameObject displayBall;
    DisplayBall db;
    public GameObject displayField;
    DisplayField df;
    public GameObject priceBoard;
    ItemCost ic;
    public GameObject scoreboard;
    Scoreboard sb;
    public GameObject pointsPer;
    TextMeshProUGUI ppt;

    
    public int itemEquipped;
    public GameObject equippedText;

    int chosenBall;
    int chosenField;
    // Start is called before the first frame update
    void Start()
    {
        MenuCanvas.SetActive(true);
        ConstCanvas.SetActive(true);
        FieldCanvas.SetActive(false);
        BallCanvas.SetActive(false);
        priceBoard.SetActive(false);
        equippedText.SetActive(false);
        pointsPer.SetActive(false);
        db = displayBall.GetComponent<DisplayBall>();
        df = displayField.GetComponent<DisplayField>();
        ic = priceBoard.GetComponent<ItemCost>();
        sb = scoreboard.GetComponent<Scoreboard>();
        ppt = pointsPer.GetComponent<TextMeshProUGUI>();

        chosenBall = PlayerPrefs.GetInt("chosenBall");
        switch (chosenBall)
        {
            case 1:
                db.currentMat = db.mat1;
                break;
            case 2:
                db.currentMat = db.mat2;
                break;
            case 3:
                db.currentMat = db.mat3;
                break;
        }

        chosenField = PlayerPrefs.GetInt("chosenField");
        switch (chosenField)
        {
            case 1:
                df.currentMesh = df.mesh1;
                break;
            case 2:
                df.currentMesh = df.mesh2;
                break;
            case 3:
                df.currentMesh = df.mesh3;
                break;
            case 4:
                df.currentMesh = df.mesh4;
                break;
            case 5:
                df.currentMesh = df.mesh5;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(df.whichMesh);
        DisplayCost();
    }

    public void BallButton()
    {
        MenuCanvas.SetActive(false);
        FieldCanvas.SetActive(false);
        BallCanvas.SetActive(true);
        displayBall.SetActive(true);
        displayField.SetActive(false);
        priceBoard.SetActive(true);
        pointsPer.SetActive(false);
        if (db.currentMat == db.mat1)
        {
            db.whichMat = 1;
        }
        if (db.currentMat == db.mat2)
        {
            db.whichMat = 2;
        }
        if (db.currentMat == db.mat3)
        {
            db.whichMat = 3;
        }
        itemEquipped = db.whichMat;
    }

    public void FieldButton()
    {
        MenuCanvas.SetActive(false);
        FieldCanvas.SetActive(true);
        BallCanvas.SetActive(false);
        displayBall.SetActive(false);
        displayField.SetActive(true);
        priceBoard.SetActive(true);
        pointsPer.SetActive(true);

        if (df.currentMesh == df.mesh1)
        {
            df.whichMesh = 1;
        }
        if (df.currentMesh == df.mesh2)
        {
            df.whichMesh = 2;
        }
        if (df.currentMesh == df.mesh3) { df.whichMesh = 3; }
        if (df.currentMesh == df.mesh4) { df.whichMesh = 4; }
        if (df.currentMesh == df.mesh5) { df.whichMesh = 5; }

        itemEquipped = df.whichMesh;
    }

    public void GoBack()
    {
        MenuCanvas.SetActive(true);
        FieldCanvas.SetActive(false);
        BallCanvas.SetActive(false);
        displayBall.SetActive(false);
        displayField.SetActive(false);
        priceBoard.SetActive(false);
        equippedText.SetActive(false);
        pointsPer.SetActive(false);
    }

    public void RightSelect()
    {
        if (FieldCanvas.activeSelf == true && df.whichMesh < 5)
        {
            df.whichMesh += 1;
        }

        if (BallCanvas.activeSelf == true && db.whichMat < 3)
        {
            db.whichMat += 1;
        }
    }

    public void LeftSelect()
    {
        if (FieldCanvas.activeSelf == true && df.whichMesh > 1)
        {
            df.whichMesh -= 1;
        }

        if (BallCanvas.activeSelf == true && db.whichMat > 1)
        {
            db.whichMat -= 1;
        }
    }

    public void BuyButton()
    {
        if (FieldCanvas.activeSelf == true)
        {
            if (sb.score >= ic.cost && itemEquipped != df.whichMesh)
            {
                sb.score = sb.score - ic.cost;
                switch (df.whichMesh)
                {
                    case 1:
                        df.currentMesh = df.mesh1;
                        chosenField = 1;
                        break;
                    case 2:
                        df.currentMesh = df.mesh2;
                        chosenField = 2;
                        break;
                    case 3:
                        df.currentMesh = df.mesh3;
                        chosenField = 3;
                        break;
                    case 4:
                        df.currentMesh = df.mesh4;
                        chosenField = 4;
                        break;
                    case 5:
                        df.currentMesh = df.mesh5;
                        chosenField = 5;
                        break;
                }
                itemEquipped = df.whichMesh;
            }
        }

        if (BallCanvas.activeSelf == true)
        {
            if (sb.score >= ic.cost && itemEquipped != db.whichMat)
            {
                sb.score = sb.score - ic.cost;
                switch (db.whichMat)
                {
                    case 1:
                        db.currentMat = db.mat1;
                        chosenBall = 1;
                        break;
                    case 2:
                        db.currentMat = db.mat2;
                        chosenBall = 2;
                        break;
                    case 3:
                        db.currentMat = db.mat3;
                        chosenBall = 3;
                        break;
                }
                itemEquipped = db.whichMat;
            }
        }
    }

    public void ExitButton()
    {
        PlayerPrefs.SetInt("chosenBall", chosenBall);
        PlayerPrefs.SetInt("chosenField", chosenField);
        SceneManager.LoadScene("GameScene");        
    }

    public void DisplayCost()
    {
        if (FieldCanvas.activeSelf == true)
        {
            switch (df.whichMesh)
            {
                case 0:
                    break;
                case 1:
                    ic.cost = 0;
                    ppt.SetText("Points Per Shot: " + df.whichMesh);
                    break;
                case 2:
                    ic.cost = 10;
                    ppt.SetText("Points Per Shot: " + df.whichMesh);
                    break;
                case 3:
                    ic.cost = 30;
                    ppt.SetText("Points Per Shot: " + df.whichMesh);
                    break;
                case 4:
                    ic.cost = 60;
                    ppt.SetText("Points Per Shot: " + df.whichMesh);
                    break;
                case 5:
                    ic.cost = 120;
                    ppt.SetText("Points Per Shot: " + df.whichMesh);
                    break;
            }

            if (df.whichMesh == itemEquipped) equippedText.SetActive(true);
            else equippedText.SetActive(false);
        }

        if (BallCanvas.activeSelf == true)
        {
            switch (db.whichMat)
            {
                case 0:
                    break;
                case 1:
                    ic.cost = 0;
                    break;
                case 2:
                    ic.cost = 5;
                    break;
                case 3:
                    ic.cost = 20;
                    break;
            }
            if (db.whichMat == itemEquipped) equippedText.SetActive(true);
            else equippedText.SetActive(false);
        }
    }
}
