using Academy.HoloToolkit.Unity;
using UnityEngine;

/// <summary>
/// GestureAction performs custom actions based on 
/// which gesture is being performed.
/// </summary>
public class GestureAction : MonoBehaviour
{
    [Tooltip("Rotation max speed controls amount of rotation.")]
    public float RotationSensitivity = 10.0f;
    public float MoveSensitivity = 1.5f;

    private Vector3 manipulationPreviousPosition;

    private float rotationFactorX;
    private float rotationFactorY;
    private float rotationFactorZ;

    private bool wasKinematic;

    void Update()
    {
        PerformRotation();
    }

    private void PerformRotation()
    {
        if (GestureManager.Instance.IsNavigating)
        {
            /* TODO: DEVELOPER CODING EXERCISE 2.c */

            // 2.c: Calculate rotationFactor based on GestureManager's NavigationPosition.X and multiply by RotationSensitivity.
            // This will help control the amount of rotation.
            rotationFactorX = GestureManager.Instance.NavigationPosition.x * RotationSensitivity;
            rotationFactorY = GestureManager.Instance.NavigationPosition.y * RotationSensitivity;
            rotationFactorZ = GestureManager.Instance.NavigationPosition.z * RotationSensitivity;

            // 2.c: transform.Rotate along the Y axis using rotationFactor.
            InteractibleManager.Instance.FocusedGameObject.transform.root.transform.Rotate(new Vector3(-1 * rotationFactorY, -1 * rotationFactorX, -1*rotationFactorZ));
        }
    }

    void PerformManipulationStart(Vector3 position)
    {
        manipulationPreviousPosition = position;
    }

    void PerformManipulationUpdate(Vector3 position)
    {
       
        if (GestureManager.Instance.IsManipulating)
        {
            /* TODO: DEVELOPER CODING EXERCISE 4.a */

            Vector3 moveVector = Vector3.zero;

            // 4.a: Calculate the moveVector as position - manipulationPreviousPosition.
            moveVector = position - manipulationPreviousPosition;

            // 4.a: Update the manipulationPreviousPosition with the current position.
            manipulationPreviousPosition = position;
            Rigidbody body = transform.root.GetComponent<Rigidbody>();
            
               // 4.a: Increment this transform's position by the moveVector.
                transform.position += moveVector * MoveSensitivity;
            
                

        }
    }
}