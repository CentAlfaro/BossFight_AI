using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("InGame Stats")]
    [SerializeField] private float pHealth = 100;
    
    [SerializeField] private float weaponDamage = 20;
    [SerializeField] private float mSpeed = 10;

    [Header("Calculations")]
    private Vector3 _moveDirection;
    private Vector3 _lastMovement;
    //private Vector3 _mousePos;
    public bool isAttacking = false;
    public bool isMoving = false;
    public bool canMove;
    public bool preparingToMove;
    public bool isRolling;
    public bool canRoll;

    public bool canDamageEnemy;

    [Header("References")]
    private Rigidbody _rb;
    [SerializeField] public GameObject WeaponCollider;
    [SerializeField] public MonsterScript currentMonster;
    


    public void OnDamage(float dmgDealt)
    {
        pHealth = pHealth - dmgDealt;
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessInputs();

    }
    private void FixedUpdate()
    {
        PlayerMovement();
        
    }

    private void ProcessInputs()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (horizontalInput != 0 || verticalInput !=0)
        {
            preparingToMove = true;
        }
        else
        {
            preparingToMove = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canRoll)
            {
                isRolling = true;
            }
            
        }

        if (Input.GetMouseButton(0))
        {
            isAttacking = true;
            WeaponCollider.SetActive(true);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
            WeaponCollider.SetActive(false);
        }
    }

   
    private void PlayerMovement()
    {
        if (canMove)
        {
            if (isRolling)
            {
                _rb.velocity = _lastMovement * 1.5f;
            }
            else
            {
            
                _rb.velocity = new Vector3(_moveDirection.x * mSpeed, 0, _moveDirection.z * mSpeed);
                _lastMovement = _rb.velocity;
                
                if (_moveDirection != Vector3.zero)
                {
                    transform.forward = _moveDirection;
                }

            }
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }

        if (_rb.velocity != Vector3.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
    
        }

    }

    public void ResetMovement()
    {
        isRolling = false;
    }

    public void DamageEnemy()
    {
        if (currentMonster !=null)
        {
            currentMonster.monsterOnDamage(weaponDamage);
            currentMonster = null;
        }
        
        
    }



}
