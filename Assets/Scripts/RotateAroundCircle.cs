using UnityEngine;
using UnityEngine.InputSystem;

public class RotateAroundCircle : MonoBehaviour
{
    public float sensitivity = 0.2f;

    void Update()
    {
        if (Mouse.current == null) return;

        float mouseX = Mouse.current.position.ReadValue().x;
        float centerX = Camera.main
            .WorldToScreenPoint(transform.position).x;

        float angle = (mouseX - centerX) * sensitivity;
        angle = Mathf.Clamp(angle, -60f, 60f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}