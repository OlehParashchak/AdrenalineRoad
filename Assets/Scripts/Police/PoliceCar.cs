using System.Collections;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float chaseDuration = 5f;

    private Transform player;
    private bool isChasing = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(ChasePlayer());
    }

    private void Update()
    {
        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private IEnumerator ChasePlayer()
    {
        isChasing = true;
        yield return new WaitForSeconds(chaseDuration);
        isChasing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                StartCoroutine(Retreat());
            }
        }
    }

    private IEnumerator Retreat()
    {
        isChasing = false;
        yield return new WaitForSeconds(1f);
        isChasing = true;
        StartCoroutine(ChasePlayer());
    }
}