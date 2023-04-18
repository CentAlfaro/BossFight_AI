using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Image hpBar;
    public float maxHP;
    public float curHP;

    public int _meleeCounter;

    public int _heavyCounter;

    [SerializeField] private ParticleSystem meleeKaboom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = curHP / maxHP;
    }

    public void MeleeExplosion()
    {
        meleeKaboom.Play();
    }

    public void PlusOneMeleeAttack()
    {
        _meleeCounter += 1;
        Debug.Log($"Melee Counter: {_meleeCounter}");
    }

    public void PlusOneHeavyAttack()
    {
        _heavyCounter += 1;
        Debug.Log($"Heavy Counter: {_heavyCounter}");
    }
}
