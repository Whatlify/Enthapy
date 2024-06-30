using ns0;
using svchost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Velocity
{
    public partial class VelocityPanel : UserControl
    {
        [CompilerGenerated]
        private sealed class Class1
        {
            public uint uint_0;

            public int int_0;
        }

        public static List<long> list_0 = new List<long>();

        public static bool bool_0;

        public static bool bool_1 = false;

        xCryptoRandom rand = new xCryptoRandom();
        public VelocityPanel()
        {
            InitializeComponent();

            uint uint_0 = 0u;
            if (Class2.GetWindowThreadProcessId(Class2.FindWindow("LWJGL", null), out uint_0) == 0)
            {
                // Do something if Minecraft isn't open.
            }

            int int_0 = rand.Next(sldMinimumVelocity.Int32_0, sldMaximumVelocity.Int32_0);

            Task.Run(async () =>
            {
                await Velocity(uint_0);
            });
        }

        private void sldMinimumVelocity_Event_0(object sender, EventArgs e)
        {
            lbMinimumVelocity.Text = (sldMinimumVelocity.Int32_0 / 1F).ToString("Minimum Velocity: 0");
            if (sldMinimumVelocity.Int32_0 > sldMaximumVelocity.Int32_0)
            {
                sldMaximumVelocity.Int32_0 = sldMinimumVelocity.Int32_0;
            }
        }

        private void sldMaximumVelocity_Event_0(object sender, EventArgs e)
        {
            lbMaximumVelocity.Text = (sldMaximumVelocity.Int32_0 / 1F).ToString("Maximum Velocity: 0");
            if (sldMaximumVelocity.Int32_0 < sldMinimumVelocity.Int32_0)
            {
                sldMinimumVelocity.Int32_0 = sldMaximumVelocity.Int32_0;
            }
        }

        private void sldChance_Event_0(object sender, EventArgs e)
        {
            lbReachChance.Text = (sldChance.Int32_0 / 1F).ToString("Chance: 0");
        }

        int int_0;

        private async Task Velocity(uint uint_0)
        {
            MemoryVelocity gClass = new MemoryVelocity(uint_0);

            while (true)
            {
                int_0 = rand.Next(sldMinimumVelocity.Int32_0, sldMaximumVelocity.Int32_0);
                double double_ = 800000.0 / (double)this.int_0;

                if (!cbVelocity.Checked || bool_0)
                {
                    int_0 = rand.Next(sldMinimumVelocity.Int32_0, sldMaximumVelocity.Int32_0);
                    await Task.Delay(1000);
                    continue;
                }

                foreach (long item in list_0.ToList())
                {
                    double num = gClass.method_1<double>(item);

                    if (num <= 800000.0 && num >= 8000.0)
                    {
                        if (!bool_1)
                        {
                            gClass.method_3(item, double_);
                        }
                        else
                        {
                            gClass.method_3(item, 8000.0);
                        }
                    }
                    else
                    {
                        list_0.Remove(item);
                    }
                }

                await Task.Delay(5000);
            }
        }

        private void cbVelocity_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVelocity.Checked) 
            {
                bool_0 = true;
            }

            else
            {
                bool_0 = false;
            }
        }
    }
}
