using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recipesDeliveredText;

    void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += Instance_OnStateChanged;
        Hide();
    }

    private void Instance_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();
            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
            StartCoroutine(RestartGame()); // This was not in the course, but I added a quick way for the game to automatically restart after game over (since this was missed in the course).
        }
        else
        {
            Hide();
        }
    }

    void Show()
    {
        gameObject.SetActive(true);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(4f);
        Loader.Load(Loader.Scene.MainMenuScene);
    }
}
