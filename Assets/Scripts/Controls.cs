using UnityEngine;

public class Controls : MonoBehaviour
{
    public Camera Camera;
    public Rigidbody Player;
    public float MovementSpeed;
    public float ControlsSensitivity;
    private float Speed;
    private Vector3 _previousMousePosition;

    private void Start()
    {
        Camera = Camera.main;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _previousMousePosition = Camera.ScreenToViewportPoint(Input.mousePosition);

        } else if (Input.GetMouseButtonUp(0))
        {
            Speed = 0;
        } else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Camera.ScreenToViewportPoint(Input.mousePosition) - _previousMousePosition;
            Speed += delta.x;
            _previousMousePosition = Camera.ScreenToViewportPoint(Input.mousePosition);
        }

    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(Speed) > 0) Speed = 1 * Mathf.Sign(Speed);
        Player.velocity = new Vector3(-MovementSpeed, 0, 10 * Speed * ControlsSensitivity);

        Speed = 0;
    }
}