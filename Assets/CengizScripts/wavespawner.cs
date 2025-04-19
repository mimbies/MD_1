using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavespawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }


    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnpoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown =1f;

    private SpawnState state= SpawnState.COUNTING;
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }
    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                Debug.Log("test 39");

                WaveCompleted();

            }
            else
            {
                return;
            }
        }


        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                Debug.Log("test 54");
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("test 73");
            nextWave = 0;


        }
        else
        {
            nextWave++;
        }
        
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {

            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("karl") == null)
            {
                Debug.Log("test 93");

                return false;
            }

        }
       
        return true;

    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++)
        {

            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }


        state= SpawnState.WAITING;

        yield break;
        
    }

    void SpawnEnemy (Transform _enemy)
    {
        Transform _sp= spawnpoints[Random.Range(0,spawnpoints.Length)];
        Instantiate(_enemy, _sp.position,_sp.rotation);
        
    }

}
