using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public float LevelSpeed;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(1, 0, 0), LevelSpeed * Time.deltaTime);
    }
}