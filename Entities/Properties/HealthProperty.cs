using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
    
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDied;
    
    public event EventHandler OnHealthAmountMaxChanged;

    [SerializeField] private int healthAmountMax;
    
    private int _healthAmount;

    private void Awake() {
        _healthAmount = healthAmountMax;
    }

    public void TakeDamage(int amount) {
        _healthAmount -= amount;
        _healthAmount = Mathf.Clamp(_healthAmount, 0, healthAmountMax);

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (IsDead() == true) {
            OnDied?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Heal(int amount) {
        _healthAmount += amount;
        _healthAmount = Mathf.Clamp(_healthAmount, 0, healthAmountMax);

        OnHealed?.Invoke(this, EventArgs.Empty);
    }

    public void HealMax() {
        Heal(healthAmountMax);
    }
    
    public void SetHealthAmountMax(int healthAmountMax, bool updateHealthAmount = true) {
        this.healthAmountMax = healthAmountMax;

        if(updateHealthAmount == true) 
            _healthAmount = healthAmountMax;

        OnHealthAmountMaxChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetHealthAmount() => _healthAmount;
    public int GetHealthAmountMax() => healthAmountMax;

    public float GetHealthAmountNormalized() {
        return (float)_healthAmount / healthAmountMax;
    }
    
    public bool IsDead() => _healthAmount == 0;
    public bool IsFullHealth() => _healthAmount == healthAmountMax;

}
