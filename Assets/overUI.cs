using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class overUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventdata)
    {
        GameObject.Find("player").GetComponent<placetowers>().canplace = false;
    }
    public void OnPointerExit(PointerEventData eventdata)
    {
        GameObject.Find("player").GetComponent<placetowers>().canplace = true;
    }
}
