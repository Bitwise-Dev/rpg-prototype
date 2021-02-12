using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput
{
    public KeyCode Input;
    public UserInputStateType UserInputState;
    public float Time;
    public UserInput(KeyCode input, UserInputStateType userInputState)
    {
        Input = input;
        UserInputState = userInputState;
        Time = 0f;
    }
}
