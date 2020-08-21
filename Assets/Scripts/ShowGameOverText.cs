using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameOverText : MonoBehaviour {
    [SerializeField] Text gameOverText;
    [SerializeField] Text tapToContinueText;
    [SerializeField] GameObject hideOnGameOver;
    [SerializeField] GameObject finalExplosion;

    bool isReadyToRestart;
    const float textFadeTime = 1.0f;
    const float delayBetweenExplosionAndText = 0.5f;

    void Start()
    {
        gameOverText.CrossFadeAlpha(0.0f, 0.0f, false);
        tapToContinueText.CrossFadeAlpha(0.0f, 0.0f, false);

    }

    void OnEnable()
    {
        GameOverEventPublisher.OnGameOver += OnGameOver;
    }

    void OnDisable()
    {
        GameOverEventPublisher.OnGameOver -= OnGameOver;
    }

    void OnGameOver() {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        Time.timeScale = 0;
        hideOnGameOver?.SetActive(false);
        if (finalExplosion != null)
        {
            finalExplosion.SetActive(true);
            yield return new WaitForSecondsRealtime(delayBetweenExplosionAndText);
        }
        if (gameOverText != null)
        {
            gameOverText.CrossFadeAlpha(1.0f, textFadeTime, true);
            yield return new WaitForSecondsRealtime(textFadeTime);
        }
        if (tapToContinueText != null)
        {
            tapToContinueText.CrossFadeAlpha(1.0f, textFadeTime, true);
            isReadyToRestart = true;
        }
    }

    void Update()
    {
        if (isReadyToRestart && Input.GetButton("Fire1"))
        {
            Time.timeScale = 1.0f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }


}
