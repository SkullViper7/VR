using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Petanque : MonoBehaviour
{
    [SerializeField] private GameObject[] _boulesP1;
    [SerializeField] private GameObject[] _boulesP2;
    [SerializeField] private GameObject _cochonet;
    private float speed;
    private Rigidbody rb;
    public int ScoreP1;
    public int ScoreP2;

    private void OnCollisionEnter(Collision collision)
    {
        WaitStopMoveBall();
    }

    IEnumerator WaitStopMoveBall()
    {
        foreach (GameObject go in _boulesP1)
        {
            rb = go.GetComponent<Rigidbody>();
            speed = rb.velocity.magnitude;
            if (speed < 0.5)
            {
                Score();
            }
        }
       yield return null;
    }

    private void Score()
    {
        ScoreP1 = 0;
        ScoreP2 = 0;

        foreach (GameObject go in _boulesP1)
        {
            float dist = Vector3.Distance(go.transform.position, _cochonet.transform.position);
            dist = dist * 100;
            ScoreP1 = ScoreP1 + (int)dist;
        }

        foreach (GameObject go in _boulesP2)
        {
            float dist = Vector3.Distance(go.transform.position, _cochonet.transform.position);
            dist = dist * 100;
            ScoreP2 = ScoreP2 + (int)dist;
        }
        Debug.Log("Score P1 " + ScoreP1);
        Debug.Log("Score P2 " + ScoreP2);
    }
}
