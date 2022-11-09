using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Game Game;
    public Transform Segment;
    public Transform Head;
    public TextMeshPro SegmentCounter;
    private List<Transform> segments = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    public Text ScoreText;
    private int Score = 0;

    void AddSegment()
    {
        Vector3 PositionOffset = new Vector3(1, 0, 0);
        Transform segment = Instantiate(Segment, positions[positions.Count - 1] + PositionOffset, Quaternion.identity, Head.transform);
        segments.Add(segment);
        positions.Add(segment.position);
        SegmentCounter.SetText(positions.Count.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Block block))
        {
            Head.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Head.GetComponent<Controls>().enabled = false;
            while (block.Difficulty > 0 && segments.Count > 0)
            {
                block.Difficulty--;
                DestroySegment();
                Score++;
            }
            if (block.Difficulty == 0 && segments.Count > 0)
            {
                Head.GetComponent<Controls>().enabled = true;
            }
            else
            {
                block.Difficulty--;
                Destroy(Head.gameObject);
                Game.Defeat();
            }
            ScoreText.text = Score.ToString();
        }
        else
        if (collision.collider.TryGetComponent(out Food food))
        {
            for (int i = 0; i < food.FoodValue; i++)
            {
                AddSegment();
                Score++;
            }
            food.FoodValue = 0;
            ScoreText.text = Score.ToString();
        }
    }

    public void ReachFinish()
    {
        Head.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Head.GetComponent<Controls>().enabled = false;
        Game.Victory();
    }

    void DestroySegment()
    {
        Destroy(segments[0].gameObject);
        segments.RemoveAt(0);
        positions.RemoveAt(1);
        SegmentCounter.SetText(positions.Count.ToString());
    }

    void Awake()
    {
        positions.Add(Head.position);
        AddSegment();
        AddSegment();
        AddSegment();
        AddSegment();
    }

    void Update()
    {
        float distance = (Head.position - positions[0]).magnitude;
        if (distance > 1)
        {
            Vector3 direction = (Head.position - positions[0]).normalized;
            positions.Insert(0, positions[0] + direction);
            positions.RemoveAt(positions.Count - 1);

            distance -= 1;
        }

        for (int i = 0; i < segments.Count; i++)
        {
            segments[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance);
        }
    }
}
