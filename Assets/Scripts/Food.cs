using UnityEngine;

public class Food : MonoBehaviour
{
    public int FoodValue;
    private void Start()
    {
        FoodValue = Random.Range(0, 20);
    }

    private void Update()
    {
        if (FoodValue == 0)
            Destroy(this.gameObject);
    }
}