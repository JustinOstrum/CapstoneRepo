using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "IngredientsDataObject", order = 1)]
public class IngredientData : ScriptableObject
{
    public List<string> fruitNames = new List<string>();
}
