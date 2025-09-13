using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyType1, enemyType2, enemyType3, enemyType4;
    
    public Transform[] spawnPoints;

    private WavesJson config;
    
    public void SetConfig(WavesJson data) => config = data;

    
    public void StartSpawning()
    {
        if (config?.Waves == null || config.Waves.Length == 0)
        {
            Debug.Log("No hay olas");
            return;
        }

        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (var wave in config.Waves)
        {
            yield return StartCoroutine(SpawnSchedule(wave));
        }
    }

    private IEnumerator SpawnSchedule(WaveEntry wave)
    {
        if (wave.Enemies == null || wave.Enemies.Length == 0)
            yield break;

        System.Array.Sort(wave.Enemies,(a, b) => a.Time.CompareTo(b.Time));
        
        float start = Time.time;

        foreach (var e in wave.Enemies)
        {
            float target = start + e.Time;
            float wait = target + Time.time;
            if(wait > 0f) yield return new WaitForSeconds(wait);
            SpawnOne(e.Enemy);
        }
    }

    private void SpawnOne(int enemyType)
    {
        GameObject prefab = GetPrefab(enemyType);

        if (prefab == null)
        {
            Debug.Log($"Enemigo no asignado para tipo: {enemyType}");
            return;
        }
        
        Transform point = (spawnPoints != null && spawnPoints.Length > 0) ? spawnPoints[Random.Range(0, spawnPoints.Length)] : transform;
        
        Instantiate(prefab, point.position, point.rotation);
    }

    private GameObject GetPrefab(int type)
    {
        switch (type)
        {
            case 0:
                return enemyType1;
            case 1:
                return enemyType2;
            case 2:
                return enemyType3;
            case 3:
                return enemyType4;
            default:
                Debug.Log($"tipo de enemigo {type} invalido");
                return null;
        }
    }
}
