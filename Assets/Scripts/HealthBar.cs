using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetMaxHp(int maxHp)
    {
        _slider.maxValue = maxHp;
        _slider.value = maxHp;
    }

    public void SetHp(int hp)
    {
        _slider.value = hp;
    }
}
