using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plenom.Components.Busylight.Sdk;

using LightService = RRLightProgram.Program;
using System.Diagnostics;
using System.ComponentModel;

namespace RRLightProgram
{   
    public class Busylight
    {
        //Declare controller for Busylight
        BusylightController bLightController = new BusylightController();
        PulseSequence bLightPulse = new PulseSequence();
        
        /// <summary>
        ///     Change the color of the light
        /// </summary>
        /// <param name="inputColor"></param>
        public void ChangeColor(BusylightColor inputColor)
        {
            ChangeColor(inputColor, steady: true);
        }

        /// <summary>
        ///     Change the color of the light, including options to flash
        /// </summary>
        /// <param name="inputColor"></param>
        /// <param name="steady"></param>
        public void ChangeColor(BusylightColor inputColor, bool steady)
        {
            //Clear current light state
            bLightController.Light(BusylightColor.Off);

            //if steady is true, then static light
            if (steady == true)
            {
                bLightController.Light(inputColor);
            }
            //if steady is false, and color is red then pulse (amber)
            else if (steady == false & inputColor == BusylightColor.Red)
            {
                bLightPulse.Color = new BusylightColor() { RedRgbValue = 100, GreenRgbValue = 30, BlueRgbValue = 0 };
                bLightPulse.Step1 = 10;
                bLightPulse.Step2 = 14;
                bLightPulse.Step3 = 18;
                bLightPulse.Step4 = 22;
                bLightPulse.Step5 = 26;
                bLightPulse.Step6 = 22;
                bLightPulse.Step7 = 18;
                bLightPulse.Step8 = 14;
                bLightController.Pulse(bLightPulse);
            }
            //if steady is false, and color is blue then flash dimly
            else if (steady == false & inputColor == BusylightColor.Blue)
            {
                bLightPulse.Color = inputColor;
                bLightPulse.Step1 = 0;
                bLightPulse.Step2 = 0;
                bLightPulse.Step3 = 0;
                bLightPulse.Step4 = 0;
                bLightPulse.Step5 = 0;
                bLightPulse.Step6 = 0;
                bLightPulse.Step7 = 0;
                bLightPulse.Step8 = 5;
                bLightController.Pulse(bLightPulse);
            }
        }
    }
}
