using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character")]
public class DNDCharacter : ScriptableObject
{
    [Header("Adjustable Attributes")]
    private string folderPath = "Token"; // Folder name inside the Assets/Resources folder
    public string name;
    public ClassRole classRole;
    public Sprite token;
    public int level;
    public Race race;

    public string description;

    //Base Stats
    public int baseStr;
    public int baseDex;
    public int baseCon;
    public int baseInt;
    public int baseWis;
    public int baseCha;



    public Moves[] moves;
}
