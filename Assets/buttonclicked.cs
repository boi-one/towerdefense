using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonclicked : MonoBehaviour
{
    public bool clickspawn = false;
    public bool clicktowerselect = false;
    public Sprite clickedbutton;
    public Sprite unclickedbutton;
    public Button button;
    
    public bool click1 = false;
    public Sprite clickedbuttont1;
    public Sprite unclickedbuttont1;
    public Button buttont1;
    public TMP_Text textb1;

    public bool click2 = false;
    public Sprite clickedbuttont2;
    public Sprite unclickedbuttont2;
    public Button buttont2;
    public TMP_Text textb2;

    public bool click3 = false;
    public Sprite clickedbuttont3;
    public Sprite unclickedbuttont3;
    public Button buttont3;
    public TMP_Text textb3;

    public bool click4 = false;
    public Sprite clickedbuttont4;
    public Sprite unclickedbuttont4;
    public Button buttont4;
    public TMP_Text textb4;

    public bool click5 = false;
    public Sprite clickedbuttont5;
    public Sprite unclickedbuttont5;
    public Button buttont5;
    public TMP_Text textb5;

    public bool click6 = false;
    public Sprite clickedbuttont6;
    public Sprite unclickedbuttont6;
    public Button buttont6;
    public TMP_Text textb6;

    public bool click7 = false;
    public Sprite clickedbuttont7;
    public Sprite unclickedbuttont7;
    public Button buttont7;
    public TMP_Text textb7;

    public bool click8 = false;
    public Sprite clickedbuttont8;
    public Sprite unclickedbuttont8;
    public Button buttont8;
    public TMP_Text textb8;

    public bool clickupgradem = false;
    public Sprite clickedbuttonum;
    public Sprite unclickedbuttonum;
    public Button buttonum;


    private void Start()
    {
        GameObject.Find("bgtowerpanel").SetActive(false);
        GameObject.Find("bgupgradepanel").SetActive(false);

        textb1.text ="tower1\n"+20;
        textb2.text ="tower2\n"+25;
        textb3.text ="tower3\n"+30;
        textb4.text ="tower4\n"+35;
        textb5.text ="tower5\n"+40;
        textb6.text ="tower6\n"+45;
        textb7.text ="tower7\n"+50;
        textb8.text ="tower8\n"+55;

        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade2").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade3").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade4").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade5").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade6").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade7").gameObject.SetActive(false);
    }
    public void TowerSelectMenu()
    {
        if (!clicktowerselect)
        {
            button.image.sprite = clickedbutton;
            GameObject.Find("Canvas").transform.Find("bgtowerpanel").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("start wave").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("UpgradeTowers").gameObject.SetActive(false);
            clicktowerselect = true;
        }
        else
        {
            button.image.sprite = unclickedbutton;
            GameObject.Find("bgtowerpanel").SetActive(false);
            GameObject.Find("Canvas").transform.Find("start wave").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("UpgradeTowers").gameObject.SetActive(true);
            clicktowerselect = false;
            click1 = false;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = false;
            click6 = false;
            click7 = false;
            click8 = false;
            buttont1.image.sprite = unclickedbuttont1;
            buttont2.image.sprite = unclickedbuttont2;
            buttont3.image.sprite = unclickedbuttont3;
            buttont4.image.sprite = unclickedbuttont4;
            buttont5.image.sprite = unclickedbuttont5;
            buttont6.image.sprite = unclickedbuttont6;
            buttont7.image.sprite = unclickedbuttont7;
            buttont8.image.sprite = unclickedbuttont8;
        }
    }
    public void UpgradeMenu()
    {
        if (!clickupgradem)
        {
            buttonum.image.sprite = clickedbuttonum;
            GameObject.Find("Canvas").transform.Find("bgupgradepanel").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("start wave").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("towersz").gameObject.SetActive(false);
            clickupgradem = true;
        }
        else
        {
            buttonum.image.sprite = unclickedbuttonum;
            GameObject.Find("Canvas").transform.Find("bgupgradepanel").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("start wave").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("towersz").gameObject.SetActive(true);
            clickupgradem = false;
        }
    }
    public void Tower1ButtonSelected()
    {
        if (!click1)
        {
            buttont1.image.sprite = clickedbuttont1;
            buttont2.image.sprite = unclickedbuttont2;
            buttont3.image.sprite = unclickedbuttont3;
            buttont4.image.sprite = unclickedbuttont4;
            buttont5.image.sprite = unclickedbuttont5;
            buttont6.image.sprite = unclickedbuttont6;
            buttont7.image.sprite = unclickedbuttont7;
            buttont8.image.sprite = unclickedbuttont8;
            click1 = true;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = false;
            click6 = false;
            click7 = false;
            click8 = false;
        }
        else
        {
            buttont1.image.sprite = unclickedbuttont1;
            click1 = false;
        }
    }
    public void Tower2ButtonSelected()
    {
        if (!click2)
        {
            buttont1.image.sprite = unclickedbuttont1;
            buttont2.image.sprite = clickedbuttont2;
            buttont3.image.sprite = unclickedbuttont3;
            buttont4.image.sprite = unclickedbuttont4;
            buttont5.image.sprite = unclickedbuttont5;
            buttont6.image.sprite = unclickedbuttont6;
            buttont7.image.sprite = unclickedbuttont7;
            buttont8.image.sprite = unclickedbuttont8;
            click1 = false;
            click2 = true;
            click3 = false;
            click4 = false;
            click5 = false;
            click6 = false;
            click7 = false;
            click8 = false;  
        }
        else
        {
            buttont1.image.sprite = unclickedbuttont1;
            click2 = false;
        }
    }
    public void Tower3ButtonSelected()
    {
        if (!click3)
        {
            buttont1.image.sprite = unclickedbuttont1;
            buttont2.image.sprite = unclickedbuttont2;
            buttont3.image.sprite = clickedbuttont3;
            buttont4.image.sprite = unclickedbuttont4;
            buttont5.image.sprite = unclickedbuttont5;
            buttont6.image.sprite = unclickedbuttont6;
            buttont7.image.sprite = unclickedbuttont7;
            buttont8.image.sprite = unclickedbuttont8;
            click1 = false;
            click2 = false;
            click3 = true;
            click4 = false;
            click5 = false;
            click6 = false;
            click7 = false;
            click8 = false;
        }
        else
        {
            buttont3.image.sprite = unclickedbuttont3;
            click3 = false;
        }
    }
    public void Tower4ButtonSelected()
    {
        if (!click4)
        {
            buttont1.image.sprite = unclickedbuttont1;
            buttont2.image.sprite = unclickedbuttont2;
            buttont3.image.sprite = unclickedbuttont3;
            buttont4.image.sprite = clickedbuttont4;
            buttont5.image.sprite = unclickedbuttont5;
            buttont6.image.sprite = unclickedbuttont6;
            buttont7.image.sprite = unclickedbuttont7;
            buttont8.image.sprite = unclickedbuttont8;
            click1 = false;
            click2 = false;
            click3 = false;
            click4 = true;
            click5 = false;
            click6 = false;
            click7 = false;
            click8 = false;
        }
        else
        {
            buttont4.image.sprite = unclickedbuttont4;
            click4 = false;
        }
    }
    public void Tower5ButtonSelected()
    {
        if (!click5)
        {
            buttont1.image.sprite = unclickedbuttont1;
            buttont2.image.sprite = unclickedbuttont2;
            buttont3.image.sprite = unclickedbuttont3;
            buttont4.image.sprite = unclickedbuttont4;
            buttont5.image.sprite = clickedbuttont5;
            buttont6.image.sprite = unclickedbuttont6;
            buttont7.image.sprite = unclickedbuttont7;
            buttont8.image.sprite = unclickedbuttont8;
            click1 = false;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = true;
            click6 = false;
            click7 = false;
            click8 = false;
        }
        else
        {
            buttont5.image.sprite = unclickedbuttont5;
            click5 = false;
        }
    }
    public void Tower6ButtonSelected()
    {
        if (!click6)
        {
            buttont1.image.sprite = unclickedbuttont1;
            buttont2.image.sprite = unclickedbuttont2;
            buttont3.image.sprite = unclickedbuttont3;
            buttont4.image.sprite = unclickedbuttont4;
            buttont5.image.sprite = unclickedbuttont5;
            buttont6.image.sprite = clickedbuttont6;
            buttont7.image.sprite = unclickedbuttont7;
            buttont8.image.sprite = unclickedbuttont8;
            click1 = false;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = false;
            click6 = true;
            click7 = false;
            click8 = false;
        }
        else
        {
            buttont6.image.sprite = unclickedbuttont6;   
            click6 = false;
        }
    }
    public void Tower7ButtonSelected()
    {
        if (!click7)
        {
            buttont1.image.sprite = unclickedbuttont1;
            buttont2.image.sprite = unclickedbuttont2;
            buttont3.image.sprite = unclickedbuttont3;
            buttont4.image.sprite = unclickedbuttont4;
            buttont5.image.sprite = unclickedbuttont5;
            buttont6.image.sprite = unclickedbuttont6;
            buttont7.image.sprite = clickedbuttont7;
            buttont8.image.sprite = unclickedbuttont8;
            click1 = false;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = false;
            click6 = false;
            click7 = true;
            click8 = false;
        }
        else
        {
            buttont7.image.sprite = unclickedbuttont7;   
            click7 = false;
        }
    }
    public void Tower8ButtonSelected()
    {
        if (!click8)
        {
            buttont1.image.sprite = unclickedbuttont1;
            buttont2.image.sprite = unclickedbuttont2;
            buttont3.image.sprite = unclickedbuttont3;
            buttont4.image.sprite = unclickedbuttont4;
            buttont5.image.sprite = unclickedbuttont5;
            buttont6.image.sprite = unclickedbuttont6;
            buttont7.image.sprite = unclickedbuttont7;
            buttont8.image.sprite = clickedbuttont8;
            click1 = false;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = false;
            click6 = false;
            click7 = false;
            click8 = true;
        }
        else
        {
            buttont8.image.sprite = unclickedbuttont8;
            click8 = false;
        }
    }
    public void StartWave()
    {
        GameObject.Find("spawner").GetComponent<spawn>().timertext.text = 300.ToString();
        Debug.Log("300");
        GameObject.Find("spawner").GetComponent<spawn>().Spawning();
    }
    public void Upgrade1()
    {
        GameObject.Find("player").GetComponent<player>().playerspeed = GameObject.Find("player").GetComponent<player>().playerspeed * 2;
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade1").gameObject.SetActive(false);
        GameObject.Find("player").GetComponent<player>().points -= 500;
    }
    public void Upgrade2()
    {
        //geen upgrade
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade2").gameObject.SetActive(false);
    }
    public void Upgrade3()
    {
        //geen upgrade
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade3").gameObject.SetActive(false);
    }
    public void Upgrade4()
    {
        //geen upgrade
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade4").gameObject.SetActive(false);
    }
    public void Upgrade5()
    {
        //geen upgrade
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade5").gameObject.SetActive(false);
    }
    public void Upgrade6()
    {
        //geen upgrade
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade6").gameObject.SetActive(false);
    }
    public void Upgrade7()
    {

        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade7").gameObject.SetActive(false);
    }
    public void Upgrade8()
    {
        GameObject.Find("Canvas").transform.Find("satelietimage").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("bgupgradepanel").transform.Find("upgrade8").gameObject.SetActive(false);
        GameObject.Find("player").GetComponent<player>().points -= 2000;
    }
}