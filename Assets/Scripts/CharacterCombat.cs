using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    public float attack_speed = 1f;
    public float attack_delay = 0.6f;

    public event System.Action OnAttack;

    private float attack_cooldown = 0f;
    private CharacterStats my_stats;

    private void Start()
    {
        my_stats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if(attack_cooldown > 0)
        {
            attack_cooldown -= Time.deltaTime;
        }
    }

    public void Attack(CharacterStats target_stats)
    {
        if(attack_cooldown <= 0f)
        {
            StartCoroutine(DoDamage(target_stats, attack_delay));

            if (OnAttack != null)
                OnAttack();

            attack_cooldown = 1f / attack_speed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(my_stats.damage.GetValue());
    }
        
}
