using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField] private string nextLevel;
    [SerializeField] private Player player;
    public Image coverImage;

    void Awake()
    {
        Debug.Assert(inputActions != null, "Input Actions not assigned in GameController");
        Debug.Assert(coverImage != null, "Cover Image not assigned in GameController");

        inputActions.Enable();
    }

    void Start()
    {
        IsPlayerAlive = true;

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


    public void OnPlayerDeath()
    {
        if (!IsPlayerAlive) return;
        IsPlayerAlive = false;

        // Pause game, cover screen, reload scene
        StartCoroutine(StartPlayerDeathAnimation());
    }
    

    private IEnumerator StartPlayerDeathAnimation()
    {
        yield return _waitForSeconds1;

        coverImage.color = Color.clear;
        coverImage.enabled = true;

        bool tweenFinished = false;
        LeanTween.alpha(coverImage.rectTransform, 1f, 1f).setEase(LeanTweenType.linear).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            tweenFinished = true;
        });

        yield return new WaitUntil(() => tweenFinished);
        yield return _waitForSeconds1;

        // Restart the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        yield return null;
    }
    

    public void ToNextLevel()
    {
        Debug.Assert(nextLevel != null, "Next Level not assigned in GameController");
        coverImage.color = Color.black;
        coverImage.enabled = true;
        player.isInvincible = true;
        LeanTween.delayedCall(0f, () =>
            LeanTween.alpha(coverImage.rectTransform, 0f, 1f).setEase(LeanTweenType.linear).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                coverImage.enabled = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
                player.isInvincible = false;
            })
        ).setIgnoreTimeScale(true);
        Time.timeScale = 0f;
    }
    */
}
