using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUI : MonoBehaviour
{
    public TextMeshPro _scoreText;

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
        _scoreText.text = "En attente du lancement de la première boule";
    }

    public void UpdateScore(string closetPlayer)
    {
        _scoreText.text = "Le joueur le plus proche est " + closetPlayer;
    }
}
