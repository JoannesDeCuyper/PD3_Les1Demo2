using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//[RequireComponent(typeof(CharacterController))]

public class CharacterControllerBehaviour : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _velocity = Vector3.zero; //[m/s]

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
	
	void Update ()
    {   
        if(!_characterController.isGrounded)
        {
            _velocity += Physics.gravity * Time.deltaTime;
        }
        
        Vector3 movement = _velocity * Time.deltaTime;

        _characterController.Move(movement);
	}
}
