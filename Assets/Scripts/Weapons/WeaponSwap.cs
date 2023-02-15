using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponSwap : MonoBehaviour
    {
        [SerializeField] private GameObject[] weapons;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                weapons[2].SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                weapons[0].SetActive(false);
                weapons[1].SetActive(false);
                weapons[2].SetActive(true);
            }
        }
    }
}