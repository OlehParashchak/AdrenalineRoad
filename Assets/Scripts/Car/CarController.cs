using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float carSpeed;
    private float currentSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxXPosition;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    private bool isSpeedIncreased = false;

    public float CarSpeed
    {
        get { return carSpeed; }
        set { carSpeed = value; }
    }

    private void Start()
    {
        currentSpeed = carSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);

        if (isMovingLeft)
        {
            MoveLeft();
        }
        else if (isMovingRight)
        {
            MoveRight();
        }

        PlayerMove();
        MaxXPosition();
    }

    private void PlayerMove()
    {
        transform.Translate(Vector3.up * carSpeed * Time.deltaTime);
    }

    private void StartMovingLeft()
    {
        isMovingLeft = true;
    }

    private void StopMovingLeft()
    {
        isMovingLeft = false;
    }

    private void StartMovingRight()
    {
        isMovingRight = true;
    }

    private void StopMovingRight()
    {
        isMovingRight = false;
    }

    private void MoveLeft()
    {
        float moveInput = -0.5f;
        transform.Translate(Vector3.right * moveInput * acceleration * Time.deltaTime);
    }

    private void MoveRight()
    {
        float moveInput = 0.5f;
        transform.Translate(Vector3.right * moveInput * acceleration * Time.deltaTime);
    }

    private void GasPedal()
    {
        if (!isSpeedIncreased)
        {
            currentSpeed += 5f;
            isSpeedIncreased = true;
        }
    }

    private void BrakePedal()
    {
        if (currentSpeed > minSpeed)
        {
            currentSpeed -= 2f;
            isSpeedIncreased = false;
        }
    }

    private void MaxXPosition()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxXPosition, maxXPosition);
        transform.position = clampedPosition;
    }
}

