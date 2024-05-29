using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;


public class BuyShopController : MonoBehaviour
{
    public bool isActive;
    //assigned in Inspector
    public UIDocument doc;
    //UI doc root
    private VisualElement _root;
    private VisualElement shopMain;
    private VisualElement background;
    private VisualElement textBar;

    private Label shopKeepText;
    private Label buySellText;
    private Label playerCurrency;
    private Label confirmationText;
    private Label warningText;

    private bool buySell; //false: buy, true: sell
    private bool warning;

    private int idx;

    private int topBarIdx;
    private int barIdx;
    private int pageIdx;

    private bool sellConfirm;
    private bool confirm;
    private int deduction;
    private string item;
    private int playerItemIdx;

    private VisualElement topBar1;
    private VisualElement topBar2;
    private VisualElement topBar3;
    private VisualElement topBar4;
    private VisualElement bar1;
    private VisualElement bar2;
    private VisualElement bar3;
    private VisualElement bar4;
    private VisualElement bar5;
    private VisualElement bar6;
    private VisualElement sideBar;
    private VisualElement confirmationBox;
    private VisualElement warningBox;

    private StyleColor translucentWhite = new Color(1, 1, 1, 0.15f);
    private StyleColor translucentBlack = new Color(0, 0, 0, 0.75f);
    private StyleColor transparent = new Color(0, 0, 0, 0);

    private StyleBackground blank;
    public Texture2D CSMDecoy;
    public Texture2D CSMDecoyB;
    public Texture2D CSMDecoyS;
    public Texture2D CSMHull;
    public Texture2D CSMHullB;
    public Texture2D CSMHullS;
    public Texture2D CSMTarget;
    public Texture2D CSMTargetB;
    public Texture2D CSMTargetS;
    public Texture2D CSMDrive;
    public Texture2D CSMDriveB;
    public Texture2D CSMDriveS;
    public Texture2D CSMComms;
    public Texture2D CSMCommsS;
    public Texture2D CSMReactor;
    public Texture2D CSMReactorS;

    public Texture2D GRCS;
    public Texture2D GRCSB;
    public Texture2D GRCSS;
    public Texture2D GRCSAdvanced;
    public Texture2D GRCSAdvancedB;
    public Texture2D GRCSAdvancedS;
    public Texture2D BBEngines;
    public Texture2D BBEnginesB;
    public Texture2D BBEnginesS;
    public Texture2D CRBBEngines;
    public Texture2D CRBBEnginesB;
    public Texture2D CRBBEnginesS;
    public Texture2D DDCREngines;
    public Texture2D DDCREnginesB;
    public Texture2D DDCREnginesS;
    public Texture2D DDEngines;
    public Texture2D DDEnginesB;
    public Texture2D DDEnginesS;

    public Texture2D RadBas;
    public Texture2D RadBasB;
    public Texture2D RadBasS;
    public Texture2D BBRad;
    public Texture2D BBRadB;
    public Texture2D BBRadS;
    public Texture2D CRRad;
    public Texture2D CRRadB;
    public Texture2D CRRadS;
    public Texture2D LPRad;
    public Texture2D LPRadB;
    public Texture2D LPRadS;
    public Texture2D DDrad;
    public Texture2D DDradB;
    public Texture2D DDradS;
    public Texture2D Command;
    public Texture2D CommandS;

    public Texture2D DEW;
    public Texture2D DEWB;
    public Texture2D DEWS;
    public Texture2D DPGun;
    public Texture2D DPGunB;
    public Texture2D DPGunS;
    public Texture2D PDC;
    public Texture2D PDCB;
    public Texture2D PDCS;
    public Texture2D PDEW;
    public Texture2D PDEWB;
    public Texture2D PDEWS;
    public Texture2D SingleGun;
    public Texture2D SingleGunB;
    public Texture2D SingleGunS;
    public Texture2D BBEW;
    public Texture2D BBEWB;
    public Texture2D BBEWS;
    public Texture2D BBGuns;
    public Texture2D BBGunsB;
    public Texture2D BBGunsS;
    public Texture2D BBRail;
    public Texture2D BBRailB;
    public Texture2D BBRailS;
    public Texture2D CREW;
    public Texture2D CREWB;
    public Texture2D CREWS;
    public Texture2D CRGuns;
    public Texture2D CRGunsB;
    public Texture2D CRGunsS;
    public Texture2D CRRail;
    public Texture2D CRRailB;
    public Texture2D CRRailS;
    public Texture2D DDEW;
    public Texture2D DDEWB;
    public Texture2D DDEWS;
    public Texture2D DDGuns;
    public Texture2D DDGunsB;
    public Texture2D DDGunsS;
    public Texture2D DDRail;
    public Texture2D DDRailB;
    public Texture2D DDRailS;

