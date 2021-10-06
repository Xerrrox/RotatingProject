using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreFiller : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private float _maxTime;

    [SerializeField]
    private float _minTime;

    public void SetProgress(float value, float maxValue)
    {
        float normalizedValue = value / maxValue;
        float duration = Mathf.Lerp(_minTime, _maxTime, normalizedValue);

        StartCoroutine(LerpValue(0, normalizedValue, duration, SetSliderValue));
        StartCoroutine(LerpValue(0, value, duration, SetTextValue));
    }

    private IEnumerator LerpValue(float startValue, float endValue, float duration, UnityAction<float> action)
    {
        float elapsed = 0;
        float nextValue;

        while(elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            action?.Invoke(nextValue);
            elapsed += Time.deltaTime;
            yield return null;
        }
        action?.Invoke(endValue);
    }

    private void SetSliderValue(float value)
    {
        _slider.value = value;
    }

    private void SetTextValue(float value)
    {
        value = (int)value;
        _text.text = value.ToString();
    }
}
