using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MineOr : MonoBehaviour
{
    [Header("Get Component")]
    public GameObject mineOrPrefab;
    public Text LevelText;
    public Text goldUpgradeButton;
    public Text TimerBar;
    public Slider slider;
    public Image timeBarImage;
    private Button button;
    public GameObject Button;
    public CameraMovement cameraMovement;

    [Header("Gold")]
    public float BonusGoldSpeed = 15;
    public int BonusGold;

    public Text goldText;
    public int goldCount = 0;
    public float goldIncreaseSpeed = 1f;

    int reachGold = 100;

    [Header("Level / Stage")]
    public int currentLevel = 0;
    public int currentStage = 1;

    [Header("Stats")]
    public int health;
    public int shield;

    private int hours;
    private int minutes;
    private int seconds;

    public float totalTime = 10;
    private float currentTimeInseconds = 0;
    
    private bool isTimerRunning = false;

    bool isClick;
    private bool timerBarIsActive = false;
    

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
        string formatedGoldCount = goldCount > 10000 ? (goldCount / 1000).ToString() + "K" : goldCount.ToString();
        goldText.text = formatedGoldCount.ToString();
        goldProduction();
        if (isClick == true)
        {
            LevelText.text = "Mine d'or niveau : " + currentLevel.ToString() + "\n" + BonusGold.ToString() + " / Sec\n" + "Vie : " + health.ToString() + " Bouclier" + shield.ToString();
            goldUpgradeButton.text = "Upgrade : " + formatedGoldCount.ToString() + " / " + reachGold.ToString();
        }

        if (goldCount < reachGold)
        { 
          goldUpgradeButton.color = Color.red;
        }
        else
        {
            goldUpgradeButton.color = Color.green;
        }

        if (isTimerRunning == true) 
        {
            currentTimeInseconds += Time.deltaTime;
            float progress = currentTimeInseconds / totalTime;
            timeBarImage.rectTransform.localScale = new Vector3(progress, 1f, 0.5f);
            timeBarImage.fillAmount = progress;
            slider.value = progress;
            timerBarIsActive = true;
            
            if (currentTimeInseconds >= totalTime)
            {
                StopTimer();
                timerBarIsActive = false;
            }
            hours = (int)(currentTimeInseconds / 3600);
            minutes = (int)((currentTimeInseconds % 3600) / 60);
            seconds = (int)(currentTimeInseconds % 60);
            
        }

        if (timerBarIsActive == true) 
        {
          TimerBar.gameObject.SetActive(true);
          int integerTime = Mathf.RoundToInt(currentTimeInseconds);
          TimerBar.text = "Temps : "+ hours.ToString() + " Hrs " + minutes.ToString() + " Min " + seconds.ToString() + " Sec" + " / " + totalTime.ToString() + " Sec";
        }
        else
        {
          TimerBar.gameObject.SetActive (false);
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
        
        
        if (goldCount >= reachGold)
        {
            goldCount = goldCount - reachGold;
            StartTimer();
        }
    } 

    void IncreaseGold()
    {
        if (isTimerRunning == false) 
        {
            goldCount = goldCount + BonusGold;
            ResetTimer();
            
        }
    }

    public void goldProduction()
    {
       
    }


    void increaseLevel()
    {
                             
                currentLevel++;
                
                reachGold = reachGold * 4;
                BonusGold = BonusGold * 2;
                totalTime = totalTime * 2;

                health = health + 10;
                shield = shield + 10;
            
        
    }

    void increaseStage()
    {
      
    }

    void getGoldCount()
    {
        
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer() 
    {
      isTimerRunning=false;
        increaseLevel();
    }

    public void ResetTimer()
    {
        currentTimeInseconds = 0.0f;
    }



}
