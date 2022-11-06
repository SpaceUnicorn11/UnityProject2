using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Game Game;
    public GameObject Segment;
    public GameObject Head;
    private LinkedList<GameObject> segments = new LinkedList<GameObject>();

    void AddSegments(int count)
    {
        for (int i = 0; i < count; i++)
        {
            segments.AddLast(Instantiate(Segment, transform));
            segments.Last.Value.transform.position += new Vector3(-Head.transform.position.x + 1 + i, -0.5f, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Block block)) return;
        Game.StopLevel();
        Head.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Head.GetComponent<Controls>().enabled = false;
        while(block.Difficulty > 0 && segments.Count > 0)
        {
            block.Difficulty--;
            DestroySegment();
        }
        if (block.Difficulty == 0)
        {
            Destroy(collision.collider.gameObject);
            Game.MoveLevel();
            Head.GetComponent<Controls>().enabled = true;
        }
    } 

    void DestroySegment()
    {
        Destroy(segments.Last.Value);
        segments.Remove(segments.Last);
    }

    void Start()
    {
        segments.AddLast(Head);
        AddSegments(4);
    }

    void Update()
    {
        foreach (GameObject segment in segments)
        {
            segment.GetComponent<Rigidbody>().velocity = Head.GetComponent<Rigidbody>().velocity;
        }
        
    }
}
