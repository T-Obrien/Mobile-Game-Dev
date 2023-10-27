using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCost : MonoBehaviour
{
    public int cost;
    TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.SetText("Cost: " + cost);
    }
}
