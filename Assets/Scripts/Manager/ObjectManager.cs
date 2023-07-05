using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public enum HitEffectKey
    {
        Planet,
        Garbage,
        End
    }

    public static ObjectManager instance { get; private set; }

    private Dictionary<int, Queue<Garbage>> garbageMap;

    private Dictionary<HitEffectKey, Queue<ParticleSystem>> hitEffectMap;

    private ObjectData objectData;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);

            return;
        }

        instance = this;

        garbageMap = new Dictionary<int, Queue<Garbage>>();

        hitEffectMap = new Dictionary<HitEffectKey, Queue<ParticleSystem>>();    
    }

    private void Start()
    {
        objectData = GameManager.instance.data.objectData;
    }

    public void CreateGarbage(int key, int count)
    {
        if (key >= objectData.garbages.Length)
        {
            return;
        }

        if (!garbageMap.ContainsKey(key))
        {
            garbageMap.Add(key, new Queue<Garbage>());
        }

        for (int i = 0; i < count; i++)
        {
            Instantiate(objectData.garbages[key], transform).gameObject.SetActive(false);
        }
    }
    public void ReturnGarbage(Garbage garbage, int key)
    { 
        if (!garbageMap[key].Contains(garbage))
        {
            garbageMap[key].Enqueue(garbage);
        }
    }
    public Garbage GetGarbage(int key)
    {
        if (!garbageMap.ContainsKey(key))
        {
            garbageMap.Add(key, new Queue<Garbage>());
        }

        if (garbageMap[key].Count == 0)
        {
            CreateGarbage(key, GameManager.instance.data.gamestateData.createGarbageCount);
        }

        return garbageMap[key].Dequeue();
    }
    public void CreateHitEffect(HitEffectKey key, int count)
    {
        if (key >= HitEffectKey.End)
        {
            return;
        }
     
        if (!hitEffectMap.ContainsKey(key))
        {
            hitEffectMap.Add(key, new Queue<ParticleSystem>());
        }

        for (int i = 0; i < count; i++)
        {
            ParticleSystem effect = Instantiate(objectData.hit[(int)key], transform);

            effect.gameObject.SetActive(false);

            hitEffectMap[key].Enqueue(effect);
        }
    }

    public void OnHitEffect(HitEffectKey key, Vector2 position)
    {

    }


    private IEnumerator ReturnEffect(ParticleSystem effect, Queue<ParticleSystem> pool)
    {

        


        yield break;
    }
}