using System.Collections.Generic;
using Inventory.Items;
using UnityEditor;
using UnityEngine;
using Random = System.Random;
using Runtime = Wigro.Runtime;
namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ItemAsset> _items;
        [SerializeField] private List<Sprite> _iconsItems;
        [SerializeField] private InventoryCell _inventoryCellTemplate;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _draggingParent;
        [SerializeField] private GameObject _infoPanel;
        
        private Runtime.Settings _settings;
        
        private void Awake()
        {
            string[] guids = AssetDatabase.FindAssets( $"t:{typeof( Runtime.Settings ).Name}" );
            if ( guids.Length > 0 )
            {
                var settingsPath = AssetDatabase.GUIDToAssetPath( guids[ 0 ] );
                _settings = AssetDatabase.LoadAssetAtPath<Runtime.Settings>( settingsPath );
            }
            else
            {
                Debug.Log("File not found");
            }
            
            Random rnd = new Random();
            for (int i = 1; i < _settings.amount; i++)
            {
                ItemAsset _item = new ItemAsset();
                _item.ItemID = DatabaseReader.itemsID[i - 1];
                _item.UIIcon = _iconsItems[rnd.Next(0, _iconsItems.Count - 1)];
                _item.Rarity = DatabaseReader.itemsRarity[i];
                _items.Add(_item);
            }
        }

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
                cell.Init(_draggingParent,_infoPanel,_settings.ShowInfo);
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