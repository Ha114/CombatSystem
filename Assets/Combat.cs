using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    private Text health;
    private int hp = 100;
    private GameObject enemy;
    public Action _Damage;


    void Start()
    {
        //Health
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        enemy = GameObject.FindGameObjectWithTag("enemy");
        AI._Damage += TakeDamage;
    }

    //take Damage
    private void OnTriggerEnter(Collider other)
    {
        //reaction to a collision with an enemy
        Damage(2);
    }
    void TakeDamage() {
        var dist = Vector3.Distance(transform.position, enemy.transform.position);
        if (dist<=2) {
            Debug.Log("DAMAGE");
            Damage(40); }
    }
    void Damage(int d) {
        hp = hp - d;
        if (hp <= 0) { health.text = "GAME OVER, hp = " + hp; }
        else
        {
            health.text = "Health: " + hp;
        }

    }

    //deal damage
    void DealDamage()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("Press F");
            CanInteract();
        }
    }

    void CanInteract()
    {
        var dist = Vector3.Distance(transform.position, enemy.transform.position);
        if (dist <= 4f)
        {
            enemy.SetActive(false);
            Debug.Log("The enemy is destroyed");
        }
        else
        {
            Debug.Log("Nope");
        }
    }

    private void Update()
    {
        DealDamage();
    //    TakeDamage();
    }
    private void OnDisable()
    {
        AI._Damage -= TakeDamage;
    }

}
