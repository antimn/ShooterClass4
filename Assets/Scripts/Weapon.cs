using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float force = 10;
    public float damage =  10;
    public GameObject impcatPrefub;
    public Transform shootPoint;
    public int i = 1; 
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
