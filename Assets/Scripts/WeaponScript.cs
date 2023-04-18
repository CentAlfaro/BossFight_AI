using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private PlayerScript player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {

            player.currentMonster = other.GetComponent<MonsterScript>();
            player.canDamageEnemy = true;

        }
    }
}
