using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private int _score = 0;

    //TODO SetUpSingleton same imlementation!
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() => _score;

    public void AddScore(int score) => _score += score;

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
