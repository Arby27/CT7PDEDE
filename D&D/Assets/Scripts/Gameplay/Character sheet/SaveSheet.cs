using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSheet : MonoBehaviour {

    public Button saveButton;
    public GameObject warningText;



	// Use this for initialization
	void Start () {
        saveButton.interactable = false;
        warningText.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (Globals.statRollsEnabled[0] == false && Globals.statRollsEnabled[1] == false && Globals.statRollsEnabled[2] == false &&
            Globals.statRollsEnabled[3] == false && Globals.statRollsEnabled[4] == false && Globals.statRollsEnabled[5] == false)
        {
            saveButton.interactable = true;
            warningText.SetActive(false);
        }
	}

    public void Save()
    {
        CharacterSheet.characterSheet.RacialBonus();
        CharacterSheet.characterSheet.LevelUp();
        WriteToFile.writeToFile.WriteString();
        //WriteToFile.writeToFile.WriteData();
        MenuSettings.menuSettingsInstance.BackToMain();
    }
}
