using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationButtons : MonoBehaviour {

    int value;
    public Text currentStat;
    public Text textValue;
    public GameObject RollButton;
    

    public void Roll()
    {
        value = (Random.Range(1, 6) + Random.Range(1, 6) + Random.Range(1, 6));
        textValue.text = value.ToString();
        RollButton.SetActive(false);
        if (currentStat.text == "Strength")
        {
            CharacterSheet.characterSheet.Strength = value;
            CharacterSheet.characterSheet.StatBonus();
            Globals.statRollsEnabled[0] = false;
        }
        if (currentStat.text == "Dexterity")
        {
            CharacterSheet.characterSheet.Dex = value;
            CharacterSheet.characterSheet.StatBonus();
            Globals.statRollsEnabled[1] = false;
        }
        if (currentStat.text == "Constitution")
        {
            CharacterSheet.characterSheet.Con = value;
            CharacterSheet.characterSheet.StatBonus();
            Globals.statRollsEnabled[2] = false;
        }
        if (currentStat.text == "Intelligence")
        {
            CharacterSheet.characterSheet.intelligence = value;
            CharacterSheet.characterSheet.StatBonus();
            Globals.statRollsEnabled[3] = false;
        }
        if (currentStat.text == "Wisdom")
        {
            CharacterSheet.characterSheet.Wis = value;
            CharacterSheet.characterSheet.StatBonus();
            Globals.statRollsEnabled[4] = false;
        }
        if (currentStat.text == "Charisma")
        {
            CharacterSheet.characterSheet.Cha = value;
            CharacterSheet.characterSheet.StatBonus();
            Globals.statRollsEnabled[5] = false;
        }

        
    }

}
