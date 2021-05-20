using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float m_range = 15f;
    public float m_fireRate = 1f;
    private float m_fireCountdown = 0f;

    [Header("Unity Setup Field")]

    public string m_enemyTag = "Enemy";
    public Transform m_partToRotate;
    public float m_turnSpeed = 10;

    public GameObject m_bulletPrefab;
    public Transform m_firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(m_enemyTag);
        float shortesDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortesDistance <= m_range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        //타겟 록온
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(m_partToRotate.rotation, lookRotation, Time.deltaTime * m_turnSpeed).eulerAngles;
        m_partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if (m_fireCountdown <= 0f)
        {
            Shoot();
            m_fireCountdown = 1f / m_fireRate;
        }
        m_fireCountdown -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject newBullet = (GameObject)Instantiate(m_bulletPrefab, m_firePoint.position, m_firePoint.rotation);
        Bullet bullet = newBullet.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_range);
    }
}
