using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform m_target;
    public float m_speed = 45f;
    public GameObject impactEffect;
    public void Seek(Transform _target)
    {
        m_target = _target;
    }

    private void Update()
    {
        if (m_target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = m_target.position - transform.position;
        float distanceFrame = m_speed * Time.deltaTime;
        

        if (dir.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject newEffect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(newEffect, 2f);
        Destroy(gameObject);
    }

}
