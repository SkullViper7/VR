using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (DrunkManager.Instance.Drunkenness <= 1)
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
                    DrunkManager.Instance.Drunkenness += 0.0002f;
                }
            }
        }
    }
}
