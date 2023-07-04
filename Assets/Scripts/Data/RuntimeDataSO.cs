using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameDataSO",
menuName = "Scriptable Object/GameData", order = 0)]

public class RuntimeDataSO : ScriptableObject
{
    [field: SerializeField] public ClickerData clickerData { get; private set; }
    [field: SerializeField] public PlanetData planetData { get; private set; }
    [field: SerializeField] public GarbageData garbageData { get; private set; }
    [field: SerializeField] public ObjectData objectData { get; private set; }


}


[Serializable]
public class ClickerData
{
    [field: SerializeField] public float hitCheckTime { get; private set; }

}


[Serializable]
public class PlanetData
{

}


[Serializable]
public class GarbageData
{

}


[Serializable]
public class ObjectData
{

}