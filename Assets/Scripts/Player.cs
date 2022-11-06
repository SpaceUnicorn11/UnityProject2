using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Segment;
    public GameObject Head;
    private LinkedList<GameObject> segments = new LinkedList<GameObject>();

    void Start()
    {
        segments.AddLast(Head);
        for (int i = 0; i < 4; i++)
        {
            segments.AddLast(Instantiate(Segment,transform));
            segments.Last.Value.transform.position += new Vector3(-Head.transform.position.x + 1 + i, -0.5f, 0);
            segments.Last.Value.GetComponent<HingeJoint>().connectedBody = segments.Last.Previous.Value.GetComponent<Rigidbody>();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
