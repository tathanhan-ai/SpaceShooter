using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button Button;
    private Slider _healthSlider;
   

    void Start()
    {
        _healthSlider = GetComponent<Slider>();
        Button.onClick.AddListener(delegate { OutButtonClick(); });
    }

    // Update is called once per frame
private void OutButtonClick()
    {
        if(_healthSlider.value >= _healthSlider.minValue && _healthSlider.value<= _healthSlider.maxValue) {

            _healthSlider.value -= 10;
        }
    }
}
