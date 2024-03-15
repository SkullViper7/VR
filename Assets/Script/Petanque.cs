using System.Collections;
using UnityEngine;

public class Petanque : MonoBehaviour
{
    [SerializeField] private GameObject[] _boulesP1;
    [SerializeField] private GameObject[] _boulesP2;
    [SerializeField] private GameObject _cochonet;
    public string playerName1;
    public string playerName2;
    private int _scoreP1;
    private int _scoreP2;
    private float _speed;
    private Rigidbody _rb;

    //Singleton
    private static Petanque _instance = null;
    private Petanque() { }
    public static Petanque Instance => _instance;
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
    }

    public IEnumerator WaitStopMoveBall()
    {
        bool allStopP1 = false;
        bool allStopP2 = false;

        foreach (GameObject go in _boulesP1)
        {
            _rb = go.GetComponent<Rigidbody>();
            _speed = _rb.velocity.magnitude;
            if (_speed >= 0.5f)
            {
                yield return new WaitUntil(() => _rb.velocity.magnitude < 0.5f);
            }
        }

        allStopP1 = true;
        foreach (GameObject go in _boulesP2)
        {
            _rb = go.GetComponent<Rigidbody>();
            _speed = _rb.velocity.magnitude;
            if (_speed >= 0.5f)
            {
                yield return new WaitUntil(() => _rb.velocity.magnitude < 0.5f);
            }
        }

        allStopP2 = true;
        if (allStopP1 && allStopP2)
        {
            GetClosestPlayer();
        }
    }

    private void GetClosestPlayer()
    {
        float closestDistanceP1 = float.MaxValue;
        float closestDistanceP2 = float.MaxValue;

        foreach (GameObject go in _boulesP1)

        {
            float distance = Vector3.Distance(go.transform.position, _cochonet.transform.position);
            if (distance < closestDistanceP1)
            {
                closestDistanceP1 = distance;
            }
        }

        foreach (GameObject go in _boulesP2)
        {
            float distance = Vector3.Distance(go.transform.position, _cochonet.transform.position);
            if (distance < closestDistanceP2)
            {
                closestDistanceP2 = distance;
            }
        }
        if (closestDistanceP1 < closestDistanceP2)
        {
            if (string.IsNullOrEmpty(playerName1))
            {
                ScoreUI.Instance.UpdateClosetPlayer("le joueur 1");
                _scoreP1++;
                ScoreUI.Instance.UpdateScorePlayer(_scoreP1);
            }
            else
            {
                ScoreUI.Instance.UpdateClosetPlayer(playerName1);
                _scoreP1++;
                ScoreUI.Instance.UpdateScorePlayer(_scoreP1);
            }
        }
        else
        {
            if (string.IsNullOrEmpty(playerName2))
            {
                ScoreUI.Instance.UpdateClosetPlayer("le joueur 2");
                _scoreP2++;
                ScoreUI.Instance.UpdateScorePlayer(_scoreP2);
            }
            else
            {
                ScoreUI.Instance.UpdateClosetPlayer(playerName2);
                _scoreP2++;
                ScoreUI.Instance.UpdateScorePlayer(_scoreP2);
            }
        }
    }
}