    //awake
    private void Awake()
    {
        //retrieve UI doc root
        _root = doc.rootVisualElement;
        idx = 0;
        topBarIdx = 0;
        barIdx = 0;
        pageIdx = 0;
        shopMain = _root.Q<VisualElement>("MAIN");
        shopMain.visible = false;
        isActive = false;

        background = _root.Q<VisualElement>("BACKGROUND");
        textBar = _root.Q<VisualElement>("TEXTBAR");

        shopKeepText = _root.Q<Label>("SHOPKEEP");

        playerCurrency = _root.Q<Label>("CURRENCY");
        playerCurrency.visible = false;

        buySellText = _root.Q<Label>("BUYSELL");
        buySellText.visible = false;

        confirmationText = _root.Q<Label>("CONFIRMATIONTEXT");
        warningText = _root.Q<Label>("WARNINGTEXT");

        topBar1 = _root.Q<VisualElement>("TOP1");
        topBar2 = _root.Q<VisualElement>("TOP2");
        topBar3 = _root.Q<VisualElement>("TOP3");
        topBar4 = _root.Q<VisualElement>("TOP4");
        bar1 = _root.Q<VisualElement>("BAR1");
        bar2 = _root.Q<VisualElement>("BAR2");
        bar3 = _root.Q<VisualElement>("BAR3");
        bar4 = _root.Q<VisualElement>("BAR4");
        bar5 = _root.Q<VisualElement>("BAR5");
        bar6 = _root.Q<VisualElement>("BAR6");
        sideBar = _root.Q<VisualElement>("SIDE");
        confirmationBox = _root.Q<VisualElement>("BUYSELLCONFIRMATION");
        confirmationBox.visible = false;

        warningBox = _root.Q<VisualElement>("WARNINGBOX");
        warningBox.visible = false;
        warning = false;
        confirm = false;
        sellConfirm = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //shopMain = _root.Q<VisualElement>("MAIN");
        //shopMain.visible = false;

        //shopKeepText = _root.Q<Label>("SHOPKEEP");

        //playerCurrency = _root.Q<Label>("CURRENCY");
        //playerCurrency.visible = false;

        //buySellText = _root.Q<Label>("BUYSELL");
        //buySellText.visible = false;

        //confirmationText = _root.Q<Label>("CONFIRMATIONTEXT");
        //warningText = _root.Q<Label>("WARNINGTEXT");

        //topBar1 = _root.Q<VisualElement>("TOP1");
        //topBar2 = _root.Q<VisualElement>("TOP2");
        //topBar3 = _root.Q<VisualElement>("TOP3");
        //topBar4 = _root.Q<VisualElement>("TOP4");
        //bar1 = _root.Q<VisualElement>("BAR1");
        //bar2 = _root.Q<VisualElement>("BAR2");
        //bar3 = _root.Q<VisualElement>("BAR3");
        //bar4 = _root.Q<VisualElement>("BAR4");
        //bar5 = _root.Q<VisualElement>("BAR5");
        //bar6 = _root.Q<VisualElement>("BAR6");
        //sideBar = _root.Q<VisualElement>("SIDE");
        //confirmationBox = _root.Q<VisualElement>("BUYSELLCONFIRMATION");
        //confirmationBox.visible = false;

        //warningBox = _root.Q<VisualElement>("WARNINGBOX");
        //warningBox.visible = false;
        //warning = false;
        //confirm = false;
        //sellConfirm = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet += 100000;
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet += 100;
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet = 0;
            }
            background.visible = true;
            Debug.Log(idx);
            playerCurrency.text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet + " GP";
            if (warning == true)
            {
                warningBox.visible = true;
                if (Input.GetKeyDown(KeyCode.P))
                {
                    warningBox.visible = false;
                    warning = false;
                }
            }
            else if (confirm == true)
            {
                confirmationBox.visible = true;
                if (Input.GetKeyDown(KeyCode.P))
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet -= deduction;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[playerItemIdx] = item;
                    confirm = false;
                    confirmationBox.visible = false;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    confirm = false;
                    confirmationBox.visible = false;
                }
            }
            else if (sellConfirm == true)
            {
                confirmationBox.visible = true;
                if (Input.GetKeyDown(KeyCode.P))
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet += deduction;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[playerItemIdx] = null;
                    sellConfirm = false;
                    confirmationBox.visible = false;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    sellConfirm = false;
                    confirmationBox.visible = false;
                }
            }
            else
            {
                if (idx == 0)
                {
                    textBar.visible = true;
                    shopKeepText.text = "So, dear friend, what trouble did you encounter this time?";
                    buySellText.visible = true;
                    buySellText.text = "    Continue P";
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        idx++;
                    }
                }
                if (idx == 1)
                {
                    shopKeepText.text = "A man of few words eh? Well, doesn't matter as long as your money's good.";
                    buySellText.visible = true;
                    buySellText.text = "Q Exit | I Buy | Sell O";
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        idx = 2;
                        buySell = false;
                        shopMain.visible = true;
                        playerCurrency.visible = true;
                    }
                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        idx = 2;
                        buySell = true;
                        shopMain.visible = true;
                        playerCurrency.visible = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        idx = 3;
                    }
                }
                if (idx == 2)
                {
                    if (buySell == false)
                    {
                        shopKeepText.text = "You'll be buying top of the line military grade equipment! Best in the black market!";
                        buySellText.text = "Q Exit | P Buy | Sell O";
                        if (Input.GetKeyDown(KeyCode.O))
                        {
                            buySell = true;
                            topBarIdx = 0;
                            barIdx = 0;
                            pageIdx = 0;
                        }
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            idx = 3;
                        }
                        if (topBarIdx == 0)
                        {
                            topBar1.style.backgroundColor = translucentWhite;
                            topBar2.style.backgroundColor = transparent;
                            topBar3.style.backgroundColor = transparent;
                            topBar4.style.backgroundColor = transparent;
                            if (Input.GetKeyDown(KeyCode.D))
                            {
                                topBarIdx = 1;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (pageIdx == 0)
                            {
                                bar1.style.backgroundImage = CSMDecoyB;
                                bar2.style.backgroundImage = CSMHullB;
                                bar3.style.backgroundImage = CSMTargetB;
                                bar4.style.backgroundImage = CSMDriveB;
                                bar5.style.backgroundImage = blank;
                                bar6.style.backgroundImage = blank;
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CSMDecoy;
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 100)
                                        {
                                            int full = 20;
                                            for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                            {
                                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                {
                                                    full = i;
                                                    break;
                                                }
                                            }
                                            if (full < 20)
                                            {
                                                confirmationBox.visible = true;
                                                confirmationText.text = "Buy Decoys for 100 GP?";
                                                deduction = 100;
                                                item = "Decoy";
                                                playerItemIdx = full;
                                                confirm = true;
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "You've got a little too much in your hold there mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CSMHull;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 50)
                                        {
                                            int full = 20;
                                            for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                            {
                                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                {
                                                    full = i;
                                                    break;
                                                }
                                            }
                                            if (full < 20)
                                            {
                                                confirmationBox.visible = true;
                                                confirmationText.text = "Buy Hull Repair Plating for 50 GP?";
                                                deduction = 50;
                                                item = "Hull";
                                                playerItemIdx = full;
                                                confirm = true;
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "You've got a little too much in your hold there mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CSMTarget;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 1500)
                                        {
                                            int full = 20;
                                            for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                            {
                                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                {
                                                    full = i;
                                                    break;
                                                }
                                            }
                                            if (full < 20)
                                            {
                                                confirmationBox.visible = true;
                                                confirmationText.text = "Buy Targeting Module for 1500 GP?";
                                                deduction = 1500;
                                                item = "TargetMod";
                                                playerItemIdx = full;
                                                confirm = true;
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "You've got a little too much in your hold there mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CSMDrive;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    //if (Input.GetKeyDown(KeyCode.S))
                                    //{
                                    //    barIdx = 4;
                                    //}
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 200)
                                        {
                                            int full = 20;
                                            for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                            {
                                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                {
                                                    full = i;
                                                    break;
                                                }
                                            }
                                            if (full < 20)
                                            {
                                                confirmationBox.visible = true;
                                                confirmationText.text = "Buy Turret Drive for 200 GP?";
                                                deduction = 200;
                                                item = "Drive";
                                                playerItemIdx = full;
                                                confirm = true;
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "You've got a little too much in your hold there mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                //else if (barIdx == 4)
                                //{
                                //    bar1.style.backgroundColor = transparent;
                                //    bar2.style.backgroundColor = transparent;
                                //    bar3.style.backgroundColor = transparent;
                                //    bar4.style.backgroundColor = transparent;
                                //    bar5.style.backgroundColor = translucentWhite; 
                                //    bar6.style.backgroundColor = transparent;
                                //    if (Input.GetKeyDown(KeyCode.W))
                                //    {
                                //        barIdx = 3;
                                //    }
                                //    if (Input.GetKeyDown(KeyCode.S))
                                //    {
                                //        barIdx = 5;
                                //    }
                                //}
                                //else if (barIdx == 5)
                                //{
                                //    bar1.style.backgroundColor = transparent;
                                //    bar2.style.backgroundColor = transparent;
                                //    bar3.style.backgroundColor = transparent;
                                //    bar4.style.backgroundColor = transparent;
                                //    bar5.style.backgroundColor = transparent;
                                //    bar6.style.backgroundColor = translucentWhite; 
                                //    if (Input.GetKeyDown(KeyCode.W))
                                //    {
                                //        barIdx = 4;
                                //    }
                                //}
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 100)
                            {
                                bar1.style.backgroundColor = translucentBlack;
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 50)
                            {
                                bar2.style.backgroundColor = translucentBlack;
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 1500)
                            {
                                bar3.style.backgroundColor = translucentBlack;
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 200)
                            {
                                bar4.style.backgroundColor = translucentBlack;
                            }

                        }
                        else if (topBarIdx == 1)
                        {
                            topBar1.style.backgroundColor = transparent;
                            topBar2.style.backgroundColor = translucentWhite;
                            topBar3.style.backgroundColor = transparent;
                            topBar4.style.backgroundColor = transparent;
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                topBarIdx = 0;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (Input.GetKeyDown(KeyCode.D))
                            {
                                topBarIdx = 2;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (pageIdx == 0)
                            {
                                bar1.style.backgroundImage = GRCSB;
                                bar2.style.backgroundImage = GRCSAdvancedB;
                                bar3.style.backgroundImage = BBEnginesB;
                                bar4.style.backgroundImage = CRBBEnginesB;
                                bar5.style.backgroundImage = DDCREnginesB;
                                bar6.style.backgroundImage = DDEnginesB;
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = GRCS;
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 2500)
                                        {
                                            int full = 20;
                                            for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                            {
                                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                {
                                                    full = i;
                                                    break;
                                                }
                                            }
                                            if (full < 20)
                                            {
                                                confirmationBox.visible = true;
                                                confirmationText.text = "Buy Basic RCS for 2500 GP?";
                                                deduction = 2500;
                                                item = "BRCS";
                                                playerItemIdx = full;
                                                confirm = true;
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "You've got a little too much in your hold there mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = GRCSAdvanced;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 3000)
                                        {
                                            int full = 20;
                                            for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                            {
                                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                {
                                                    full = i;
                                                    break;
                                                }
                                            }
                                            if (full < 20)
                                            {
                                                confirmationBox.visible = true;
                                                confirmationText.text = "Buy Advanced RCS for 3000 GP?";
                                                deduction = 3000;
                                                item = "ARCS";
                                                playerItemIdx = full;
                                                confirm = true;
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "You've got a little too much in your hold there mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = BBEngines;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 8000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.BATTLESHIP)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Heavy Thrusters for 8000 GP?";
                                                    deduction = 8000;
                                                    item = "BBEngines";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "These engines are a little overkill for anything smaller than a battleship my friend.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CRBBEngines;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 7600)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.BATTLESHIP || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.CRUISER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Large X Thrusters for 7600 GP?";
                                                    deduction = 7600;
                                                    item = "CRXEngines";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 4)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = translucentWhite;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DDCREngines;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 5;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 7000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.CRUISER || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.DESTROYER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Advanced Engines for 7000 GP?";
                                                    deduction = 7000;
                                                    item = "EnginesA";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 5)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = translucentWhite;
                                    sideBar.style.backgroundImage = DDEngines;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 6400)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.DESTROYER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy High Thrust Engines for 6400 GP?";
                                                    deduction = 6400;
                                                    item = "EnginesHT";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "You do realise that this part is not gonna work on larger ships right?";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 2500)
                            {
                                bar1.style.backgroundColor = translucentBlack;
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 3000)
                            {
                                bar2.style.backgroundColor = translucentBlack;
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 8000)
                            {
                                bar3.style.backgroundColor = translucentBlack;
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 7600)
                            {
                                bar4.style.backgroundColor = translucentBlack;
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 7000)
                            {
                                bar5.style.backgroundColor = translucentBlack;
                            }
                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 6400)
                            {
                                bar6.style.backgroundColor = translucentBlack;
                            }
                        }
                        else if (topBarIdx == 2)
                        {
                            topBar1.style.backgroundColor = transparent;
                            topBar2.style.backgroundColor = transparent;
                            topBar3.style.backgroundColor = translucentWhite;
                            topBar4.style.backgroundColor = transparent;
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                topBarIdx = 1;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (Input.GetKeyDown(KeyCode.D))
                            {
                                topBarIdx = 3;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (pageIdx == 0)
                            {
                                bar1.style.backgroundImage = RadBasB;
                                bar2.style.backgroundImage = BBRadB;
                                bar3.style.backgroundImage = CRRadB;
                                bar4.style.backgroundImage = LPRadB;
                                bar5.style.backgroundImage = DDradB;
                                bar6.style.backgroundImage = blank;
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = RadBas;
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 2400)
                                        {
                                            int full = 20;
                                            for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                            {
                                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                {
                                                    full = i;
                                                    break;
                                                }
                                            }
                                            if (full < 20)
                                            {
                                                confirmationBox.visible = true;
                                                confirmationText.text = "Buy Basic Radome for 2400 GP?";
                                                deduction = 2400;
                                                item = "RadB";
                                                playerItemIdx = full;
                                                confirm = true;
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "You've got a little too much in your hold there mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = BBRad;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 6000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.BATTLESHIP)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Battleship Radar for 6000 GP?";
                                                    deduction = 6000;
                                                    item = "BBRad";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I'm pretty sure that power draw is going to burn out your ship's reactor.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CRRad;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 4400)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.CRUISER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Cruiser Radar for 4400 GP?";
                                                    deduction = 4400;
                                                    item = "CRRad";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "It's called a 'Cruiser' radar for a reason.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = LPRad;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 4000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.CRUISER || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.DESTROYER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Low Profile Radar for 4000 GP?";
                                                    deduction = 4000;
                                                    item = "LPRad";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "Does a Battleship look 'Low Profile' to you?";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 4)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = translucentWhite;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DDrad;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 3;
                                    }
                                    //if (Input.GetKeyDown(KeyCode.S))
                                    //{
                                    //    barIdx = 5;
                                    //}
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 3000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.DESTROYER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Standard Radar for 3000 GP?";
                                                    deduction = 3000;
                                                    item = "RadS";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                //else if (barIdx == 5)
                                //{
                                //    bar1.style.backgroundColor = transparent;
                                //    bar2.style.backgroundColor = transparent;
                                //    bar3.style.backgroundColor = transparent;
                                //    bar4.style.backgroundColor = transparent;
                                //    bar5.style.backgroundColor = transparent;
                                //    bar6.style.backgroundColor = translucentWhite;
                                //    sideBar.style.backgroundImage = DDEngines;
                                //    if (Input.GetKeyDown(KeyCode.W))
                                //    {
                                //        barIdx = 4;
                                //    }
                                //}
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 2400)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 6000)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 4400)
                                {
                                    bar3.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 4000)
                                {
                                    bar4.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 3000)
                                {
                                    bar5.style.backgroundColor = translucentBlack;
                                }
                            }
                        }
                        else if (topBarIdx == 3)
                        {
                            topBar1.style.backgroundColor = transparent;
                            topBar2.style.backgroundColor = transparent;
                            topBar3.style.backgroundColor = transparent;
                            topBar4.style.backgroundColor = translucentWhite;
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                topBarIdx = 2;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (pageIdx == 0)
                            {
                                bar1.style.backgroundImage = DEWB;
                                bar2.style.backgroundImage = DPGunB;
                                bar3.style.backgroundImage = PDCB;
                                bar4.style.backgroundImage = PDEWB;
                                bar5.style.backgroundImage = SingleGunB;
                                bar6.style.backgroundImage = BBEWB;
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DEW;
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 1000)
                                        {
                                            if (true)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Directed Energy Turret for 1000 GP?";
                                                    deduction = 1000;
                                                    item = "DEW";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                //warningBox.visible = true;
                                                //warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                //warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DPGun;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 1500)
                                        {
                                            if (true)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Dual Purpose Guns for 1500 GP?";
                                                    deduction = 1500;
                                                    item = "DPGuns";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                //warningBox.visible = true;
                                                //warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                //warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = PDC;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 600)
                                        {
                                            if (true)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Point Defense Cannon for 600 GP?";
                                                    deduction = 600;
                                                    item = "PDC";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                //warningBox.visible = true;
                                                //warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                //warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = PDEW;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 1200)
                                        {
                                            if (true)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Point Defense Energy Weapon for 1200 GP?";
                                                    deduction = 1200;
                                                    item = "PDEW";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                //warningBox.visible = true;
                                                //warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                //warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 4)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = translucentWhite;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = SingleGun;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 5;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 1000)
                                        {
                                            if (true)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Single Gun Turret for 1000 GP?";
                                                    deduction = 1000;
                                                    item = "SGun";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                //warningBox.visible = true;
                                                //warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                //warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 5)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = translucentWhite;
                                    sideBar.style.backgroundImage = BBEW;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 0;
                                        pageIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 15000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.BATTLESHIP)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Heavy Energy Weapons for 15000 GP?";
                                                    deduction = 15000;
                                                    item = "BBEW";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "Are you deliberately trying to fry your reactor or something?";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 1000)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 1500)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 600)
                                {
                                    bar3.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 1200)
                                {
                                    bar4.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 1000)
                                {
                                    bar5.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 15000)
                                {
                                    bar6.style.backgroundColor = translucentBlack;
                                }
                            }
                            else if (pageIdx == 1)
                            {
                                bar1.style.backgroundImage = BBGunsB;
                                bar2.style.backgroundImage = BBRailB;
                                bar3.style.backgroundImage = CREWB;
                                bar4.style.backgroundImage = CRGunsB;
                                bar5.style.backgroundImage = CRRailB;
                                bar6.style.backgroundImage = DDEWB;
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = BBGuns;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 5;
                                        pageIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 14000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.BATTLESHIP)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Heavy Gun Turret for 14000 GP?";
                                                    deduction = 14000;
                                                    item = "BBGun";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "The recoil alone is going to throw your entire ship off course.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = BBRail;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 16000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.BATTLESHIP)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Heavy Railguns for 16000 GP?";
                                                    deduction = 16000;
                                                    item = "BBRG";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "That's gonna crack both the enemy ship and your ship apart mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CREW;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 9000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.CRUISER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Medium Energy Weapons for 9000 GP?";
                                                    deduction = 9000;
                                                    item = "CREW";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CRGuns;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 8000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.CRUISER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Medium Gun Turret for 8000 GP?";
                                                    deduction = 8000;
                                                    item = "CRGun";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 4)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = translucentWhite;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CRRail;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 5;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 10000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.CRUISER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Medium Railguns for 10000 GP?";
                                                    deduction = 10000;
                                                    item = "CRRG";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 5)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = translucentWhite;
                                    sideBar.style.backgroundImage = DDEW;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 0;
                                        pageIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 6500)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.DESTROYER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Light Energy Weapons for 6500 GP?";
                                                    deduction = 6500;
                                                    item = "DDEW";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 14000)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 16000)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 9000)
                                {
                                    bar3.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 8000)
                                {
                                    bar4.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 10000)
                                {
                                    bar5.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 6500)
                                {
                                    bar6.style.backgroundColor = translucentBlack;
                                }
                            }
                            else if (pageIdx == 2)
                            {
                                bar1.style.backgroundImage = DDGunsB;
                                bar2.style.backgroundImage = DDRailB;
                                bar3.style.backgroundImage = blank;
                                bar4.style.backgroundImage = blank;
                                bar5.style.backgroundImage = blank;
                                bar6.style.backgroundImage = blank;
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DDGuns;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 5;
                                        pageIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 6000)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.DESTROYER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Rotary Autocannons for 6000 GP?";
                                                    deduction = 6000;
                                                    item = "DDGun";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I know you like more dakka but this turret won't fit.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DDRail;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet >= 7500)
                                        {
                                            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().ShipClass == PlayerInfo.ShipType.DESTROYER)
                                            {
                                                int full = 20;
                                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                                {
                                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == null || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "")
                                                    {
                                                        full = i;
                                                        break;
                                                    }
                                                }
                                                if (full < 20)
                                                {
                                                    confirmationBox.visible = true;
                                                    confirmationText.text = "Buy Light Railguns for 7500 GP?";
                                                    deduction = 7500;
                                                    item = "DDRG";
                                                    playerItemIdx = full;
                                                    confirm = true;
                                                }
                                                else
                                                {
                                                    warningBox.visible = true;
                                                    warningText.text = "You've got a little too much in your hold there mate.";
                                                    warning = true;
                                                }
                                            }
                                            else
                                            {
                                                warningBox.visible = true;
                                                warningText.text = "I don't think that part is gonna fit on your ship mate.";
                                                warning = true;
                                            }
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "Your wallet's a little to light to buy that mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 6000)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().Wallet < 7500)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                            }
                        }
                    }
                    else
                    {
                        shopKeepText.text = "You could sell it. Just don't blame me if you find it in the hands of some pirate running amuck in the sector.";
                        buySellText.text = "Q Exit | I Buy | Sell P";
                        if (Input.GetKeyDown(KeyCode.I))
                        {
                            buySell = false;
                            topBarIdx = 0;
                            barIdx = 0;
                            pageIdx = 0;
                        }
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            idx = 3;
                        }
                        if (topBarIdx == 0)
                        {
                            topBar1.style.backgroundColor = translucentWhite;
                            topBar2.style.backgroundColor = transparent;
                            topBar3.style.backgroundColor = transparent;
                            topBar4.style.backgroundColor = transparent;
                            if (Input.GetKeyDown(KeyCode.D))
                            {
                                topBarIdx = 1;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (pageIdx == 0)
                            {
                                bar1.style.backgroundImage = CSMDecoyB;
                                bar2.style.backgroundImage = CSMHullB;
                                bar3.style.backgroundImage = CSMTargetB;
                                bar4.style.backgroundImage = CSMDriveB;
                                bar5.style.backgroundImage = CSMCommsS;
                                bar6.style.backgroundImage = CSMReactorS;
                                int c1 = 20;
                                int c2 = 20;
                                int c3 = 20;
                                int c4 = 20;
                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                {
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "Decoy")
                                    {
                                        c1 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "Hull")
                                    {
                                        c2 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "TargetMod")
                                    {
                                        c3 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "Drive")
                                    {
                                        c4 = i;
                                    }
                                }
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CSMDecoy;
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c1 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Decoys for 50 GP?";
                                            deduction = 50;
                                            playerItemIdx = c1;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CSMHull;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c2 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Hull Repair Plating for 25 GP?";
                                            deduction = 25;
                                            playerItemIdx = c2;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CSMTarget;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c3 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Targeting Module for 750 GP?";
                                            deduction = 750;
                                            playerItemIdx = c3;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CSMDrive;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c4 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Turret Drive for 100 GP?";
                                            deduction = 100;
                                            playerItemIdx = c4;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 4)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = translucentWhite;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CSMComms;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 5;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        warningBox.visible = true;
                                        warningText.text = "Do you want to be deaf, dumb and blind in outer space?";
                                        warning = true;
                                    }
                                }
                                else if (barIdx == 5)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = translucentWhite;
                                    sideBar.style.backgroundImage = CSMReactor;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        warningBox.visible = true;
                                        warningText.text = "Good luck even getting out of port without a reactor mate.";
                                        warning = true;
                                    }
                                }
                                if (c1 == 20)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (c2 == 20)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                                if (c3 == 20)
                                {
                                    bar3.style.backgroundColor = translucentBlack;
                                }
                                if (c4 == 20)
                                {
                                    bar4.style.backgroundColor = translucentBlack;
                                }
                            }
                        }
                        else if (topBarIdx == 1)
                        {
                            topBar1.style.backgroundColor = transparent;
                            topBar2.style.backgroundColor = translucentWhite;
                            topBar3.style.backgroundColor = transparent;
                            topBar4.style.backgroundColor = transparent;
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                topBarIdx = 0;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (Input.GetKeyDown(KeyCode.D))
                            {
                                topBarIdx = 2;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (pageIdx == 0)
                            {
                                bar1.style.backgroundImage = GRCSS;
                                bar2.style.backgroundImage = GRCSAdvancedS;
                                bar3.style.backgroundImage = BBEnginesS;
                                bar4.style.backgroundImage = CRBBEnginesS;
                                bar5.style.backgroundImage = DDCREnginesS;
                                bar6.style.backgroundImage = DDEnginesS;
                                int c1 = 20;
                                int c2 = 20;
                                int c3 = 20;
                                int c4 = 20;
                                int c5 = 20;
                                int c6 = 20;
                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                {
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "BRCS")
                                    {
                                        c1 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "ARCS")
                                    {
                                        c2 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "BBEngines")
                                    {
                                        c3 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "CRXEngines")
                                    {
                                        c4 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "EnginesA")
                                    {
                                        c5 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "EnginesHT")
                                    {
                                        c6 = i;
                                    }
                                }
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = GRCS;
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c1 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Basic RCS Pod for 1250 GP?";
                                            deduction = 1250;
                                            playerItemIdx = c1;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = GRCSAdvanced;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c2 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Advanced RCS Pod for 1500 GP?";
                                            deduction = 1500;
                                            playerItemIdx = c2;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = BBEngines;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c3 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Heavy Thrusters for 4000 GP?";
                                            deduction = 4000;
                                            playerItemIdx = c3;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CRBBEngines;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c4 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Large X Thrusters for 3800 GP?";
                                            deduction = 3800;
                                            playerItemIdx = c4;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 4)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = translucentWhite;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DDCREngines;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 5;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c5 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Advanced Engines for 3500 GP?";
                                            deduction = 3500;
                                            playerItemIdx = c5;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 5)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = translucentWhite;
                                    sideBar.style.backgroundImage = DDEngines;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c6 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell High Thurst Engines for 3200 GP?";
                                            deduction = 3200;
                                            playerItemIdx = c6;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                if (c1 == 20)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (c2 == 20)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                                if (c3 == 20)
                                {
                                    bar3.style.backgroundColor = translucentBlack;
                                }
                                if (c4 == 20)
                                {
                                    bar4.style.backgroundColor = translucentBlack;
                                }
                                if (c5 == 20)
                                {
                                    bar5.style.backgroundColor = translucentBlack;
                                }
                                if (c6 == 20)
                                {
                                    bar6.style.backgroundColor = translucentBlack;
                                }
                            }
                        }
                        else if (topBarIdx == 2)
                        {
                            topBar1.style.backgroundColor = transparent;
                            topBar2.style.backgroundColor = transparent;
                            topBar3.style.backgroundColor = translucentWhite;
                            topBar4.style.backgroundColor = transparent;
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                topBarIdx = 1;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (Input.GetKeyDown(KeyCode.D))
                            {
                                topBarIdx = 3;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (pageIdx == 0)
                            {
                                int c1 = 20;
                                int c2 = 20;
                                int c3 = 20;
                                int c4 = 20;
                                int c5 = 20;
                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                {
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "RadB")
                                    {
                                        c1 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "BBRad")
                                    {
                                        c2 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "CRRad")
                                    {
                                        c3 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "LPRad")
                                    {
                                        c4 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "RadS")
                                    {
                                        c5 = i;
                                    }
                                }
                                bar1.style.backgroundImage = RadBasS;
                                bar2.style.backgroundImage = BBRadS;
                                bar3.style.backgroundImage = CRRadS;
                                bar4.style.backgroundImage = LPRadS;
                                bar5.style.backgroundImage = DDradS;
                                bar6.style.backgroundImage = CommandS;
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = RadBas;
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c1 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Basic Radome for 1200 GP?";
                                            deduction = 1200;
                                            playerItemIdx = c1;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = BBRad;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c2 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Battleship Radar for 3000 GP?";
                                            deduction = 3000;
                                            playerItemIdx = c2;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CRRad;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c3 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Cruiser Radar for 2200 GP?";
                                            deduction = 2200;
                                            playerItemIdx = c3;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = LPRad;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c4 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Low Profile Radar for 2000 GP?";
                                            deduction = 2000;
                                            playerItemIdx = c4;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 4)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = translucentWhite;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DDrad;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 5;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c5 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Standard Radar for 1500 GP?";
                                            deduction = 1500;
                                            playerItemIdx = c5;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 5)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = translucentWhite;
                                    sideBar.style.backgroundImage = Command;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        warningBox.visible = true;
                                        warningText.text = "How the hell do you plan to control the ship without a command module?";
                                        warning = true;
                                    }
                                }
                                if (c1 == 20)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (c2 == 20)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                                if (c3 == 20)
                                {
                                    bar3.style.backgroundColor = translucentBlack;
                                }
                                if (c4 == 20)
                                {
                                    bar4.style.backgroundColor = translucentBlack;
                                }
                                if (c5 == 20)
                                {
                                    bar5.style.backgroundColor = translucentBlack;
                                }
                            }
                        }
                        else if (topBarIdx == 3)
                        {
                            topBar1.style.backgroundColor = transparent;
                            topBar2.style.backgroundColor = transparent;
                            topBar3.style.backgroundColor = transparent;
                            topBar4.style.backgroundColor = translucentWhite;
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                topBarIdx = 2;
                                pageIdx = 0;
                                barIdx = 0;
                            }
                            if (pageIdx == 0)
                            {
                                bar1.style.backgroundImage = DEWS;
                                bar2.style.backgroundImage = DPGunS;
                                bar3.style.backgroundImage = PDCS;
                                bar4.style.backgroundImage = PDEWS;
                                bar5.style.backgroundImage = SingleGunS;
                                bar6.style.backgroundImage = BBEWS;
                                int c1 = 20;
                                int c2 = 20;
                                int c3 = 20;
                                int c4 = 20;
                                int c5 = 20;
                                int c6 = 20;
                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                {
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "DEW")
                                    {
                                        c1 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "DPGuns")
                                    {
                                        c2 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "PDC")
                                    {
                                        c3 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "PDEW")
                                    {
                                        c4 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "SGun")
                                    {
                                        c5 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "BBEW")
                                    {
                                        c6 = i;
                                    }
                                }
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DEW;
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c1 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Directed Energy Turret for 500 GP?";
                                            deduction = 500;
                                            playerItemIdx = c1;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DPGun;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c2 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Dual Purpose Guns for 750 GP?";
                                            deduction = 750;
                                            playerItemIdx = c2;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = PDC;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c3 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Point Defense Cannon for 300 GP?";
                                            deduction = 300;
                                            playerItemIdx = c3;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = PDEW;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c4 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Point Defense Energy Weapon for 600 GP?";
                                            deduction = 600;
                                            playerItemIdx = c4;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 4)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = translucentWhite;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = SingleGun;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 5;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c5 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Single Gun Turret for 500 GP?";
                                            deduction = 500;
                                            playerItemIdx = c5;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 5)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = translucentWhite;
                                    sideBar.style.backgroundImage = BBEW;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 0;
                                        pageIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c6 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Heavy Energy Weapons for 7500 GP?";
                                            deduction = 7500;
                                            playerItemIdx = c6;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                if (c1 == 20)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (c2 == 20)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                                if (c3 == 20)
                                {
                                    bar3.style.backgroundColor = translucentBlack;
                                }
                                if (c4 == 20)
                                {
                                    bar4.style.backgroundColor = translucentBlack;
                                }
                                if (c5 == 20)
                                {
                                    bar5.style.backgroundColor = translucentBlack;
                                }
                                if (c6 == 20)
                                {
                                    bar6.style.backgroundColor = translucentBlack;
                                }
                            }
                            else if (pageIdx == 1)
                            {
                                bar1.style.backgroundImage = BBGunsS;
                                bar2.style.backgroundImage = BBRailS;
                                bar3.style.backgroundImage = CREWS;
                                bar4.style.backgroundImage = CRGunsS;
                                bar5.style.backgroundImage = CRRailS;
                                bar6.style.backgroundImage = DDEWS;
                                int c1 = 20;
                                int c2 = 20;
                                int c3 = 20;
                                int c4 = 20;
                                int c5 = 20;
                                int c6 = 20;
                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                {
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "BBGun")
                                    {
                                        c1 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "BBRG")
                                    {
                                        c2 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "CREW")
                                    {
                                        c3 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "CRGun")
                                    {
                                        c4 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "CRRG")
                                    {
                                        c5 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "DDEW")
                                    {
                                        c6 = i;
                                    }
                                }
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = BBGuns;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 5;
                                        pageIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c1 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Heavy Gun Turret for 7000 GP?";
                                            deduction = 7000;
                                            playerItemIdx = c1;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = BBRail;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c2 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Heavy Railguns for 8000 GP?";
                                            deduction = 8000;
                                            playerItemIdx = c2;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 2)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = translucentWhite;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CREW;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c3 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Medium Energy Weapons for 4500 GP?";
                                            deduction = 4500;
                                            playerItemIdx = c3;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 3)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = translucentWhite;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CRGuns;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c4 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Medium Gun Turret for 4000 GP?";
                                            deduction = 4000;
                                            playerItemIdx = c4;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 4)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = translucentWhite;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = CRRail;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 3;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 5;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c5 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Medium Railguns for 5000 GP?";
                                            deduction = 5000;
                                            playerItemIdx = c5;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 5)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = translucentWhite;
                                    sideBar.style.backgroundImage = DDEW;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 4;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 0;
                                        pageIdx = 2;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c6 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Light Energy Weapons for 3250 GP?";
                                            deduction = 3250;
                                            playerItemIdx = c6;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                if (c1 == 20)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (c2 == 20)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                                if (c3 == 20)
                                {
                                    bar3.style.backgroundColor = translucentBlack;
                                }
                                if (c4 == 20)
                                {
                                    bar4.style.backgroundColor = translucentBlack;
                                }
                                if (c5 == 20)
                                {
                                    bar5.style.backgroundColor = translucentBlack;
                                }
                                if (c6 == 20)
                                {
                                    bar6.style.backgroundColor = translucentBlack;
                                }
                            }
                            else if (pageIdx == 2)
                            {
                                bar1.style.backgroundImage = DDGunsS;
                                bar2.style.backgroundImage = DDRailS;
                                bar3.style.backgroundImage = blank;
                                bar4.style.backgroundImage = blank;
                                bar5.style.backgroundImage = blank;
                                bar6.style.backgroundImage = blank;
                                int c1 = 20;
                                int c2 = 20;
                                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems.Length; i++)
                                {
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "DDGun")
                                    {
                                        c1 = i;
                                    }
                                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().PlayerItems[i] == "DDRG")
                                    {
                                        c2 = i;
                                    }
                                }
                                if (barIdx == 0)
                                {
                                    bar1.style.backgroundColor = translucentWhite;
                                    bar2.style.backgroundColor = transparent;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DDGuns;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 5;
                                        pageIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        barIdx = 1;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c1 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Rotary Autocannons for 3000 GP?";
                                            deduction = 3000;
                                            playerItemIdx = c1;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                else if (barIdx == 1)
                                {
                                    bar1.style.backgroundColor = transparent;
                                    bar2.style.backgroundColor = translucentWhite;
                                    bar3.style.backgroundColor = transparent;
                                    bar4.style.backgroundColor = transparent;
                                    bar5.style.backgroundColor = transparent;
                                    bar6.style.backgroundColor = transparent;
                                    sideBar.style.backgroundImage = DDRail;
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        barIdx = 0;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        if (c2 < 20)
                                        {
                                            confirmationBox.visible = true;
                                            confirmationText.text = "Sell Light Railguns for 3750 GP?";
                                            deduction = 3750;
                                            playerItemIdx = c2;
                                            sellConfirm = true;
                                        }
                                        else
                                        {
                                            warningBox.visible = true;
                                            warningText.text = "You can't sell what you don't have mate.";
                                            warning = true;
                                        }
                                    }
                                }
                                if (c1 == 20)
                                {
                                    bar1.style.backgroundColor = translucentBlack;
                                }
                                if (c2 == 20)
                                {
                                    bar2.style.backgroundColor = translucentBlack;
                                }
                            }
                        }
                    }
                }
                if (idx == 3)
                {
                    shopKeepText.text = "Until next time, dear friend!";
                    buySellText.visible = true;
                    buySellText.text = "             Continue P";
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        idx = 0;
                        topBarIdx = 0;
                        barIdx = 0;
                        pageIdx = 0;
                        confirmationBox.visible = false;
                        warningBox.visible = false;
                        shopMain.visible = false;
                        playerCurrency.visible = false;
                        buySellText.visible = false;
                        warning = false;
                        confirm = false;
                        sellConfirm = false;
                        isActive = false;
                    }
                }
            }
        }
        else
        {
            background.visible = false;
            shopMain.visible = false;
            textBar.visible = false;
            confirmationBox.visible = false;
            warningBox.visible = false;
        }
    }
}
