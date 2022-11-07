using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] WallPrefabs;
    public GameObject Food;
    public GameObject Finish;
    public Transform TrackStart;
    public int WallsCount;
    public int DistanceBetweenWalls;

    private void Awake()
    {
        for(int i = 0; i < WallsCount; i++)
        {
            int prefabIndex = Random.Range(0, WallPrefabs.Length);
            GameObject Wall = Instantiate(WallPrefabs[prefabIndex],transform);
            Wall.transform.localPosition = new Vector3(-DistanceBetweenWalls * (i + 1), 0, -1);
            for(int j = 0; j < Random.Range(1,4); j++)
            {
                GameObject food = Instantiate(Food, transform);
                food.transform.localPosition = Wall.transform.position + new Vector3(Random.Range(5, DistanceBetweenWalls-5), 0.5f, Random.Range(-8, 8));
            }

        }
        GameObject finish = Instantiate(Finish,transform);
        finish.transform.localPosition = new Vector3(-DistanceBetweenWalls * (WallsCount + 1), 0, 0);
        TrackStart.localScale = new Vector3(WallsCount * 5 + 5, 1, 1);
    }
}
