using UnityEngine;

public class GameOverEventPublisher : MonoBehaviour
{
    public delegate void GameOverAction();
    public static event GameOverAction OnGameOver;

    bool isGameOver;

    void OnTriggerEnter()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            if (OnGameOver != null)
            {
                OnGameOver();
            }
        }
    }
}
