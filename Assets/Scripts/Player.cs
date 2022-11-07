using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Game Game;
    public Transform Segment;
    public Transform Head;
    public TextMeshPro SegmentCounter;
    private List<Transform> segments = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

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
        if (collision.collider.TryGetComponent(out Finish finish))
        {
            Game.Victory();
        } else
        if (collision.collider.TryGetComponent(out Block block))
        {
            Head.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Head.GetComponent<Controls>().enabled = false;
            while (block.Difficulty > 0 && segments.Count > 0)
            {
                block.Difficulty--;
                DestroySegment();
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
        } else
        if (collision.collider.TryGetComponent(out Food food))
        {
            for (int i = 0; i < food.FoodValue; i++)
            {
                AddSegment();
            }
            food.FoodValue = 0;
        }


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
