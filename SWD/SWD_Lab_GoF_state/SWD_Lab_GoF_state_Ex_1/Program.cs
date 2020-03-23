using System;

namespace SWD_Lab_GoF_state_Ex_1
{
    class Program
    {
        private void onEnterPressedEvent(object sender, FlashLight.FlashLightEvent e)
        {
            
        }
        static void Main(string[] args)
        {
            FlashLight flashLight;
            flashLight.FlashLightEvent e;
            
            Console.WriteLine("Press the enter key to switch state");
            while (true)
            {
                if (Console.ReadKey() == "E")
                {
                    flashLight.HandleEvent(e);
                }
            }
        }
    }
}
