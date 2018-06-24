using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoarding : MonoBehaviour {

   public Camera playerCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position + playerCam.transform.rotation * Vector3.forward,
            playerCam.transform.rotation * Vector3.up);
	}
}
