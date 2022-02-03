using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOOM : MonoBehaviour
{
    [SerializeField] private GameObject ForExp;
    [SerializeField] private LayerMask _layerMask;

    private void Start()
    {
        Invoke("Boom",3f);
    }


    private void OnEnable()
    {
    //    StartCoroutine(Boom());
    
    }

    void Boom()
    {
       
        Instantiate(ForExp, (Vector2)transform.position + Vector2.down, Quaternion.identity);
        var colliders = Physics2D.OverlapCircleAll(transform.position, 1f,_layerMask);
        foreach (var cold in colliders)
        {
            Destroy(cold.gameObject);
        }
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
