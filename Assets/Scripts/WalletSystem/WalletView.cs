using TMPro;
using UnityEngine;

namespace WalletSystem
{
    public class WalletView: MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Wallet _wallet;
        
        private void OnEnable()
        {
            _wallet.PointsValueChanged += OnPointsValueChanged;
        }

        private void OnDisable()
        {
            _wallet.PointsValueChanged -= OnPointsValueChanged;
        }

        private void OnPointsValueChanged(int points)
        {
            Debug.Log($"points: {points}");
            _text.text = points.ToString();
        }
    }
}