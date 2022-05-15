using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CommonHandler : MonoBehaviour
{
    public static CommonHandler instance;

    [Header("Animation Settings")]
    public float fadeInDuration;
    public float fadeOutDuration;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void FadeInAnimation(GameObject panel, GameObject parent = null, float fadeDuration = -1f)
    {
        StartCoroutine(FadeIn(panel, parent, fadeDuration));
    }

    public void FadeOutAnimation(GameObject panel, GameObject parent = null, float fadeDuration = -1f)
    {
        StartCoroutine(FadeOut(panel, parent, fadeDuration));
    }

    IEnumerator FadeIn(GameObject panel, GameObject parent = null, float fadeDuration = -1f)
    {
        float FadeDuration = fadeDuration < 0 ? fadeInDuration : fadeDuration;
        if (parent != null) { parent.SetActive(true); }
        var panelImages = panel.GetComponentsInChildren<Image>();
        var panelTexts = panel.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (Image panelImage in panelImages)
        {
            // if the gameobject of image is not active then don't add them
            Color defaultColor = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, panelImage.color.a);
            panelImage.color = new Color(0, 0, 0, 0);
            panelImage.DOColor(defaultColor, FadeDuration).SetUpdate(true);
        }
        foreach (TextMeshProUGUI panelText in panelTexts)
        {
            Color defaultColor = new Color(panelText.color.r, panelText.color.g, panelText.color.b, panelText.color.a);
            panelText.color = new Color(0, 0, 0, 0);
            panelText.DOColor(defaultColor, FadeDuration).SetUpdate(true);
        }
        panel.SetActive(true);
        yield return new WaitForSeconds(FadeDuration);
    }

    IEnumerator FadeOut(GameObject panel, GameObject parent = null, float fadeDuration = -1f)
    {
        float FadeDuration = fadeDuration < 0 ? fadeOutDuration : fadeDuration;
        var panelImages = panel.GetComponentsInChildren<Image>();
        var panelTexts = panel.GetComponentsInChildren<TextMeshProUGUI>();
        List<Color> defaultPanelImagesColors = new List<Color>();
        List<Color> defaultPanelTextsColors = new List<Color>();
        foreach (Image panelImage in panelImages)
        {
            defaultPanelImagesColors.Add(panelImage.color);
            panelImage.DOColor(new Color(0, 0, 0, 0), FadeDuration).SetUpdate(true);
        }
        foreach (TextMeshProUGUI panelText in panelTexts)
        {
            defaultPanelTextsColors.Add(panelText.color);
            panelText.DOColor(new Color(0, 0, 0, 0), FadeDuration).SetUpdate(true);
        }

        yield return new WaitForSeconds(FadeDuration);
        panel.SetActive(false); int counterIndex = 0;
        foreach (Image panelImage in panelImages)
        {
            panelImage.DOColor(defaultPanelImagesColors[counterIndex], 0).SetUpdate(true);
            counterIndex++;
        }
        counterIndex = 0;
        foreach (TextMeshProUGUI panelText in panelTexts)
        {
            panelText.DOColor(defaultPanelTextsColors[counterIndex], 0).SetUpdate(true);
            counterIndex++;
        }

        if (parent != null)
        {
            parent.SetActive(false);
        }
    }
}
