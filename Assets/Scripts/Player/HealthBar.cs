using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    private Slider _healthSlider;
   

    void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }


    public void UpdateHealthBar(float damage)
    {
            _healthSlider.value -= damage;
    }
}
