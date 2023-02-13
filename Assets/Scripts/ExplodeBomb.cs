using DefaultNamespace;
using UnityEngine;


public class ExplodeBomb : MonoBehaviour
{
    [SerializeField] private float forceBomb = 50f;
    [SerializeField] private float damage = 50f;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] private float radius = 40f;

    public void Explode()
    {
        Instantiate(explosionEffect, transform.position,
            transform.rotation); //Создаем эффекты взрыва по области(как я понял)
        Collider[]
            colliders = Physics.OverlapSphere(transform.position, radius); //опделеяем наверное область(радиус) взрыва

        foreach (Collider nearbyObject in colliders) //Создаем систему столкновения
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