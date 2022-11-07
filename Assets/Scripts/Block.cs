using UnityEngine;

public class Block : MonoBehaviour
{
    public int Difficulty;

    private void Start()
    {
        Difficulty = Random.Range(0, 50);
    }

    private void Update()
    {
        if (Difficulty == 0)
        Destroy(this.gameObject);
    }
}