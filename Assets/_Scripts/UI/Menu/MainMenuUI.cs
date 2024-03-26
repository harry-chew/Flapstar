using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class MainMenuUI : MonoBehaviour
{
    [Header("Animation Settings")]
    public float animationTimer;

    [Header("MainMenu Buttons")]
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;
    public LoadGameAnimation blinkAnimation;

    [Header("SettingsMenu Buttons")]
    public VolumeSliderComponent audioSfxSlider;
    public VolumeSliderComponent musicSlider;
    public Button backButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject settingsMenu;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClick);
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnPlayButtonClick()
    {
        StartCoroutine(LoadGameCoroutine());
    }

    private IEnumerator LoadGameCoroutine()
    {
        blinkAnimation.Blink();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game");
    }

    private void OnSettingsButtonClick()
    {
        Sequence anim = DOTween.Sequence();
        anim.Join(settingsMenu.transform.DOMoveX(0.0f, animationTimer)).SetEase(Ease.InOutCirc);
        anim.Play().WaitForCompletion();
    }

    private void OnQuitButtonClick()
    {
        Application.Quit();
    }

    private void OnBackButtonClick()
    {
        Sequence anim = DOTween.Sequence();
        anim.Join(settingsMenu.transform.DOMoveX(1920.0f, animationTimer)).SetEase(Ease.InOutCirc);
        anim.Play().WaitForCompletion();
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(OnPlayButtonClick);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        quitButton.onClick.RemoveListener(OnQuitButtonClick);
        backButton.onClick.RemoveListener(OnBackButtonClick);
    }
}