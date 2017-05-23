using UnityEngine;
using System.Collections;

public class Claw : MonoBehaviour {
    public Transform origin;
    public float speed = 4f;
    public Gun gun;
    public ScoreManager scoreManager;
    private Vector3 target;
    private int jewelValue = 100;
    private GameObject childObject;
    private LineRenderer lineRenderer;
    private bool hitJewel;
    private bool retracting;


    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, transform.position);
        if (transform.position == origin.position && retracting)
        {
            gun.CollectedObject();
            if (hitJewel)
            {
                scoreManager.AddPoints(jewelValue);
                hitJewel = false;
            }
            Destroy(childObject);
            gameObject.SetActive(false);
        }
    }

    public void ClawTarget(Vector3 pos)
    {
        target = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        retracting = true;
        target = origin.position;

        if (other.gameObject.CompareTag("Jewel"))
        {
            hitJewel = true;
            childObject = other.gameObject;
            other.transform.SetParent(this.transform);
        }

        else if (other.gameObject.CompareTag("Rock"))
        {
            childObject = other.gameObject;
            other.transform.SetParent(this.transform);
        }
    }
}
