using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        score = PlayerPrefs.GetInt("currentScore");
    }

    // Update is called once per frame
    void Update()
    {
        txt.SetText("Score: " + score);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("currentScore", score);
    }
}
