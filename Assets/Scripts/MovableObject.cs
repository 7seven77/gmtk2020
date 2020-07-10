using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    // The direction the object is travelling
    protected float direction;

    // Speed at which the object moves
    [SerializeField]
    protected float movementSpeed = 1;

    [SerializeField]
    protected float rotationalSpeed = 1;

    protected virtual void Start()
    {
        CalibrateDirection();
    }

    /// <summary>
    /// Moves the object in the direction it is facing
    /// </summary>
    protected void MoveForwards()
    {
        transform.position += MoveInDirection(direction, movementSpeed);
    }

    /// <summary>
    /// Gets the transformation vector for an angle and magnitude
    /// </summary>
    /// <param name="direction">Angle to move in</param>
    /// <param name="magnitude">Length of return Vector</param>
    /// <returns></returns>
    protected static Vector3 MoveInDirection(float direction, float magnitude)
    {
        return AngleToVector(direction) * magnitude;
    }

    /// <summary>
    /// Converts an angle into a vector
    /// </summary>
    /// <param name="direction">Angle to convert</param>
    /// <returns></returns>
    protected static Vector3 AngleToVector(float direction)
    {
        float angle = direction * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
    }

    /// <summary>
    /// Change the direction variable to match the rotation quaternion
    /// (Fix the variable)
    /// </summary>
    protected void CalibrateDirection()
    {
        direction = transform.rotation.eulerAngles.z;
    }

    /// <summary>
    /// Change the rotation quaternion to match the direction variable
    /// (Fix the sprite)
    /// </summary>
    protected void CalibrateRotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction));
    }
}
