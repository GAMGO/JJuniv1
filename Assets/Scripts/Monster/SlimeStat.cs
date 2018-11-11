using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStat : MonoBehaviour {
    public float slimeSpeed = 2.0f;
    public float slimeRotat = 2.0f;
    public float slimeFall = 50.0f;
    public float slimeRange = 2.0f;
    public float slimeHp = 100.0f;
    public float attackRate = 30.0f;
    public CharacterStat lastHitBy = null;
    public SlimeFSMManager manager;
    private void Awake()
    {
        manager = GetComponent<SlimeFSMManager>();
    }

    public void NotifyDead()
    {
        manager.NotifyDead();
    }

    public void ApplyDamage(CharacterStat from)
    {
        slimeHp -= from.attackRate;
        if (slimeHp <= 0)
        {
            manager.SetDead();
            if (lastHitBy == null)
            {
                lastHitBy = from;
            }
            from.NotifyDead();
            
        }
    }
}
