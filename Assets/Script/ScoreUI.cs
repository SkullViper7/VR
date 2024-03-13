using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUI : MonoBehaviour
{
    public TextMeshPro _scoreTextP1;
    public TextMeshPro _scoreTextP2;

    //Singleton
    private static ScoreUI _instance = null;
    private ScoreUI() { }
    public static ScoreUI Instance => _instance;
    //

    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        //
        _scoreTextP1.text = "Score joueur 1 : 0";
        _scoreTextP2.text = "Score joueur 2 : 0";
    }

    public void UpdateScore(int scoreP1, int scoreP2)
    {
        _scoreTextP1.text = "Score joueur 1 : " + scoreP1.ToString();
        _scoreTextP2.text = "Score joueur 2 : " + scoreP2.ToString();
    }
}
