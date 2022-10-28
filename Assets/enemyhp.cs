using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhp : MonoBehaviour
{
    public GameObject ehp;
    public GameObject iehp;
    // Start is called before the first frame update
    void Start()
    {
        ehp = GameObject.Find("spawner").GetComponent<spawn>().ehp;
        iehp = Instantiate(ehp);
    }

    // Update is called once per frame
    void Update()
    {
        iehp.transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
    }
    private void OnDestroy()
    {
        Destroy(iehp);
    }
}
