using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            if (health.CurrentHealth < health.MaxHealth)
            {
                AudioController.Instance.PlaySFX("Bonus");
                Destroy(collision.gameObject);
                health.CurrentHealth += 25;
            }
        }
    }
}
