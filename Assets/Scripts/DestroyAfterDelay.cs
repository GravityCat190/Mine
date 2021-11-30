using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    [SerializeField] int delayTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayTime);
    }
}
