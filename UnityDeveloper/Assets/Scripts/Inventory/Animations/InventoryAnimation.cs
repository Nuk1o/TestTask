using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Runtime = Wigro.Runtime;
namespace Inventory.Animations
{
    public class InventoryAnimation : MonoBehaviour
    {
        [SerializeField] private Canvas _inventoryCanvas;
        [SerializeField] private RectTransform _background;
        [SerializeField] private Animator _inventoryAnimator;
        [SerializeField] private Button _openInventoryBtn;
        [SerializeField] private Button _closeInventoryBtn;
        private Runtime.Settings settings;
        private void Start()
        {
            string[] guids = AssetDatabase.FindAssets( $"t:{typeof( Runtime.Settings ).Name}" );
            if ( guids.Length > 0 )
            {
                var settingsPath = AssetDatabase.GUIDToAssetPath( guids[ 0 ] );
                settings = AssetDatabase.LoadAssetAtPath<Runtime.Settings>( settingsPath );
            }
            else
            {
                Debug.Log("File not found");
            }
            _openInventoryBtn.onClick.AddListener(delegate { OpenAnimationInventory(); });
            _closeInventoryBtn.onClick.AddListener(delegate { CloseAnimationInventoy(); });
        }

        private void OpenAnimationInventory()
        {
            Debug.Log(settings.OpenAnimated);
            Debug.Log(settings.CloseAnimated);
            _inventoryCanvas.gameObject.SetActive(true);
            _inventoryAnimator.enabled = true;
            if (settings.OpenAnimated)
            {
                _openInventoryBtn.interactable = false;
                _inventoryAnimator.SetBool("OpenAnimated",true);
                _inventoryAnimator.SetBool("CloseAnimated",false);
                _inventoryAnimator.SetBool("isOpen",true);
            }
            else
            {
                _inventoryAnimator.enabled = false;
                _background.anchoredPosition = new Vector2(0, 0);
            }
        }

        private void CloseAnimationInventoy()
        {
            _inventoryAnimator.enabled = true;
            if (settings.CloseAnimated)
            {
                _openInventoryBtn.interactable = true;
                _inventoryAnimator.SetBool("isOpen",false);
                _inventoryAnimator.SetBool("CloseAnimated",true);
                _inventoryAnimator.SetBool("OpenAnimated",false);
            }
            else
            {
                _inventoryAnimator.enabled = false;
                _background.anchoredPosition = new Vector2(0, -1000);
            }
        }
    }
}