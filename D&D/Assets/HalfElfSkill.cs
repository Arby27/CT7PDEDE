using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HalfElfSkill : MonoBehaviour {

    public Dropdown[] halfelfStats = new Dropdown[2];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CharacterSheet.characterSheet.halfElfStat[0] = (CharacterSheet.Stats)halfelfStats[0].value;
        CharacterSheet.characterSheet.halfElfStat[1] = (CharacterSheet.Stats)halfelfStats[1].value;
	}
}
