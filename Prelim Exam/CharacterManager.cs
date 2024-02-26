using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public DNDCharacter[] characters;
    private string folderPath = "Characters"; // Folder name inside the Assets/Resources folder

    void Awake()
    {
        characters = Resources.LoadAll<DNDCharacter>(folderPath);
    }
}
