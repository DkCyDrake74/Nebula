using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public MineOr mineOr;
    public Text goldText;
    public int goldCount = 0;
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

        {
            int goldCounter = mineOr.BonusGold;
            goldCount = goldCount + goldCounter;
            Debug.Log(goldCounter);
        } 
    }
   

}
