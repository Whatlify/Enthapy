using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Enthapy
{
    public partial class End : Form
    {
        private int progressValue = 0;
        private bool loading = false;
        private bool isDragging = false;
        private Point lastCursorPos;
        private Timer dragTimer;
        private Bitmap blurredImage;

        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

        public End()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Environment.Exit(0);
        }

        private Form1 form1;

        private async void Form2_Load(object sender, EventArgs e)
        {
            lbLoading.ForeColor = Color.Transparent;
            // Set the loading flag to true
            loading = true;

            // Panel Animation
            TextAnimation.Start();

            // Gradually increase the value of the trackbar to make it look like a progress bar
            while (progressValue < 100)
            {
                progressValue++;
                sldProgress.Int32_0 = progressValue;

                // Pause for a short time to give the appearance of a smooth animation
                if (progressValue >= 75)
                {
                    lbLoading.Text = "Finalizing...";
                    await Task.Delay(40);
                    if (progressValue == 100)
                    {
                        if (form1 == null) // Check if the form has already been created
                        {
                            this.Hide();
                            form1 = new Form1(); // Create new instance of Form2
                            form1.ShowDialog();
                            this.Dispose();
                            this.Close();
                        }
                    }
                }
                else
                {
                    await Task.Delay(10);
                }
            }

            // Gradually fade in the text
            for (double i = 0.0; i <= 1.0; i += 0.05)
            {
                lbLoading.ForeColor = Color.FromArgb((int)(i * 255), Color.White);
                await Task.Delay(50);
            }

            // Gradually fade out the text
            for (double i = 1.0; i >= 0.0; i -= 0.05)
            {
                lbLoading.ForeColor = Color.FromArgb((int)(i * 255), Color.White);
                await Task.Delay(50);
            }

            // Reset the values of the trackbar and text
            progressValue = 100;
            lbLoading.ForeColor = Color.Transparent;

            // Set the loading flag to false
            loading = false;
        }

        private double opacity = 0.0;
        private bool fadeIn = true;

        private async void TextAnimation_Tick(object sender, EventArgs e)
        {
            if (lbLoading.Opacity < 1.0)
            {
                lbLoading.Opacity += 0.10f;
                lbLoading.Invalidate(); // force a redraw
            }
            else
            {
                TextAnimation.Enabled = false;
                TextAnimation2.Enabled = true;
            }
        }

        private void TextAnimation2_Tick(object sender, EventArgs e)
        {
            if (lbLoading.Opacity > 0.0)
            {
                lbLoading.Opacity -= 0.10f;
                lbLoading.Invalidate(); // force a redraw
            }
            else
            {
                TextAnimation2.Enabled = false;
                TextAnimation.Enabled = true;
            }
        }

        private void sldProgress_MouseDown(object sender, MouseEventArgs e)
        {
            sldProgress.Int32_0 = progressValue;
        }

        private void sldProgress_MouseUp(object sender, MouseEventArgs e)
        {
            sldProgress.Int32_0 = progressValue;
        }

        private void sldProgress_MouseMove(object sender, MouseEventArgs e)
        {
            sldProgress.Int32_0 = progressValue;
        }

        private void sldProgress_MouseEnter(object sender, EventArgs e)
        {
            sldProgress.Int32_0 = progressValue;
        }

        private void sldProgress_MouseLeave(object sender, EventArgs e)
        {
            sldProgress.Int32_0 = progressValue;
        }

        private void sldProgress_MouseHover(object sender, EventArgs e)
        {
            sldProgress.Int32_0 = progressValue;
        }

        private void DragTimer_Tick(object sender, EventArgs e)
        {
            Point deltaPos = new Point(Cursor.Position.X - lastCursorPos.X, Cursor.Position.Y - lastCursorPos.Y);
            Location = new Point(Location.X + deltaPos.X, Location.Y + deltaPos.Y);
            lastCursorPos = Cursor.Position;

            // Redraw the window to capture the blurred image
            IntPtr handle = this.Handle;
            Graphics g = Graphics.FromHwnd(handle);
            Rectangle rect = new Rectangle(Point.Empty, this.Size);
            blurredImage = new Bitmap(rect.Width, rect.Height, g);
            Graphics g2 = Graphics.FromImage(blurredImage);
            g2.CopyFromScreen(this.PointToScreen(Point.Empty), Point.Empty, this.Size);
            g2.FillRectangle(new SolidBrush(Color.FromArgb(64, Color.Black)), rect);
            RedrawWindow(handle, IntPtr.Zero, IntPtr.Zero, 0x85);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                dragTimer.Start();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                dragTimer.Stop();
                blurredImage?.Dispose();
                blurredImage = null;
                RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, 0x85);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84: // WM_NCHITTEST
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x01) // HTCLIENT
                        m.Result = (IntPtr)0x02; // HTCAPTION
                    return;
                case 0x85: // WM_NCPAINT
                    base.WndProc(ref m);
                    if (blurredImage != null)
                    {
                        using (Graphics g = Graphics.FromHwnd(m.HWnd))
                        {
                            Point pt = PointToScreen(Point.Empty);
                            g.DrawImage(blurredImage, 0, 0, Width, Height);
                        }
                    }
                    return;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private Bitmap backBuffer;
        private Graphics backGraphics;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (backBuffer == null || backBuffer.Size != ClientSize)
            {
                backBuffer = new Bitmap(ClientSize.Width, ClientSize.Height, e.Graphics);
                backGraphics = Graphics.FromImage(backBuffer);
            }

            backGraphics.Clear(BackColor);
            // draw your content here

            e.Graphics.DrawImage(backBuffer, Point.Empty);
        }
    }
}
