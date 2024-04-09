using System;
using Inventory.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler,IPointerEnterHandler,IPointerExitHandler
    {
        public event Action DroppingItem;
        
        [SerializeField] private Text _nameField;
        [SerializeField] private Image _icon;
        [SerializeField] private int _rarity;
        [SerializeField] private int _flag;
        [SerializeField] private Image _cellImage;

        private Transform _draggingParent;
        private Transform _originalgParent;
        private RectTransform _rectTransform;
        private GameObject _infoPanel;
        private InfoPanel _info;
        private bool _isShowInfo;
        
        private bool In(RectTransform originalParent)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(originalParent, transform.position);
        }
        
        public void Render(IItem item)
        {
            _nameField.text = item.ItemID;
            _icon.sprite = item.UIIcon;
            _rarity = item.Rarity;
            _flag = item.Flag;
            transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f, 1);
            SetRarityColor();
        }

        private void SetRarityColor()
        {
            switch (_rarity)
            {
                case 1:
                    _cellImage.color = Color.blue; 
                    break;
                case 2:
                    _cellImage.color = Color.red;
                    break;
                case 3:
                    _cellImage.color = Color.yellow;
                    break;
                default:
                    _cellImage.color = Color.gray;
                    break;
            }
        }

        public void Init(Transform draggingParent, GameObject infoPanel, bool isShowInfo)
        {
            _draggingParent = draggingParent;
            _originalgParent = transform.parent;
            _rectTransform = GetComponent<RectTransform>();
            _infoPanel = infoPanel;
            _isShowInfo = isShowInfo;
            _info = _infoPanel.GetComponent<InfoPanel>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (In((RectTransform)_originalgParent))
            {
                InsertInGrid();
            }
            else
            {
                Dropped();
            }
        }

        private void Dropped()
        {
            DroppingItem?.Invoke();
        }

        private void InsertInGrid()
        {
            int closeIndex = 0;
            float closeDistance = Mathf.Infinity;
            
            for (int i = 0; i < _originalgParent.transform.childCount; i++)
            {
                float distance = Vector3.Distance(transform.position, _originalgParent.GetChild(i).position);
                if (distance < closeDistance)
                {
                    closeDistance = distance;
                    closeIndex = i;
                }
            }

            transform.parent = _originalgParent;
            transform.SetSiblingIndex(closeIndex);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.parent = _draggingParent;
            _infoPanel.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isShowInfo)
            {
                _info.SetValues(_nameField.text,_rarity);
                _infoPanel.SetActive(true);
                InfoPanel _component = _infoPanel.GetComponent<InfoPanel>();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _infoPanel.SetActive(false);
        }
    }
}