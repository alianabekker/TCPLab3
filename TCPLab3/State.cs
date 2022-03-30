using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLab3
{
    class StateMachine
    {
        public class Transition
        {
            public int state;
            public double startP;
            public double endP;
            public Transition(int _state, double _startP, double _endP)
            {
                state = _state;
                startP = _startP;
                endP = _endP;
            }
        }

        //состояние 
        public int State { get; set; }
        // список связей с другими состояниями
        private List<Transition> _transitions = new List<Transition>();
        public List<Transition>Transitions { get{ return _transitions; } }
        public StateMachine(int state, List<Transition> transitions)
        {
            State = state;
            _transitions = transitions; 
        }
    }
}
