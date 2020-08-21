using UnityEngine;

public class GameOverEventPublisher : MonoBehaviour
{
    public delegate void GameOverAction();
    public static event GameOverAction OnGameOver;

    private bool isGameOver;

    private void OnTriggerEnter()
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
