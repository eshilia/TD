using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float m_speed = 15f;

    private Transform m_target;
    private int m_wavePointIndex = 0;

    private void Start()
    {
        Application.targetFrameRate = 60;
        m_target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = m_target.position - transform.position;
        transform.Translate(dir.normalized * m_speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, m_target.position) <= 0.3f)
        {
            NextWaypoint();
        }
    }


    void NextWaypoint()
    {
        if (m_wavePointIndex >= Waypoints.points.Length - 1)
        {
            LastWaypoint();
            return;
        }

        m_wavePointIndex++;
        m_target = Waypoints.points[m_wavePointIndex];


    }

    void LastWaypoint()
    {
        if(this.gameObject != null)
            Destroy(gameObject);
    }

}
