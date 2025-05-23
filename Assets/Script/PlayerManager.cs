using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;

    public static PlayerManager Instance { get { return _instance; } }

    public bool IsPlayer1Playing = true;
    public bool IsDrinking = true;

    public List<GameObject> Player1Balls;
    public List<GameObject> Player2Balls;

    public List<Transform> Player1BallsOriginalPos;
    public List<Transform> Player2BallsOriginalPos;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void ResetBalls()
    {
        for (int i = 0; i < Player1Balls.Count; i++)
        {
            Player1Balls[i].transform.position = Player1BallsOriginalPos[i].position;
        }

        for (int i = 0; i < Player2Balls.Count; i++)
        {
            Player2Balls[i].transform.position = Player2BallsOriginalPos[i].position;
        }
    }

    /// <summary>
    /// Is the player 1 playing ?
    /// </summary>
    /// <param name="trueOrFalse"></param>
    public void ChangePlayer(bool trueOrFalse)
    {
        IsPlayer1Playing = trueOrFalse;
    }
}
