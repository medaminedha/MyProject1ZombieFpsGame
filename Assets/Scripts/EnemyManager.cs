//by Dhaoui Mohamed amine E2 A
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;

    public void Hit(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            gameManager.enemiesAlive--;
            //destroying thee enemie
            Destroy(gameObject);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().destination = player.transform.position;
        if(GetComponent<UnityEngine.AI.NavMeshAgent>().velocity.magnitude >1)
        {
            enemyAnimator.SetBool("IsRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("IsRunning", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
            //Debug.Log("player hit!");
        }
    }
    
}
