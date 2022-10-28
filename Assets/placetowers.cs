
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class placetowers : MonoBehaviour
{
    public bool canplace = false;
    private GameObject uitowerspawned;
    public GameObject uitower;
    private GameObject mouse;
    Vector3 worldpos;
    public GameObject tower;

    float bulletspeed = 10;
    static public Dictionary<GameObject, Vector3> bulletdict = new Dictionary<GameObject, Vector3>();
    static public List<Tower> spawnedtowers = new List<Tower>();
    public float lastfire = 0f;
    public GameObject bullet;
    static public List<Enemy> enemies;
    public Tower tc;

    public Tilemap tilemap;
    public TileBase pathtile;
    //public Tower basictower;

    // Start is called before the first frame update
    void Start()
    {
        uitowerspawned = null;
        mouse = GameObject.Find("player").GetComponent<player>().mouse;
        enemies = GameObject.Find("spawner").GetComponent<spawn>().enemies;
    }

    // Update is called once per frame
    void Update()
    {
        float closestdist = 9999999;
        foreach (Tower t in spawnedtowers)
        {
            if ((t.position - mouse.transform.position).magnitude < closestdist) //bekijkt alle torens en hoever de muis van de dichstbijzijnde toren is
                closestdist = (t.position - mouse.transform.position).magnitude;
        }
        //place towers
        worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldpos.z = 0;                                                     //kijkt waar de muis is 
        mouse.transform.position = worldpos;
        if (GameObject.Find("Canvas").GetComponent<buttonclicked>().clicktowerselect)
        {
            if (uitowerspawned == null)
                uitowerspawned = Instantiate(uitower);                //als in de ui de toren select knop is ingedrukt en spawnt een ui indicator waar je wel en niet torens kan plaatsen
            if (uitowerspawned != null) 
                uitowerspawned.transform.position = mouse.transform.position;
            if (closestdist < 1 || tilemap.GetTile(tilemap.WorldToCell(mouse.transform.position)) == pathtile)  
            {
                //Debug.Log("toren niet plaatsen");
                uitowerspawned.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.25f);
                canplace = false;
            }
            else
            {
                //Debug.Log("toren plaatsen");
                uitowerspawned.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.25f);
                canplace = true;
            }
            if (Input.mousePosition.x > (int)((float)Screen.width * 0.771f))
                uitowerspawned.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);

            if (Input.GetMouseButtonDown(0) && uitowerspawned.GetComponent<SpriteRenderer>().color != new Color(0, 0, 0, 0f) && tilemap.GetTile(tilemap.WorldToCell(mouse.transform.position)) != pathtile)
            {
                //Debug.Log("klik");
                if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click1) //kijkt welke knop in de ui je aandrukt zodat verschillende torens geplaatst kunnen worden 
                    TowerButton(1);
                if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click2)
                    TowerButton(2);
                if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click3)
                    TowerButton(3);
                if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click4)
                    TowerButton(4);
                if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click5)
                    TowerButton(5);
                if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click6)
                    TowerButton(6);
                if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click7)
                    TowerButton(7);
                if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click8)
                    TowerButton(8);
            }
        }
        //check if enemy is close
        bool fired = true;
        foreach (Tower t in spawnedtowers)
        {
            if (Time.time <= lastfire + tc.cooldown)
            {
                continue;               //cooldown voor het schieten van de torens
            }
            fired = true;
            GameObject closestenemy = null;
            float closestedist = 99999;
            foreach (Enemy e in enemies)                 //zorgt ervoor dat de enemies geschoten kunnen worden
            {
                if ((t.position - e.enemyGameObject.transform.position).magnitude < closestedist)
                {
                    closestedist = (t.position - e.enemyGameObject.transform.position).magnitude;
                    closestenemy = e.enemyGameObject;
                }
                /*float diste = (t.position - e.enemyGameObject.transform.position).magnitude;
                if (diste < closestedist)
                {
                    diste = closestedist;

                }*/
            }
            if (closestedist < 8)
            {
                Debug.Log(closestenemy);
                GameObject ibullet = Instantiate(bullet, t.position, t.towerGameObject.transform.rotation);
                bulletdict.Add(ibullet, closestenemy.transform.position
                    + ((GameObject.Find("spawner").GetComponent<spawn>().ec.points[0].transform.position
                    - closestenemy.transform.position).normalized * Mathf.Pow(closestedist, 1.25f) / 5f) - t.position/*.normalized*/);
                float dy = t.position.y - closestenemy.transform.position.y;
                float dx = t.position.x - closestenemy.transform.position.x;
                ibullet.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(dy, dx) * Mathf.Rad2Deg + 90);//draait de kogels in de richting van de enemy (waarschijnlijk niet meer nodig dankzij trailrenderer)
            }
            if (fired)
                lastfire = Time.time;
        }
        foreach (KeyValuePair<GameObject, Vector3> b in bulletdict)  //beweegt de kogels
        {
            b.Key.transform.position += b.Value * Time.deltaTime * bulletspeed;
        }
        //hitenemy
        foreach (KeyValuePair<GameObject, Vector3> bt in bulletdict)
        {
            foreach (Enemy e in enemies.ToList())
            {
                if ((e.enemyGameObject.transform.position - bt.Key.transform.position).magnitude < 1f)
                {
                    e.hp -= 5;             //laat de enemies damage krijgen
                    if (e.hp <= 0)
                    {
                        enemies.Remove(e);
                        Destroy(e.enemyGameObject);
                        GameObject.Find("player").GetComponent<player>().points += 20;
                    }
                }
            }
        }
    }
    public void TowerButton(int button)
    {
        //Debug.Log(spawnedtowers.Count);
        if (canplace && mouse.transform.position.x < 15 && mouse.transform.position.x > -15 && mouse.transform.position.y < 15 && mouse.transform.position.y > -15)
        {
            //Debug.Log("werk plaats");
            uitowerspawned.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.25f);
            GameObject spawnedtower = Instantiate(tower);        //plaatst een andere toren afhankelijk welke knop in de ui is ingedrukt
            if (button == 1)
            {
                tc = new Tower() { towerGameObject = spawnedtower, towername = "basictower", cost = 20, bulletspeed = 20f, cooldown = 2f, damage = 0.5f, range = 5f };
                spawnedtowers.Add(tc);
                spawnedtower.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tower1");
                if (GameObject.Find("player").GetComponent<player>().points >= tc.cost)
                {
                    GameObject.Find("player").GetComponent<player>().points -= tc.cost;
                }
                else if (GameObject.Find("player").GetComponent<player>().points < tc.cost)
                {
                    spawnedtowers.Remove(tc);
                    Destroy(tc.towerGameObject);
                }
            }
            if (button == 2)
            {
                tc = new Tower() { towerGameObject = spawnedtower, towername = "tower2", cost = 25, bulletspeed = 20f, cooldown = 0.5f, damage = 0.1f, range = 3f };
                spawnedtowers.Add(tc);
                spawnedtower.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tower2");
                if (GameObject.Find("player").GetComponent<player>().points >= tc.cost)
                {
                    GameObject.Find("player").GetComponent<player>().points -= tc.cost;
                }
                else if (GameObject.Find("player").GetComponent<player>().points < tc.cost)
                {
                    spawnedtowers.Remove(tc);
                    Destroy(tc.towerGameObject);
                }
            }
            if (button == 3)
            {
                tc = new Tower() { towerGameObject = spawnedtower, towername = "tower3", cost = 30, bulletspeed = 40f, cooldown = 5f, damage = 1f, range = 10f };
                spawnedtowers.Add(tc);
                spawnedtower.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tower3");
                if (GameObject.Find("player").GetComponent<player>().points >= tc.cost)
                {
                    GameObject.Find("player").GetComponent<player>().points -= tc.cost;
                }
                else if (GameObject.Find("player").GetComponent<player>().points < tc.cost)
                {
                    spawnedtowers.Remove(tc);
                    Destroy(tc.towerGameObject);
                }
            }
            if (button == 4)
            {
                tc = new Tower() { towerGameObject = spawnedtower, towername = "tower4", cost = 35, bulletspeed = 20f, cooldown = 2f, damage = 0.5f, range = 5f };
                spawnedtowers.Add(tc);
                spawnedtower.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tower4");
                if (GameObject.Find("player").GetComponent<player>().points >= tc.cost)
                {
                    GameObject.Find("player").GetComponent<player>().points -= tc.cost;
                }
                else if (GameObject.Find("player").GetComponent<player>().points < tc.cost)
                {
                    spawnedtowers.Remove(tc);
                    Destroy(tc.towerGameObject);
                }
            }
            if (button == 5)
            {
                tc = new Tower() { towerGameObject = spawnedtower, towername = "tower5", cost = 40, bulletspeed = 20f, cooldown = 2f, damage = 0.5f, range = 5f };
                spawnedtowers.Add(tc);
                spawnedtower.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tower5");
                if (GameObject.Find("player").GetComponent<player>().points >= tc.cost)
                {
                    GameObject.Find("player").GetComponent<player>().points -= tc.cost;
                }
                else if (GameObject.Find("player").GetComponent<player>().points < tc.cost)
                {
                    spawnedtowers.Remove(tc);
                    Destroy(tc.towerGameObject);
                }
            }
            if (button == 6)
            {
                tc = new Tower() { towerGameObject = spawnedtower, towername = "tower6", cost = 45, bulletspeed = 20f, cooldown = 2f, damage = 0.5f, range = 5f };
                spawnedtowers.Add(tc);
                spawnedtower.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tower6");
                if (GameObject.Find("player").GetComponent<player>().points >= tc.cost)
                {
                    GameObject.Find("player").GetComponent<player>().points -= tc.cost;
                }
                else if (GameObject.Find("player").GetComponent<player>().points < tc.cost)
                {
                    spawnedtowers.Remove(tc);
                    Destroy(tc.towerGameObject);
                }
            }
            if (button == 7)
            {
                tc = new Tower() { towerGameObject = spawnedtower, towername = "tower7", cost = 50, bulletspeed = 20f, cooldown = 2f, damage = 0.5f, range = 5f };
                spawnedtowers.Add(tc);
                spawnedtower.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tower7");
                if (GameObject.Find("player").GetComponent<player>().points >= tc.cost)
                {
                    GameObject.Find("player").GetComponent<player>().points -= tc.cost;
                }
                else if (GameObject.Find("player").GetComponent<player>().points < tc.cost)
                {
                    spawnedtowers.Remove(tc);
                    Destroy(tc.towerGameObject);
                }
            }
            if (button == 8)
            {
                tc = new Tower() { towerGameObject = spawnedtower, towername = "tower8", cost = 55, bulletspeed = 20f, cooldown = 2f, damage = 0.5f, range = 5f };
                spawnedtowers.Add(tc);
                spawnedtower.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tower8");
                if (GameObject.Find("player").GetComponent<player>().points >= tc.cost)
                {
                    GameObject.Find("player").GetComponent<player>().points -= tc.cost;
                }
                else if (GameObject.Find("player").GetComponent<player>().points < tc.cost)
                {
                    spawnedtowers.Remove(tc);
                    Destroy(tc.towerGameObject);
                }
            }
            spawnedtower.transform.position = mouse.transform.position;
        }
    }
}
public class Tower
{
    public string towername;
    public float bulletspeed;
    public float cooldown;
    public float lastfire = 0f;
    public float damage;
    public float range;
    public int cost;
    public GameObject towerGameObject;
    public Vector3 position => towerGameObject.transform.position;
}
