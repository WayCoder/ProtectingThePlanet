using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] private int index;

    private new Rigidbody2D rigidbody;

    private Transform target;

    private float moveSpeed;

    private float rotationSpeed;

    private int planetIndex;


    public void Initialize(Transform transform, Vector3 position ,float moveSpeed, float rotationSpeed, int planetIndex)
    {
        target = transform;

        this.transform.position = position;  

        this.moveSpeed = moveSpeed;

        this.rotationSpeed = rotationSpeed;

        this.planetIndex = planetIndex;  

        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        ObjectManager.instance?.ReturnGarbage(this, index);

        planetIndex = -1;

        target = null;
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (target != null)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }


    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;

            Vector2 velocity = direction * moveSpeed;

            rigidbody.AddForce(velocity - rigidbody.velocity);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.activeSelf)
        {
            return;
        }

        switch (collision.tag)
        {
            case "Clicker":
                GameManager.instance.IncreaseScore(planetIndex, GameManager.instance.data.garbageData.scores[index]);
                ObjectManager.instance.OnHitEffect(ObjectManager.HitEffectKey.Garbage, transform.position);
                gameObject.SetActive(false);
                break;

            case "Planet":
                Planet planet = collision.GetComponent<Planet>();
                planet?.OnDamage(GameManager.instance.data.garbageData.scores[index]);
                ObjectManager.instance.OnHitEffect(ObjectManager.HitEffectKey.Planet, collision.ClosestPoint(transform.position));
                ObjectManager.instance.OnHitEffect(ObjectManager.HitEffectKey.Garbage, transform.position);
                gameObject.SetActive(false);
                break;
        }
    }
}