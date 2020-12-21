using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    private Text health;
    private int hp = 100;
    private GameObject enemy;


    void Start()
    {
        //Health
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
    }

    //take Damage
    private void OnTriggerEnter(Collider other)
    {
        hp = hp - 40;
        if (hp <= 0) { health.text = "GAME OVER, hp = " + hp; }
        else
        {
            health.text = "Health: " + hp;
           // other.gameObject.SetActive(false);
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
        enemy = GameObject.FindGameObjectWithTag("enemy");
        var dist = Vector3.Distance(transform.position, enemy.transform.position);
        if (dist <= 3f)
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
    }

}
