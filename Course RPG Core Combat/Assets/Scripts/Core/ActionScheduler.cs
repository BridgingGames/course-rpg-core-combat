using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        private IAction currentAction;

        // Receive an IAction and check If It's already being used;
        // If It's a new IAction, call Cancel() on the current one and set It as the new one.
        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null) currentAction.Cancel();
            currentAction = action;
        }

        // Calls StartAction() with a null value, canceling any current action.
        public void CancelCurrentAction()
        {
            StartAction(null);
        }
    }
}