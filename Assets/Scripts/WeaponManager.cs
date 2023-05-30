//by Dhaoui Mohamed amine E2 A
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 100f;
    public float damage =25f;
    public Animator playerAnimator;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    [SerializeField]
    private float bulletSpeed = 600;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }
        if(Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Shoot");
            Shoot();
        }
    }

    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);
        RaycastHit hit;
        
        GameObject bullet =Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed );
        Destroy(bullet, 1);

        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            //Debug.Log("hit");
            EnemyManager enemymanager = hit.transform.GetComponent<EnemyManager>();
            if(enemymanager != null)
            {
                enemymanager.Hit(damage);
            }
        }

    }
    
}
