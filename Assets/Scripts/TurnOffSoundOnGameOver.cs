using UnityEngine;

public class TurnOffSoundOnGameOver : MonoBehaviour
{
    private void OnEnable()
    {
        GameOverEventPublisher.OnGameOver += TurnOffSound;
    }

    private void OnDisable()
    {
        GameOverEventPublisher.OnGameOver -= TurnOffSound;
    }

    private void TurnOffSound()
    {
        GetComponent<AudioSource>()?.Stop();
    }
}