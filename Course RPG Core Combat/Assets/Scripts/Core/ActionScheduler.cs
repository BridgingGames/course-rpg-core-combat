using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        // Variables.
        private IAction _currentAction;

        /* Method that receives and tracks the current IAction;
         * If the IAction is already stored, returns;
         * If the current IAction is not null, call It's Cancel() method;
         * Replace the current IAction with the received IAction.
         * */
        public void StartAction(IAction action)
        {
            if (_currentAction == action) return;
            if (_currentAction != null) _currentAction.Cancel();
            _currentAction = action;
        }
    }
}