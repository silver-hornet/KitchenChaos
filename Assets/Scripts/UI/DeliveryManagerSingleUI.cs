using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recipeNameText; // Should use TextMeshProUGUI instead of just TextMeshPro. The former is meant for UI canvases.

    public void SetRecipeSO(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.recipeName;
    }
}
