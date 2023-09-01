using System;
using System.Collections.Generic;
using System.Text;

namespace Ultra_Budget_Gamify
{
    public class BudgetAction
    {
        private string ActionName = "Non précisé";
        private float ActionGain = 0;
        private float ActionLoss = 0;
        private DateTime ActionDate ;
        private int Id;

        public BudgetAction(string actionName, float actionGain, float actionLoss) 
        {
            ActionName = actionName;
            ActionGain = actionGain;
            ActionLoss = actionLoss;
            Id = 0;

        }

        public struct ActionStruct
        {
            string name;
            float gain;
            float loss;

            public ActionStruct(string actionName, float actionGain, float actionLoss) 
            { 
                name = actionName;
                gain = actionGain;
                loss = actionLoss;
            }

        }

        #region public Get

        public ActionStruct GetActionStruct()
        {
            return new ActionStruct(ActionName, ActionGain, ActionLoss);
        }

        public string GetActionName => ActionName;

        public float GetActionGain => ActionGain;

        public float GetActionLoss => ActionLoss;

        public int GetId() { return Id; }

        #endregion

        #region public Set
            public void SetActionName(string actionName) { ActionName = actionName; }
            public void SetActionGain(float gain) {  ActionGain = gain; }
            public void SetActionLoss(float loss) {  ActionLoss = loss; }
            public void SetActionDate(DateTime time) {  ActionDate = time; }
            public void SetId(int id) { Id = id; }

        #endregion

    }
}
