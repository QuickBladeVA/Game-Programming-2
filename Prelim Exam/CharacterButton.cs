using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    public TextMeshProUGUI classTxt;
    public TextMeshProUGUI levelText;

public void SetCharacterData(DNDCharacter unit)
    {
        classTxt.text = unit.classRole.ToString();
        levelText.text = unit.level.ToString();
    }
}
