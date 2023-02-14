using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [SerializeField] private float hpCurrent = 1;
    public int prefabCount = 4;

    public void ReceiveDamage(float damage)
    {
        hpCurrent -= damage;

        if (hpCurrent <= 0f)
        {
            Destroy(gameObject);
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.OnPrefabDestroyed();
        }
    }
}