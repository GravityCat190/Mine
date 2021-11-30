using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Target : MonoBehaviour
{
    private int minTargetPoints = 3;
    private int maxTargetPoints = 5;

    public int points;
    public LineManager LineManager;
    [SerializeField] private ParticleSystem DieExplosion;
    public abstract void GetHit();

    public virtual void Start()
    {
        LineManager = FindObjectOfType<LineManager>();
    }

    public void SetPoints()
    {
        points = Random.Range(minTargetPoints, maxTargetPoints + 1);
    }

    public void Die()
    {
        Instantiate(DieExplosion, transform.position, DieExplosion.transform.rotation);
        Destroy(gameObject);
    }
}
