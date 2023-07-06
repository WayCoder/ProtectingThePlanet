using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SpawnPositions
{ 
    [field: SerializeField] public Vector3 position1 { get; private set; }

    [field: SerializeField] public Vector3 position2 { get; private set; }
}
