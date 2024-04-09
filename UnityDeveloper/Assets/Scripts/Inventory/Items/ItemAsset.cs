using UnityEngine;

namespace Inventory.Items
{
    [CreateAssetMenu(menuName = "Item")]
    public class ItemAsset : ScriptableObject, IItem
    {
        [SerializeField] private string _itemID;
        [SerializeField] private Sprite _uiIcon;
        [SerializeField] private int _rarity;
        [SerializeField] private int _flag;

        public string ItemID
        {
            get => _itemID;
            set => _itemID = value;
        }

        public Sprite UIIcon
        {
            get => _uiIcon;
            set => _uiIcon = value;
        }

        public int Rarity
        {
            get => _rarity;
            set => _rarity = value;
        }

        public int Flag => _flag;
    }
}