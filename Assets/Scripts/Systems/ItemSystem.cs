using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems
{
    public class ItemSystem : MonoBehaviour
    {
        public static ItemSystem Instance;
        [SerializeField] public ItemLibrary itemLibrary;
        public GameObject pfDropItem;
        public Inventory inventory;
    
        private void Awake()
        {
            Instance = this;
            inventory = new Inventory();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SpawnRandomItem();
            }    
        }

        public void SpawnRandomItem()
        {
            Vector3 pos = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
            Item item = itemLibrary.GetRandomItem();
            GameObject obj = Instantiate(pfDropItem, pos, Quaternion.identity);
            DropItem itemComponent = obj.GetComponent<DropItem>(); 
            itemComponent.SetContent(item);
            itemComponent.onPickUp += item1 =>
            {
                inventory.AddItem(item1);
                UISystem.Instance.RedrawInventory();
            };
        }

        public void EquipItem(Item item)
        {
            Hero hero = HeroSystem.Instance.activeHero;
            if (!hero) return;
            var oldItem = hero.equipment.AddItem(item);
            if (oldItem != null)
            {
                inventory.AddItem(oldItem);
            }
            inventory.RemoveItem(item);
            UISystem.Instance.RedrawInventory();
            UISystem.Instance.RedrawEquipment();
        }

        public void RemoveItem(Item item)
        {
            Hero hero = HeroSystem.Instance.activeHero;
            hero.equipment.RemoveItem(item.type);
            inventory.AddItem(item);
            UISystem.Instance.RedrawInventory();
            UISystem.Instance.RedrawEquipment();
        }
    }
}