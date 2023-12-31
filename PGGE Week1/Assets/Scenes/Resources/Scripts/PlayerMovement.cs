using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerMovement playerMovement;

    [HideInInspector]
    public CharacterController mCharacterController;
    public Animator mAnimator;
    public float mWalkSpeed = 1.0f;
    public float mRotationSpeed = 50.0f;

    void Start()
    {
        mCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        float speed = mWalkSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = mWalkSpeed * 2.0f;
        }
        if (mAnimator == null) return;
        transform.Rotate(0.0f, hInput * mRotationSpeed * Time.deltaTime,
        0.0f);
        Vector3 forward =
        transform.TransformDirection(Vector3.forward).normalized;
        forward.y = 0.0f;
        mCharacterController.Move(forward * vInput * speed *
        Time.deltaTime);
        mAnimator.SetFloat("PosX", 0);
        mAnimator.SetFloat("PosZ", vInput * speed / 2.0f * mWalkSpeed);
    }

    private void 
}