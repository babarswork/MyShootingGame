using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private int enemyKillCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        Debug.Log("kills" + enemyKillCount);
    }
    public void RestartGame()
    {
        Invoke("Restart", 5f);
    }
    void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gunshoot");
    }
}
