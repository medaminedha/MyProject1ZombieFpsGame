using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public float ClipLength = 1f;
    
    public AudioSource fireSource;
    public AudioClip fireClip;


    public Camera PlayerCamera;
    public Transform shootPoint;
    public GameObject bullet;
    void Start()
    {
        InstantiateAudio(fireClip);
    }
    private void InstantiateAudio(AudioClip clip){
        fireSource = gameObject.AddComponent<AudioSource>();
        fireSource.clip = clip;
    }
    public void playSound(){
        if(fireSource.isPlaying)
            fireSource.Stop();
            fireSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
        
            Shoot();
            Debug.Log("Gotcha!");
        }
    }


    void Shoot()
    {
        Ray ray = PlayerCamera.ViewportPointToRay(new Vector3 (0.5f,0.5f,0f));
        RaycastHit hit;
        Vector3 target;
        if(Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }else
        {
            target= ray.GetPoint(75);
        }
        Vector3 shootDirection = target - shootPoint.position;
        GameObject realBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        realBullet.transform.forward = shootDirection.normalized;
        realBullet.GetComponent<Rigidbody>().AddForce(shootDirection.normalized*10,ForceMode.Impulse);
       
    }
    
}
