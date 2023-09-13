using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReserveOr : MonoBehaviour
{
    public MineOr mineOr;
    public CameraMovement cameraMovement;

    public Text reserveOrLevelText;
    public Text reserveOrUpgradeButton;
    public Text reserveOrTimerBar;
    public Slider reserveOrSlider;
    public Image reserveOrTimeBarImage;

    public int limitGold;
    
    private bool isFull;
    private bool isClick;

    private int currentGold;
    void Start()
    {
        currentGold = mineOr.goldCount;
    }

    
    void Update()
    {
        currentGold = mineOr.goldCount;
        string formatedCurrentGold = currentGold > 10000 ? (currentGold / 1000).ToString() + "K" : currentGold.ToString();
        CheckGold();
        Debug.Log(isFull);
        if (isClick == true)
        {
            reserveOrLevelText.text = formatedCurrentGold.ToString();
        }
    }

    private void OnMouseDown()
    {
        if (isClick == false) 
        {
            reserveOrLevelText.gameObject.SetActive(true);
            cameraMovement.canMove = false;
            isClick = true;
        
        }
        else
        {
            reserveOrLevelText.gameObject.SetActive(false);
            cameraMovement.canMove = true;
            isClick = false;
        }
    }

    private void CheckGold()
    {
        if (currentGold <= limitGold) 
        {
            isFull = false;
        }
        else  
        {
          isFull=true;
        }
    }
}
