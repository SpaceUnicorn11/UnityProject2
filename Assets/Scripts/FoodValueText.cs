using TMPro;
using UnityEngine;

public class FoodValueText : MonoBehaviour
{
    public TextMeshPro Text;
    public Food Food;
    void Update()
    {
        Text.text = Food.FoodValue.ToString();
    }
}
