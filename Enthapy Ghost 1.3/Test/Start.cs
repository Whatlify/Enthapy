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

namespace Enthapy
{
    public partial class Start : Form
    {
        private const int ButtonStartY = 100;
        private const int ButtonEndY = 150;
        private const int AnimationDuration = 500;
        private int elapsed;
        private Point buttonStartPos;
        private Point buttonEndPos;
        private bool isDragging = false;
        private Point lastCursorPos;
        private Timer dragTimer;
        private Bitmap blurredImage;
        private Bitmap backBuffer;
        private Graphics backGraphics;

        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);
        public Start()
        {
            this.SuspendLayout();
            InitializeComponent();
            this.ResumeLayout();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            // Set up the button
            btnLoad.Location = new Point(btnLoad.Location.X, ButtonStartY);
            buttonStartPos = new Point(btnLoad.Location.X, ButtonStartY);
            buttonEndPos = new Point(btnLoad.Location.X, ButtonEndY);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Environment.Exit(0);
        }

        private async void LoadAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Size.Height <= 450) // adjust this value to your desired maximum height
            {
                this.Height += (int)3.65;
            }
            if (this.Opacity < 1)
            {
                this.Visible = true;
                this.Opacity += 0.04;
            }
            else if (this.Opacity == 1 & this.Height == 450)
            {
                LoadAnimation.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAnimation.Start();;
            btnAnimation.Start();
            this.Opacity = 0;
            this.Height = 175;
        }
        private End form2;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (form2 == null) // Check if the form has already been created
            {
                this.Hide();
                form2 = new End(); // Create new instance of Form2
                form2.ShowDialog();
                this.Dispose();
                this.Close();
            }
        }

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

        private bool mouseOver;

        private void TextAnimation_Tick(object sender, EventArgs e)
        {
            if (mouseOver)
            {
                // Fade in and change color
                if (label1.ForeColor.A < 255)
                {
                    label1.ForeColor = Color.FromArgb(label1.ForeColor.A + 5, Color.FromArgb(205, 255, 255, 230));
                }
            }
            else
            {
                // Fade out and change color back to original
                if (label1.ForeColor.A > 0)
                {
                    label1.ForeColor = Color.FromArgb(label1.ForeColor.A - 5, Color.White);
                }
            }

            // Stop the timer when the label is fully faded in or out
            if ((mouseOver && label1.ForeColor.A == 255) || (!mouseOver && label1.ForeColor.A == 0))
            {
                TextAnimation.Stop();
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            mouseOver = true;
            TextAnimation.Start();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            mouseOver = false;
            TextAnimation.Start();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            mouseOver = true;
            TextAnimation.Start();
        }

        private void btnAnimation_Tick(object sender, EventArgs e)
        {
            elapsed += btnAnimation.Interval;

            if (elapsed >= AnimationDuration)
            {
                // Stop the timer and set the button to its final position
                btnAnimation.Stop();
                btnLoad.Location = buttonEndPos;
            }
            else
            {
                // Calculate the position of the button based on the elapsed time and easing function
                float t = (float)elapsed / AnimationDuration;
                float easing = EasingFunction(t);
                int y = (int)(buttonStartPos.Y + (buttonEndPos.Y - buttonStartPos.Y) * easing);
                btnLoad.Location = new Point(buttonStartPos.X, y);
            }
        }

        private float EasingFunction(float t)
        {
            // This is an example of a cubic easing function
            return t * t * t;
        }
    }
}
