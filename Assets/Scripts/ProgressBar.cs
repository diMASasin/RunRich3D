using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WalletSystem;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fillImage;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _wallet.PointsValueChanged += OnPointsValueChanged;
        _wallet.LevelIncreased += OnLevelIncreased;
    }

    private void OnDisable()
    {
        _wallet.PointsValueChanged -= OnPointsValueChanged;
        _wallet.LevelIncreased -= OnLevelIncreased;
    }

    private void OnPointsValueChanged(int value)
    {
        _slider.value = (float)value / _wallet.CurrentRichnessLevel.TargetValue;
    }

    private void OnLevelIncreased(RichnessLevel current, RichnessLevel next)
    {
        _fillImage.color = current.Color;
        _text.text = current.Text;
        _text.color = current.Color;
    }
}