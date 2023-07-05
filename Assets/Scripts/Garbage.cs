using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] private int index;

    private GarbageData data;

    private Transform target;

    private float moveSpeed;

    private float rotationSpeed;

    public void Initialize(Transform transform, float moveSpeed, float rotationSpeed)
    {
        target = transform;

        this.moveSpeed = moveSpeed;

        this.rotationSpeed = rotationSpeed;
    }



    private void OnEnable()
    {
      
    }

    private void OnDisable()
    {
        ObjectManager.instance?.ReturnGarbage(this, index);

        target = null;
    }

    private void Start()
    {
        data = GameManager.instance.data.garbageData;
    }

    private void Update()
    {
        if (target != null)
        {
           





        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        collision.GetComponent<IDamageable>()?.OnDamage(data.scores[index]);

        if (collision.CompareTag("Clicker"))
        {
            GameManager.instance.IncreaseScore(index, data.scores[index]);

        }

        gameObject.SetActive(false);
    }
}