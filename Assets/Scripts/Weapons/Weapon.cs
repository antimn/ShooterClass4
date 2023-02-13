using DefaultNamespace;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public float force = 10;
    [SerializeField] public float damage = 10;
    [SerializeField] public GameObject impcatPrefub;
    [SerializeField] public Transform shootPoint;
// Это я написал во время урока, просто отрефакторил не много, дискрипшн не писал, решил его писать на основе уже гранаты
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