using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeliveryResultUI : MonoBehaviour
{
    const string POPUP = "Popup";

    [SerializeField] Image backgroundImage;
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] Color successColor;
    [SerializeField] Color failedColor;
    [SerializeField] Sprite successSprite;
    [SerializeField] Sprite failedSprite;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;

        gameObject.SetActive(false);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUP);
        backgroundImage.color = failedColor;
        iconImage.sprite = failedSprite;
        messageText.text = "DELIVERY\nFAILED";
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUP);
        backgroundImage.color = successColor;
        iconImage.sprite = successSprite;
        messageText.text = "DELIVERY\nSUCCESS";
    }
}
