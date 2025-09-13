using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WavesJson 
{
    public WaveEntry[] Waves;
}

[System.Serializable]
public class WaveEntry
{
    public int Wave;
    public EnemySpawn[] Enemies;
}

[System.Serializable]
public class EnemySpawn
{
    public int Enemy;
    public float Time;
}