using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        public string CodeName { get; }
        private string state;
        public string State {
            get { return this.state; }
            private set
            {
                if(value!="inProgress" && value!="Finished")
                {
                    throw new ArgumentException();
                }
                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public Mission(string codeName,string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
