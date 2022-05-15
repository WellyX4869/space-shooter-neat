using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class GameplayHandler : MonoBehaviour
{
    public static GameplayHandler instance;

    [Header("Player Status")]
    [SerializeField] GameObject playerStatusPanel;
    [SerializeField] TextMeshProUGUI waveStatusText;
    [SerializeField] Slider levelStatusSlider;
    int waveStatusCounter;

    [Header("Between Waves")]
    [SerializeField] GameObject wavePanel;
    [SerializeField] TextMeshProUGUI waveLevelText;
    [SerializeField] float waveShowTime;

    [Header("Level Up - Mods")]
    [SerializeField] GameObject levelUpModsPanel;
    [SerializeField] List<Image> randomMods;

    [Header("Angel's Offer")]
    [SerializeField] GameObject angelsOfferPanel;
    [SerializeField] List<Image> randomOffers;

    [Header("Pause")]
    [SerializeField] GameObject pausePanel;
    [SerializeField] List<Image> pickedMods = new List<Image>();
    [SerializeField] GameObject settings;
    [SerializeField] GameObject backHomeConfirmation;
    bool isSettingOpened;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); }
        else { instance = this; }
    }

    private void Start()
    {
        isSettingOpened = false;
        playerStatusPanel.SetActive(true);
        wavePanel.SetActive(false);
        levelUpModsPanel.SetActive(false);
        angelsOfferPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        // For debug purposes only
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextWave();
        }
    }

    #region BETWEEN WAVES
    public void ShowNextWave()
    {
        // Setup wave panel
        StartCoroutine(ShowNextWaveCoroutine());
    }

    IEnumerator ShowNextWaveCoroutine()
    {
        // Restrict Player Movement
        PlayerHandler.instance.DisableFire();
        PlayerMovement.instance.DisablePlayerMovement();
        
        // Setup Next Level Wave of Enemies

        waveStatusCounter++;
        waveStatusText.text = waveStatusCounter + "/25";
        waveLevelText.text = "Wave " + waveStatusCounter;
        CommonHandler.instance.FadeInAnimation(wavePanel, null, 0.25f);
        yield return new WaitForSeconds(waveShowTime + 0.25f);
        CommonHandler.instance.FadeOutAnimation(wavePanel, null, 0.2f);
        yield return new WaitForSeconds(0.2f);

        PlayerMovement.instance.EnablePlayerMovement();
        PlayerHandler.instance.EnableFire();
    }
    #endregion

    #region PAUSE
    public void OpenPausePanel()
    {
        Time.timeScale = 0f;
        CommonHandler.instance.FadeInAnimation(pausePanel);
    }

    public void OpenBackHomeConfirmation()
    {
        CommonHandler.instance.FadeInAnimation(backHomeConfirmation);
    }

    public void CancelBackHome()
    {
        backHomeConfirmation.SetActive(false);
    }

    public void BackHome()
    {
        GameManager.instance.LoadMainMenu();
    }

    public void Resume() 
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void TouchSettings()
    {
        isSettingOpened = !isSettingOpened;
        if (isSettingOpened)
            CommonHandler.instance.FadeInAnimation(settings);
        else settings.SetActive(false);
    }

    public void TouchSoundSettings()
    {

    }
    #endregion

    #region LEVEL UP - MODS
    public void ShowLevelUp()
    {
        // Setup Random Mods
    }
    #endregion

    #region ANGEL'S OFFER
    public void ShowAngelsOffer()
    {
        // Setup Random Angel's Offer
    }
    #endregion
}
