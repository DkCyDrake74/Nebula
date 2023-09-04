using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Build_Manager : MonoBehaviour
{
    private Button button;
    public GameObject ButtonBuild;
    private bool isOn = false;
    void Start()
    {
       button = GameObject.Find("ButtonMenu").GetComponent<Button>();
       button.onClick.AddListener(buttonSelected);
       
    }  

    public void buttonSelected()
    {
        if (isOn == false) 
          { 
            
            ButtonBuild.SetActive(true);
            isOn = true;
          }
        else
          {
           
            ButtonBuild.SetActive(false);
            isOn = false;
          }
    }

    void OnDisable()
    {
        
        button.onClick.RemoveListener(buttonSelected);
    }


}
