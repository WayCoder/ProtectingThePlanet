using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RuntimeDataSO",
menuName = "Scriptable Object/RuntimeDataSO", order = 0)]

public class RuntimeDataSO : ScriptableObject
{
    [field: SerializeField] public GameStateData gamestateData { get; private set; }
    [field: SerializeField] public ClickerData clickerData { get; private set; }
    [field: SerializeField] public PlanetData planetData { get; private set; }
    [field: SerializeField] public GarbageData garbageData { get; private set; }
    [field: SerializeField] public ObjectData objectData { get; private set; }
    [field: SerializeField] public SoundData soundData { get; private set; }
    [field: SerializeField] public UIData uiData { get; private set; }
}

[Serializable]
public class GameStateData
{
    [field: SerializeField] public float gameplayTime { get; private set; }
    [field: SerializeField] public int createGarbageCount { get; private set; }
    [field: SerializeField] public int createHitEffectCount { get; private set; }
}

[Serializable]
public class ClickerData
{
    [field: SerializeField] public float hitCheckTime { get; private set; }
}

[Serializable]
public class PlanetData
{
    [field: SerializeField] public int maxHealth { get; private set; }
    [field: SerializeField] public Color hitColor { get; private set; }
    [field: SerializeField] public float colorizeTime { get; private set; }



}


[Serializable]
public class GarbageData
{
    [field: SerializeField] public int[] scores { get; private set; }
    [field: SerializeField] public float minMoveSpeed { get; private set; }
    [field: SerializeField] public float maxMoveSpeed { get; private set; }
    [field: SerializeField] public float minRotationSpeed { get; private set; }
    [field: SerializeField] public float maxRotationSpeed { get; private set; }
    [field: SerializeField] public float minSpawnTime { get; private set; }
    [field: SerializeField] public float maxSpawnTime { get; private set; }
}


[Serializable]
public class ObjectData
{
    [field: SerializeField] public Garbage[] garbages { get; private set; }
    [field: SerializeField] public ParticleSystem[] hitEffect { get; private set; }
}


[Serializable]
public class SoundData
{
    [field: SerializeField] public AudioClip bgm { get; private set; }
    [field: SerializeField] public AudioClip planetHit { get; private set; }
    [field: SerializeField] public AudioClip garbageHit { get; private set; }
}


[Serializable]
public class UIData
{
    [field: SerializeField] public string titleText { get; private set; }
    [field: SerializeField] public string endingText { get; private set; }
    [field: SerializeField] public string startText { get; private set; }
    [field: SerializeField] public string retryText { get; private set; }
    [field: SerializeField] public string winnerText { get; private set; }
    [field: SerializeField] public string loserText { get; private set; }
    [field: SerializeField] public Color winnerTextColor { get; private set; }
    [field: SerializeField] public Color loserTextColor { get; private set; }
    [field: SerializeField] public Color timerBaseColor { get; private set; }
    [field: SerializeField] public Color timerRedColor { get; private set; }
    [field: SerializeField] public Color planetSafeColor { get; private set; }
    [field: SerializeField] public Color planetWarningColor { get; private set; }
    [field: SerializeField] public Color planetDangerColor { get; private set; }
    [field: SerializeField] public float planetWarningAmount { get; private set; }
    [field: SerializeField] public float planetDangerAmount { get; private set; }
}