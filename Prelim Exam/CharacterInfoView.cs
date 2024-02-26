using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class CharacterInfoView : MonoBehaviour
{
    public DNDCharacter character;

    [Header("UI Headers")]
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI classText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI raceText;
    public TextMeshProUGUI descText;

    public TextMeshProUGUI strText;
    public TextMeshProUGUI dexText;
    public TextMeshProUGUI conText;
    public TextMeshProUGUI intText;
    public TextMeshProUGUI wisText;
    public TextMeshProUGUI chaText;

    public TextMeshProUGUI strModText;
    public TextMeshProUGUI dexModText;
    public TextMeshProUGUI conModText;
    public TextMeshProUGUI intModText;
    public TextMeshProUGUI wisModText;
    public TextMeshProUGUI chaModText;

    public Image image;


    public GameObject characterTextPrefab;
    public Transform parentPos;

    [Header("Fixed Attributes")]

    public int hp;
    public int attack;
    private int classHp;
    public int classAttack;
    public int ac;
    public int initiative;
    public int speed;

    //Modifiers
    public int strMod;
    public int dexMod;
    public int conMod;
    public int intMod;
    public int wisMod;
    public int chaMod;


    private string folderPath = "Class"; // Folder name inside the Assets/Resources folder


    public void OnClick(DNDCharacter character)
    {
        ClearMoves();
        Modifiers(character);
        ClassContent(character);
        RaceContent(character);
        hp = (classHp * character.level) + conMod;
        attack = (classAttack * character.level);
        character.moves = Resources.LoadAll<Moves>(folderPath);
        initiative = (10 + dexMod);
        Moves(character);
        DisplayCharacter(character);
    }

    public void DisplayCharacter(DNDCharacter character)
    {
        characterNameText.text = character.name;
        classText.text = character.classRole.ToString();
        levelText.text = character.level.ToString();
        hpText.text = hp.ToString();
        attackText.text = attack.ToString();
        raceText.text = character.race.ToString();
        if (descText == null || character.description == "")
        {
            descText.text = "???";
        }
        else
        {
            descText.text = character.description.ToString();
        }
        if (character.token == null) 
        {
            image.sprite = Resources.Load<Sprite>("Unknown");
        }
        else
        {
            image.sprite =character.token;
        }


        strText.text = character.baseStr.ToString();
        dexText.text = character.baseDex.ToString();
        conText.text = character.baseCon.ToString();
        intText.text = character.baseInt.ToString();
        wisText.text = character.baseWis.ToString();
        chaText.text = character.baseCha.ToString();

        strModText.text=strMod.ToString();
        dexModText.text=dexMod.ToString();
        conModText.text=conMod.ToString();
        intModText.text=intMod.ToString();
        wisModText.text = wisMod.ToString(); 
        chaModText.text = chaMod.ToString();

    }

    public void ClearView()
    {
        character = null;
        characterNameText.text = "--";
        classText.text = "--";
        levelText.text = "--";
        hpText.text = "--";
        attackText.text = "--";
        raceText.text = "--";

        descText.text = "???";

        strText.text = "--";
        dexText.text = "--";
        conText.text = "--";
        intText.text = "--";
        wisText.text = "--";
        chaText.text = "--";

        strModText.text = "--";
        dexModText.text = "--";
        conModText.text = "--";
        intModText.text = "--";
        wisModText.text = "--";
        chaModText.text = "--";
        

    }

    void OnDisable()
    {
        ClearView();
    }

    public void Modifiers(DNDCharacter character)
    {
        strMod = (character.baseStr - 10) / 2;
        dexMod = (character.baseDex - 10) / 2;
        conMod = (character.baseCon - 10) / 2;
        intMod = (character.baseInt - 10) / 2;
        wisMod = (character.baseWis - 10) / 2;
        chaMod = (character.baseCha - 10) / 2;
    }

    public void ClassContent(DNDCharacter character)
    {
        switch (character.classRole)
        {
            case ClassRole.Artificer:
                classHp = 8;
                folderPath = "Class/Artificer";
                classAttack = intMod;
                ac = (10 + dexMod);

                break;

            case ClassRole.Barbarian:
                classHp = 12;
                folderPath = "Class/Barbarian";
                classAttack = strMod;
                break;

            case ClassRole.Bard:
                classHp = 8;
                folderPath = "Class/Bard";
                classAttack = chaMod;
                ac = (10 + dexMod);
                break;

            case ClassRole.Cleric:
                classHp = 8;
                folderPath = "Class/Cleric";
                classAttack = wisMod;
                break;

            case ClassRole.Druid:
                classHp = 8;
                folderPath = "class/Druid";
                classAttack = wisMod;
                break;

            case ClassRole.Fighter:
                classHp = 10;
                folderPath = "Class/Fighter";
                classAttack = (strMod) + (dexMod / 2);
                break;

            case ClassRole.Monk:
                classHp = 8;
                folderPath = "Class/Monk";
                classAttack = (dexMod) + (wisMod / 2);
                break;

            case ClassRole.Paladin:
                classHp = 10;
                folderPath = "Class/Paladin";
                classAttack = (chaMod) + (strMod / 2);
                break;

            case ClassRole.Ranger:
                classHp = 10;
                folderPath = "Class/Ranger";
                classAttack = (dexMod) + (strMod / 2);
                break;

            case ClassRole.Rogue:
                classHp = 8;
                folderPath = "Class/Rogue";
                classAttack = dexMod;
                break;

            case ClassRole.Sorcerer:
                classHp = 6;
                folderPath = "Class/Sorcerer";
                classAttack = chaMod;
                break;

            case ClassRole.Warlock:
                classHp = 8;
                folderPath = "Class/Warlock";
                classAttack = chaMod;
                break;

            case ClassRole.Wizard:
                classHp = 6;
                folderPath = "Class/Wizard";
                classAttack = intMod;
                break;
        }
    }

    public void RaceContent(DNDCharacter character)
    {
        switch (character.race)
        {
            case Race.Human:
                speed = 30;
                strMod = +1;
                dexMod = +1;
                conMod = +1;
                intMod = +1;
                wisMod = +1;
                chaMod = +1;

                break;
            case Race.Elf:
                speed = 35;
                dexMod = +3;
                wisMod = +1;
                break;
            case Race.Dwarf:
                speed = 25;
                conMod = +3;
                strMod = +1;
                break;
            case Race.Halfling:
                speed = 25;
                dexMod = +2;
                chaMod = +2;
                break;
            case Race.Gnome:
                speed = 25;
                intMod = +3;
                dexMod = +1;
                break;
            case Race.HalfOrc:
                speed = 30;
                strMod = +3;
                conMod = +1;
                break;
            case Race.Tiefling:
                speed = 30;
                chaMod = +3;
                intMod = +1;
                break;
            case Race.Dragonborn:
                speed = 30;
                strMod = +2;
                chaMod = +2;
                break;

        }
    }

    public void Moves(DNDCharacter character)
    {
        Debug.Log(character.moves);
        foreach (Moves m in character.moves)
        {
            GameObject TextPrefab = Instantiate(characterTextPrefab, parentPos);
            MovesText characterText = TextPrefab.GetComponent<MovesText>();
            characterText.SetMovesData(m);
        }
    }
    public void ClearMoves ()
    {
        GameObject[] deleteMoves = GameObject.FindGameObjectsWithTag("Move");

        foreach (GameObject m in deleteMoves)
        {
            Destroy(m);
        }
    }
}
