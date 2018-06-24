using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using UnityEngine;

public class WriteToFile : MonoBehaviour {

    public static WriteToFile writeToFile;

    public static List<string> loadedData = new List<string>();
    TextAsset textAsset;

    string path = "Assets/Resources/";
    int lineNo = 0;
    string[] data;
    string line;

    private void Awake()
    {
        writeToFile = this;
    }

    public void WriteString()
    {
       
        StreamWriter writer = new StreamWriter(path + CharacterSheet.characterSheet.Name + ".txt", false);
        writer.WriteLine( CharacterSheet.characterSheet.Name);
        writer.WriteLine( CharacterSheet.characterSheet.Strength);
        writer.WriteLine(CharacterSheet.characterSheet.Dex);
        writer.WriteLine(CharacterSheet.characterSheet.Con);
        writer.WriteLine(CharacterSheet.characterSheet.intelligence);
        writer.WriteLine(CharacterSheet.characterSheet.Wis);
        writer.WriteLine(CharacterSheet.characterSheet.Cha);
        writer.WriteLine(CharacterSheet.characterSheet.race);
        writer.WriteLine(CharacterSheet.characterSheet.subRace);
        writer.WriteLine(CharacterSheet.characterSheet.playerClass);
        writer.WriteLine(CharacterSheet.characterSheet.playerSubClass);
        writer.WriteLine(CharacterSheet.characterSheet.alignment);
        writer.WriteLine(CharacterSheet.characterSheet.level);
        writer.WriteLine(CharacterSheet.characterSheet.Exp);
        for (int i = 0; i < 6; i++)
        {
            writer.WriteLine("Modifier: " + CharacterSheet.characterSheet.bonuses[i]);
        }
        writer.Close();
    }

    public void WriteData()
    {
        string filePath = "Assets/Resources/" + CharacterSheet.characterSheet.Name + ".dat";
        FileStream file;

        if (File.Exists(filePath))
        {
            file = File.OpenWrite(filePath);
        }
        else
        {
            file = File.Create(filePath);
        }

       

       

        file.Close();
        
    }

    public void ReadData()
    {
        StreamReader streamReader = new StreamReader(path + CharacterSheet.characterSheet.Name + ".txt");

        line = streamReader.ReadLine();
        
        while (line != null)
        {
            data[lineNo] = line;
            lineNo++;
            line = streamReader.ReadLine();
        }

        CharacterSheet.characterSheet.DataRead(data[0], int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]),
                                               (CharacterSheet.Race)Enum.Parse(typeof(CharacterSheet.Race),data[7]), (CharacterSheet.SubRace)Enum.Parse(typeof(CharacterSheet.SubRace),data[8]),
                                               (CharacterSheet.Classes)Enum.Parse(typeof(CharacterSheet.Classes), data[9]), (CharacterSheet.SubClass)Enum.Parse(typeof(CharacterSheet.SubClass), data[10]),
                                               (CharacterSheet.Alignment)Enum.Parse(typeof(CharacterSheet.Alignment), data[11]),
                                               int.Parse(data[12]), int.Parse(data[13]), int.Parse(data[14]), int.Parse(data[15]),
                                               int.Parse(data[16]), int.Parse(data[17]), int.Parse(data[18]), int.Parse(data[19]));
                                              
  
    }



}
