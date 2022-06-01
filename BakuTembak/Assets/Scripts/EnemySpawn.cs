using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // from https://www.youtube.com/watch?v=Vrld13ypX_I

    // define all the things that are needed in a wave
    [System.Serializable]
    public class Wave
    {
        // enemy game object
        public Transform enemy;
        public int numberOfEnemies;
        public float enemyDelay;
    }
    
    // save the things that are needed in a wave
    public Wave[] waves;
    // index of the wave
    private int nextWave = 0;

    public float waveInterval = 10f;
    public float waveCountdown;

    // define the states
    public enum SpawnState {SPAWN, COUNT};
    // state spawn = we spawn the enemy
    // state count = we counting down the time until the next spawn

    // save the states as variable, so we can use it in the code
    // set to count state first
    public SpawnState state = SpawnState.COUNT;

    // array for the available spawn points
    public Transform[] spawnPoints;

    void Start()
    {
        // set the countdown to the wave interval
        waveCountdown = waveInterval;

    }

    void Update()
    {
        // run when the countdown reach 0
        if(waveCountdown <= 0)
        {
            // if we directly call the SpawnEnemy() here, the method will be called at every frame
            // we can make some states to decide when to spawn, wait, etc.
            
            // run when the countdown reach 0 AND not in the SPAWN state yet
            if(state != SpawnState.SPAWN)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        // if not, just continue the waveCountdown
        else 
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    // so the function is not called every update
    IEnumerator SpawnWave(Wave wave) 
    {
        // change the state
        state = SpawnState.SPAWN;

        // to count how many enemy will be spawned
        for (int i = 0; i < wave.numberOfEnemies; i++)
        {
            SpawnEnemy(wave.enemy);
            // in between each enemies, there will also be some delay, so the enemies is not stacked
            yield return new WaitForSeconds(1f/wave.enemyDelay);
        }

        // go to the next wave
        WaveComplete();

        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        // create random spawn point, based on the spawn
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // create new enemy object, at random spawn point
        Instantiate(enemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }

    void WaveComplete()
    {
        // change the state back to count
        state = SpawnState.COUNT;
        
        // reset the countdown
        waveCountdown = waveInterval;

        // if the nextWave reach the end of the array, to loop the wave
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        // else, go to the next wave
        else
        {
            nextWave++;
        }
        
    }

}