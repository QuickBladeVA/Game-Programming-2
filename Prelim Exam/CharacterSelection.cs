using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public CharacterManager characterManager;
    public Transform parentPos;
    public GameObject characterButtonPrefab;
    public CharacterInfoView characterInfoView;

    void Start()
    {
        Debug.Log(characterManager.characters.Count());
        foreach (DNDCharacter c in characterManager.characters)
        {
            GameObject buttonPrefab = Instantiate(characterButtonPrefab,parentPos);
            CharacterButton characterButton = buttonPrefab.GetComponent<CharacterButton>();
            characterButton.SetCharacterData(c);
            Button button =buttonPrefab.GetComponent<Button>();
            button.onClick.AddListener(()=>characterInfoView.OnClick(c));

        }

    }
}
