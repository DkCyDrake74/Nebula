using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text goldText;
    int goldCount = 0;
    public float goldIncreaseSpeed = 1f;
    void Start()
    {
        
        InvokeRepeating("IncreaseGold", goldIncreaseSpeed, goldIncreaseSpeed);
    }

   
    void Update()
    {
        goldText.text = "Gold : " + goldCount.ToString();

    }

    void IncreaseGold()
    {
     goldCount = goldCount + 5;
    }
}
