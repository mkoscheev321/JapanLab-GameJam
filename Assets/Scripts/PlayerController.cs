using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    public Image coverImage;

    void Start()
    {
        Time.timeScale = 0f;

        FadeFromBlack(1f, () =>
        {
            Time.timeScale = 1f;
        });
    }

    public LTDescr FadeToBlack(float duration = 1f, System.Action callback = null)
    {
        coverImage.color = Color.clear;
        coverImage.enabled = true;
        return LeanTween.alpha(coverImage.rectTransform, 1f, duration).setEase(LeanTweenType.linear).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public LTDescr FadeFromBlack(float duration = 1f, System.Action callback = null)
    {
        coverImage.color = Color.black;
        coverImage.enabled = true;
        return LeanTween.alpha(coverImage.rectTransform, 0f, duration).setEase(LeanTweenType.linear).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            coverImage.enabled = false;
            callback?.Invoke();
        });
    }

    public void ToNextLevel()
    {
        Debug.Assert(nextLevel != null, "Next Level not assigned in GameController");
        coverImage.color = Color.black;
        coverImage.enabled = true;
        LeanTween.delayedCall(0f, () =>
            LeanTween.alpha(coverImage.rectTransform, 0f, 1f).setEase(LeanTweenType.linear).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                coverImage.enabled = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
            })
        ).setIgnoreTimeScale(true);
        Time.timeScale = 0f;
    }
    
}
