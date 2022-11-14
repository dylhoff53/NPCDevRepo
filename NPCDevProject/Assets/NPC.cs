using System;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private int startingHp = 100;
    [SerializeField] private ParticleSystem deathParticlePrefab;

    private int currentHp;

    private float CurrentHpPct
    {
        get { return (float)currentHp / (float)startingHp; }
    }


    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnNPCDied = delegate { };

    private void Start()
    {
        currentHp = startingHp;
    }


    internal void TakeDamage(int amount) {
        GetComponent<IHealth>().TakeDamage(amount);
    }

    private void Die()
    {
        OnNPCDied();
        GameObject.Destroy(this.gameObject);
    }
}