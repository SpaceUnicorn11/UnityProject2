using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;
    public float CameraOffset;

    // Update is called once per frame
    void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.x = Target.position.x + CameraOffset;
        transform.position = transformPosition;
    }
}
