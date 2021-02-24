using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSorter
{
    Character[] _characters;
    Dictionary<float, Character> _characterList = new Dictionary<float, Character>();

    public CharacterSorter(Character[] characters)
    {
        _characters = characters;

        Character[] _arrangedCharacters = new Character[_characters.Length];
        _arrangedCharacters[0] = _characters[0];

  
    }

    public void SortAscending()
    {
  
    }
   

}
