using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] Transform _topTransform;
    [SerializeField] Transform _bottomTransform;
    [SerializeField] Transform _ballTransform;
    [SerializeField] int currentLevel = 0;
    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _actualLevelText;
    [SerializeField] TextMeshProUGUI _nextLevelText;

    void Update()
    {
        SliderProgress();
    }
    public void SliderProgress()
    {
        _actualLevelText.text = "" + (currentLevel + 1);
        _nextLevelText.text = "" + (currentLevel + 2);

        float _totalDistance = (_topTransform.position.y - _bottomTransform.position.y);
        float _distanceLeft = _totalDistance - (_ballTransform.position.y - _bottomTransform.position.y);
        float value = (_distanceLeft / _totalDistance);

        _slider.value = Mathf.Lerp(_slider.value, value, 5f);
    }
}
