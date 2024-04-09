using UnityEngine;

namespace Inventory.Items
{
    public interface IItem
    {
        string ItemID { get; }
        Sprite UIIcon { get; }
        int Rarity { get; }
        int Flag { get; }
    }
}