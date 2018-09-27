using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//[RequireComponent(typeof(CharacterController))]

public class CharacterControllerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _absoluteTransform;

    [SerializeField]
    private float _acceleration = 3; //[m/s^2]

    [SerializeField]
    private float _dragOnGround = 1.0f; //getal tussen 0 en 1

    private CharacterController _characterController;
    private Vector3 _velocity = Vector3.zero; //[m/s]
    private Vector3 _inputMovement;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        //Zo kan je het ook doen
        //_characterController = (CharacterController)GetComponent(typeof(CharacterController));
        //_characterController = GetComponent("CharacterController") as CharacterController;
        
        /*if(_characterController == null)
        {
            Debug.LogError("CharactercontrollerBehaviour needs a characterControllerComponent");
        }

        Assert.IsNotNull(_characterController, "ERROR : charactercontrollerBehaviour needs a charactercontroller component");*/
	}

    //fixedUpdate --> physics

    private void Update()
    {
        _inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate ()
    {
        ApplyGround();

        ApplyGravity();

        ApplyMovement();

        ApplyDragOnGround();

        DoMovement();
	}

    private void ApplyGround()
    {
        //past effect van de grond toe
        if (_characterController.isGrounded)
        {
            _velocity -= Vector3.Project(_velocity, Physics.gravity);
        }
    }
    private void ApplyGravity()
    {
        //past effect van de gravity
        if (!_characterController.isGrounded)
        {
            _velocity += Physics.gravity * Time.fixedDeltaTime;
        }
    }

    private void ApplyMovement()
    {
        if(_characterController.isGrounded)
        {
            //or
            //xzForward = new Vector3(_absoluteTransform.forward.x, 0, _absoluteTransform.forward.z);

            //or
            //Vector3 xzForward = _absoluteTransform.forward;
            //xzForward.y = 0;

            Vector3 xzForward = Vector3.Scale(_absoluteTransform.forward, new Vector3(1, 0, 1));

            Quaternion relativeRotation = Quaternion.LookRotation(xzForward);

            Vector3 relativeMovement = relativeRotation * _inputMovement;

            _velocity += relativeMovement * _acceleration * Time.fixedDeltaTime;

        }
    }

    private void ApplyDragOnGround()
    {
        //or make use of Lerp
        if(_characterController.isGrounded)
        {
            _velocity *= (1 - Time.fixedDeltaTime * _dragOnGround);
        }
    }

    private void DoMovement()
    {
        //beweging
        Vector3 displacement = _velocity * Time.fixedDeltaTime;

        _characterController.Move(displacement);
    }
}
