using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI _score;
    GameSession _gameSession;

    // Start is called before the first frame update
    void Start()
    {
        _score = GetComponent<TextMeshProUGUI>();
        _gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        _score.text = _gameSession.GetScore().ToString();
    }
}
