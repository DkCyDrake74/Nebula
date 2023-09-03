using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Build_Manager : MonoBehaviour
{
    private Button button;
    public GameObject ButtonBuild;
    void Start()
    {
       button = GameObject.Find("ButtonMenu").GetComponent<Button>();
       button.onClick.AddListener(buttonSelected);
       
    }  

    public void buttonSelected()
    {
        Debug.Log("Click");
        ButtonBuild.SetActive(true);
    }

    void OnDisable()
    {
        Debug.Log("Remove Listener");
        button.onClick.RemoveListener(buttonSelected);
    }


}
