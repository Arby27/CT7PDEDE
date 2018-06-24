using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceEnum : MonoBehaviour {

    public Dropdown raceDropDown;
    public Dropdown subRaceDropDown;
    public GameObject[] halfElfDropDown;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
            if (CharacterSheet.characterSheet.race == CharacterSheet.Race.Dwarf)
            {
                subRaceDropDown.ClearOptions();
                subRaceDropDown.AddOptions(new List<string> { "Hill Dwarf", "Mountain Dwarf" });
                CharacterSheet.characterSheet.subRace = (CharacterSheet.SubRace)subRaceDropDown.value + 8;
            }
            else if (CharacterSheet.characterSheet.race == CharacterSheet.Race.Elf)
            {
                Debug.Log("Elf");
                subRaceDropDown.ClearOptions();
                subRaceDropDown.AddOptions(new List<string> { "High Elf", "Wood Elf", "Dark Elf" });
                CharacterSheet.characterSheet.subRace = (CharacterSheet.SubRace)subRaceDropDown.value + 1;
        }
            else if (CharacterSheet.characterSheet.race == CharacterSheet.Race.Halfling)
            {
                subRaceDropDown.ClearOptions();
                subRaceDropDown.AddOptions(new List<string> { "Lightfoot", "Stout" });
                CharacterSheet.characterSheet.subRace = (CharacterSheet.SubRace)subRaceDropDown.value + 4;
        }
            else if (CharacterSheet.characterSheet.race == CharacterSheet.Race.Gnome)
            {
                subRaceDropDown.ClearOptions();
                subRaceDropDown.AddOptions(new List<string> { "Forest Gnome", "Rock Gnome" });
                CharacterSheet.characterSheet.subRace = (CharacterSheet.SubRace)subRaceDropDown.value + 6;
        }
            else
            {
                subRaceDropDown.ClearOptions();
                subRaceDropDown.AddOptions(new List<string> { "None" });
                CharacterSheet.characterSheet.subRace = (CharacterSheet.SubRace)subRaceDropDown.value;
        }

        if (CharacterSheet.characterSheet.race == CharacterSheet.Race.HalfElf)
        {
            halfElfDropDown[0].SetActive(true);
            halfElfDropDown[1].SetActive(true);
        }
        

        CharacterSheet.characterSheet.race = (CharacterSheet.Race)raceDropDown.value - 1;
        CharacterSheet.characterSheet.StatBonus();
         
	}
}
