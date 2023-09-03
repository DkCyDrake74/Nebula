using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChroniumManager : MonoBehaviour
{
    public Text ChroniumText;
    int ChroniumCount = 0;
    public float ChroniumIncreaseSpeed = 1f;

    void Start()
    {
        InvokeRepeating("IncreaseChronium", ChroniumIncreaseSpeed, ChroniumIncreaseSpeed);
    }

    
    void Update()
    {
        ChroniumText.text = "Chronium : " + ChroniumCount.ToString();
    }

    void IncreaseChronium()
    {
        ChroniumCount = ChroniumCount + 5;
    }
}
