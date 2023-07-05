using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawn_A;

    [SerializeField] private Transform[] spawn_B;

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

        float time;

        int index;

        Garbage garbage1;

        Garbage garbage2;

        Transform target1;

        Transform target2;

        float moveSpeed;

        float rotationSpeed;

        while(true)
        {
            time = Random.Range(data.garbageData.minSpawnTime, data.garbageData.maxSpawnTime);

            yield return new WaitForSeconds(time);

            index = Random.Range(0, data.objectData.garbages.Length);

            garbage1 = ObjectManager.instance.GetGarbage(index);

            garbage2 = ObjectManager.instance.GetGarbage(index);

            target1 = spawn_A[Random.Range(0, spawn_A.Length - 1)];

            target2 = spawn_B[Random.Range(0, spawn_B.Length - 1)];

            moveSpeed = Random.Range(data.garbageData.minMoveSpeed, data.garbageData.maxMoveSpeed);

            rotationSpeed = Random.Range(data.garbageData.minRotationSpeed, data.garbageData.maxRotationSpeed);

            garbage1.Initialize(target1, moveSpeed, rotationSpeed);

            garbage2.Initialize(target2, moveSpeed, rotationSpeed);
        }
    }
}