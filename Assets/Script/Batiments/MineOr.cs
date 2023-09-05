using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineOr : MonoBehaviour
{
    [Header("Get Component")]
    public GameObject mineOrPrefab;
    public Text LevelText;
    private Button button;
    public GameObject Button;
    public CameraMovement cameraMovement;

    [Header("Gold")]
    public float BonusGoldSpeed = 15;
    public int BonusGold;

    public Text goldText;
    public int goldCount = 0;
    public float goldIncreaseSpeed = 1f;

    [Header("Level / Stage")]
    public int currentLevel = 0;
    public int currentStage = 1;

    [Header("Stats")]
    public int health;
    public int shield;

    bool isClick;
    

    void Start()
    {
       
        health = 0; shield = 0;

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
        if (isClick == true)
        {
            LevelText.text = "Mine d'or niveau : " + currentLevel.ToString() + "\n" + BonusGold.ToString() + " / Sec\n" + "Vie : " + health.ToString() + " Bouclier" + shield.ToString();
        }
    }

    private void OnMouseDown()
    {
        if (isClick == false)
        {
            LevelText.gameObject.SetActive(true);
            isClick = true;
            button.gameObject.SetActive(true);
            cameraMovement.canMove = false;

        }
        else 
        {
            LevelText.gameObject.SetActive(false);
            isClick = false;
            button.gameObject.SetActive(false);
            cameraMovement.canMove = true;
            
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
            health = 50;
            shield = 50;

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
