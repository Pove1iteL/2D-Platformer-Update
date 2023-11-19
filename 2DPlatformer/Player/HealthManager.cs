using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Text _visualHealthPointPlayer;
    [SerializeField] private Slider _sliderHealthDynamic;
    [SerializeField] private Slider _sliderSmoothHealth;

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private EnemyStats _enemyrStats;

    [SerializeField] private float _curranrVelocity = 0;
    [SerializeField] private float _smoothTime = 100;

    private void Awake()
    {
        _sliderHealthDynamic.maxValue = _playerStats.MaxHealthPoint;
        _sliderSmoothHealth.maxValue = _playerStats.MaxHealthPoint;
    }

    private void Update()
    {
        _visualHealthPointPlayer.text = $"{_playerStats.HealthPoint}/{_playerStats.MaxHealthPoint}";

        _sliderHealthDynamic.value = _playerStats.HealthPoint;

        _sliderSmoothHealth.value = Mathf.SmoothDamp(_sliderSmoothHealth.value, _playerStats.HealthPoint, ref _curranrVelocity, _smoothTime * Time.deltaTime);
    }

    public void TakeDamage()
    {
        int damage = 16;
        _playerStats.GetDamage(damage);
    }

    public void GetHeal()
    {
        int heal = 10;
        _playerStats.TakeHeal(heal);
    }
}
