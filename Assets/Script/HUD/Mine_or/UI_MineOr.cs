using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MineOr : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject m_MineOr;
    private Button button;
    void Start()
    {
        button = GameObject.Find("ButtonBuildMineOr").GetComponent<Button>();
        button.onClick.AddListener(buttonSelected);
    }

    public void buttonSelected() 
    {
        
        GameObject mineOr = Instantiate(m_MineOr, SpawnPoint.position, SpawnPoint.rotation);
    }
    
}
