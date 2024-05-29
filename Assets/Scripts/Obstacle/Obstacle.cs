using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Action<int> TakeDamageEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            TakeDamageEvent?.Invoke(25);
            AudioController.Instance.PlaySFX("Damage");
        }
    }
}
