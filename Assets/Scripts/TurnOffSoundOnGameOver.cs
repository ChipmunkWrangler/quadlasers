using UnityEngine;

public class TurnOffSoundOnGameOver : MonoBehaviour
{
    void OnEnable()
    {
        GameOverEventPublisher.OnGameOver += TurnOffSound;
    }

    void OnDisable()
    {
        GameOverEventPublisher.OnGameOver -= TurnOffSound;
    }

    void TurnOffSound()
    {
        GetComponent<AudioSource>()?.Stop();
    }
}