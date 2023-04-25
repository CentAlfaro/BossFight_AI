using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject tornadoSkill;

    public Image hpBar;
    [SerializeField] private float maxHP;
    [SerializeField] private float curHP;
    private bool _isSpecialTriggered = false;

    public int _meleeCounter;
    public int _heavyCounter;

    [SerializeField] private ParticleSystem meleeKaboom;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = curHP / maxHP;
    }

    public void monsterOnDamage(float damage)
    {
        curHP -= damage;
        Debug.Log($"Monster Health: {curHP}");

        if (curHP <= maxHP*0.3f  && !_isSpecialTriggered)
        {
            GetComponent<Animator>().SetTrigger("Cast Spell");
            _isSpecialTriggered = true;
        }
        else if (curHP <= 0)
        {
            GetComponent<Animator>().SetTrigger("Die");
        }
    }

    public void MeleeExplosion() //triggered by melee and heavy animation
    {
        meleeKaboom.Play();
    }

    public void PlusOneMeleeAttack() //triggered by melee animation
    {
        _meleeCounter += 1;
        //Debug.Log($"Melee Counter: {_meleeCounter}");
    }

    public void PlusOneHeavyAttack()//triggered by heavy animation
    {
        _heavyCounter += 1;
        //Debug.Log($"Heavy Counter: {_heavyCounter}");
    }

    public void CreateTornado()//triggered by special attack
    {
        var tornado = Instantiate(tornadoSkill, transform.position+(transform.forward*10f), Quaternion.identity);
    }

    public void DestroyMonster()//triggered by death animation
    {
        Destroy(gameObject);
    }
}
