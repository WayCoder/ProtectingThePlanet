
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private Planet[] planets;

    [SerializeField] private SpawnPositions[] positions;

    private void OnDisable()
    {
       
    }
    private void OnEnable()
    {
        StartCoroutine(GarbageSpawn());
    }
    private IEnumerator GarbageSpawn()
    {
        RuntimeDataSO data = GameManager.instance.data;

        Garbage garbage1;

        Garbage garbage2;

        Vector3 position1;

        Vector3 position2;

        float time;

        int garbageIndex;

        int targetIndex;

        float moveSpeed;

        float rotationSpeed;

        while(true)
        {
            time = Random.Range(data.garbageData.minSpawnTime, data.garbageData.maxSpawnTime);

            yield return new WaitForSeconds(time);

            garbageIndex = Random.Range(0, data.objectData.garbages.Length);

            garbage1 = ObjectManager.instance.GetGarbage(garbageIndex);

            garbage2 = ObjectManager.instance.GetGarbage(garbageIndex);

            moveSpeed = Random.Range(data.garbageData.minMoveSpeed, data.garbageData.maxMoveSpeed);

            rotationSpeed = Random.Range(data.garbageData.minRotationSpeed, data.garbageData.maxRotationSpeed);

            targetIndex = Random.Range(0, positions.Length - 1);

            position1 = positions[targetIndex].position1;

            position2 = positions[targetIndex].position2;

            garbage1.Initialize(planets[0].transform, position1, moveSpeed, rotationSpeed, 0);

            garbage2.Initialize(planets[1].transform, position2, moveSpeed, rotationSpeed, 1);
        }
    }
}