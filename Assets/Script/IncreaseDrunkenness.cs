using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IncreaseDrunkenness : MonoBehaviour
{
    ParticleSystem _particleSystem;
    ParticleCollisionEvent[] _collisionEvents;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _collisionEvents = new ParticleCollisionEvent[16];
    }

    private void OnParticleCollision(GameObject other)
    {
        if (DrunkManager.Instance.Player1Drunkenness <= 1)
        {
            int collCount = _particleSystem.GetSafeCollisionEventSize();

            if (collCount > _collisionEvents.Length)
            {
                _collisionEvents = new ParticleCollisionEvent[collCount];
            }

            int eventCount = _particleSystem.GetCollisionEvents(other, _collisionEvents);

            for (int i = 0; i < eventCount; i++)
            {
                if (other.tag == "MainCamera")
                {
                    if (DrunkManager.Instance.DrinkSlider.value < 1)
                    {
                        DrunkManager.Instance.DrinkSlider.value += 0.002f;
                    }

                    if (PlayerManager.Instance.IsPlayer1Playing)
                    {
                        DrunkManager.Instance.Player1Drunkenness += 0.0002f;
                    }
                    else
                    {
                        DrunkManager.Instance.Player2Drunkenness += 0.0002f;
                    }

                    if (DrunkManager.Instance.DrinkSlider.value >= 1)
                    {
                        DrunkManager.Instance.Slider.SetActive(false);
                        DrunkManager.Instance.Tip.text = "You can play now !";

                        if (PlayerManager.Instance.IsPlayer1Playing)
                        {
                            for (int j = 0; j < PlayerManager.Instance.Player1Balls.Count; j++)
                            {
                                PlayerManager.Instance.Player1Balls[j].SetActive(true);
                            }
                        }

                        else
                        {
                            for (int j = 0; j < PlayerManager.Instance.Player2Balls.Count; j++)
                            {
                                PlayerManager.Instance.Player2Balls[j].SetActive(true);
                            }
                        }
                    }
                }
            }
        }
    }
}
