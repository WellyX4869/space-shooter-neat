using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MainMenuHandler : MonoBehaviour
{
    public static MainMenuHandler instance;

    [Header("Menu")]
    [SerializeField] GameObject confirmationQuitMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject helpMenu;

    [Header("Main Menu")]
    [SerializeField] TextMeshProUGUI gameVersionText;
    [SerializeField] TextMeshProUGUI levelClearedText;
    int gameVersion;

    [Header("Settings")]
    [SerializeField] Sprite toggleOn;
    [SerializeField] Sprite toggleOff;
    [SerializeField] Image soundToggle;
    [SerializeField] Image sfxToggle;
    [SerializeField] Image vibrateToggle;
    bool soundOn = true, sfxOn = true;
    bool vibrateOn = true;

    [Header("Help")]
    [SerializeField] TextMeshProUGUI helpPageText;
    [SerializeField] List<GameObject> helpContents = new List<GameObject>();
    int indexShowedHelpContentPage;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        confirmationQuitMenu.SetActive(false);
        settingsMenu.SetActive(false);
        helpMenu.SetActive(false);

        SetupSettings();
        SetupHelpContent();
    }

    #region MAIN MENU
    public void OpenConfirmationQuitMenu()
    {
        CommonHandler.instance.FadeInAnimation(confirmationQuitMenu);
    }

    public void OpenSettingsMenu()
    {
        CommonHandler.instance.FadeInAnimation(settingsMenu);
    }

    public void OpenHelpMenu()
    {
        CommonHandler.instance.FadeInAnimation(helpMenu);
    }

    public void PlayGame()
    {
        GameManager.instance.LoadGame();
    }

    public void ShowPreviousVersion()
    {

    }

    public void ShowNextVersion()
    {

    }
    #endregion

    #region SETTINGS
    void SetupSettings()
    {
        soundOn = SettingsManager.instance.SoundOn;   
        sfxOn = SettingsManager.instance.SfxOn;
        vibrateOn = SettingsManager.instance.VibrateOn;

        ToggleSound();
        ToggleSFX();
        ToggleVibration();
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
        SettingsManager.instance.SoundOn = soundOn;
        if (soundOn)
        {
            soundToggle.sprite = toggleOn;
            SettingsManager.instance.SoundVolume = 1f;
        }
        else
        {
            soundToggle.sprite = toggleOff;
            SettingsManager.instance.SoundVolume = 0f;
        }
    }

    public void ToggleSFX()
    {
        sfxOn = !sfxOn;
        SettingsManager.instance.SfxOn = sfxOn;
        if (sfxOn)
        {
            sfxToggle.sprite = toggleOn;
            SettingsManager.instance.SfxVolume = 1f;
        }
        else
        {
            sfxToggle.sprite = toggleOff;
            SettingsManager.instance.SfxVolume = 0f;
        }
    }

    public void ToggleVibration()
    {
        vibrateOn = !vibrateOn;
        SettingsManager.instance.VibrateOn = vibrateOn;
        if (vibrateOn)
        {
            vibrateToggle.sprite = toggleOn;
        }
        else
        {
            vibrateToggle.sprite = toggleOff;
        }
    }

    public void CloseSettingsMenu()
    {
        CommonHandler.instance.FadeOutAnimation(settingsMenu);
    }
    #endregion

    #region HELP
    void SetupHelpContent()
    {
        foreach(GameObject content in helpContents)
        {
            content.SetActive(false);
        }
      
        if(helpContents.Count > 0) { helpContents[0].SetActive(true); }
        indexShowedHelpContentPage = 0;

        helpPageText.text = (indexShowedHelpContentPage + 1) + "/" + helpContents.Count;
    }

    public void ShowPreviousHelp()
    {
        if(indexShowedHelpContentPage <= 0) { return; }
        helpContents[indexShowedHelpContentPage].SetActive(false);
        indexShowedHelpContentPage--;
        helpContents[indexShowedHelpContentPage].SetActive(true);
        helpPageText.text = (indexShowedHelpContentPage + 1) + "/" + helpContents.Count;
    }
    
    public void ShowNextHelp()
    {
        if (indexShowedHelpContentPage >= helpContents.Count - 1) { return; }
        helpContents[indexShowedHelpContentPage].SetActive(false);
        indexShowedHelpContentPage++;
        helpContents[indexShowedHelpContentPage].SetActive(true);
        helpPageText.text = (indexShowedHelpContentPage + 1) + "/" + helpContents.Count;
    }   
    
    public void CloseHelpMenu()
    {
        CommonHandler.instance.FadeOutAnimation(helpMenu);
    }
    #endregion

    #region CONFIRMATION QUIT
    public void CloseConfirmationQuitMenu()
    {
        CommonHandler.instance.FadeOutAnimation(confirmationQuitMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
