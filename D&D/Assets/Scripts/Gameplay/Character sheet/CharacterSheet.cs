using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSheet : MonoBehaviour {

    
 static public CharacterSheet characterSheet;

    #region character Sheet Stats

   public string Name;
   public int Health;
   public int currentHealth;
   public int tempHealth;
   public int Exp;
   public int armourClass;
   public int Strength;
   public int Dex;
   public int Con;
   public int Wis;
   public int intelligence;
   public int Cha;
   public int profBonus;
   public int initiave;
   public int speed;
   public int deathSuccess;
   public int deathFail;
   public int hitDice;
   public int currentHitDice;
   public int passiveWisdom;
   public int platinumPieces;
   public int goldPieces;
   public int electrumPieces;
   public int silverPieces;
   public int copperPieces;
   public Classes playerClass;
   public SubClass playerSubClass;
   public Race race;
   public SubRace subRace;
   public Alignment alignment;
   public bool proficient;
   public bool darkVision = false;
 #endregion
   public int level = 1;
   public int[] bonuses = new int[6];
   public int[] spellLevel = new int[10];
   public int[] currentSpellSlots = new int[10];
   public int ki;
   public int currentKi;
   public int stat;
   bool hasSpells = true;

   public Stats[] halfElfStat = new Stats[2];


    public GameObject CreatorUI;
    public Text hitPointText;

   
    // Use this for initialization
    void Start() {
        characterSheet = this;
        LongRest();
        RacialBonus();
        StatBonus();
    }

    // Update is called once per frame
    void Update() {
      
            HitPoints();
        
    }

    #region Class Enums

    public enum Race
    {
        Elf,
        Halfling,
        Gnome,
        Tiefling,
        HalfOrc,
        HalfElf,
        Human,
        Dwarf,
        Dragonborn
    }

    public enum SubRace
    {
        none, 
        //Elf
        HighElf,
        WoodElf,
        DarkElf,

        //Halfling
        Lightfoot,
        Stout,

        //Gnome
        ForestGnome,
        RockGnome,
        //Dwarf

        HillDwarf,
        MountainDwarf

    }

    public enum Classes
        {
            Barbarian,
            Bard,
            Cleric,
            Druid,
            Fighter,
            Monk,
            Paladin,
            Ranger,
            Rogue,
            Sorcerer,
            Warlock,
            Wizard
        }

    public enum SubClass
    {
        None,
        //Barbarian
        PathOfBeserker,
        PathOfTotemWarrior,

        //Bard(Magic)
        CollegeOfLore,
        CollegeOfValor,

        //Cleric(Magic)
        KnowlegdeDomain,
        LifeDomain,
        LightDomain,
        NatureDomain,
        TempestDomain,
        TrickeryDomain,
        WarDomain,

        //Druid(Magic)
        CircleLand,
        CircleMoon,
  
        //Fighter
        BattleMaster,
        Champion,
        EldritchKnight, //Magic
   
        //Monk
        WayShadow,
        WayElements,
        WayOpenHands,
    
        //Paladin (Magic)
        OathDevotion,
        OathAncients,
        OathPurge,
  
        //Ranger (Magic lvl2+)
        BeastMaster,
        Hunter,
 
        //Rogue
        ArcaneTrickster, //Magic
        Assassin,
        Thief,
    
        //Sorcerer (Magic)
        DraconicBloodline,
        WildMagic,
  
        //Warlock (Magic)
        Archfey,
        Fiend,
        GreatOldOne,

        //Wizard (Magic)
        SchoolEvocation,
        SchoolNecromancy,
        SchoolTransmutation,
        ShcoolConjuration,
        SchoolDivination,
        SchoolAbjuration,
        SchoolEnchantment,
        SchoolIllusion

    }

    public enum Alignment
    {
        LawfulGood,
        NeutralGood,
        ChaoticGood,
        LawfulNeutral,
        TrueNeutral,
        ChaoticNeutral,
        LawfulEvil,
        NeutralEvil,
        ChaoticEvil
    }

    public enum Stats
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    #endregion

    //Gameplay
   public void LongRest()
    {
        currentHealth = Health;
        currentHitDice = currentHitDice + (hitDice/2);
        if (currentHitDice > hitDice)
        {
            currentHitDice = hitDice;
        }
        currentKi = ki;
        for (int i = 0; i < spellLevel.Length; i++)
        {
            currentSpellSlots[i] = spellLevel[i];
        }
    }
   public void StatBonus() // applies the stat bonuses from stat scores
    {
        //stats must follow order STR, DEX, CON, INT, WIS, CHA
        for (int i = 0; i < 5; i++)
        {
#region stat type
            if (i == 0)
            {
                stat = Strength;
            }
            else if (i == 1)
            {
                stat = Dex;
            }
            else if (i == 2)
            {
                stat = Con;
            }
            else if (i == 3)
            {
                stat = intelligence;
            }
            else if (i == 4)
            {
                stat = Wis;
            }
            else
            {
                stat = Cha;
            }
#endregion
            #region statbonuse
            if (stat == 1)
            {
                bonuses[i] = -5;
            }
            else if (stat == 2 || stat == 3)
            {
                bonuses[i] = -4;
            }
            else if (stat == 4 || stat == 5)
            {
                bonuses[i] = -3;
            }
            else if (stat == 6 || stat == 7)
            {
                bonuses[i] = -2;
            }
            else if (stat == 8 || stat == 9)
            {
                bonuses[i] = -1;
            }
            else if (stat == 10 || stat == 11)
            {
                bonuses[i] = 0;
            }
            else if (stat == 12 || stat == 13)
            {
                bonuses[i] = 1;
            }
            else if (stat == 14 || stat == 15)
            {
                bonuses[i] = 2;
            }
            else if (stat == 16 || stat == 17)
            {
                bonuses[i] = 3;
            }
            else if (stat == 18 || stat == 19)
            {
                bonuses[i] = 4;
            }
            else if (stat == 20 || stat == 21)
            {
                bonuses[i] = 5;
            }
            else if (stat == 22 || stat == 23)
            {
                bonuses[i] = 6;
            }
            else if (stat == 24 || stat == 25)
            {
                bonuses[i] = 7;
            }
            else if (stat == 26 || stat == 27)
            {
                bonuses[i] = 8;
            }
            else if (stat == 28 || stat == 29)
            {
                bonuses[i] = 9;
            }
            else
            {
                bonuses[i] = 10;
            } 
            #endregion
        }
        initiave = bonuses[1];//initiave bonus = dex bonus
    }

    //Character creation
   public void RacialBonus() // this function is to automatically add racial bonuses to the stats
    {
        if (race == Race.Dragonborn)
        {
          
            Strength = Strength + 2;
            Cha = Cha + 1;
            if (Strength > 20 ) // these checks need to be seperate or will set wrong stats to 20
            {
                Strength = 20;
            }
            if (Cha > 20)
            {
                Cha = 20;
            }
            speed = 30;
        }

        if (race == Race.Dwarf)
        {
            darkVision = true;
            Con = Con + 2;
            if (Con > 20)
            {
                Con = 20;
            }
            speed = 25;

            if (subRace == SubRace.HillDwarf)
            {
                Wis = Wis + 1;
                if (Wis > 20)
                {
                    Wis = 20;
                }
                Health = Health + 1;
            }
            if (subRace == SubRace.MountainDwarf)
            {
                Strength = Strength + 2;
                if (Strength > 20)
                {
                    Strength = 20;
                }
            }
        }

        if (race == Race.Elf)
        {
            darkVision = true;
            Dex = Dex + 2;
            if (Dex > 20)
            {
                Dex = 20;
            }
            speed = 30;

            if (subRace == SubRace.HighElf)
            {
                intelligence = intelligence + 1;
                if (intelligence > 20)
                {
                    intelligence = 20;
                }
            }
            if (subRace == SubRace.WoodElf)
            {
                Wis = Wis + 1;
                if (Wis > 20)
                {
                    Wis = 20;
                }
                speed = 35;
            }
            if (subRace == SubRace.DarkElf)
            {
                Cha = Cha + 1;
                if (Cha > 20)
                {
                    Cha = 20;
                }
            }
        }

        if (race == Race.Halfling)
        {
            Dex = Dex + 2;
            if (Dex > 20)
            {
                Dex = 20;
            }
            speed = 25;

            if (subRace == SubRace.Lightfoot)
            {
                Cha = Cha + 1;
                if (Cha > 20)
                {
                    Cha = 20;
                }
            }
            if (subRace == SubRace.Stout)
            {
                Con = Con + 1;
                if (Con > 20)
                {
                    Con = 20;
                }
            }
        }

        if (race == Race.Human)
        {
            speed = 30;
            Strength = Strength + 1;
            Dex = Dex + 1;
            Con = Con + 1;
            intelligence = intelligence + 1;
            Wis = Wis + 1;
            Cha = Cha + 1;
        }

        if (race == Race.Gnome)
        {
            darkVision = true;
            speed = 25;
            intelligence = intelligence + 2;
            if (intelligence > 20)
            {
                intelligence = 20;
            }

            if (subRace == SubRace.ForestGnome)
            {
                Dex = Dex + 1;
                if (Dex > 20)
                {
                    Dex = 20;
                }
            }
            if (subRace == SubRace.RockGnome)
            {
                Con = Con + 1;
                if (Con > 20)
                {
                    Con = 20;
                }
            }
        }

        if (race == Race.HalfElf)
        {
            darkVision = true;
            speed = 30;
            Cha = Cha + 2;
            if (Cha > 20)
            {
                Cha = 20;
            }

            if (halfElfStat[0] == Stats.Strength || halfElfStat[1] == Stats.Strength)
            {
                Strength = Strength + 1;
            }
            if (halfElfStat[0] == Stats.Dexterity || halfElfStat[1] == Stats.Dexterity)
            {
                Dex = Dex + 1;
            }
            if (halfElfStat[0] == Stats.Constitution || halfElfStat[1] == Stats.Constitution)
            {
                Con = Con + 1;
            }
            if (halfElfStat[0] == Stats.Intelligence || halfElfStat[1] == Stats.Intelligence)
            {
                intelligence = intelligence + 1;
            }
            if (halfElfStat[0] == Stats.Wisdom || halfElfStat[1] == Stats.Wisdom)
            {
                Wis = Wis + 1;
            }
            if (halfElfStat[0] == Stats.Charisma || halfElfStat[1] == Stats.Charisma)
            {
                Cha = Cha + 1;
            }
            //Add in if half elf selected, choose 2 stats to increase
        }

        if (race == Race.HalfOrc)
        {
            darkVision = true;
            speed = 30;
            Strength = Strength + 2;
            Con = Con + 1;
            if (Strength > 20)
            {
                Strength = 20;
            }
            if (Con > 20)
            {
                Con = 20;
            }
        }

        if (race == Race.Tiefling)
        {
            darkVision = true;
            speed = 30;
            intelligence = intelligence + 1;
            Cha = Cha + 2;
            if (intelligence > 20)
            {
                intelligence = 20;
            }
            if (Cha > 20)
            {
                Cha = 20;
            }
        }
    }

  

    //Level Up
  public  void LevelUp() // level up at certain xp levels (call on xp gain?)
    {
        int currentLevel = level;
        //5e dosent have a standard leve curve instead follws a random number for progression as such automation for this has to be hard coded
        if (Exp >= 300)
        {
            level = 2;
        }
        if (Exp >= 900)
        {
            level = 3;
        }
        if (Exp >= 2700)
        {
            level = 4;
        }
        if (Exp >= 6500)
        {
            level = 5;
        }
        if (Exp >= 14000)
        {
            level = 6;
        }
        if (Exp >= 23000)
        {
            level = 7;
        }
        if (Exp >= 34000)
        {
            level = 8;
        }
        if (Exp >= 48000)
        {
            level = 9;
        }
        if (Exp >= 64000)
        {
            level = 10;
        }
        if (Exp >= 85000)
        {
            level = 11;
        }
        if (Exp >= 100000)
        {
            level = 12;
        }
        if (Exp >= 120000)
        {
            level = 13;
        }
        if (Exp >= 140000)
        {
            level = 14;
        }
        if (Exp >= 165000)
        {
            level = 15;
        }
        if (Exp >= 195000)
        {
            level = 16;
        }
        if (Exp >= 225000)
        {
            level = 17;
        }
        if (Exp >= 265000)
        {
            level = 18;
        }
        if (Exp >= 305000)
        {
            level = 19;
        }
        if (Exp >= 355000)
        {
            level = 20;
        }

        ProfBonus();
        SpellSlots();

        if (currentLevel != level)
        {
            hitDice++;
            HitPoints();
            if (subRace == SubRace.HillDwarf)
            {
                Health = Health + 1;
            }
            if (playerClass == Classes.Monk && level > 1)
            {
                ki = level;
            }
        }
    }

    void SpellSlots()
    {
        if (playerClass == Classes.Barbarian || playerClass == Classes.Fighter ||
            playerClass == Classes.Monk || playerClass == Classes.Ranger && level < 2 ||
            playerClass == Classes.Rogue || playerClass == Classes.Paladin && level < 2)
        {
            hasSpells = false;
        }

        if (playerSubClass == SubClass.EldritchKnight || playerSubClass == SubClass.ArcaneTrickster)
        {
            hasSpells = true;
        }

        if (hasSpells == true)
        {
            if( playerClass != Classes.Warlock || playerClass != Classes.Ranger||
                playerClass != Classes.Paladin || playerClass != Classes.Rogue || playerClass != Classes.Fighter)
            {
                #region basic spell slots
                if (level == 1)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 2;
                   
                }
                else if (level == 2)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 3;
                    
                }
                else if (level == 3)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 4;
                    spellLevel[2] = 2;
                   
                }
                else if (level == 4)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                   
                }
                else if (level == 5)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 2;
                   
                }
                else if (level == 6)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                  
                }
                else if (level == 7)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 1;
                   
                }
                else if (level == 8)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 2;
                   
                }
                else if (level == 9)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 3;
                    spellLevel[5] = 1;
                   
                }
                else if (level == 10)
                {
                    spellLevel[0] = 5;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 3;
                    spellLevel[5] = 2;
                    
                }
                else if (level == 11 || level == 12)
                {
                    spellLevel[0] = 5;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 3;
                    spellLevel[5] = 2;
                    spellLevel[6] = 1;
                   
                }
                else if (level == 13 || level == 14)
                {
                    spellLevel[0] = 5;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 3;
                    spellLevel[5] = 2;
                    spellLevel[6] = 1;
                    spellLevel[7] = 1;
                   
                }
                else if (level == 15 || level == 16)
                {
                    spellLevel[0] = 5;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 3;
                    spellLevel[5] = 2;
                    spellLevel[6] = 1;
                    spellLevel[7] = 1;
                    spellLevel[8] = 1;
                    spellLevel[9] = 0;
                }
                else if (level == 17)
                {
                    spellLevel[0] = 5;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 3;
                    spellLevel[5] = 2;
                    spellLevel[6] = 1;
                    spellLevel[7] = 1;
                    spellLevel[8] = 1;
                    spellLevel[9] = 1;
                }
                else if (level == 18)
                {
                    spellLevel[0] = 5;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 3;
                    spellLevel[5] = 3;
                    spellLevel[6] = 1;
                    spellLevel[7] = 1;
                    spellLevel[8] = 1;
                    spellLevel[9] = 1;
                }
                else if (level == 19)
                {
                    spellLevel[0] = 5;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 3;
                    spellLevel[5] = 3;
                    spellLevel[6] = 2;
                    spellLevel[7] = 1;
                    spellLevel[8] = 1;
                    spellLevel[9] = 1;
                }
                else
                {
                    spellLevel[0] = 5;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 3;
                    spellLevel[5] = 3;
                    spellLevel[6] = 2;
                    spellLevel[7] = 2;
                    spellLevel[8] = 1;
                    spellLevel[9] = 1;
                }
                #endregion
            }
                #region cantrip deviation
            if (playerClass == Classes.Bard || playerClass == Classes.Druid)
            {
                spellLevel[0] = spellLevel[0] - 1;
            }
            if (playerClass == Classes.Sorcerer)
            {
                spellLevel[0] = spellLevel[0] + 1;
            }
            #endregion
            if (playerClass == Classes.Warlock)
            {
                #region warlock spell slots
                spellLevel[0] = 2;
                spellLevel[1] = 1;
                if (level == 2)
                {
                    spellLevel[1] = 2;
                }
                else if (level == 3)
                {
                    spellLevel[1] = 0;
                    spellLevel[2] = 2;
                }
                else if (level == 4)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 0;
                    spellLevel[2] = 2;
                }
                else if (level == 5 || level == 6)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 0;
                    spellLevel[2] = 0;
                    spellLevel[3] = 2;
                }
                else if (level == 7 || level == 8)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 0;
                    spellLevel[2] = 0;
                    spellLevel[3] = 0;
                    spellLevel[4] = 2;
                }
                else if (level == 9)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 0;
                    spellLevel[2] = 0;
                    spellLevel[3] = 0;
                    spellLevel[4] = 0;
                    spellLevel[5] = 2;
                }
                else if (level == 10)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 0;
                    spellLevel[2] = 0;
                    spellLevel[3] = 0;
                    spellLevel[4] = 0;
                    spellLevel[5] = 2;
                }
                else if (level == 11 || level == 12 || level == 13 || level == 14 ||
                         level == 15 || level == 16)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 0;
                    spellLevel[2] = 0;
                    spellLevel[3] = 0;
                    spellLevel[4] = 0;
                    spellLevel[5] = 3;
                }
                else if (level == 17 || level == 18 || level == 19 || level == 20)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 0;
                    spellLevel[2] = 0;
                    spellLevel[3] = 0;
                    spellLevel[4] = 0;
                    spellLevel[5] = 4;
                }
                #endregion
            }

            if (playerClass == Classes.Ranger || playerClass == Classes.Paladin)
            {
                #region ranger and paladin spells
                spellLevel[0] = 0;
                if (level == 2)
                {
                    spellLevel[1] = 2;
                }
                else if (level == 3 || level == 4)
                {
                    spellLevel[1] = 3;
                }
                else if (level == 5 || level == 6)
                {
                    spellLevel[1] = 4;
                    spellLevel[2] = 2;
                }
                else if (level == 7 || level == 8)
                {
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                }
                else if (level == 9 || level == 10)
                {
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 2;
                }
                else if (level == 11 || level == 12)
                {
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                }
                else if (level == 13 || level == 14)
                {
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 1;
                }
                else if (level == 15 || level == 16)
                {
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 2;
                }
                else if (level == 17 || level == 18)
                {
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 2;
                    spellLevel[5] = 1;
                }
                else
                {
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 2;
                    spellLevel[5] = 2;
                }
#endregion
            }

            if (playerSubClass == SubClass.EldritchKnight || playerSubClass == SubClass.ArcaneTrickster)
            {
                #region subclass spellslots
                if (level == 3)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 2;
                }
                else if (level == 4 || level == 5 || level == 6)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 3;

                }
                else if (level == 7 || level == 8 || level == 9)
                {
                    spellLevel[0] = 3;
                    spellLevel[1] = 4;
                    spellLevel[2] = 2;
                }
                else if (level == 10 || level == 11 || level == 12)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                }
                else if (level == 13 || level == 14 || level == 15)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 2;
                }
                else if (level == 16 || level == 17 || level == 18)
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                }
                else
                {
                    spellLevel[0] = 4;
                    spellLevel[1] = 4;
                    spellLevel[2] = 3;
                    spellLevel[3] = 3;
                    spellLevel[4] = 1;
                }
