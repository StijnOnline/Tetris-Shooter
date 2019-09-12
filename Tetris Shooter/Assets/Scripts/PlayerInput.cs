using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput
{
    public float[] GetInput()
    {
        float[] input = new float[8];
        //buttons set in Project settings

        input[0] = (int)Input.GetAxisRaw("Player1Hor");
        input[1] = (int)Input.GetAxisRaw("Player1Ver");
        input[2] = (int)Input.GetAxis("Player1Rot");
        input[3] = Input.GetButtonDown("Player1Sav") ? 1 : 0;


        //GameManager.Instance.players[0].GetBlock()?.Move(_inputHor, _inputVer);
        //GameManager.Instance.players[0].GetBlock()?.Rotate(_inputRot);
        //if (_inputSav) { GameManager.Instance.players[0].SaveBlock(); }

        input[4] = Input.GetAxis("Player2Hor");
        input[5] = Input.GetAxis("Player2Ver");
        input[6] = Input.GetAxis("Player2Rot");
        input[7] = Input.GetButtonDown("Player2Sav") ? 1 : 0;
        //GameManager.Instance.players[1].GetBlock()?.Move(_inputHor, _inputVer);
        //GameManager.Instance.players[1].GetBlock()?.Rotate(_inputRot);
        //if (_inputSav) { GameManager.Instance.players[1].SaveBlock(); }

        return input;
    }
}
