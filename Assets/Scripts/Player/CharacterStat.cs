using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Saving Statdata
public class CharacterStat : MonoBehaviour
{
    public float s = 4.0f;
    public float rs = 540.0f;
    public float fall = 50.0f;
    public float attackR = 2.0f;
    public float hp = 100.0f;
    public float attackRate = 35.0f;
    public SlimeStat lastHitBy = null;
    public FSMManager manager;
    private void Awake()
    {
        manager = GetComponent<FSMManager>();
    }
    public void NotifyDead()
    {
        manager.NotifyDead();
    }
    public void ApplyDamage(SlimeStat from)
    {
        hp -= from.attackRate;
        if (hp <= 0)
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