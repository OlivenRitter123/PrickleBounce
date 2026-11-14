using UnityEngine;
using UnityEngine.InputSystem;

public class RotateAroundCircle : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mouseScreen = Mouse.current.position.ReadValue();

        // Mittelpunkt des Objekts in Bildschirmkoordinaten
        Vector2 centerScreen =
            Camera.main.WorldToScreenPoint(transform.position);

        Vector2 direction = mouseScreen - centerScreen;

        float angle = Mathf.Atan2(direction.y, direction.x)
                      * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(angle, 0f, 0f);
    }
}