using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SnowballFight
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _fillImage = null;
        [SerializeField] private float _fillSpeed = 0f;

        private float _fullProgress = 1f;
        private Coroutine _progressCoroutine = null;
        
        public Image FillImage => _fillImage;
       
        private void Update()
        {           
            _progressCoroutine = StartCoroutine(IEIncrease());            
        }

        private void OnDisable()
        {
            if (_progressCoroutine != null)
                StopCoroutine(_progressCoroutine);
        }       

        private void IncrementFillAmount()
        {
            _fillImage.fillAmount += _fillSpeed * Time.deltaTime;
        }       

        private IEnumerator IEIncrease()
        {            
            IncrementFillAmount();
            if (_fillImage.fillAmount == _fullProgress)
            {
                yield return new WaitForSeconds(0.2f);
                _fillImage.fillAmount = 0f;
            }
        }
    }
}