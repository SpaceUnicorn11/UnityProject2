using UnityEngine;

public class Block : MonoBehaviour
{
    public int Difficulty;

    private void Start()
    {
        Difficulty = Random.Range(0, 50);
    }
}