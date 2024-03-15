using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUI : MonoBehaviour
{
    public TextMeshPro _closetPlayerText;
    public TextMeshPro _scoreP1;
    public TextMeshPro _scoreP2;

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
        _closetPlayerText.text = "En attente du lancement de la première boule";
        _scoreP1.text = Petanque.Instance.playerName1 + " : 0";
        _scoreP2.text = Petanque.Instance.playerName2 + " : 0";
    }

    // Va 
    public void UpdateClosetPlayer(string closetPlayer)
    {
        _closetPlayerText.text = "Le joueur le plus proche est " + closetPlayer;
    }

    // Va update le texte score des joueurs avec une variable int.
    public void UpdateScorePlayer(int score)
    {
        _scoreP1.text = Petanque.Instance.playerName1 + " : " + score;
        _scoreP2.text = Petanque.Instance.playerName2 + " : " + score;
    }
}
