using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRay : MonoBehaviour {

    Ray RollerRay;
    RaycastHit RollerHit;
    int layermask;
    static int lastRoll;
    // Use this for initialization
    void Start() {
        layermask = (1 >> 8);
    }

    // Update is called once per frame
    void Update() {
       // DiceResult();
    }

    public  int DiceResult()
    {
        //masks all the layers except the bitshifted layer in start
        layermask = ~layermask;

        //debug to see postiion and length of ray
        Debug.DrawRay(transform.position, Vector3.up, Color.red);

        //does a raycast pointing up from the center of the dice ( can be applied to any dice as long as it has this script) and outputs a hit,
        //then saves the value on the upward facing face as last roll. 
        //TODO last roll needs to account of more than 1 dice being rolled at a time, i.e 2d6
        if (Interation.diceRolled == true)
        {
            if (Physics.Raycast(transform.position, Vector3.up, out RollerHit, 1.0f, layermask, QueryTriggerInteraction.Collide))
            {

                lastRoll = int.Parse(RollerHit.collider.transform.gameObject.tag);
                print(lastRoll);
                return lastRoll;
            }
        }
        return 0;
    } 

   
}
