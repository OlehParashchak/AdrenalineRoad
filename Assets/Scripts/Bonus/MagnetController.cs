using System.Collections;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public UIController UiController;

    [SerializeField] private float magnetDuration = 5f;
    [SerializeField] private float magnetStrength = 4f;

    private bool isMagnetActive = false;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        UiController.MagnetSlider.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Magnet"))
        {
            ActivateMagnet();
            Destroy(collision.gameObject);
        }
    }

    private void ActivateMagnet()
    {
        if (!isMagnetActive)
        {
            AudioController.Instance.PlaySFX("Bonus");
            isMagnetActive = true;
            UiController.MagnetSlider.gameObject.SetActive(true);
            StartCoroutine(MagnetRoutine());
        }
    }

    private IEnumerator MagnetRoutine()
    {
        float timer = 0f;
        UiController.MagnetSlider.maxValue = magnetDuration;
        UiController.MagnetSlider.value = magnetDuration;

        while (timer < magnetDuration)
        {
            timer += Time.deltaTime;
            UiController.MagnetSlider.value = magnetDuration - timer;
            AttractScore();
            yield return null;
        }

        isMagnetActive = false;
        UiController.MagnetSlider.gameObject.SetActive(false);
    }

    private void AttractScore()
    {
        GameObject[] score = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in score)
        {
            Vector3 direction = (playerTransform.position - coin.transform.position).normalized;
            coin.transform.position = Vector3.MoveTowards(coin.transform.position, playerTransform.position, magnetStrength * Time.deltaTime);
        }
    }
}