using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowGameOverText : MonoBehaviour {
    [SerializeField] public Text gameOverText;
    [SerializeField] public Text tapToContinueText;
    [SerializeField] public GameObject hideOnGameOver;
    [SerializeField] public GameObject finalExplosion;

    private bool isReadyToRestart;
    private const float textFadeTime = 1.0f;
    private const float delayBetweenExplosionAndText = 0.5f;

    private void Start()
    {
        gameOverText.CrossFadeAlpha(0.0f, 0.0f, false);
        tapToContinueText.CrossFadeAlpha(0.0f, 0.0f, false);

    }

    private void OnEnable()
    {
        GameOverEventPublisher.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameOverEventPublisher.OnGameOver -= OnGameOver;
    }

    private void OnGameOver() {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
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

        if (modeButton != null)
        {
            modeButton.CrossFadeAlpha(1.0f, textFadeTime, true);
        }
        if (tapToContinueText != null)
        {
            tapToContinueText.CrossFadeAlpha(1.0f, textFadeTime, true);
            isReadyToRestart = true;
        }
    }

    public void Restart()
    {
        if (!isReadyToRestart) return;
        Time.timeScale = 1.0f;
        print("Restart");
        SceneManager.LoadScene(0);
    }


}
