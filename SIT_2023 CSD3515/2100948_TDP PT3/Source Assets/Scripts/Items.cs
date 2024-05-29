using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public string ItemName;
    public enum ItemClass
    {
        GEAR,
        CONSUMABLES,
        SENSORS,
        WEAPONS
    }
    public ItemClass ItemType;
    public bool Restricted;
    public int BuyCost;
    public int SaleCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
