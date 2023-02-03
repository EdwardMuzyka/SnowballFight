using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace SnowballFight
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private Image _joystickBackground = null;
        [SerializeField] private Image _joystick = null;
        [SerializeField] private PlayerAttack _playerAttack = null;

        private Vector2 _inputVector;

        public Vector2 InputVector => _inputVector;

        public event Action OnMove;
        public event Action OnStop;

        public void OnDrag(PointerEventData eventData)
        {
            if (_playerAttack.IsShooting == false)
            {
                Vector2 pos;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
                {
                    pos.y = (pos.y / _joystickBackground.rectTransform.sizeDelta.y);
                }

                _inputVector = new Vector2(transform.position.x + 10.35f, pos.y * 2);
                _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;
                _joystick.rectTransform.anchoredPosition = new Vector2(transform.position.x + 10.35f,
                                                                       _inputVector.y * (_joystickBackground.rectTransform.sizeDelta.y / 2));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_playerAttack.IsShooting == false)
            {                
                OnMove?.Invoke();
                OnDrag(eventData);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _inputVector = Vector2.zero;
            _joystick.rectTransform.anchoredPosition = Vector2.zero;
            OnStop?.Invoke();
        }
        
        public float Vertical()
        {
            if (_inputVector.y != 0)
                return _inputVector.y;            
            return _inputVector.y = 0;
        }
    }
}