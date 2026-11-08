using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float zoomStep = 3f;
    [SerializeField] private float minDistance = 5f;
    [SerializeField] private float maxDistance = 60f;

    private Vector3 zoomDirection;
    private float distance;

    void Start()
    {
        distance = cam.localPosition.magnitude;
        zoomDirection = cam.localPosition.normalized;
    }

    void Update()
    {
        Pan();
        Zoom();
    }

    void Pan()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        Vector2 input = Vector2.zero;
        if (kb.wKey.isPressed) input.y += 1;
        if (kb.sKey.isPressed) input.y -= 1;
        if (kb.aKey.isPressed) input.x -= 1;
        if (kb.dKey.isPressed) input.x += 1;
        
        Vector3 move = new Vector3(input.x, 0, input.y).normalized;
        transform.Translate(move * panSpeed * Time.deltaTime, Space.Self);
    }

    void Zoom()
    {
        var mouse = Mouse.current;
        if (mouse == null) return;
        
        float scroll = mouse.scroll.ReadValue().y;
        if (scroll == 0) return;
        
        distance -= Mathf.Sign(scroll) * zoomStep;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        cam.localPosition = zoomDirection * distance;
    }
}
