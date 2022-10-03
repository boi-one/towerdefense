using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonclicked : MonoBehaviour
{
    public Sprite clickedbutton;
    public Sprite unclickedbutton;
    public Button button;
    public bool click = false;
    public bool click1 = false;
    public bool click2 = false;
    public bool click3 = false;
    public bool click4 = false;
    public bool click5 = false;
    public bool click6 = false;
    public bool click7 = false;
    public bool click8 = false;

    private void Start()
    {
        GameObject.Find("bgtowerpanel").SetActive(false);
    }
    public void TowerSelectMenu()
    {
        if (!click)
        {
            button.image.sprite = clickedbutton;
            GameObject.Find("Canvas").transform.Find("bgtowerpanel").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("start wave").gameObject.SetActive(false);
            click = true;
        }
        else
        {
            button.image.sprite = unclickedbutton;
            GameObject.Find("bgtowerpanel").SetActive(false);
            GameObject.Find("Canvas").transform.Find("start wave").gameObject.SetActive(true);
            click = false;
        }
    }
    public void Tower1ButtonSelected()
    {
        if (!click1)
        {
            button.image.sprite = clickedbutton;
            click1 = true;
        }
        else
        {
            button.image.sprite = unclickedbutton;
            click1 = false;
        }
    }
    public void StartWave()
    {
        StartCoroutine(GameObject.Find("spawner").GetComponent<spawn>().Spawning());
    }
}
