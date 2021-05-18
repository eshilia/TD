using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform m_enemyPrefab;
    public Transform m_spawnPoint;
    public float m_timeBetweenWaves = 5f;
    private float m_countDown = 2f;
    private int m_waveIndex = 0;
    public Text m_waveCountDownText; 

    private void Update()
    {
        if (m_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            m_countDown = m_timeBetweenWaves;
        }
        m_countDown -= Time.deltaTime;

        m_waveCountDownText.text =Mathf.Floor( m_countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        m_waveIndex++;
        for (int i = 0; i < m_waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }


    }
    void SpawnEnemy()
    {
        Instantiate(m_enemyPrefab, m_spawnPoint.position, m_spawnPoint.rotation);
    }
}
