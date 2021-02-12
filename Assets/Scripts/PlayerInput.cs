using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInput
{
    private bool _debugMode;
    private List<UserInput> _currentInputs;
    private const float MAX_USER_INPUT_UP_TIME = 2f;

    public PlayerInput(bool debugMode)
    {
        _debugMode = debugMode;
        _currentInputs = new List<UserInput>();

        OutputDebugLog("Successfully Initialized");
    }

    public void AddCurrentInput(KeyCode userInput, UserInputStateType userInputState)
    {
        _currentInputs.Add(new UserInput(userInput, userInputState));

        OutputDebugLog("Adding " + userInput.ToString() + " " + userInputState.ToString() + " Current Inputs");
    }

    public void RemoveCurrentInput(KeyCode userInput)
    {
        UserInput userInputToRemoveFromList = GetUserInput(userInput);
        _currentInputs.Remove(userInputToRemoveFromList);

        OutputDebugLog("Removing " + userInput.ToString() + " from Current Inputs");
    }

    private void RemoveCurrentInputs(List<UserInput> userInputs)
    {
        _currentInputs = _currentInputs.Except(userInputs).ToList();

        OutputDebugLog("Removing " + userInputs.Count + " input(s) from CurrentInputs");
    }

    public List<UserInput> GetCurrentInputs()
    {
        OutputDebugLog("Returning Current Inputs: " + _currentInputs);
        
        return _currentInputs;
    }

    public void UpdateInputState(KeyCode userInput, UserInputStateType updatedUserInputState)
    {
        foreach (UserInput currentUserInput in _currentInputs)
        {
            if (currentUserInput.Input == userInput)
            {
                currentUserInput.UserInputState = updatedUserInputState;
            }
        }

        OutputDebugLog("Updating " + userInput.ToString() + " state to " + updatedUserInputState.ToString());
    }

    public void UpdateTime()
    {
        List<UserInput> userInputsToRemove = new List<UserInput>();

        foreach (UserInput currentInput in _currentInputs)
        {
            currentInput.Time += Time.deltaTime;

            if (currentInput.UserInputState == UserInputStateType.UP && currentInput.Time >= MAX_USER_INPUT_UP_TIME)
            {
                userInputsToRemove.Add(currentInput);
            }
        }

        if (userInputsToRemove.Count > 0)
        {
            RemoveCurrentInputs(userInputsToRemove);
        }
    }

    public bool TryGetUserInput (KeyCode keyCode, out UserInput userInput)
    {
        userInput = GetUserInput(keyCode);

        if (userInput != null)
        {
            return true;
        }

        return false;
    }

    private UserInput GetUserInput (KeyCode userInput)
    {
        return _currentInputs.SingleOrDefault(i => i.Input == userInput);
    }

    private void OutputDebugLog(string message)
    {
        if (_debugMode)
        {
            Debug.Log("[PlayerInputManager] " + message);
        }
    }
}
