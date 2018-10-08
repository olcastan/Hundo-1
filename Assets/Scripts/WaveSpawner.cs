﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
	public class Wave {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 30f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public SpawnState getState() {
        return state;
    }

    void Start() {
        waveCountdown = timeBetweenWaves;
    }

    void Update() {
        if (state == SpawnState.WAITING) {
            if (!EnemyIsAlive()) {
                //new round               
                WaveCompleted();
            } else {
                return;
            }
        }

        if (waveCountdown <= 0f) {
            if (state == SpawnState.COUNTING) {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else {         
            waveCountdown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive() { 
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f) {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null) {
                return false;
            }
        }   
        return true;
    }

    void WaveCompleted() {
        Debug.Log("Wave completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 == waves.Length - 1) {
            //nextWave = 0;
            Debug.Log("All waves completed");
        }
        else {
            nextWave++;
        }        
    }

    IEnumerator SpawnWave(Wave _wave) {
        Debug.Log("Spawning wave" + _wave.name);

        state = SpawnState.SPAWNING;

        //spawn
        for (int i = 0; i < _wave.count; i++) {
            SpawnEnemey(_wave.enemy);
            yield return new WaitForSeconds(1 / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemey(Transform _enemy) {
        //Spawn enemy
        Debug.Log("Spawning enemy: " + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

}
