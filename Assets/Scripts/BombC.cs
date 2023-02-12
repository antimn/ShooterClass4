using UnityEngine;

namespace DefaultNamespace
{
    public class BombC : MonoBehaviour

    {
        [SerializeField] public GameObject grenadePrefab;
        [SerializeField] private float throwForce = 40f;

        public void Bomb()

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
    }
}