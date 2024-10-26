using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlXSpeed = 40f;
    [SerializeField] float controlYSpeed = 50f;
    [SerializeField] float xClampRange = 17f;
    [SerializeField] float yClampRange = 9f;

    [SerializeField] float controlRollFactor = 25f;
    [SerializeField] float controlPitchFactor = 30f;
    [SerializeField] float rotationSpeed = 5f;
    Vector2 movement;
    void Start()
    {
        
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    void ProcessTranslation()
    {
        float xOffset = movement.x * controlXSpeed * Time.deltaTime;
        float rawXPosition = transform.localPosition.x + xOffset;
        float clampXPosition = Mathf.Clamp(value: rawXPosition, -xClampRange, xClampRange);

        float yOffset = movement.y * controlXSpeed * Time.deltaTime;
        float rawYPosition = transform.localPosition.y + yOffset;
        float clampYPosition = Mathf.Clamp(value: rawYPosition, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampXPosition, clampYPosition, transform.localPosition.z);
    }
    void ProcessRotation()
    {
        float roll = -movement.x * controlRollFactor;
        float pitch = -movement.y * controlPitchFactor;
        Quaternion targetRotation = Quaternion.Euler( pitch,transform.localRotation.y ,roll); 
        transform.localRotation = Quaternion.Lerp(transform.localRotation,targetRotation,rotationSpeed * Time.deltaTime);      
    }
}
