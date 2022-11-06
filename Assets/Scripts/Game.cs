using UnityEngine;

public class Game : MonoBehaviour
{
    public LevelMovement Level;

    public void StopLevel()
    {
        Level.Stop = true;
    }
    public void MoveLevel()
    {
        Level.Stop = false;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
