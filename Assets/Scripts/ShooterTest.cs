using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class ShooterTest : MonoBehaviour
{
    public float force = 10;

  private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit))
            {
                print(hit.transform.gameObject.name);

                var rigitbody = hit.transform.GetComponent<Rigidbody>();
                if (rigitbody == null)
                {
                    return;
                }
                rigitbody.AddForce(transform.forward * force, ForceMode.Impulse);
            }
        }
    }
}
