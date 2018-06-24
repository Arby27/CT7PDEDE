using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceCreate : Photon.MonoBehaviour {

    //TODO fix sprite swaping add grabbed object to spawned dice, add rigidbodies to spawned dice


    public SteamVR_TrackedObject TrackedObj; // a tracked object in scene

    public SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)TrackedObj.index); } } // gets the controllerid via tracked object

    public PhotonView photonView;

    public GameObject[] dicetypes = new GameObject[6];
    public Sprite[] DiceSprites = new Sprite[6];
    public GameObject[] Panel = new GameObject[2];
    public int DiceSpriteNum = 0;
    public Canvas controllerCanvas;
    public Image currentSprite;
    Text DiceAmountText;
    bool diceRolled;
    float targetTimer;
    float timerMax;
    int currenttrackPadPos;
    bool numbChange = false;
    int currentNumb = 1;
    bool spawnedDice = false;
    bool bottomHighlighted = true;
   
    // Use this for initialization
    void Start () {
        TrackedObj = GetComponent<SteamVR_TrackedObject>();
        currentSprite.sprite = DiceSprites[0];
        DiceAmountText = GetComponentInChildren<Text>();
        DiceAmountText.text = "Dice to Roll " + currentNumb.ToString();
        timerMax = 1.0f;
        dicetypes[0].name = "D4";
        dicetypes[1].name = "D6";
        dicetypes[2].name = "D8";
        dicetypes[3].name = "D10";
        dicetypes[4].name = "D12";
        dicetypes[5].name = "D20";
        Panel[0].SetActive(true);
        Panel[1].SetActive(false);
        controllerCanvas.enabled = false;
     
    }
	
	// Update is called once per frame
	void Update () {
        currenttrackPadPos = (int)PadPos();
        UIActive();
        SpawnDice();
	}


    #region Advanced Dice Roller interaction

    void UIActive()
    {
        
        if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad) && currenttrackPadPos == (int)TrackPadPos.Down)
        {
            controllerCanvas.enabled = true;
        }

       
    }


    void SpawnDice()
    {


        if (controllerCanvas.enabled == true)
        {
            if (numbChange == false)
            {
                if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad) && currenttrackPadPos == (int)TrackPadPos.Right)
                {

                    DiceSpriteNum++;
                    if (DiceSpriteNum > 5)
                    {
                        DiceSpriteNum = 0;
                    }
                    currentSprite.sprite = DiceSprites[DiceSpriteNum];
                }

                if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad) && currenttrackPadPos == (int)TrackPadPos.Left)
                {
                    DiceSpriteNum--;
                    if (DiceSpriteNum < 0)
                    {
                        DiceSpriteNum = 5;
                    }
                    currentSprite.sprite = DiceSprites[DiceSpriteNum];
                }
            }
            else
            {
                if(Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad) && currenttrackPadPos == (int)TrackPadPos.Right)
                {
                    currentNumb++;
                    DiceAmountText.text = "Dice to Roll " + currentNumb.ToString();
                    if (currentNumb >= 15)
                    {
                        currentNumb = 1;
                    }
                }

                if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad) && currenttrackPadPos == (int)TrackPadPos.Left)
                {
                    currentNumb--;
                    DiceAmountText.text = "Dice to Roll " + currentNumb.ToString();
                    if (currentNumb < 1)
                    {
                        currentNumb = 15;
                    }
                }
            }
            if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad) && currenttrackPadPos == (int)TrackPadPos.Up)
            {
                if (bottomHighlighted == true)
                {
                    bottomHighlighted = false;
                }
                else
                {
                    bottomHighlighted = true;
                }
                if (numbChange == false)
                {
                    numbChange = true;
                }
                else
                {
                    numbChange = false;
                }
            }

            if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                for (int i = 0; i < currentNumb; i++)
                {
                    if (photonView.isMine)
                    {
                        Interation.createdDice = Instantiate(dicetypes[DiceSpriteNum], transform);
                        Interation.grabbedObject = Interation.createdDice;
                    }
                    else
                    {
                        NetworkSpawnDice();
                    }
                    Interation.grabbedObject = Interation.createdDice;
                    Interation.grabbedObject.transform.parent = gameObject.transform;
                    Interation.grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                    
                }

                if (diceRolled == true)
                {
                    Destroy(Interation.createdDice);
                    diceRolled = false;
                    targetTimer = timerMax;
                }
                spawnedDice = true;
                controllerCanvas.enabled = false;
            }

            if (Controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                if (Interation.grabbedObject.tag == "Dice")
                {
                    Globals.globalray = Interation.grabbedObject.GetComponent<DiceRay>();
                    diceRolled = true;
                    //wait
                    Globals.lastDiceRoll = Globals.globalray.DiceResult();

                    Debug.Log(Globals.lastDiceRoll);

                }

                if (Interation.grabbedObject.GetComponent<Collider>().isTrigger == true)
                {
                    Interation.grabbedObject.GetComponent<Collider>().enabled = true;
                }

                Interation.grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                Interation.grabbedObject.transform.parent = null;
                if (spawnedDice == true)
                {
                    Destroy(Interation.createdDice, 5);
                    spawnedDice = false;
                }
            }

            if (bottomHighlighted == true)
            {
                Panel[0].SetActive(true);
                Panel[1].SetActive(false);
            }
            else
            {
                Panel[0].SetActive(false);
                Panel[1].SetActive(true);
            }
        }
    }

    void DiceReset()
    {
        if (diceRolled == true)
        {
            targetTimer -= Time.deltaTime;
            if (targetTimer <= 0.0f)
            {
                diceRolled = false;
                targetTimer = timerMax;
            }
        }
    }

    #endregion

    public enum TrackPadPos
    {
        Off = 0,
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4
    }

    TrackPadPos PadPos()
    {
        Vector2 currentPadPos = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
        bool isup = currentPadPos.y >= 0;
        bool isRight = currentPadPos.x >= 0;

        if (isup)
        {
            if (isRight)
            {
                if (currentPadPos.y > currentPadPos.x)
                {
                    return TrackPadPos.Up;
                }
                else
                {
                    return TrackPadPos.Right;
                }
            }
            else
            {
                if (currentPadPos.y > -currentPadPos.x)
                {
                    return TrackPadPos.Up;
                }
                else
                {
                    return TrackPadPos.Left;
                }
            }
        }
        else if (!isup)
        {
            if (isRight)
            {
                if (-currentPadPos.y > currentPadPos.x)
                {
                    return TrackPadPos.Down;
                }
                else
                {
                    return TrackPadPos.Right;
                }
            }
            else
            {
                if (-currentPadPos.y > -currentPadPos.x)
                {
                    return TrackPadPos.Down;
                }
                else
                {
                    return TrackPadPos.Left;
                }
            }
        }
        else
        {
            return TrackPadPos.Off;
        }


    }


    [PunRPC]
    void NetworkSpawnDice()
    {
        if (currentSprite == dicetypes[0])
        {
          PhotonNetwork.Instantiate("D4_Mesh", transform.position, transform.rotation, 0);
           
        }
        
    }
}
