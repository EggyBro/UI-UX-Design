using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public enum ShipType
    {
        DESTROYER,
        CRUISER,
        BATTLESHIP
    }
    public ShipType ShipClass;
    public int Wallet;
    public string[] PlayerItems;
    public GameObject Battleship;
    public GameObject Cruiser;
    public GameObject Destroyer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerItems = new string[20];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShipClass = ShipType.DESTROYER;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShipClass = ShipType.CRUISER;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShipClass = ShipType.BATTLESHIP;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (ShipClass == ShipType.DESTROYER)
        {
            Battleship.SetActive(false);
            Cruiser.SetActive(false);
            Destroyer.SetActive(true);
        }
        else if (ShipClass == ShipType.CRUISER)
        {
            Battleship.SetActive(false);
            Cruiser.SetActive(true);
            Destroyer.SetActive(false);
        }
        else if (ShipClass == ShipType.BATTLESHIP)
        {
            Battleship.SetActive(true);
            Cruiser.SetActive(false);
            Destroyer.SetActive(false);
        }
    }
}
