using UnityEngine;


public class CharacterStats : MonoBehaviour {

    public int max_health = 100;

    public int CurrentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        CurrentHealth = max_health;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {

    }
}
