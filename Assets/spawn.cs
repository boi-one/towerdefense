using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class spawn : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public List<int> enemyIndexes = new List<int>();
    private int spawns = 5;
    public GameObject basicenemy;
    public bool spawning = false;
    bool canSetSpawningTrue;
    GameObject deadenemy;
    public TMP_Text timertext;
    float lasttime = 0;
    public float lastspawn = 0f;
    public float cooldown = 0.5f;
    public GameObject spawnedenemy;
    public Enemy ec;
    public bool wave = false;
    public int wavelength = 2;
    public int maxwavelength = 2;
    public float timercd = 0.5f;
    public float newtimer = 0;
    public GameObject ehp;
    public int bruh = 1;
    int enemiesspawns = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy se in enemies.ToList()) //zorgt ervoor dat elke enemy het pad volgt
        {
            GameObject.Find("enemy(Clone)").GetComponent<enemyhp>().iehp.transform.position = se.enemyGameObject.transform.position;
            GameObject.Find("enemy(Clone)").GetComponent<enemyhp>().iehp.transform.localScale = new Vector3(se.hp/2, 1, 0);
            //enemies move
            if (se.points.Count > 0)
            {
                se.enemyGameObject.transform.position += (se.points[0].transform.position - se.enemyGameObject.transform.position).normalized * Time.deltaTime * 10;    //(se.points[0].transform.position - se.enemyGameObject.transform.position).normalized * Time.deltaTime * se.speed;
                if (Vector3.Distance(se.enemyGameObject.transform.position, se.points[0].transform.position) < 0.5f) //removed de dichtstbijzijnde waypoint zodat de enemy naar de volgende waypoint gaat in de list
                    se.points.RemoveAt(0);
            }
            //enemy does damage
            if (Vector3.Distance(se.enemyGameObject.transform.position, GameObject.Find("player").GetComponent<player>().thebase.transform.position) < 2) //doet damage aan de base als de enemies dichtbij zijn
            {
                deadenemy = se.enemyGameObject;
                if (GameObject.Find("player").GetComponent<player>().health > 0f)
                {
                    GameObject.Find("player").GetComponent<player>().health -= se.damage;                                                           
                    GameObject.Find("player").GetComponent<player>().hp.value = GameObject.Find("player").GetComponent<player>().health;
                    
                }
                deadenemy.transform.position = new Vector3(20, 20, 0);
                enemies.Remove(se); //als de enemies de base raken worden ze gedestroyed
                Destroy(deadenemy);
                Destroy(GameObject.Find("enemy(Clone)").GetComponent<enemyhp>().iehp);
            }   
        }
        //timer enemy spawns
        if (System.Convert.ToInt32(timertext.text) > 0)
        {
            canSetSpawningTrue = true;
            timertext.text = ((int)(300 - (Time.time - lasttime))).ToString();
        }
        else if (System.Convert.ToInt32(timertext.text) <= 0)
        {
            if (canSetSpawningTrue)
            {
                spawning = true;
                canSetSpawningTrue = false;
            }
            if (spawning)
            {
                Spawning();
                spawning = false;
            }
        }
        else
            spawning = false;
        //Debug.Log(timertext.text + " spawning= " + spawning);

        if (GameObject.Find("player").GetComponent<player>().health == 0 || GameObject.Find("player").GetComponent<player>().hp.value <= 0)
            SceneManager.LoadScene("Dead");
        //Debug.Log(Time.time + " cd " + lastspawn);
    }
    public void Spawning()
    {
        spawning = false;
        bool resetTimer = false;
        int spawns = 0;
        StartCoroutine(Timer());
    }
    IEnumerator Timer() //dit is hoogst waarschijnlijk zeer inefficient
    {
        bool resetTimer = false;
        int spawns = 0;
        for (int i = 0; i < 8; i++)
        {
            if(i < 8)
                Debug.Log(i);
            lastspawn = Time.time + cooldown;
            spawnedenemy = Instantiate(basicenemy, transform.position, transform.rotation);
            List<Enemy> randomenemy = new List<Enemy>() { new Enemy() { enemyGameObject = spawnedenemy, enemyname = "basicenemy", hp = 0.5f, speed = 100f, damage = 1 },
                    new Enemy() { enemyGameObject = spawnedenemy, enemyname = "strongerenemy", hp = 1f, speed = 100f, damage = 2 },
                    new Enemy() { enemyGameObject = spawnedenemy, enemyname = "strongestenemy", hp = 2f, speed = 100f, damage = 4 } };
            ec = randomenemy[Random.Range(0, 3)];
            enemies.Add(ec);
            for (int ii = 0; ii < GameObject.Find("points").transform.childCount; ii++)
                ec.points.Add(GameObject.Find("points").transform.GetChild(ii));
            enemyIndexes.Add(1);
            if (ec.enemyname == "basicenemy")
                ec.enemyGameObject.GetComponent<SpriteRenderer>().color = Color.red;
            if (ec.enemyname == "strongerenemy")
                ec.enemyGameObject.GetComponent<SpriteRenderer>().color = Color.green;
            if (ec.enemyname == "strongestenemy")
                ec.enemyGameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            if (i == 8)
            {
                Debug.Log("BREAK");
                timertext.text = 300.ToString();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
public class Enemy
{
    public string enemyname;
    public float hp;
    public float speed;
    public float damage;
    public GameObject enemyGameObject;
    public List<Transform> points = new List<Transform>();
}