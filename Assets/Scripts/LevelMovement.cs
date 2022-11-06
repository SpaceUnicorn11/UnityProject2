using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public Transform Level;
    public float LevelSpeed;
    public bool Stop = false;

    void Update()
    {
        if (!Stop)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(1, 0, 0), LevelSpeed * Time.deltaTime);
        }
    }
}