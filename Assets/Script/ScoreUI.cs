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

        //Affichage de départ par défaut.
        _closetPlayerText.text = "En attente du lancement de la première boule";
        _scoreP1.text = Petanque.Instance.playerName1 + " : 0";
        _scoreP2.text = Petanque.Instance.playerName2 + " : 0";
    }

    // Va update le joueur le plus proche avec une variable string nécessaire.
    public void UpdateClosetPlayer(string closetPlayer)
    {
        _closetPlayerText.text = "Le joueur le plus proche : " + closetPlayer;
    }

    // Va update le texte score des joueurs avec une variable int pour le joueur 1 & 2.
    public void UpdateScorePlayer(int scoreP1, int scoreP2)
    {
        _scoreP1.text = Petanque.Instance.playerName1 + " : " + scoreP1;
        _scoreP2.text = Petanque.Instance.playerName2 + " : " + scoreP2;
    }
}
