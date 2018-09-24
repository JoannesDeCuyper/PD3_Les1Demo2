using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//[RequireComponent(typeof(CharacterController))]

public class CharacterControllerBehaviour : MonoBehaviour
{
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        //Zo kan je het ook doen
        //_characterController = (CharacterController)GetComponent(typeof(CharacterController));
        //_characterController = GetComponent("CharacterController") as CharacterController;
        
        if(_characterController == null)
        {
            Debug.LogError("CharactercontrollerBehaviour needs a characterControllerComponent");
        }

        Assert.IsNotNull(_characterController, "ERROR : charactercontrollerBehaviour needs a charactercontroller component");
	}
	
	void Update ()
    {
		
	}
}
