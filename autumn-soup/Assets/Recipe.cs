using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Makes it editable in the Inspector
public class Recipe
{
    public string dishName;
    public List<string> requiredIngredients;
}
