using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class bombThrow : MonoBehaviour

{
    [SerializeField] private float forceBomb = 5;
    [SerializeField] private float damage = 10;
    [SerializeField] private GameObject impcatPrefub;
    [SerializeField] public GameObject grenadePrefab;
    [SerializeField] private float delay = 3f;
    [SerializeField] private float countDown;
    [SerializeField] private bool HasExploded = false;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float throwForce = 40f;

    private void ThrowBomb()
    {
        // В этой строке мы создаем копию граннаты, но не могу объяснить абсолютно кажде слово, к примеру transform.position, transform.rotation
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);  
        // Тут мы создаем риджед бади для гранаты
        Rigidbody rb = grenade.GetComponent<Rigidbody>(); 
        // Включаем гравитацию для рб во время генерации, в самом юнити я ее выключил чтобы граната не падала на пол при старте
        rb.useGravity = true;
        //бросаем гранату с силой 
        rb.AddForce(transform.forward * throwForce);
    }

    private void Start()
    {
        //На самом старте у нас начинается отсчет, когда он станет <0 произойдет Explode
        countDown = delay;
    }

    private void Update()
    {
        // Тут мы используем GetMouseButtonUp который срабатывает когда мы отпускаем левую кнопку мышки
        if (Input.GetMouseButtonUp(0))
        {
            // Это вызов нашего войда в котором мы написали создания копии префаба гранаты и метание ее
            ThrowBomb();
        }


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