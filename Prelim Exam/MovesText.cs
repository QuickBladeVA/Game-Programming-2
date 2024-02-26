using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MovesText : MonoBehaviour
{
    public TextMeshProUGUI movesTxt;


    public void SetMovesData(Moves unit)
    {
        if (unit.description == null||unit.description=="")
        {
            movesTxt.text = unit.name.ToString() + " Damage: " + unit.damage + " Damage type: " + unit.type;
        }
        else
        {
            movesTxt.text = unit.name.ToString() + " Damage: " + unit.damage + " Damage type: " + unit.type + " Description: " + unit.description;
        }
    }
}
