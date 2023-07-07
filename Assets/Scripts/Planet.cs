using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [field: SerializeField] public int index { get; set; }
    [field: SerializeField] public float health { get; set; }

    private SpriteRenderer spriteRenderer;

    private Color baseColor;

    private Coroutine colorizeCoroutine;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        baseColor = spriteRenderer.color;
    }

    public void Initialize(float health)
    {
        this.health = health;
    }


    public void OnDamage(int score)
    {
        health -= score;

        if(colorizeCoroutine != null)
        {
            StopCoroutine(colorizeCoroutine);
        }


        UIManager.instance.SetHealthBarUI(true, index, health, GameManager.instance.data.planetData.maxHealth);

        colorizeCoroutine = StartCoroutine(HitColorize());

        
    }


    private IEnumerator HitColorize()
    {
        spriteRenderer.color = GameManager.instance.data.planetData.hitColor;

        yield return new WaitForSeconds(GameManager.instance.data.planetData.colorizeTime);

        spriteRenderer.color = baseColor;
    }


}