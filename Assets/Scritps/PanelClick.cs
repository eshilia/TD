using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelClick : MonoBehaviour, IPointerDownHandler
{
    static PanelClick sInstance;
    public static PanelClick Instance { get { return sInstance; } }
    public Camera mainCamera;
    public GameObject clickEffect;
    LeaderPenguin Leader;


    RaycastHit hit;
    public RaycastHit Hit { get { return hit; } }

    private void Awake()
    {
        sInstance = this;
        Leader = GameObject.Find("Penguin").GetComponent<LeaderPenguin>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out hit);

        clickEffect.transform.position = hit.point;

        
        Debug.Log("클릭" + hit.point);
        Leader.StopCoroutine("Move");
        Leader.StartCoroutine("Move");
        
    }


}

