using UnityEngine;

public class NitroController : MonoBehaviour
{
    [SerializeField] private UIController UIController;

    private float nitroMultiplier = 3f;
    private float nitroDuration = 5f;

    private bool isNitroActive = false;
    private float originalSpeed;
    private float nitroTimer = 0f;

    private CarController carController;

    private void Start()
    {
        UIController.NitroSlider.value = 0f;
        UIController.NitroSlider.gameObject.SetActive(false);

        carController = GetComponent<CarController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Nitro"))
        {
            AudioController.Instance.PlaySFX("Bonus");
            ActivateNitro();
            Destroy(collision.gameObject);
        }
    }

    private void ActivateNitro()
    {
        if (!isNitroActive && carController != null)
        {
            isNitroActive = true;
            originalSpeed = carController.CarSpeed;
            carController.CarSpeed *= nitroMultiplier;

            UIController.NitroSlider.gameObject.SetActive(true);
            InvokeRepeating("UpdateNitroSlider", 0f, 0.1f);
            Invoke("DeactivateNitro", nitroDuration);
        }
    }

    private void DeactivateNitro()
    {
        if (carController != null)
        {
            isNitroActive = false;
            carController.CarSpeed = originalSpeed;
            UIController.NitroSlider.gameObject.SetActive(false);
            nitroTimer = 0f;
        }
    }

    private void UpdateNitroSlider()
    {
        nitroTimer += 0.1f;
        float progress = nitroTimer / nitroDuration;
        UIController.NitroSlider.value = 1f - progress;
        if (progress >= 1f)
        {
            DeactivateNitro();
        }
    }
}