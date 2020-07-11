using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 0;

    public float direction;

    [SerializeField]
    public int duration = 0;
    public void Initialise(float angle)
    {
        direction = angle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction));
    }

    // Update is called once per frame
    void Update()
    {
        float angle = direction * Mathf.Deg2Rad;
        Vector3 deltaPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * bulletSpeed;
        transform.position += deltaPosition;
        duration--;
        if (duration < 1)
        {
            Destroy(gameObject);
        }
    }
}
