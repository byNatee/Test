using UnityEngine;

public class Game : MonoBehaviour
{
    private void Start() => 
        GameStop();

    private void GameStop()
    {
        Time.timeScale = 0;
        InputController.StartGameAction += GameStart;
    }

    private void GameStart()
    {
        Time.timeScale = 1;
        InputController.StartGameAction -= GameStart;
    }
}
