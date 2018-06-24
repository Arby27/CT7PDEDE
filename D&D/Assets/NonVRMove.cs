using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRMove : MonoBehaviour {

    Ray mouseRay;
    RaycastHit mouseRayHit;
    bool isGrabbed;
    GameObject heldObj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,1,0));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position += Vector3.down * Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out mouseRayHit))
            {
                if (mouseRayHit.collider.attachedRigidbody != null)
                {
                    heldObj = raycastGrab(mouseRayHit.collider);
                }
            }




         }
        if (Input.GetMouseButtonUp(0))
        {
            // Globals.globalInteraction.putDownObject();
            raycastDrop(heldObj);
        }

    }


    GameObject raycastGrab(Collider collision)
    {
        GameObject grabbedObject;
        if (isGrabbed == false)
        {
            grabbedObject = collision.gameObject;

            grabbedObject.transform.position = Input.mousePosition;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            isGrabbed = true;
        }
        else
        {
            grabbedObject = null;
        }
       
        return grabbedObject;
    
    }

    void raycastDrop(GameObject currentObj)
    {
        if (currentObj.tag == "Dice")
        {
            Globals.globalray.DiceResult();
        }
        currentObj.GetComponent<Rigidbody>().isKinematic = false;
        currentObj.transform.parent = null;
        isGrabbed = false;
    }
}
