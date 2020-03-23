using System;
using System.Collections.Generic;
using System.Text;

namespace SWD_Lab_GoF_state_Ex_1
{
    public class FlashLight
    {
        public enum FlashLightEvent {PowerBtnPressed};
        enum FlashLightState { On, Off}

        private FlashLightState _currentState;

        public FlashLight()
        {
            _currentState = FlashLightState.Off;
        }

        public void HandleEvent(FlashLightEvent evt)
        {
            switch (_currentState)
            {
                case FlashLightState.On:
                    _currentState = FlashLightState.Off;
                    Console.WriteLine($"Changed currentState to: {_currentState}");
                    break;

                case FlashLightState.Off:
                    _currentState = FlashLightState.On;
                    Console.WriteLine($"Changed currentState to: {_currentState}");
                    break;

                default:
                    break;
            }
        }
    }
}
