using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody Player;
    public float Speed;
    private Vector3 _previousMousePosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 Direction = (Input.mousePosition - _previousMousePosition).normalized;
            Vector3 NewPosition = Vector3.zero;
            NewPosition.z = Direction.x;
            Player.AddForce(NewPosition * Speed, ForceMode.Acceleration);
        }
        _previousMousePosition = Input.mousePosition;
    }
}