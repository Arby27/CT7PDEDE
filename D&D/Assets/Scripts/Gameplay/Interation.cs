using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Interation : MonoBehaviour
{

   public  SteamVR_TrackedObject TrackedObj; // a tracked object in scene

   public  SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)TrackedObj.index); } } // gets the controllerid via tracked object




    public static GameObject grabbedObject; // this will be the object you pick up
    GameObject selectedDie;
    bool isGrabbed = false;
    bool grounded = false;
    public static bool diceRolled = false;
    int frameCount;
    int frameCounter;
    Vector3 lastPos;
    Vector3 currentPos;
    Vector3 totalPos;
    float lastXPos;
    float controllerX;
    public static GameObject createdDice;
    float targetTime = 1.0f;
    float targetTimer = 1.0f;


    
    void Start()
    {
        
        grabbedObject = null;
        TrackedObj = GetComponent<SteamVR_TrackedObject>();
        // selectedDie = Globals.globalDiceCreate.dicetypes[1];
        //Globals.globalDiceCreate.currentSprite = Globals.globalDiceCreate.DiceSprites[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbedObject != null)
        {
            ThrowObject();
            DiceRoll();

        }
        // UIActive();
        //spawnDice();
        Globals.globalInteraction = this;

    }

    #region Object Interaction
    private void OnTriggerStay(Collider collision) //whilst within collider spheres can pick up object
    {
        PickupObject(collision);
    }

    private void OnTriggerExit(Collider other) // when not colliding free up picked up object
    {
        PutDownObject();
    }

    private void DiceRoll()
    {

        controllerX = Controller.transform.rot.x;

        if (lastXPos < controllerX - 0.1f && frameCounter > 25 || lastXPos > controllerX + 0.1f && frameCounter > 25)
        {
            grabbedObject.transform.Rotate(Random.rotation.eulerAngles);
            frameCounter = 0;
        }
        lastXPos = controllerX;
        frameCounter++;

    }

    private void ThrowObject()
    {
        if (Controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            //currentPos = grabbedObject.GetComponent<Rigidbody>().position;
            // totalPos = currentPos - lastPos;
            grabbedObject.GetComponent<Rigidbody>().velocity = Controller.velocity;
            grabbedObject.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
            // frameCount = 0;
        }
    }

    public void PickupObject(Collider collision)
    {

        grabbedObject = collision.gameObject;
        if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip) && grabbedObject != null) // if grip button is pressed and no other object is picked up,set transform of coliiding object to hand
                                                                                                   // and turn off gravity
        {
            if (grabbedObject.GetComponent<Collider>().isTrigger == true)
            {
                grabbedObject.GetComponent<Collider>().enabled = false;
            }
            grabbedObject.transform.parent = gameObject.transform;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            isGrabbed = true;
            diceRolled = false;



        }

        if (Controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip) && grabbedObject != null) // when the grip is released free up the picked up object
        {
            if (grabbedObject.tag == "Dice")
            {
                Globals.globalray = grabbedObject.GetComponent<DiceRay>();
                diceRolled = true;
                //wait
                Globals.lastDiceRoll = Globals.globalray.DiceResult();



            }

            if (grabbedObject.GetComponent<Collider>().isTrigger == true)
            {
                grabbedObject.GetComponent<Collider>().enabled = true;
            }

            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.transform.parent = null;
            isGrabbed = false;

        }

    }

    public void PutDownObject()
    {

        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.parent = null;
        isGrabbed = false;


    }
    #endregion


    

}
