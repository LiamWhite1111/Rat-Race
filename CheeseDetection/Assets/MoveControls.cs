using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class sampleCharacter : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float steerSpeed = 10f;



    void Update()
    {
        float move = 0f; 
        float steer = 0f;
       

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        transform.Rotate(0, 0, steer * steerSpeed * Time.deltaTime);
        transform.Translate(0, move * moveSpeed * Time.deltaTime, 0);


    }
}
