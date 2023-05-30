//by Dhaoui Mohamed amine E2 A
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public Text healthText;

    public void Hit(float damage)
    {
        health -= damage;
        healthText.text= health.ToString() + "Health ";
        if(health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
