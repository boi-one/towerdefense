using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class spawn : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<int> enemyIndexes = new List<int>();
    private int waves = 2;
    public GameObject basicenemy;
    private float speed = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*float closestd = 999999999;
        foreach(GameObject e in enemies)
        {
            closestd = (GameObject.Find("thebase").transform.position - e.transform.position).magnitude;
        }*/
    }
    public IEnumerator Spawning()
    {
        for (int i = 0; i < 2; i++)//enemy amount
        {
            for (int ii = 0; ii < waves; ii++)//waves
            {
                GameObject spawnedenemy = Instantiate(basicenemy, transform.position, transform.rotation);
                enemies.Add(spawnedenemy);
                enemyIndexes.Add(1);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}
