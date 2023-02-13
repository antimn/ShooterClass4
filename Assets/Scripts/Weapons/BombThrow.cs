using DefaultNamespace;
using UnityEngine;

public class BombThrow : MonoBehaviour

{
    [SerializeField] private float delay = 3f;
    [SerializeField] private float countDown;
    [SerializeField] private bool HasExploded = false;


    private void Start()
    {
        // На самом старте у нас начинается отсчет, когда он станет <0 произойдет Explode
        countDown = delay;
    }

    public void Update()
    {
        // Тут мы используем GetMouseButtonUp который срабатывает когда мы отпускаем левую кнопку мышки
        if (Input.GetMouseButtonUp(0))
        {
            // Делаем гет компонент из нашего объекта префаба бомбы
            // Это вызов нашего войда в котором мы написали создания копии префаба гранаты и метание ее
            BombCreate BombCreate = gameObject.GetComponent<BombCreate>();
            BombCreate.Bomb();
        }


        countDown -= Time.deltaTime; // -= эквивалетно countDown - Time.deltaTime
        if (countDown <= 0f &&
            !HasExploded) // countDown меньше или равно 0 ИЛИ HasExploded(фолс в дефолте сверху) знак ! = дефолт
            // Когда значения выше в if становится ТРУ, а именно countDown становится 0 или меньше, происхоидт Explode
        {
            // В MonoBehaviour нельзя использовать 'new', поэтому я использовал GetComponent 
            // и прицепил к префабу бомбы скрипт ExplodeBombT
            ExplodeBomb Explode = gameObject.GetComponent<ExplodeBomb>();
            Explode.Explode();
        }
    }
}