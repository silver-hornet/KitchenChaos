using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;

    void Awake()
    {
        playButton.onClick.AddListener(() => // This is a Lambda, which is a type of Delegate. In this case, this is the equivalent of calling a function such as void PlayClick()
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        quitButton.onClick.AddListener(() => // This is a Lambda, which is a type of Delegate. In this case, this is the equivalent of calling a function such as void PlayClick()
        {
            Application.Quit();
        });
    }
}
