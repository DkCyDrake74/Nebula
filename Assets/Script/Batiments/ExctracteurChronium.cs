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
    private int reachChronium;
    private int bonusChronium;

    public CameraMovement cameraMovement;

    public Text ChroniumText;
    int ChroniumCount = 0;

    public float ChroniumIncreaseSpeed = 1f;
    private bool isClick;

    [Header("Timer")]
    public float ChroniumTotalTimeInSeconds = 10;
    private float currentTimeInseconds = 0;

    private bool isTimerRunning = false;

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
        ChroniumText.text = "Chronium : " + ChroniumCount.ToString();
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



