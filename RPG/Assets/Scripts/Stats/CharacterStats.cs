using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/* Contains all the stats for a character. */

public class CharacterStats : MonoBehaviour {

	public Stat maxHealth;			// Maximum amount of health
	public int currentHealth {get;protected set;}	// Current amount of health

	public Stat damage;
	public Stat armor;
    public StatF speed;

	public event System.Action OnHealthReachedZero;

    private NavMeshAgent agent;

    // Start with max HP.
    public virtual void Awake()
    {
		currentHealth = maxHealth.GetValue();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed.GetValue();
	}

	public virtual void Start ()
	{
		
	}

	// Damage the character
	public void TakeDamage (int damage)
	{
		// Subtract the armor value - Make sure damage doesn't go below 0.
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		// Subtract damage from health
		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + " damage.");

		// If we hit 0. Die.
		if (currentHealth <= 0)
		{
			if (OnHealthReachedZero != null) {
				OnHealthReachedZero ();
			}
		}
	}

    public void TakeMagicDamage (int damage)
    {
        // Subtract damage from health
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        // If we hit 0. Die.
        if (currentHealth <= 0)
        {
            if (OnHealthReachedZero != null)
            {
                OnHealthReachedZero();
            }
        }
    }

	// Heal the character.
	public void Heal (int amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
	}

    // Slow the character for a duration
    public void Slow (float percentage, float duration)
    {
        StartCoroutine(SlowEnumerator(percentage, duration));
    }

    IEnumerator SlowEnumerator(float percentage, float duration)
    {
        float multiplier = percentage / 100f;
        float speedReducer = -speed.GetValue() * percentage;
        speed.AddModifier(speedReducer);
        agent.speed = speed.GetValue();

        yield return new WaitForSeconds(duration);

        speed.RemoveModifier(speedReducer);
        agent.speed = speed.GetValue();
    }

    public void Poison (int amountPerTick, float duration)
    {
        StartCoroutine(PoisonEnumerator(amountPerTick, duration));
    }

    IEnumerator PoisonEnumerator(int amountPerTick, float duration)
    {
        float timer = 0f;
        float tickSpeed = 0.7f;
        while (timer <= duration)
        {
            TakeMagicDamage(amountPerTick);
            yield return new WaitForSeconds(tickSpeed);
            timer += tickSpeed;
        }
    }
}
