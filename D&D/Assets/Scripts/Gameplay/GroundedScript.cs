using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedScript : MonoBehaviour {

    float GroundDist;
    Collider diceCol;

	// Use this for initialization
	void Start () {
        diceCol = gameObject.GetComponent<Collider>();
        GroundDist = diceCol.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
        
        Debug.Log(isGrounded());
        Debug.Log(GroundDist);
	}

    bool isGrounded()
    {
        Debug.DrawRay(transform.position, -Vector3.up * (GroundDist + 0.1f), Color.red);
        return Physics.Raycast(transform.position, -Vector3.up, GroundDist + 0.1f);
    }
}
