using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
    //This camera input class is an example of how to get input from a connected mouse using Unity's default input system;
    //It also includes an optional mouse sensitivity setting;
    public class CameraMouseInput : CameraInput
    {
        //Mouse input axes;
        public string mouseHorizontalAxis = "Mouse X";
        public string mouseVerticalAxis = "Mouse Y";
        public string horizontalAxisInput = "Horizontal";
        public string verticalAxisInput = "Vertical";

        //Invert input options;
		public bool invertHorizontalInput = false;
		public bool invertVerticalInput = false;
        public bool useRawInput = true;

        //Use this value to fine-tune mouse movement;
        //All mouse input will be multiplied by this value;
        public float mouseInputMultiplier = 0.01f;

	    public override float GetHorizontalCameraInput()
        {
            //Get raw mouse input;
            float _input = Input.GetAxisRaw(mouseHorizontalAxis);
            
            //Since raw mouse input is already time-based, we need to correct for this before passing the input to the camera controller;
            if(Time.timeScale > 0f && Time.deltaTime > 0f)
            {
                _input /= Time.deltaTime;
                _input *= Time.timeScale;
            }
            else
                _input = 0f;

            //Apply mouse sensitivity;
            _input *= mouseInputMultiplier;

            //Invert input;
            if(invertHorizontalInput)
                _input *= -1f;

            return _input;
        }

        public override float GetVerticalCameraInput()
        {
           //Get raw mouse input;
            float _input = -Input.GetAxisRaw(mouseVerticalAxis);
            
            //Since raw mouse input is already time-based, we need to correct for this before passing the input to the camera controller;
            if(Time.timeScale > 0f && Time.deltaTime > 0f)
            {
                _input /= Time.deltaTime;
                _input *= Time.timeScale;
            }
            else
                _input = 0f;

            //Apply mouse sensitivity;
            _input *= mouseInputMultiplier;

            //Invert input;
            if(invertVerticalInput)
                _input *= -1f;

            return _input;
        }

        public override float GetHorizontalAxisInput()
        {
            if (useRawInput)
                return Input.GetAxisRaw(horizontalAxisInput);
            else
                return Input.GetAxis(horizontalAxisInput);
        }
        public override float GetVerticalAxisInput()
        {
            if (useRawInput)
                return Input.GetAxisRaw(verticalAxisInput);
            else
                return Input.GetAxis(verticalAxisInput);
        }
        
    }
}
