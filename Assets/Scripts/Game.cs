using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject VictoryScreen;
    public GameObject LoseScreen;

    public void Defeat()
    {
        LoseScreen.SetActive(true);
    }

    public void Victory()
    {
        VictoryScreen.SetActive(true);
        LevelIndex++;
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt("LevelIndex", 0);
        private set
        {
            PlayerPrefs.SetInt("LevelIndex", value);
            PlayerPrefs.Save();
        }
    }
}
