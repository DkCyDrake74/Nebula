using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveOr : MonoBehaviour
{
    public MineOr mineOr;

    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log(mineOr.goldCount);
    }
}
