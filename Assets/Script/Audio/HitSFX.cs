using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSFX : MonoBehaviour
{
    AudioSource _source;
    [SerializeField] AudioClip _ballHit;
    [SerializeField] AudioClip _groundHit;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1Ball" || collision.gameObject.tag == "Player2Ball")
        {
            _source.PlayOneShot(_ballHit);
        }

        if (collision.gameObject.tag == "Ground")
        {
            _source.PlayOneShot(_groundHit);
        }
    }
}
