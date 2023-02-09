using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class bombThrow : MonoBehaviour
    
{
    [SerializeField]private float forceBomb = 5;
    [SerializeField]private float damage =  10;
    [SerializeField]private GameObject impcatPrefub;
    [SerializeField]public GameObject grenadePrefab;
    [SerializeField]private float delay = 3f;
    [SerializeField]private float countDown;
    [SerializeField]private bool HasExploded = false;
    [SerializeField]private GameObject explosionEffect;
    [SerializeField]private float radius = 5f;
    [SerializeField]private float throwForce = 40f;
    
    
    
    private void Start()
    {
        countDown = delay;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ThrowBomb();
        }

        void ThrowBomb()
        {
         GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
           Rigidbody rb = grenade.GetComponent<Rigidbody>();
           rb.AddForce(transform.forward * throwForce);
        }
        {

            countDown -= Time.deltaTime;
            if (countDown <= 0f && !HasExploded)
            {
                Explode();
            }

            void Explode()
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

                foreach (Collider nearbyObject in colliders)
                {
                    Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(forceBomb, transform.position, radius);
                    }

                    DestructibleObject dest = nearbyObject.GetComponent<DestructibleObject>();
                   if (dest != null)
                   {
                       dest.ReceiveDamage(damage);
                   }
                   
                }
                {
                    Destroy(gameObject);
                }
                print("boom");
            }

        }
    }
}