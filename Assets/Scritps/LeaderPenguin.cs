using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LeaderPenguin : MonoBehaviour
{
    [SerializeField] float m_speed = 5;
    float targetDistance;
    public Camera mainCamera;
    public LayerMask playingFieldMask;
    public RaycastHit rayHit;



    private void Start()
    {
        
    }
    private void Update()
    {
        rayHit = PanelClick.Instance.Hit;
        
    }
    


    IEnumerator Move()
    {
        PanelClick.Instance.clickEffect.SetActive(true);
        while (true)
        {
            targetDistance = (rayHit.point - transform.position).magnitude;
            transform.LookAt(rayHit.point);

            transform.position += (transform.forward * m_speed * Time.deltaTime);
            //Vector3.Lerp(transform.position, rayHit.point, m_speed * Time.deltaTime);
            //
            if (targetDistance <= 0.1f )
            {
                StopCoroutine("Move");
                PanelClick.Instance.clickEffect.SetActive(false);
            }
            yield return null;
        }
    }
}
