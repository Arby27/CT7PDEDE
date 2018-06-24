using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    public static bool spawned = false;
	// Use this for initialization
	void Awake () {
        if (spawned == false)
        {
            spawned = true;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
	}
	

}
