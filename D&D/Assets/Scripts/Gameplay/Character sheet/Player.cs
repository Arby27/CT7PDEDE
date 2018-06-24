using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Slider HealthBar;
    public Text healthText;
    int damage;
	// Use this for initialization
	void Start () {

        if (CharacterSheet.characterSheet.Health == 0)
        {
            CharacterSheet.characterSheet.Health = 10;
        }
        
        CharacterSheet.characterSheet.currentHealth = CharacterSheet.characterSheet.Health;
        CharacterSheet.characterSheet.tempHealth = 0;
        HealthBar.value = (CharacterSheet.characterSheet.currentHealth / (CharacterSheet.characterSheet.Health + CharacterSheet.characterSheet.tempHealth)) * 100;
        healthText.text = CharacterSheet.characterSheet.currentHealth + "/" + CharacterSheet.characterSheet.Health;

        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(damage);
        }
	}

    void TakeDamage(int dmg)
    {
        CharacterSheet.characterSheet.currentHealth = CharacterSheet.characterSheet.currentHealth - dmg;
        healthText.text = CharacterSheet.characterSheet.currentHealth + "/" + CharacterSheet.characterSheet.Health;
        HealthBar.value = (CharacterSheet.characterSheet.currentHealth / CharacterSheet.characterSheet.Health) * 100;
    }
}
