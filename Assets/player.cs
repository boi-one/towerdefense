using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    public bool canplace = false;
    public float speed = 2;
    public float bspeed = 6;
    public GameObject mouse;
    public GameObject tower;
    public GameObject uitower;
    private GameObject uitowerspawned;
    public List<GameObject> spawnedtowers;
    private Vector3 mousePos;
    Vector3 worldpos;
    public Tilemap tilemap;
    public TileBase pathtile;
    //public Sprite tilesprite;
    private float offs = 1.65f;
    //EventSystem eventsystem;
    public GameObject bullet;
    public List<GameObject> bulletlist;
    private Vector3 bulletdifference;
    public GameObject closestenemy = null;
    public GameObject ibullet;
    public float dx;
    public float dy;
    public Rigidbody2D projectile;
    public float projectileSpeed;
    public Rigidbody2D target;
    // Start is called before the first frame update
    void Start()
    {
        uitowerspawned = null;
    }

    // Update is called once per frame
    Vector3 camera { get { return new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0); } set { value.z = -10;  Camera.main.transform.position = value; }}
    void Update()
    {
        //camera follow player
         camera += (new Vector3(transform.position.x, transform.position.y, 0)
            - new Vector3(camera.x-offs, camera.y, 0)).normalized 
            * Time.deltaTime * Mathf.Pow((new Vector3(camera.x-offs, camera.y, 0) 
            - new Vector3(transform.position.x, transform.position.y, 0)).magnitude, 1.25f);
        if((camera - transform.position).magnitude < 0.01f)
            camera = transform.position;

        //place towers
        worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldpos.z = 0;
        mouse.transform.position = worldpos;
        if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click)
        {
            if (uitowerspawned == null)
                uitowerspawned = Instantiate(uitower);
            if (uitowerspawned != null)
                uitowerspawned.transform.position = mouse.transform.position;
            if (uitowerspawned.transform.position.x > 5f)
                uitowerspawned.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0f);
        }
        if (GameObject.Find("Canvas").GetComponent<buttonclicked>().click1 && canplace)
        {
            float closestdist = 999999999;
            float closestedist = 999999999;
            foreach (GameObject t in spawnedtowers)
            {
                if ((t.transform.position - mouse.transform.position).magnitude < closestdist)
                    closestdist = (t.transform.position - mouse.transform.position).magnitude;
                foreach (GameObject e in GameObject.Find("spawner").GetComponent<spawn>().enemies)
                {
                    if ((t.transform.position - e.transform.position).magnitude < closestedist)
                        closestedist = (t.transform.position - e.transform.position).magnitude;
                    if (closestedist < 10)
                    {
                        closestenemy = e;
                        //InterceptionDirection(, ,1f );
                        
                    }
                }
            }
            

            if (closestdist > 1 && mouse.transform.position.x < 15 && mouse.transform.position.x > -15 && mouse.transform.position.y < 15 && mouse.transform.position.y > -15)
            {
                uitowerspawned.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 0.25f);
                if (Input.GetMouseButtonDown(0) && tilemap.GetTile(tilemap.WorldToCell(mouse.transform.position)) != pathtile)
                {
                    uitowerspawned.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                    GameObject spawnedtower = Instantiate(tower);
                    spawnedtowers.Add(spawnedtower);
                    spawnedtower.transform.position = mouse.transform.position;
                }
            }
            if (closestdist < 1 || tilemap.GetTile(tilemap.WorldToCell(mouse.transform.position)) == pathtile)
                uitowerspawned.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.25f);
        }
        //look around
        Vector3 mousepos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector3 offset = new Vector2(mousepos.x - screenPoint.x, mousepos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //walking
        if (Input.GetKey(KeyCode.W) && transform.position.y < 15)
            transform.position += new Vector3(0, speed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && transform.position.x > -15)
            transform.position += new Vector3(-speed, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) && transform.position.y > -15)
            transform.position += new Vector3(0, -speed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) && transform.position.x < 15)
            transform.position += new Vector3(speed, 0) * Time.deltaTime;
    }
    bool InterceptionDirection(Vector2 a, Vector2 b, Vector2 vA, float sB, out Vector2 result, out Vector2 fullResult)
    {
        Vector2 aToB = a - b;
        float dC = aToB.magnitude;
        float alpha = Vector2.Angle(aToB, vA) * Mathf.Deg2Rad;
        float sA = vA.magnitude;
        float r = sA / sB;
        if (Meth.SolveQuadratic(1 - r * r, 2 * r * dC * Mathf.Cos(alpha), -(dC * dC), out float root1, out float root2) == 0)
        {
            result = Vector2.zero;

            fullResult = result;
            return false;
        }
        float dA = Mathf.Max(root1, root2);
        float t = dA / sB;
        Vector2 c = a + vA * t;
        result = (c - b).normalized;
        fullResult = c - b;
        return true;
    }
}
public class Meth
{
    public static int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
    {
        float discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            root1 = Mathf.Infinity;
            root2 = -root1;
            return 0;
        }
        root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
        root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
        return discriminant > 0 ? 2 : 1;
    }
}

