using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class MineralDeposit : MonoBehaviour
{
    public enum Minerals
    {
        COAL,
        IRON,
        ELECTRUM,
    }

    public int resourceQuantity = 100;
    public Minerals mineralType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int extractMineral(int quantityToExtract)
    {
        int quantityToGive = Math.Min(quantityToExtract, resourceQuantity);
        resourceQuantity -= quantityToGive;
        return quantityToGive;
    }

    public bool hasMinerals()
    {
        return resourceQuantity > 0;
    }
}
