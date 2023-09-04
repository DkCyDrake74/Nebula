using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineOr : MonoBehaviour
{
    public GameObject mineOrPrefab;
    public Text LevelText;
    private Button button;
    public GameObject Button;

    public float BonusGoldSpeed = 15;
    public int BonusGold;
    public int test = 10;

    public int currentLevel = 0;
    public int currentStage = 1;

    public Text goldText;
    public int goldCount = 0;
    public float goldIncreaseSpeed = 1f;

    bool isClick;
    

  

    void Start()
    {
       
        isClick = false;
        InvokeRepeating("IncreaseGold", goldIncreaseSpeed, goldIncreaseSpeed);
        button = GameObject.Find("GoldUpgradeButton").GetComponent<Button>();
        button.onClick.AddListener(GoldButtonSelected);
        button.gameObject.SetActive(false);

    }



    public void Update()
    {
        goldText.text = "Gold : " + goldCount.ToString();
        goldProduction();
        Debug.Log(BonusGold);
        
    }

    private void OnMouseDown()
    {
        if (isClick == false)
        {
            LevelText.gameObject.SetActive(true);
            LevelText.text = "Mine d'or niveau : " + currentLevel.ToString() + "\n" + BonusGold.ToString() + "/ Sec";
            isClick = true;
            button.gameObject.SetActive(true);
            
            
        }
        else 
        {
            LevelText.gameObject.SetActive(false);
            isClick = false;
            button.gameObject.SetActive(false);
            
            
        }

    }

    void GoldButtonSelected()
    {
        clickUpgradeButton();
    }

    void OnDisable()
    {

        button.onClick.RemoveListener(GoldButtonSelected);
    }

    void clickUpgradeButton()
    {
        currentLevel++;
    }

    void IncreaseGold()
    {

        {
            goldCount = goldCount + BonusGold;
            
        }
    }

    public void goldProduction()
      {
        if (currentLevel == 0)
        {
            BonusGold = 5;
           
        }

        else if (currentLevel == 1)
        {
            BonusGold = 10;             
            
        }
        else if (currentLevel == 2)
        {
            BonusGold = 20;

        }
    }


    void increaseLevel()
    {
          
    }

    void increaseStage()
    {
      
    }

    void getGoldCount()
    {
        
    }





}
