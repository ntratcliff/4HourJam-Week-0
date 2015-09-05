using UnityEngine;
using System.Collections;

public class MoveVelocity : MonoBehaviour
{
    public Vector2 Velocity;
    public float Rotation;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)Velocity;
        Vector3 euler = transform.rotation.eulerAngles;
        euler.z += Rotation;
        transform.rotation = Quaternion.Euler(euler) ;
    }
}
