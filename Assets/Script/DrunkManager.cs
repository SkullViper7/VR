using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DrunkManager : MonoBehaviour
{
    private static DrunkManager _instance;

    public static DrunkManager Instance { get { return _instance; } }

    public float Drunkenness;

    [SerializeField] Volume _blur;
    [SerializeField] Volume _wobble;
    [SerializeField] Animator _canvas;
    [SerializeField] Animator _wobbleAnim;

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

    private void Update()
    {
        if (Drunkenness <= 1)
        {
            _blur.weight = Drunkenness;
            _wobble.weight = Drunkenness;

            if (Drunkenness >= 0.7f && Drunkenness <= 0.71f)
            {
                _canvas.Play("FadeIn");
            }
        }

        if (Drunkenness >= 0.98f && Drunkenness <= 0.99f)
        {
            _wobbleAnim.enabled = true;
        }
    }
}
