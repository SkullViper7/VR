using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DrunkManager : MonoBehaviour
{
    private static DrunkManager _instance;

    public static DrunkManager Instance { get { return _instance; } }

    public float Player1Drunkenness;
    public float Player2Drunkenness;

    [SerializeField] Volume _blur;
    [SerializeField] Volume _wobble;
    [SerializeField] Animator _canvas;
    [SerializeField] Animator _wobbleAnim;
    public Slider DrinkSlider; 

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
        float activeDrunkenness;

        if (PlayerManager.Instance.IsPlayer1Playing)
        {
            activeDrunkenness = Player1Drunkenness;
        }
        else
        {
            activeDrunkenness = Player2Drunkenness;
        }

        if (activeDrunkenness <= 1)
        {
            _blur.weight = activeDrunkenness;
            _wobble.weight = activeDrunkenness;

            if (activeDrunkenness >= 0.7f && activeDrunkenness <= 0.71f)
            {
                _canvas.Play("FadeIn");
            }
        }

        if (activeDrunkenness >= 0.98f && activeDrunkenness <= 0.99f)
        {
            _wobbleAnim.enabled = true;
        }
    }
}
