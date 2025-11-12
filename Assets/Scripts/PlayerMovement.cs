using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controllSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 35f;

    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float controllRollFactor = 20f;
    [SerializeField] float controllPitchFactor = 10f;
    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void ProcessTranslation()
    {
        float xOffset = movement.x * controllSpeed * Time.deltaTime;
        float rawXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawXPosition, -xClampRange, xClampRange);

        float yOffset = movement.y * controllSpeed * Time.deltaTime;
        float rawYPosition = transform.localPosition.y + yOffset;
        float clampedYPosition = Mathf.Clamp(rawYPosition, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, 0f);
    }

    void ProcessRotation()
    {
        float pitch = -controllPitchFactor * movement.y;
        float roll = -controllRollFactor * movement.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}