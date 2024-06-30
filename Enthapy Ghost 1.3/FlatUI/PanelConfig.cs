using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ns0
{
	public sealed class PanelConfig
	{
        public static async void PanelAnimation(FlatPanel gclass3_0)
        {
            double startX = gclass3_0.Location.X - 20;
            double endX = gclass3_0.Location.X;
            gclass3_0.Location = new Point((int)startX, gclass3_0.Location.Y);
            gclass3_0.BringToFront();
            int iterations = 15;
            double xIncrement = (endX - startX) / iterations;
            double amplitude = 20.0;
            double period = -1.0;
            int frameRate = 1000;
            int frameDelay = (int)Math.Round(1000.0 / frameRate);

            for (int i = 0; i < iterations; i++)
            {
                double progress = (double)i / iterations;
                double newX = startX + xIncrement * i;
                newX += (Math.Sin(progress * Math.PI * period) * amplitude * (1.15 - progress));
                gclass3_0.Location = new Point((int)newX, gclass3_0.Location.Y);
                await Task.Delay(frameDelay);
            }
            gclass3_0.Location = new Point((int)endX, gclass3_0.Location.Y);
        }

    }
}
