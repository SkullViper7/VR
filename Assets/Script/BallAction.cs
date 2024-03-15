using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerManager.Instance.IsPlayer1Playing)
        {
            PlayerManager.Instance.Player1Balls.Remove(this.gameObject);
        }

        else
        {
            PlayerManager.Instance.Player2Balls.Remove(this.gameObject);
        }

        StartCoroutine(Petanque.Instance.WaitStopMoveBall());
    }
}
