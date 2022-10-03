using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public List<Transform> points;
    [SerializeField] float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.Find("points").transform.childCount; i++)
        {
            points.Add(GameObject.Find("points").transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Count > 0)
        {
            transform.position += (points[0].position - transform.position).normalized * Time.deltaTime * speed;
            if (Vector3.Distance(transform.position, points[0].transform.position) < 0.5f)
                points.RemoveAt(0);
        }
    }
}
