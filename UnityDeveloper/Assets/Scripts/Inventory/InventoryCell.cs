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

        private Transform _draggingParent;
        private Transform _originalgParent;
        private RectTransform _rectTransform;
        [SerializeField] private GameObject _infoPanel;
        
        private bool In(RectTransform originalParent)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(originalParent, transform.position);
        }
        
        public void Render(IItem item)
        {
            _nameField.text = item.ItemID;
            _icon.sprite = item.UIIcon;
        }

        public void Init(Transform draggingParent, GameObject infoPanel)
        {
            _draggingParent = draggingParent;
            _originalgParent = transform.parent;
            _rectTransform = GetComponent<RectTransform>();
            _infoPanel = infoPanel;
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
            _infoPanel.SetActive(true);
            Debug.Log("Mouse enter");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _infoPanel.SetActive(false);
            Debug.Log("Mouse exit");
        }
    }
}