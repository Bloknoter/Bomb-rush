using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Health : MonoBehaviour
{
    public delegate void OnValueChangedDelegate(int previousvalue, int newvalue);

    public event OnValueChangedDelegate OnValueChangedEvent;

    [SerializeField]
    [Min(1)]
    private int health;

    public int HealthValue
    {
        get { return health; }
        set
        {
            int prevhealth = health;
            health = Mathf.Clamp(value, 0, maxHealth);
            if (prevhealth != health)
                OnValueChangedEvent?.Invoke(prevhealth, health);
        }
    }

    private int maxHealth;

    void Start()
    {
        maxHealth = health;
    }

}

