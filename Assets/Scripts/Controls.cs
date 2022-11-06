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
            Vector3 Force = new(0,0, Input.mousePosition.x - _previousMousePosition.x);
            Player.AddForce(Force.normalized * Speed, ForceMode.Impulse);
        }
        _previousMousePosition = Input.mousePosition;
    }
}