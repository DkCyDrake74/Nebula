using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;


public class ExctracteurChronium : MonoBehaviour
{
    public Text chroniumLevelText;
    public Text chroniumUpgradeButton;
    public Text chroniumTimerBar;
    public Slider chroniumSlider;
    public Image chroniumTimeBarImage;

    private Button button;
    public GameObject ChroniumButton;

    public int currentChroniumLevel;
    private int reachChronium = 100;
    public int bonusChronium;

    public CameraMovement cameraMovement;

    public Text ChroniumText;
    int ChroniumCount = 0;

    public float ChroniumIncreaseSpeed = 1f;
    private bool isClick;

    [Header("Stats")]
    public int ChroniumHealth;
    public int ChroniumShield;

    [Header("Timer")]
    public float ChroniumTotalTimeInSeconds = 10;
    private float currentTimeInseconds = 0;

    private bool isTimerRunning = false;

    private bool timerBarIsActive = false;

    private int hours;
    private int minutes;
    private int seconds;

    void Start()
    {
        isClick = false;
        InvokeRepeating("IncreaseChronium", ChroniumIncreaseSpeed, ChroniumIncreaseSpeed);
        button = GameObject.Find("ChroniumUpgradeButton").GetComponent<Button>();
        button.onClick.AddListener(ChroniumButtonSelected);
        button.gameObject.SetActive(false);
    }

    void Update()
    {
        string formatedChroniumCount = ChroniumCount > 10000 ? (ChroniumCount / 1000).ToString() + "K" : ChroniumCount.ToString();
        string formatedReachChronium = reachChronium > 10000 ? (reachChronium / 1000).ToString() + "K" : reachChronium.ToString();
        
        ChroniumText.text = formatedChroniumCount.ToString();

        if  (isClick == true)
        {
            chroniumLevelText.text = "Extracteur de chronium niveau : " + currentChroniumLevel.ToString() + "\n" + bonusChronium.ToString() + " / Sec\n" + "Vie : " + ChroniumHealth.ToString() + " Bouclier : " + ChroniumShield.ToString();
            chroniumUpgradeButton.text = "Upgrade : " + formatedChroniumCount.ToString() + " / " + formatedReachChronium.ToString();
        }
        if (ChroniumCount < reachChronium)
        {
            chroniumUpgradeButton.color = Color.red;
        }
        else
        {
            chroniumUpgradeButton.color = Color.green;
        }

        if (isTimerRunning == true)
        {
            currentTimeInseconds -= Time.deltaTime;
            float progress = currentTimeInseconds / ChroniumTotalTimeInSeconds;
            chroniumTimeBarImage.rectTransform.localScale = new Vector3(progress, 1f, 0.5f);
            chroniumTimeBarImage.fillAmount = progress;
            chroniumSlider.value = progress;
            timerBarIsActive = true;

            if (currentTimeInseconds <= 0)
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
            chroniumTimerBar.gameObject.SetActive(true);
            int integerTime = Mathf.RoundToInt(currentTimeInseconds);
            chroniumTimerBar.text = "Temps : " + hours.ToString() + " Hrs " + minutes.ToString() + " Min " + seconds.ToString() + " Sec";
        }
        else
        {
            chroniumTimerBar.gameObject.SetActive(false);
        }

    }

    private void OnMouseDown()
    {
        if (isClick == false)
        {
            chroniumLevelText.gameObject.SetActive(true);
            isClick = true;
            ChroniumButton.SetActive(true);
            cameraMovement.canMove = false;
        }
        else
        {
            chroniumLevelText.gameObject.SetActive(false);
            isClick = false;
            ChroniumButton.SetActive(false);
            cameraMovement.canMove = true;
        }
    }

    void ChroniumButtonSelected()
    {
        clickUpgradeButton();
    }

    void OnDisable()
    {

        button.onClick.RemoveListener(ChroniumButtonSelected);
    }

    void clickUpgradeButton()
    {


        if (ChroniumCount >= reachChronium)
        {
            ChroniumCount = ChroniumCount - reachChronium;
            StartTimer();
        }
    }

    void IncreaseChronium()
    {
        if (isTimerRunning == false)
        {
            ChroniumCount = ChroniumCount + bonusChronium;
            ResetTimer();

        }
    }

    void increaseLevel()
    {

        currentChroniumLevel++;

        reachChronium = reachChronium * 4;
        bonusChronium = bonusChronium  * 2;
        ChroniumTotalTimeInSeconds = ChroniumTotalTimeInSeconds * 2;

        ChroniumHealth = ChroniumHealth + 5;
        ChroniumShield = ChroniumShield + 5;

    }

    public void StartTimer()
    {
        isTimerRunning = true;
        currentTimeInseconds = ChroniumTotalTimeInSeconds;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        increaseLevel();
    }

    public void ResetTimer()
    {
        currentTimeInseconds = 0f;
    }
}