#endregion
            }

        }
        
    }

    public void HitPoints()
    {   
        if(hitPointText != null)
        hitPointText.text = Health.ToString();
        if (playerClass == Classes.Barbarian)
        {
            if (level == 1)
            {
                Health = 12 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 12) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Bard)
        {
            if (level == 1)
            {
                Health = 8 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 8) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Cleric)
        {
            if (level == 1)
            {
                Health = 8 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 8) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Druid)
        {
            if (level == 1)
            {
                Health = 8 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 8) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Fighter)
        {
            if (level == 1)
            {
                Health = 10 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 10) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Monk)
        {
            if (level == 1)
            {
                Health = 8 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 8) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Paladin)
        {
            if (level == 1)
            {
                Health = 10 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 10) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Ranger)
        {
            if (level == 1)
            {
                Health = 10 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 10) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Rogue)
        {
            if (level == 1)
            {
                Health = 8 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 8) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Sorcerer)
        {
            if (level == 1)
            {
                Health = 6 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 6) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Warlock)
        {
            if (level == 1)
            {
                Health = 8 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 8) + bonuses[2]);
            }
        }

        if (playerClass == Classes.Wizard)
        {
            if (level == 1)
            {
                Health = 6 + bonuses[2];
            }
            else
            {
                Health = Health + (Random.Range(1, 6) + bonuses[2]);
            }
        }


    }


    public void ProfBonus()
    {
        if (level < 5)
        {
            profBonus = 2;
        }
        else if (level >= 5 && level < 9)
        {
            profBonus = 3;
        }
        else if (level >= 9 && level < 13)
        {
            profBonus = 4;
        }
        else if (level >= 13 && level < 17)
        {
            profBonus = 5;
        }
        else
        {
            profBonus = 6;
        }
    }


    public void DataRead(string name, int str, int dex, int con, int intell, int wis, int cha,
                         CharacterSheet.Race playerRace, CharacterSheet.SubRace playerSubRace, CharacterSheet.Classes thePlayerClass, CharacterSheet.SubClass subClass, CharacterSheet.Alignment playerAlignment,
                         int playerLevel, int xp, int strBonus, int dexBonus, int conBonus, int intellBonus, int wisBonus, int chaBonus)
    {

       

        Name = name;
        Strength = str;
        Dex = dex;
        Con = con;
        intelligence = intell;
        Wis = wis;
        Cha = cha;
        race = playerRace;
        subRace = playerSubRace;
        playerClass = thePlayerClass;
        playerSubClass = subClass;
        alignment = playerAlignment;
        level = playerLevel;
        Exp = xp;
        bonuses[0] = strBonus;
        bonuses[1] = dexBonus;
        bonuses[2] = conBonus;
        bonuses[3] = intellBonus;
        bonuses[4] = wisBonus;
        bonuses[5] = chaBonus;

    }

   
}
