using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        // Global Variables.
        private IAction _currentAction;

        // This method controls which action is taking place at the moment;
        // Receveives an IAction (interface) and check if It's already playing;
        // If it's a new IAction, call the current's Cancel() method and save the new one.
        public void StartAction(IAction a)
        {
            if (_currentAction == a) return;
            if (_currentAction != null) _currentAction.Cancel();
            _currentAction = a;
        }

        // This method calls the StartAction() method with a null value, canceling any current action;
        public void CancelCurrentAction()
        {
            StartAction(null);
        }
    }
}