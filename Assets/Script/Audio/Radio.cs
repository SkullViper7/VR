using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    AudioSource _source;

    [SerializeField] AudioClip[] _clips;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        StartCoroutine(Music());
    }

    IEnumerator Music()
    {
        AudioClip clip = _clips[Random.Range(0, _clips.Length)];

        _source.PlayOneShot(clip);

        yield return new WaitForSeconds(clip.length);

        StartCoroutine(Music());
    }
}
