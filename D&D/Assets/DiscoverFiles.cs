using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DiscoverFiles : MonoBehaviour {


    public Dropdown fileNameDropDown;

	// Use this for initialization
	void Start () {

       /* fileNameDropDown.ClearOptions();
        DirectoryInfo info = new DirectoryInfo("Assets/Resources/");
        FileInfo[] fileInfo = info.GetFiles();
        foreach (FileInfo fileName in fileInfo)
        {
            //fileNameDropDown.AddOptions(fileName.Name.ToList<Dropdown.OptionData>());
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
