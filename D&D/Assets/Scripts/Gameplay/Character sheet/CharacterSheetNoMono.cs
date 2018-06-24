using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterSheetNoMono {


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
    public bool hasSpells = true;

    public Stats[] halfElfStat = new Stats[2];


    public GameObject CreatorUI;
    public Text hitPointText;



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


    public void DataRead(string name, int str, int dex, int con, int intell, int wis, int cha,
                         CharacterSheetNoMono.Race playerRace, CharacterSheetNoMono.SubRace playerSubRace, CharacterSheetNoMono.Classes thePlayerClass,
                         CharacterSheetNoMono.SubClass subClass, CharacterSheetNoMono.Alignment playerAlignment,
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
