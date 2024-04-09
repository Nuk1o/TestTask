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

        public string ItemID => _itemID;
        public Sprite UIIcon => _uiIcon;
        public int Rarity => _rarity;
        public int Flag => _flag;
    }
}