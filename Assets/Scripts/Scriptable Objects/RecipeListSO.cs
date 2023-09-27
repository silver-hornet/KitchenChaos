using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu()] // We only want one of these in the game, so don't need to have this as an option. But turned it on initially to add SOs to the List in the Inspector.
public class RecipeListSO : ScriptableObject
{
    public List<RecipeSO> recipeSOList;
}
