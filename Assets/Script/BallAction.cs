using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("A passer le collider");
        StartCoroutine(Petanque.Instance.WaitStopMoveBall());
    }
}
