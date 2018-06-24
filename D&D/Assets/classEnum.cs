using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class classEnum : MonoBehaviour {


    public Dropdown classDropDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CharacterSheet.characterSheet.playerClass = (CharacterSheet.Classes)classDropDown.value;
	}
}
