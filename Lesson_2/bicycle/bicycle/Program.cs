using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycle
{
    class Program
    {
        class Brakes 
        {
            public void SlowDown() { }
        }
        class Gab { }

        class Bicycle
        {
         /*   public void tube
            {
                get { return Tube;}
            }*/

            public void Ride(){}
            public void Stop(){}
            public void TurnRight(){}
            public void TurnLeft() { }
            class Tube { }
            class Handlebar { }
            class Pedals { }
            class Wheels { }
            class Saddle { }
            class Switches 
            {
                public void SwitchingSpeedInc() { }
                public void SwitchingSpeddDec() { }
            }
            class Circuit { }
            class DiscBrakes : Brakes 
            {
                public void FastSlowDown() { }
            }
            class V_Brakes : Brakes { }
            class SpringGab : Gab { }
            class LiquidGab : Gab { }
        }
        static void Main(string[] args)
        {
        }
    }
}
