using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private Text _textID;
        [SerializeField] private Text _textRarity;

        public void SetValues(string itemID, int rarity)
        {
            _textID.text = itemID;
            _textRarity.text = rarity.ToString();
        }
    }
}