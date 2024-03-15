using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetBottlePos : MonoBehaviour
{
    // Help by : https://www.youtube.com/watch?v=lPPa9y_czlE

    [SerializeField] private Transform _initPosBottle;
    [SerializeField] private Transform _PosBottle;

    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject _presser;
    private AudioSource _sound;
    private bool _isPressed;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            _presser = other.gameObject;
            onPress.Invoke();
            _sound.Play();
            _isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == _presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            _isPressed = false;
        }
    }

    public void ResetPos()
    {
        _PosBottle = _initPosBottle;
    }
}
