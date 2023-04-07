using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
using System.ComponentModel;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float playerspeed = 50;
    public float bspeed = 6;
    public GameObject mouse;
    private float offs = 1.65f;
    public float projectileSpeed;
    public GameObject thebase;
    public float health;
    public UnityEngine.UI.Slider hp;
    public TMP_Text text;
    public int points;
    // Start is called before the first frame update
    void Start()
    {
        health = 35f;
        thebase = GameObject.Find("thebase");
        GameObject.Find("Canvas").transform.Find("satelietimage").gameObject.SetActive(false);
        points = 100;
    }

    // Update is called once per frame
    Vector3 camera { get { return new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0); } set { value.z = -10; Camera.main.transform.position = value; } }
    void Update()
    {
        hp.value = health;
        text.text ="money " + points.ToString();
        //camera follow player
        camera += (new Vector3(transform.position.x, transform.position.y, 0)
           - new Vector3(camera.x - offs, camera.y, 0)).normalized
           * Time.deltaTime * Mathf.Pow((new Vector3(camera.x - offs, camera.y, 0)
           - new Vector3(transform.position.x, transform.position.y, 0)).magnitude, 1.25f);
        if ((camera - transform.position).magnitude < 0.01f)
            camera = transform.position;

        //look around
        Vector3 mousepos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector3 offset = new Vector2(mousepos.x - screenPoint.x, mousepos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //walking
        if (Input.GetKey(KeyCode.W) && transform.position.y < 15)
            transform.position += new Vector3(0, playerspeed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && transform.position.x > -15)
            transform.position += new Vector3(-playerspeed, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) && transform.position.y > -15)
            transform.position += new Vector3(0, -playerspeed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) && transform.position.x < 15)
            transform.position += new Vector3(playerspeed, 0) * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.G))
            points += 100;
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }
}

