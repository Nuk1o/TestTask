using System.Collections.Generic;
using Inventory.Items;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ItemAsset> _items;
        [SerializeField] private InventoryCell _inventoryCellTemplate;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _draggingParent;
        [SerializeField] private GameObject _infoPanel;

        private void OnEnable()
        {
            Render(_items);
        }

        public void Render(List<ItemAsset> items)
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
            items.ForEach(item =>
            {
                var cell = Instantiate(_inventoryCellTemplate, _container);
                cell.Init(_draggingParent,_infoPanel);
                cell.Render(item);
                cell.DroppingItem += ()=>DestroyItem(cell.gameObject);
            });
        }

        private void DestroyItem(GameObject item)
        {
            Destroy(item);
        }
    }
}