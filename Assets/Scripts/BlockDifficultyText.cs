using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlockDifficultyText : MonoBehaviour
{
    public TextMeshPro Text;
    public Block Block;

    void Update()
    {
        Text.text = Block.Difficulty.ToString();
    }
}
