using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public GameObject claw;
    public bool isShooting;
    public Animator minerAnimator;
    public Claw clawScript;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            LaunchClaw();
        }

    }

    void LaunchClaw()
    {
        isShooting = true;
        minerAnimator.speed = 0;
        RaycastHit hit;
        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, down, out hit, 100))
        {
            claw.SetActive(true);
            clawScript.ClawTarget(hit.point);
        }
    }

    public void CollectedObject()
    {
        isShooting = false;
        minerAnimator.speed = 1;
    }
}
