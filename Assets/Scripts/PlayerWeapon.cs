using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    bool isFiring = false;
    Vector2 mousePosition;

    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    void ProcessFiring()
    {
       foreach (var laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        mousePosition = Mouse.current.position.ReadValue();
        crosshair.position = mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(mousePosition.x, mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (var laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}