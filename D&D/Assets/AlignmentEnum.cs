using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlignmentEnum : MonoBehaviour {

    public Dropdown alignmentDropDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CharacterSheet.characterSheet.alignment = (CharacterSheet.Alignment)alignmentDropDown.value;
	}
}
