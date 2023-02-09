using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]private float force = 10;
    [SerializeField]private float damage =  10;
    [SerializeField]private GameObject impcatPrefub;
    [SerializeField]private Transform shootPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
            {
                print(hit.transform.gameObject.name);

                Instantiate(impcatPrefub, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
                
                var destructible = hit.transform.GetComponent<DestructibleObject>();

                if (destructible != null)
                {
                    destructible.ReceiveDamage(damage);
                }

  
                var rigitbody = hit.transform.GetComponent<Rigidbody>();
                if (rigitbody != null)
                {
                    rigitbody.AddForce(shootPoint.forward * force, ForceMode.Impulse);
                }
            }
        }
    }
}