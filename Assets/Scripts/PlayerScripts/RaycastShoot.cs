using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{

    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public Transform gunEnd;
    public bool fire = false;

    [SerializeField] float nextFire;

    [SerializeField] Camera playerCam;
    [SerializeField] WaitForSeconds shotDelay = new WaitForSeconds(0.07f);
    [SerializeField] LineRenderer laserLine;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(fire == true && Time.time > nextFire)
        {
            

            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);            //edited


            if (Physics.Raycast(rayOrigin, playerCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

                EnemyController enemy = hit.collider.GetComponent<EnemyController>();
                if(enemy != null)
                {
                    enemy.DestroyIfHit();
                }
            }

            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCam.transform.forward * weaponRange));
            }

            fire = false;

        }

    }

    public void Shoot()
    {
        fire = true;
    }


    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDelay;
        laserLine.enabled = false;
    }


}
