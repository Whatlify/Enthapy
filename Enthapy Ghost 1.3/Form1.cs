using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using Clicker.Calls.Classes;
using System.Threading;
using System.Windows.Input;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Activities.Expressions;
using System.Runtime.ConstrainedExecution;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using InputHelperSpace;
using System.Activities;
using RandN;
using RandN.Rngs;
using RandN.Distributions;
using helpers;
using static helpers.WinStructs;
using Guna.UI2.AnimatorNS;
using System.Timers;
using System.Media;
using System.Reflection;
using System.Numerics;
using NAudio.Wave;
using System.Activities.Statements;
using Guna.UI2.WinForms;
using TheArtOfDevHtmlRenderer.Adapters.Entities;
using System.Collections.Generic;
using System.Linq;
using Memory;
using System.ServiceProcess;
using AnyDesk;
using System.Security.Cryptography;
using System.Text;
using static Guna.UI2.Native.WinApi;
using ns0;
using System.Runtime.CompilerServices;
using svchost;

namespace Enthapy
{
    public partial class Form1 : Form
    {
        private Keys LeftClickerBind = 0;
        private Keys ThrowpotBind = 0;
        static int[] randomNumbers = new int[4000];
        // rEACH
        public static uint uint_0;
        private static Form1 mainForm_0;
        // Chroma
        private float hue = 0;
        private DateTime lastClickTime = DateTime.MinValue;
        public string selectedFileName;
        Random random2 = new Random();
        svchost.xCryptoRandom rand = new svchost.xCryptoRandom();
        StandardRng rng = StandardRng.Create();


        POINT current_pos, prev_pos;
        List<POINT> coords = new List<POINT>();
        #region Api

        const int HT_CAPTION = 0x2;
        const int WM_NCLBUTTONDOWN = 0xA1;
        const uint WDA_EXCLUDEFROMCAPTURE = 0x00000011;
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)] private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "PostMessageA")] private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")] public static extern short GetAsyncKeyState(Keys key);

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule,
            [MarshalAs(UnmanagedType.LPStr)] string procName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr OpenProcess(int access, bool inheritHandle, int processId);

        [DllImport("psapi.dll", CharSet = CharSet.Auto)]
        static extern int GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule,
            System.Text.StringBuilder fileName, int size);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetProcessId(IntPtr process);

        [DllImport("ntdll.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int NtSetInformationProcess(IntPtr processHandle,
        int processInformationClass, ref int processInformation, int processInformationLength);
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")] public static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);

        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")] public static extern uint MM_BeginPeriod(uint uMilliseconds);

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        #endregion
        IntPtr hwnd;
        Point previouspx = new Point(1, 11);

        public struct POINT
        {
            public int X;
            public int Y;
        }

        public static Form1 MainF2
        {
            [CompilerGenerated]
            get
            {
                return mainForm_0;
            }
            [CompilerGenerated]
            set
            {
                mainForm_0 = value;
            }
        }

        private BufferedGraphicsContext graphicsContext;
        private BufferedGraphics backBuffer;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // enable double buffering
            graphicsContext = BufferedGraphicsManager.Current;
            graphicsContext.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            backBuffer = graphicsContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.DoubleBuffered = true;
            MainF2 = this;
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[15];
                cryptoProvider.GetBytes(bytes);
                string secureRandomString = Convert.ToBase64String(bytes);
                this.Text = secureRandomString;
            }
            HashSet<int> uniqueNumbers = new HashSet<int>();
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                double x = (double)i / randomNumbers.Length;
                double mapped = Math.Sin(x * Math.PI) * 500 + 500;
                double powered = Math.Pow(mapped, 1.5);
                randomNumbers[i] = (int)powered;
            }
            // Fix Slider Values
            sldKurtosis.Int32_0 = 150;
            sldKurtosis.Int32_1 = 100;
        }

        public IEnumerable<Control> AllControls()
        {
            return GetAllControls(this);
        }

        private IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
        }


        #region Algorithim
        private int RandomisedLeftCPS = 10;
        private async void Uniqueness()
        {
            for (; ; )
            {

                // Set minimum and maximum values for left clicks per second variation
                int minDelta = 2;
                int maxDelta = 6;

                // Set minimum and maximum values for left clicks per second
                int min = sldLCps.Int32_0 - rand.Next(minDelta, maxDelta + 1);
                int max = sldLCps.Int32_0 + rand.Next(minDelta, maxDelta + 1);

                // Generate a random seed using a hash function
                byte[] seed = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(seed);
                }
                int randomSeed = BitConverter.ToInt32(seed, 0);

                // Create a new instance of Random with the generated seed
                Random random = new Random(randomSeed);

                // Generate a random value
                RandomisedLeftCPS = random.Next(min, max + 1);

                if (cbExtraRand.Checked)
                {
                    Uniform.Int32 distribution = Uniform.NewInclusive(0, 5);
                    min = sldLCps.Int32_0 - distribution.Sample(rng);
                    Uniform.Int32 distribution2 = Uniform.NewInclusive(0, 5);
                    max = sldLCps.Int32_0 + distribution.Sample(rng);
                    Uniform.Int32 RandomisedLeftCPS = Uniform.NewInclusive(min, max);
                    Bernoulli exhaustchancer = Bernoulli.FromRatio((uint)sldExhaustChance.Int32_0, 100);
                    bool exhaustchance = exhaustchancer.Sample(rng);
                    if (exhaustchance)
                    {
                        max = (int)(max + sldExhaustDelay.Int32_0 / 10F);
                    }
                }
                await Task.Delay(750);
            }
        }
        #endregion

        #region LClicker
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;

        private Random rando = new Random();
        private double sigma = 0.03;
        private async void LeftClicker_Tick(object sender, EventArgs e)
        {
            using (var rng = new xCryptoRandom())
            {
                // Create a byte array to store the random seed value
                var bytes = new byte[4];

                // Fill the byte array with random bytes
                rng.NextBytes(bytes);

                // Convert the byte array to an integer seed value
                var seed = BitConverter.ToInt32(bytes, 0);

                // Create a new instance of the Random class with the seed value
                var rand = new svchost.xCryptoRandom(seed);

                int index = (int)(Math.Pow(random.NextDouble(), 3) * (randomNumbers.Length - 1));

                int interval = randomNumbers[index] / RandomisedLeftCPS / 2;

                double randomFactor = rand.NextDouble();
                double Kurtosis = sldKurtosis.Int32_0/100F;
                int kurtosisFactor = (int)(Math.Pow(10, Kurtosis) - 1);
                interval += kurtosisFactor * (int)randomFactor;

                // Set the interval of the timer
                LeftClicker.Interval = interval;
            }

            int MinDebounce = Convert.ToInt32(sldMinimumDebounce.Int32_0);
            int MaxDebounce = Convert.ToInt32(sldMaximumDebounce.Int32_0);
            if (cbExtraRand.Checked)
            {
                Uniform.Int32 EvaluatedValue = Uniform.NewInclusive(4983, 15107);
                LeftClicker.Interval = EvaluatedValue.Sample(rng) / RandomisedLeftCPS;
            }

            // Motion Detection
            prev_pos.X = 0;
            prev_pos.Y = 0;
            int i = 0;
            int MotionDetectionValue = rand.Next(sldMinimumPixels.Int32_0, sldMaximumPixels.Int32_0);

            hwnd = FindWindow("LWJGL", null);
            {
                bool ShiftDisable = cbShiftDisable.Checked && GetAsyncKeyState(Keys.LShiftKey) != 0;
                bool ShiftRefill = cbShiftRefill.Checked && GetAsyncKeyState(Keys.LShiftKey) != 0;
                bool onlyWhilemoving = cbMoving.Checked && GetAsyncKeyState(Keys.W) != 0 || GetAsyncKeyState(Keys.A) != 0 || GetAsyncKeyState(Keys.S) != 0 || GetAsyncKeyState(Keys.D) != 0;
                if (IsWhitelistedLeft() && !ShiftDisable)
                    if ((!cbRMBLock.Checked && WinApi.GetAsyncKeyState(WinApi.VK_LBUTTON) < 0) || (cbRMBLock.Checked && MouseButtons == MouseButtons.Left))
                    {
                        if (GetCursorPos(out current_pos) & cbMotionCheck.Checked)
                        {

                            if ((current_pos.X != prev_pos.X) || (current_pos.Y != prev_pos.Y))
                            {
                                if (i == MotionDetectionValue)
                                {
                                    SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                    PlaySound();
                                    Thread.Sleep(rand.Next(1, 4));
                                    SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                                }

                                else return;
                                coords.Add(current_pos);
                                i++;
                            }

                            prev_pos.X = current_pos.X;
                            prev_pos.Y = current_pos.Y;
                        }
                        if (!onlyWhilemoving && cbMoving.Checked)
                        {
                            return;
                        }
                        if (cbBreakBlocks.Checked)
                        {
                            if (cbMenus.Checked && ClickerExtensionHandle.InMenu()) return;
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                        }

                        if (cbMenus.Checked && ClickerExtensionHandle.InMenu())
                        {
                            if (ShiftRefill)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Thread.Sleep(rand.Next(1, 4));
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            else return;
                        }

                        if (DateTime.Now - lastClickTime >= TimeSpan.FromMilliseconds(rand.Next(MinDebounce, MaxDebounce)) && cbDebounceDelay.Checked)
                        {
                            if (cbNohitdelay.Checked & !cbBreakBlocks.Checked)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                                bool dropchance = dropchancer.Sample(rng);
                                if (dropchance)
                                {
                                    Thread.Sleep(sldDropDelay.Int32_0);
                                }
                                Thread.Sleep(rand.Next(1, 13));
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            else if (!cbBreakBlocks.Checked && !cbNohitdelay.Checked)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                                bool dropchance = dropchancer.Sample(rng);
                                if (dropchance)
                                {
                                    Thread.Sleep(sldDropDelay.Int32_0);
                                }
                                Thread.Sleep(rand.Next(43));
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            else if (cbBlatant.Checked)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                                bool dropchance = dropchancer.Sample(rng);
                                if (dropchance)
                                {
                                    Thread.Sleep(sldDropDelay.Int32_0);
                                }
                                Thread.Sleep(0);
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            else if (!cbBreakBlocks.Checked && !cbNohitdelay.Checked && !cbBlatant.Checked)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                                bool dropchance = dropchancer.Sample(rng);
                                if (dropchance)
                                {
                                    Thread.Sleep(sldDropDelay.Int32_0);
                                }
                                Thread.Sleep(random2.Next(23, 43));
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            lastClickTime = DateTime.Now;
                        }

                        else if (cbNohitdelay.Checked & !cbBreakBlocks.Checked)
                        {
                            SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                            PlaySound();
                            Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                            bool dropchance = dropchancer.Sample(rng);
                            if (dropchance)
                            {
                                Thread.Sleep(sldDropDelay.Int32_0);
                            }
                            Thread.Sleep(rand.Next(1, 13));
                            SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                        }
                        else if (!cbBreakBlocks.Checked && !cbNohitdelay.Checked)
                        {
                            SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                            PlaySound();
                            Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                            bool dropchance = dropchancer.Sample(rng);
                            if (dropchance)
                            {
                                Thread.Sleep(sldDropDelay.Int32_0);
                            }
                            Thread.Sleep(random2.Next(10, 43));
                            SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                        }
                        else if (cbBlatant.Checked)
                        {
                            SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                            PlaySound();
                            Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                            bool dropchance = dropchancer.Sample(rng);
                            if (dropchance)
                            {
                                Thread.Sleep(sldDropDelay.Int32_0);
                            }
                            Thread.Sleep(0);
                            SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                        }
                        else if (!cbBreakBlocks.Checked && !cbNohitdelay.Checked && !cbBlatant.Checked)
                        {
                            SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                            PlaySound();
                            Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                            bool dropchance = dropchancer.Sample(rng);
                            if (dropchance)
                            {
                                Thread.Sleep(sldDropDelay.Int32_0);
                            }
                            Thread.Sleep(random2.Next(23, 43));
                            SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                        }
                    }

                // ALWAYS ON
                // ALWAYS ON

                    else if (cbAlwaysOn.Checked)
                    {
                        if (GetCursorPos(out current_pos) & cbMotionCheck.Checked)
                        {

                            if ((current_pos.X != prev_pos.X) || (current_pos.Y != prev_pos.Y))
                            {
                                if (i == MotionDetectionValue)
                                {
                                    SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                    PlaySound();
                                    Thread.Sleep(rand.Next(1, 4));
                                    SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                                }

                                else return;
                                coords.Add(current_pos);
                                i++;
                            }

                            prev_pos.X = current_pos.X;
                            prev_pos.Y = current_pos.Y;
                        }
                        if (!onlyWhilemoving && cbMoving.Checked)
                        {
                            return;
                        }
                        if (cbBreakBlocks.Checked)
                        {
                            if (cbMenus.Checked && ClickerExtensionHandle.InMenu()) return;
                            SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                        }

                        if (cbMenus.Checked && ClickerExtensionHandle.InMenu())
                        {
                            if (ShiftRefill)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Thread.Sleep(rand.Next(1, 4));
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            else return;
                        }

                        if (DateTime.Now - lastClickTime >= TimeSpan.FromMilliseconds(rand.Next(MinDebounce, MaxDebounce)) && cbDebounceDelay.Checked)
                        {
                            if (cbNohitdelay.Checked & !cbBreakBlocks.Checked)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                                bool dropchance = dropchancer.Sample(rng);
                                if (dropchance)
                                {
                                    Thread.Sleep(sldDropDelay.Int32_0);
                                }
                                Thread.Sleep(rand.Next(1, 13));
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            else if (!cbBreakBlocks.Checked && !cbNohitdelay.Checked)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                                bool dropchance = dropchancer.Sample(rng);
                                if (dropchance)
                                {
                                    Thread.Sleep(sldDropDelay.Int32_0);
                                }
                                Thread.Sleep(rand.Next(43));
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            else if (cbBlatant.Checked)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                                bool dropchance = dropchancer.Sample(rng);
                                if (dropchance)
                                {
                                    Thread.Sleep(sldDropDelay.Int32_0);
                                }
                                Thread.Sleep(0);
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            else if (!cbBreakBlocks.Checked && !cbNohitdelay.Checked && !cbBlatant.Checked)
                            {
                                SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                                PlaySound();
                                Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                                bool dropchance = dropchancer.Sample(rng);
                                if (dropchance)
                                {
                                    Thread.Sleep(sldDropDelay.Int32_0);
                                }
                                Thread.Sleep(random2.Next(23, 43));
                                SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                            }
                            lastClickTime = DateTime.Now;
                        }

                        else if (cbNohitdelay.Checked & !cbBreakBlocks.Checked)
                        {
                            SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                            PlaySound();
                            Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                            bool dropchance = dropchancer.Sample(rng);
                            if (dropchance)
                            {
                                Thread.Sleep(sldDropDelay.Int32_0);
                            }
                            Thread.Sleep(rand.Next(1, 13));
                            SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                        }
                        else if (!cbBreakBlocks.Checked && !cbNohitdelay.Checked)
                        {
                            SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                            PlaySound();
                            Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                            bool dropchance = dropchancer.Sample(rng);
                            if (dropchance)
                            {
                                Thread.Sleep(sldDropDelay.Int32_0);
                            }
                            Thread.Sleep(random2.Next(10, 43));
                            SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                        }
                        else if (cbBlatant.Checked)
                        {
                            SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                            PlaySound();
                            Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                            bool dropchance = dropchancer.Sample(rng);
                            if (dropchance)
                            {
                                Thread.Sleep(sldDropDelay.Int32_0);
                            }
                            Thread.Sleep(0);
                            SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                        }
                        else if (!cbBreakBlocks.Checked && !cbNohitdelay.Checked && !cbBlatant.Checked)
                        {
                            SendMessage(hwnd, WM_LBUTTONDOWN, 0, 0);
                            PlaySound();
                            Bernoulli dropchancer = Bernoulli.FromRatio((uint)sldDropChance.Int32_0, 100);
                            bool dropchance = dropchancer.Sample(rng);
                            if (dropchance)
                            {
                                Thread.Sleep(sldDropDelay.Int32_0);
                            }
                            Thread.Sleep(random2.Next(23, 43));
                            SendMessage(hwnd, WM_LBUTTONUP, 0, 0);
                        }
                    }
            }
        }
        #endregion

        #region blatant
        private void cbBlatant_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBlatant.Checked)
            {
                sldLCps.Int32_2 = 500;
            }
            else
            {
                sldLCps.Int32_2 = 200;
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            // override the OnPaint method to enable double buffering
            e.Graphics.Clear(this.BackColor);
            base.OnPaint(e);
        }

        public async void PlaySound() // For my clicks.
        {
            await Task.Run(async () =>
            {
                if (cbClickSounds.Checked)
                {
                    var volume = sldClickVolume.Int32_0 / 100F;
                    using (var player = new AudioFileReader(selectedFileName))
                    {
                        using (var output = new WaveOutEvent())
                        {
                            output.Volume = volume;
                            output.Init(player);
                            output.Play();
                            Bernoulli inconsistentchancer = Bernoulli.FromRatio((uint)sldSoundAbnormalChance.Int32_0, 100);
                            bool inconsistentchance = inconsistentchancer.Sample(rng);
                            if (inconsistentchance)
                            {
                                Thread.Sleep(sldSoundAbnormalDelay.Int32_0);
                            }
                            await Task.Delay(sldPlayerDuration.Int32_0);
                            if (cbFadeSound.Checked)
                            {
                                FadeOut(output, TimeSpan.FromSeconds(0.08));
                            }
                            output.Stop();
                        }
                    }
                }
            });
        }

        static void FadeOut(WaveOutEvent output, TimeSpan duration)
        {
            var step = output.Volume / (int)duration.TotalMilliseconds;
            while (output.Volume > 0)
            {
                output.Volume -= step;
                Thread.Sleep(1);
            }
            output.Stop();
        }

        public void Hideall()
        {
            pnlExceptions.Visible = false;
            pnlBlockhit.Visible = false;
            pnlRandomization.Visible = false;
            pnlJitter.Visible = false;
            pnlDebounce.Visible = false;
            pnlSounds.Visible = false;
            pnlMotion.Visible = false;
        }

        public void HideallMain()
        {
            pnlClicker.Visible = false;
            pnlThrowpot.Visible = false;
            pnlVisuals.Visible = false;
            pnlDestruct.Visible = false;
        }

        private void LeftConditionals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LeftConditionals.Text == "Exceptions")
            {
                this.SuspendLayout();
                Hideall();
                pnlExceptions.Visible = true;
                this.ResumeLayout();
            }

            if (LeftConditionals.Text == "Smart Blockhit")
            {
                this.SuspendLayout();
                Hideall();
                pnlBlockhit.Visible = true;
                this.ResumeLayout();
            }

            if (LeftConditionals.Text == "Randomization")
            {
                this.SuspendLayout();
                Hideall();
                pnlRandomization.Visible = true;
                this.ResumeLayout();
            }

            if (LeftConditionals.Text == "Jitter")
            {
                this.SuspendLayout();
                Hideall();
                pnlJitter.Visible = true;
                this.ResumeLayout();
            }

            if (LeftConditionals.Text == "Debounce Delay")
            {
                this.SuspendLayout();
                Hideall();
                pnlDebounce.Visible = true;
                this.ResumeLayout();
            }

            if (LeftConditionals.Text == "Click Sounds")
            {
                this.SuspendLayout();
                Hideall();
                pnlSounds.Visible = true;
                this.ResumeLayout();
            }

            if (LeftConditionals.Text == "Motion Check")
            {
                this.SuspendLayout();
                Hideall();
                pnlMotion.Visible = true;
                this.ResumeLayout();
            }
        }

        private void sldLCps_Event_0(object sender, EventArgs e)
        {
            lbCps.Text = (sldLCps.Int32_0 / 10F).ToString("Average CPS: 0.#");
        }

        private void sldExhaustDelay_Event_0(object sender, EventArgs e)
        {
            lbExhaustDelay.Text = (sldExhaustDelay.Int32_0 / 1F).ToString("Exhaust Amount: 0");
        }

        private void sldDropDelay_Event_0(object sender, EventArgs e)
        {
            lbDropDelay.Text = (sldDropDelay.Int32_0 / 1F).ToString("Drop Amount: 0");
        }

        private void sldJitterChance_Event_0(object sender, EventArgs e)
        {
            lbJitterChance.Text = (sldJitterChance.Int32_0 / 1F).ToString("Jitter Chance: 0");
        }

        private void sldJitterX_Event_0(object sender, EventArgs e)
        {
            lbDensityX.Text = (sldJitterX.Int32_0 / 10F).ToString("Density X: 0.#");
        }

        private void sldJitterY_Event_0(object sender, EventArgs e)
        {
            lbDensityY.Text = (sldJitterY.Int32_0 / 10F).ToString("Density Y: 0.#");
        }

        private void sldBLChance_Event_0(object sender, EventArgs e)
        {
            lbBLChance.Text = (sldBLChance.Int32_0 / 1F).ToString("Blockhit Chance: 0");
        }

        private void sldBLDelay_Event_0(object sender, EventArgs e)
        {
            lbBLDelay.Text = (sldBLDelay.Int32_0 / 1F).ToString("Blockhit Down Delay: 0");
        }

        private void cbToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (cbToggle.Checked)
            {
                LeftClicker.Start();
                SetTimerResolution();
            }

            else
            {
                LeftClicker.Stop();
            }
        }

        public static bool isCursorVisible()
        {
            CURSORINFO cursorInfo = new CURSORINFO();
            cursorInfo.cbSize = Marshal.SizeOf(cursorInfo);
            if (GetCursorInfo(out cursorInfo))
            {
                int mousehandle_int = (int)cursorInfo.hCursor;
                if (mousehandle_int > 50000 & mousehandle_int < 100000)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public void Delay(double dblSecs)
        {
            DateAndTime.Now.AddSeconds(1.1574074074074073E-05);
            DateTime t = DateAndTime.Now.AddSeconds(1.1574074074074073E-05).AddSeconds(dblSecs);
            while (DateTime.Compare(DateAndTime.Now, t) <= 0)
            {
                Application.DoEvents();
            }
        }

        const int WM_RBUTTONDOWN = 0x204;
        const int WM_RBUTTONUP = 0x205;
        private void blockhit_Tick(object sender, EventArgs e)
        {
            Bernoulli blockhitchancer = Bernoulli.FromRatio((uint)sldBLChance.Int32_0, 100);
            bool blockhitchance = blockhitchancer.Sample(rng);
            hwnd = FindWindow("LWJGL", null);
            {
                if (blockhitchance = true)
                {
                    if (cbBlockhit.Checked & cbToggle.Checked && MouseButtons == MouseButtons.Left)
                    {
                        if (cbMenus.Checked && ClickerExtensionHandle.InMenu()) return;
                        SendMessage(hwnd, WM_RBUTTONDOWN, 0, 0);
                        Thread.Sleep(sldBLDelay.Int32_0);
                        SendMessage(hwnd, WM_RBUTTONUP, 0, 0);
                        Thread.Sleep(sldBLUpDelay.Int32_0);
                    }
                }
            }
        }

        private void cbBlockhit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBlockhit.Checked)
            {
                blockhit.Start();
            }

            else
            {
                blockhit.Stop();
            }
        }

        #region Slots

        private byte currentSlot = 1;
        private async void GetSlots()
        {
            for (; ; )
            {
                await Task.Delay(20);
                GetKeyPressed();
                IsWhitelistedLeft();
            }
        }


        private void GetKeyPressed()
        {
            if (WinApi.GetAsyncKeyState(DefaultKeys.keyS1) != 0) currentSlot = 1;
            if (WinApi.GetAsyncKeyState(DefaultKeys.keyS2) != 0) currentSlot = 2;
            if (WinApi.GetAsyncKeyState(DefaultKeys.keyS3) != 0) currentSlot = 3;
            if (WinApi.GetAsyncKeyState(DefaultKeys.keyS4) != 0) currentSlot = 4;
            if (WinApi.GetAsyncKeyState(DefaultKeys.keyS5) != 0) currentSlot = 5;
            if (WinApi.GetAsyncKeyState(DefaultKeys.keyS6) != 0) currentSlot = 6;
            if (WinApi.GetAsyncKeyState(DefaultKeys.keyS7) != 0) currentSlot = 7;
            if (WinApi.GetAsyncKeyState(DefaultKeys.keyS8) != 0) currentSlot = 8;
            if (WinApi.GetAsyncKeyState(DefaultKeys.keyS9) != 0) currentSlot = 9;
        }



        private bool IsWhitelistedLeft()
        {
            switch (currentSlot)
            {
                case 1: return cbToggle.Checked && SlotL1.Checked;
                case 2: return cbToggle.Checked && SlotL2.Checked;
                case 3: return cbToggle.Checked && SlotL3.Checked;
                case 4: return cbToggle.Checked && SlotL4.Checked;
                case 5: return cbToggle.Checked && SlotL5.Checked;
                case 6: return cbToggle.Checked && SlotL6.Checked;
                case 7: return cbToggle.Checked && SlotL7.Checked;
                case 8: return cbToggle.Checked && SlotL8.Checked;
                case 9: return cbToggle.Checked && SlotL9.Checked;
            }
            return false;
        }
        #endregion

        #region TimerResolution
        private static void SetTimerResolution()
        {
            uint timer = 0U;
            NtSetTimerResolution(5000, true, ref timer);
            MM_BeginPeriod(1U);
        }

        #endregion

        private void sldExhaustChance_Event_0(object sender, EventArgs e)
        {
            lbExhaustChance.Text = (sldExhaustChance.Int32_0 / 1F).ToString("Exhaust Chance: 0");
        }

        private void sldDropChance_Event_0(object sender, EventArgs e)
        {
            lbDropChance.Text = (sldDropChance.Int32_0 / 1F).ToString("Drop Chance: 0");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Refresh();
            HideallMain();
            Hideall();
            pnlClicker.Visible = true;
            pnlRandomization.Visible = true;
            Task.Run(() => Uniqueness());
            this.DoubleBuffered = true;
        }

        private void startJitter_Tick(object sender, EventArgs e)
        {
            if (cbJitter.Checked && cbToggle.Checked)
            {
                int MinJ = sldJitterMinimumDelay.Int32_0;
                int MaxJ = sldJitterMaximumDelay.Int32_0;
                Uniform.Int32 distributionJ = Uniform.NewInclusive(MinJ, MaxJ);
                startJitter.Interval = distributionJ.Sample(rng);
                int x = (int)Math.Round(Cursor.Position.X * 0.002 + Convert.ToInt32(sldJitterX.Int32_0 / 10 / 2));
                int x_ = (int)Math.Round(Cursor.Position.X * 0.003 + Convert.ToInt32(sldJitterX.Int32_0 / 10 / 2));
                int y = (int)Math.Round(Cursor.Position.Y * 0.002 + Convert.ToInt32(sldJitterY.Int32_0 / 10 / 2));
                int y_ = (int)Math.Round(Cursor.Position.Y * 0.003 + Convert.ToInt32(sldJitterY.Int32_0 / 10 / 2));
                var jitterchancevalue = sldJitterChance.Int32_0;
                Bernoulli JitterChancer = Bernoulli.FromRatio((uint)jitterchancevalue, 100);
                bool JitterChance = JitterChancer.Sample(rng);
                if (JitterChance && MouseButtons == MouseButtons.Left)
                {
                    Cursor.Position = checked(new Point(Control.MousePosition.X + this.rand.Next((int)Math.Round(unchecked(-1.0 * Conversions.ToDouble(this.sldJitterX.Int32_0 / 10F))), Conversions.ToInteger(this.sldJitterX.Int32_0 / 10F)), Control.MousePosition.Y + this.rand.Next((int)Math.Round(unchecked(-1.0 * Conversions.ToDouble(this.sldJitterY.Int32_0 / 10F))), Conversions.ToInteger(this.sldJitterY.Int32_0 / 10F))));
                }
            }
        }

        private void cbJitter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbJitter.Checked)
            {
                startJitter.Start();
            }

            else
            {
                startJitter.Stop();
            }
        }

        private void sldMinimumDebounce_Event_0(object sender, EventArgs e)
        {
            lbMinimumDebounce.Text = (sldMinimumDebounce.Int32_0 / 1F).ToString("Minimum Debounce: 0");
        }

        private void sldCheckInterval_Event_0(object sender, EventArgs e)
        {
            lbDebounceInterval.Text = (sldCheckInterval.Int32_0 / 1F).ToString("Check Interval: 0");
        }

        private void CheckIntervalTimer_Tick(object sender, EventArgs e)
        {
            int MinDebounce = Convert.ToInt32(sldMinimumDebounce.Int32_0);
            int MaxDebounce = Convert.ToInt32(sldMaximumDebounce.Int32_0);
            CheckIntervalTimer.Interval = sldCheckInterval.Int32_0;
        }

        private void sldMaximumDebounce_Event_0_1(object sender, EventArgs e)
        {
            lbMaximumDebounce.Text = (sldMaximumDebounce.Int32_0 / 1F).ToString("Maximum Debounce: 0");
        }

        private void sldBLUpDelay_Event_0(object sender, EventArgs e)
        {
            lbBLUpDelay.Text = (sldBLUpDelay.Int32_0 / 1F).ToString("Blockhit Up Delay: 0");
        }

        public void ClickSoundChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Sound files (*.mp3, *.wav)|*.mp3;*.wav";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFileName = openFileDialog1.FileName;
                ClickSoundChoice.Text = selectedFileName;
            }
        }

        private void sldClickVolume_Event_0(object sender, EventArgs e)
        {
            lbVolume.Text = (sldClickVolume.Int32_0 / 1F).ToString("Volume: 0");
        }

        private void sldPlayerDuration_Event_0(object sender, EventArgs e)
        {
            lbPlayerDuration.Text = (sldPlayerDuration.Int32_0 / 1F).ToString("Player Duration: 0");
        }

        private void flatTrackBar2_Event_0(object sender, EventArgs e)
        {
            lbJitterMaximumDelay.Text = (sldJitterMaximumDelay.Int32_0 / 1F).ToString("Jitter Maximum Interval: 0");
        }

        private void sldJitterMinimumDelay_Event_0(object sender, EventArgs e)
        {
            lbJitterMinimumDelay.Text = (sldJitterMinimumDelay.Int32_0 / 1F).ToString("Jitter Minimum Interval: 0");
        }

        private void sldSoundAbnormalChance_Event_0(object sender, EventArgs e)
        {
            lbSoundAbnormalChance.Text = (sldSoundAbnormalChance.Int32_0 / 1F).ToString("Inconsistency Chance: 0");
        }

        private void sldSoundAbnormalDelay_Event_0(object sender, EventArgs e)
        {
            lbSoundAbnormalDelay.Text = (sldSoundAbnormalDelay.Int32_0 / 1F).ToString("Inconsistency Delay: 0");
        }

        private void sldFirstPotion_Event_0(object sender, EventArgs e)
        {
            lbFirstPotion.Text = (sldFirstPotion.Int32_0 / 1F).ToString("First Potion: 0");
        }

        private void sldLastPotion_Event_0(object sender, EventArgs e)
        {
            lbLastPotion.Text = (sldLastPotion.Int32_0 / 1F).ToString("Last Potion: 0");
        }


        #region Throwpot

        // Define the key press event message
        const uint WM_KEYDOWN = 0x0100;

        public static void SendKey(Keys key)
        {
            // Get the handle of the active or foreground window
            IntPtr windowHandle = GetForegroundWindow();

            // Set the WPARAM parameter to the virtual key code of the key
            IntPtr wParam = (IntPtr)key;

            // Set the LPARAM parameter to 0 for a key press event
            IntPtr lParam = IntPtr.Zero;

            // Send the key press event message to the active or foreground window
            SendMessage(windowHandle, (int)WM_KEYDOWN, (int)wParam, (int)lParam);
        }
        #endregion

        private void bndThrowpot_Click(object sender, EventArgs e) => bndThrowpot.Text = "[...]";

        private void bndThrowpot_KeyDown(object sender, KeyEventArgs e)
        {
            if (bndThrowpot.Text == "[...]")
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        ThrowpotBind = 0;
                        bndThrowpot.Text = "[Unbound]";
                        break;

                    default:
                        ThrowpotBind = e.KeyCode;
                        bndThrowpot.Text = $"[{e.KeyCode}]";
                        break;
                }
            }
        }

        // Token: 0x04000020 RID: 32
        public uint MOUSEEVENTF_RIGHTUP = 16u;

        // Token: 0x04000021 RID: 33
        public uint MOUSEEVENTF_RIGHTDOWN = 8u;

        private void Bind_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(ThrowpotBind) != 0)
            {
            }
        }

        private void whitegradientpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                var relativePoint = this.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                if (e.Y < whitegradientpanel.Height && e.Y >= 1 && e.X >= 1 && e.X <= whitegradientpanel.Size.Width - 3 && e.Y <= whitegradientpanel.Height - 3)
                {
                    Bitmap bmp = new Bitmap(whitegradientpanel.Width, whitegradientpanel.Height);
                    whitegradientpanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    Color clr = bmp.GetPixel(e.X, e.Y);
                    blackgradientpanel.FillColor = clr;
                    updateColor();
                }
            }
        }

        private void rgbpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Y < rgbpanel.Height && e.Y >= 0 && e.X >= 1 && e.X <= rgbpanel.Size.Width - 7 && e.X < rgbpanel.Width)
                {
                    Bitmap bmp = (Bitmap)rgbpanel.Image;
                    Color clr = bmp.GetPixel(e.X, e.Y);
                    whitegradientpanel.FillColor3 = clr;
                    whitegradientpanel.FillColor4 = clr;
                    blackgradientpanel.FillColor = clr;
                    updateColor();
                }
            }
        }

        private void blackgradientpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Y < blackgradientpanel.Height && e.Y >= 0 && e.X >= 1 && e.X <= blackgradientpanel.Size.Width - 7 && e.X < blackgradientpanel.Width)
                {
                    Bitmap bmp = new Bitmap(blackgradientpanel.Width, blackgradientpanel.Height);
                    blackgradientpanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    Color clr = bmp.GetPixel(e.X, e.Y);
                    colorpreviewpanel.FillColor = clr;
                    colorpreviewpanel.Refresh();
                    blackgradientpanel.FillColor = clr;
                    blackgradientpanel.Refresh();
                    whitegradientpanel.FillColor3 = clr;
                    whitegradientpanel.FillColor4 = clr;
                    whitegradientpanel.Refresh();
                    sldLCps.Color_4 = clr;
                    sldLCps.Refresh();
                    sldExhaustChance.Color_4 = clr;
                    sldExhaustChance.Refresh();
                    sldDropChance.Color_4 = clr;
                    sldDropChance.Refresh();
                    sldExhaustDelay.Color_4 = clr;
                    sldExhaustDelay.Refresh();
                    sldDropDelay.Color_4 = clr;
                    sldDropDelay.Refresh();
                    sldBLChance.Color_4 = clr;
                    sldBLChance.Refresh();
                    sldBLUpDelay.Color_4 = clr;
                    sldBLUpDelay.Refresh();
                    sldBLDelay.Color_4 = clr;
                    sldBLDelay.Refresh();
                    sldJitterChance.Color_4 = clr;
                    sldJitterChance.Refresh();
                    sldJitterX.Color_4 = clr;
                    sldJitterX.Refresh();
                    sldJitterY.Color_4 = clr;
                    sldJitterY.Refresh();
                    sldJitterMinimumDelay.Color_4 = clr;
                    sldJitterMinimumDelay.Refresh();
                    sldJitterMaximumDelay.Color_4 = clr;
                    sldJitterMaximumDelay.Refresh();
                    sldMinimumDebounce.Color_4 = clr;
                    sldMinimumDebounce.Refresh();
                    sldMaximumDebounce.Color_4 = clr;
                    sldMaximumDebounce.Refresh();
                    sldCheckInterval.Color_4 = clr;
                    sldCheckInterval.Refresh();
                    sldClickVolume.Color_4 = clr;
                    sldClickVolume.Refresh();
                    sldPlayerDuration.Color_4 = clr;
                    sldPlayerDuration.Refresh();
                    sldSoundAbnormalChance.Color_4 = clr;
                    sldSoundAbnormalChance.Refresh();
                    sldSoundAbnormalDelay.Color_4 = clr;
                    sldSoundAbnormalDelay.Refresh();
                    sldMinimumPixels.Color_4 = clr;
                    sldMinimumPixels.Refresh();
                    sldMaximumPixels.Color_4 = clr;
                    sldMaximumPixels.Refresh();
                    MainForm.MainF.sldMinimumReach.Color_4 = clr;
                    MainForm.MainF.sldMinimumReach.Refresh();
                    MainForm.MainF.sldMaximumReach.Color_4 = clr;
                    MainForm.MainF.sldMaximumReach.Refresh();
                    MainForm.MainF.sldChance.Color_4 = clr;
                    MainForm.MainF.sldChance.Refresh();
                    sldChromaInterval.Color_4 = clr;
                    sldChromaInterval.Refresh();
                    sldKurtosis.Color_4 = clr;
                    sldKurtosis.Refresh();

                    // Checkboxes

                    cbToggle.Color_7 = clr;
                    cbToggle.Color_2 = clr;
                    cbShiftRefill.Color_7 = clr;
                    cbShiftRefill.Color_2 = clr;
                    cbBreakBlocks.Color_7 = clr;
                    cbBreakBlocks.Color_2 = clr;
                    cbMenus.Color_7 = clr;
                    cbMenus.Color_2 = clr;
                    cbBlatant.Color_7 = clr;
                    cbBlatant.Color_2 = clr;
                    cbRMBLock.Color_7 = clr;
                    cbRMBLock.Color_2 = clr;
                    cbNohitdelay.Color_7 = clr;
                    cbNohitdelay.Color_2 = clr;
                    cbShiftDisable.Color_7 = clr;
                    cbShiftDisable.Color_2 = clr;
                    cbMoving.Color_7 = clr;
                    cbMoving.Color_2 = clr;
                    cbExtraRand.Color_7 = clr;
                    cbExtraRand.Color_2 = clr;
                    cbAlwaysOn.Color_7 = clr;
                    cbAlwaysOn.Color_2 = clr;
                    cbBlockhit.Color_7 = clr;
                    cbBlockhit.Color_2 = clr;
                    cbJitter.Color_7 = clr;
                    cbJitter.Color_2 = clr;
                    cbDebounceDelay.Color_7 = clr;
                    cbDebounceDelay.Color_2 = clr;
                    cbClickSounds.Color_7 = clr;
                    cbClickSounds.Color_2 = clr;
                    cbFadeSound.Color_7 = clr;
                    cbFadeSound.Color_2 = clr;
                    cbChroma.Color_7 = clr;
                    cbChroma.Color_2 = clr;
                    cbGhostCapture.Color_7 = clr;
                    cbGhostCapture.Color_2 = clr;
                    cbUSNJournal.Color_7 = clr;
                    cbUSNJournal.Color_2 = clr;
                    cbRegistry.Color_7 = clr;
                    cbRegistry.Color_2 = clr;
                    cbRestartServices.Color_7 = clr;
                    cbRestartServices.Color_2 = clr;
                    cbClearStrings.Color_7 = clr;
                    cbClearStrings.Color_2 = clr;
                    cbTemp.Color_7 = clr;
                    cbTemp.Color_2 = clr;
                    cbLAVCrasher.Color_7 = clr;
                    cbLAVCrasher.Color_2 = clr;
                    cbClearDNS.Color_7 = clr;
                    cbClearDNS.Color_2 = clr;
                    cbShadows.Color_7 = clr;
                    cbShadows.Color_2 = clr;
                    cbClearDumps.Color_7 = clr;
                    cbClearDumps.Color_2 = clr;
                    cbPrefetch.Color_7 = clr;
                    cbPrefetch.Color_2 = clr;
                    cbMotionCheck.Color_7 = clr;
                    cbMotionCheck.Color_2 = clr;
                    MainForm.MainF.cbReach.Color_7 = clr;
                    MainForm.MainF.cbReach.Color_2 = clr;
                    MainForm.MainF.cbMoving.Color_7 = clr;
                    MainForm.MainF.cbMoving.Color_2 = clr;
                    MainForm.MainF.cbSprint.Color_7 = clr;
                    MainForm.MainF.cbSprint.Color_2 = clr;
                    MainForm.MainF.cbPlayerOnly.Color_7 = clr;
                    MainForm.MainF.cbPlayerOnly.Color_2 = clr;
                    MainForm.MainF.cbBlatantReach.Color_7 = clr;
                    MainForm.MainF.cbBlatantReach.Color_2 = clr;
                    cbTaskbarHide.Color_7 = clr;
                    cbTaskbarHide.Color_2 = clr;

                    //Slots
                    SlotL1.Color_7 = clr;
                    SlotL1.Color_2 = clr;
                    SlotL2.Color_7 = clr;
                    SlotL2.Color_2 = clr;
                    SlotL3.Color_7 = clr;
                    SlotL3.Color_2 = clr;
                    SlotL4.Color_7 = clr;
                    SlotL4.Color_2 = clr;
                    SlotL5.Color_7 = clr;
                    SlotL5.Color_2 = clr;
                    SlotL6.Color_7 = clr;
                    SlotL6.Color_2 = clr;
                    SlotL7.Color_7 = clr;
                    SlotL7.Color_2 = clr;
                    SlotL8.Color_7 = clr;
                    SlotL8.Color_2 = clr;
                    SlotL9.Color_7 = clr;
                    SlotL9.Color_2 = clr;

                    // Labels
                    lbVersion.ForeColor = clr;

                    //Combo Boxes
                    LeftConditionals.HoverState.BorderColor = clr;
                    LeftConditionals.FocusedState.BorderColor = clr;
                    LeftConditionals.Refresh();
                    ClickSoundChoice.HoverState.BorderColor = clr;
                    ClickSoundChoice.FocusedState.BorderColor = clr;
                    ClickSoundChoice.Refresh();
                    // Values
                    lbR.Text = clr.R.ToString();
                    lbG.Text = clr.G.ToString();
                    lbB.Text = clr.B.ToString();
                    lbHex.Text = "#" + clr.R.ToString("X2") + clr.G.ToString("X2") + clr.B.ToString("X2");
                    previouspx = e.Location;
                }
            }
        }

        private void updateColor()
        {
            Bitmap blackgradientpanelbmp = new Bitmap(blackgradientpanel.Width, blackgradientpanel.Height);
            blackgradientpanel.DrawToBitmap(blackgradientpanelbmp, new Rectangle(0, 0, blackgradientpanelbmp.Width, blackgradientpanelbmp.Height));
            Color clr = blackgradientpanelbmp.GetPixel(previouspx.X, previouspx.Y);
            colorpreviewpanel.FillColor = clr;
            colorpreviewpanel.Refresh();
            blackgradientpanel.FillColor = clr;
            blackgradientpanel.Refresh();
            whitegradientpanel.FillColor3 = clr;
            whitegradientpanel.FillColor4 = clr;
            whitegradientpanel.Refresh();
            sldLCps.Color_4 = clr;
            sldLCps.Refresh();
            sldExhaustChance.Color_4 = clr;
            sldExhaustChance.Refresh();
            sldDropChance.Color_4 = clr;
            sldDropChance.Refresh();
            sldExhaustDelay.Color_4 = clr;
            sldExhaustDelay.Refresh();
            sldDropDelay.Color_4 = clr;
            sldDropDelay.Refresh();
            sldBLChance.Color_4 = clr;
            sldBLChance.Refresh();
            sldBLUpDelay.Color_4 = clr;
            sldBLUpDelay.Refresh();
            sldBLDelay.Color_4 = clr;
            sldBLDelay.Refresh();
            sldJitterChance.Color_4 = clr;
            sldJitterChance.Refresh();
            sldJitterX.Color_4 = clr;
            sldJitterX.Refresh();
            sldJitterY.Color_4 = clr;
            sldJitterY.Refresh();
            sldJitterMinimumDelay.Color_4 = clr;
            sldJitterMinimumDelay.Refresh();
            sldJitterMaximumDelay.Color_4 = clr;
            sldJitterMaximumDelay.Refresh();
            sldMinimumDebounce.Color_4 = clr;
            sldMinimumDebounce.Refresh();
            sldMaximumDebounce.Color_4 = clr;
            sldMaximumDebounce.Refresh();
            sldCheckInterval.Color_4 = clr;
            sldCheckInterval.Refresh();
            sldClickVolume.Color_4 = clr;
            sldClickVolume.Refresh();
            sldPlayerDuration.Color_4 = clr;
            sldPlayerDuration.Refresh();
            sldSoundAbnormalChance.Color_4 = clr;
            sldSoundAbnormalChance.Refresh();
            sldSoundAbnormalDelay.Color_4 = clr;
            sldSoundAbnormalDelay.Refresh();
            sldMinimumPixels.Color_4 = clr;
            sldMinimumPixels.Refresh();
            sldMaximumPixels.Color_4 = clr;
            sldMaximumPixels.Refresh();
            MainForm.MainF.sldMinimumReach.Color_4 = clr;
            MainForm.MainF.sldMinimumReach.Refresh();
            MainForm.MainF.sldMaximumReach.Color_4 = clr;
            MainForm.MainF.sldMaximumReach.Refresh();
            MainForm.MainF.sldChance.Color_4 = clr;
            MainForm.MainF.sldChance.Refresh();
            sldChromaInterval.Color_4 = clr;
            sldChromaInterval.Refresh();
            sldKurtosis.Color_4 = clr;
            sldKurtosis.Refresh();

            // Checkboxes

            cbToggle.Color_7 = clr;
            cbToggle.Color_2 = clr;
            cbShiftRefill.Color_7 = clr;
            cbShiftRefill.Color_2 = clr;
            cbBreakBlocks.Color_7 = clr;
            cbBreakBlocks.Color_2 = clr;
            cbMenus.Color_7 = clr;
            cbMenus.Color_2 = clr;
            cbBlatant.Color_7 = clr;
            cbBlatant.Color_2 = clr;
            cbRMBLock.Color_7 = clr;
            cbRMBLock.Color_2 = clr;
            cbNohitdelay.Color_7 = clr;
            cbNohitdelay.Color_2 = clr;
            cbShiftDisable.Color_7 = clr;
            cbShiftDisable.Color_2 = clr;
            cbMoving.Color_7 = clr;
            cbMoving.Color_2 = clr;
            cbExtraRand.Color_7 = clr;
            cbExtraRand.Color_2 = clr;
            cbAlwaysOn.Color_7 = clr;
            cbAlwaysOn.Color_2 = clr;
            cbBlockhit.Color_7 = clr;
            cbBlockhit.Color_2 = clr;
            cbJitter.Color_7 = clr;
            cbJitter.Color_2 = clr;
            cbDebounceDelay.Color_7 = clr;
            cbDebounceDelay.Color_2 = clr;
            cbClickSounds.Color_7 = clr;
            cbClickSounds.Color_2 = clr;
            cbFadeSound.Color_7 = clr;
            cbFadeSound.Color_2 = clr;
            cbChroma.Color_7 = clr;
            cbChroma.Color_2 = clr;
            cbGhostCapture.Color_7 = clr;
            cbGhostCapture.Color_2 = clr;
            cbUSNJournal.Color_7 = clr;
            cbUSNJournal.Color_2 = clr;
            cbRegistry.Color_7 = clr;
            cbRegistry.Color_2 = clr;
            cbRestartServices.Color_7 = clr;
            cbRestartServices.Color_2 = clr;
            cbClearStrings.Color_7 = clr;
            cbClearStrings.Color_2 = clr;
            cbTemp.Color_7 = clr;
            cbTemp.Color_2 = clr;
            cbLAVCrasher.Color_7 = clr;
            cbLAVCrasher.Color_2 = clr;
            cbClearDNS.Color_7 = clr;
            cbClearDNS.Color_2 = clr;
            cbShadows.Color_7 = clr;
            cbShadows.Color_2 = clr;
            cbClearDumps.Color_7 = clr;
            cbClearDumps.Color_2 = clr;
            cbPrefetch.Color_7 = clr;
            cbPrefetch.Color_2 = clr;
            cbMotionCheck.Color_7 = clr;
            cbMotionCheck.Color_2 = clr;
            MainForm.MainF.cbReach.Color_7 = clr;
            MainForm.MainF.cbReach.Color_2 = clr;
            MainForm.MainF.cbMoving.Color_7 = clr;
            MainForm.MainF.cbMoving.Color_2 = clr;
            MainForm.MainF.cbSprint.Color_7 = clr;
            MainForm.MainF.cbSprint.Color_2 = clr;
            MainForm.MainF.cbPlayerOnly.Color_7 = clr;
            MainForm.MainF.cbPlayerOnly.Color_2 = clr;
            MainForm.MainF.cbBlatantReach.Color_7 = clr;
            MainForm.MainF.cbBlatantReach.Color_2 = clr;
            cbTaskbarHide.Color_7 = clr;
            cbTaskbarHide.Color_2 = clr;

            //Slots
            SlotL1.Color_7 = clr;
            SlotL1.Color_2 = clr;
            SlotL2.Color_7 = clr;
            SlotL2.Color_2 = clr;
            SlotL3.Color_7 = clr;
            SlotL3.Color_2 = clr;
            SlotL4.Color_7 = clr;
            SlotL4.Color_2 = clr;
            SlotL5.Color_7 = clr;
            SlotL5.Color_2 = clr;
            SlotL6.Color_7 = clr;
            SlotL6.Color_2 = clr;
            SlotL7.Color_7 = clr;
            SlotL7.Color_2 = clr;
            SlotL8.Color_7 = clr;
            SlotL8.Color_2 = clr;
            SlotL9.Color_7 = clr;
            SlotL9.Color_2 = clr;

            // Labels
            lbVersion.ForeColor = clr;

            //Combo Boxes
            LeftConditionals.HoverState.BorderColor = clr;
            LeftConditionals.FocusedState.BorderColor = clr;
            LeftConditionals.Refresh();
            ClickSoundChoice.HoverState.BorderColor = clr;
            ClickSoundChoice.FocusedState.BorderColor = clr;
            ClickSoundChoice.Refresh();
            // Values
            lbR.Text = clr.R.ToString();
            lbG.Text = clr.G.ToString();
            lbB.Text = clr.B.ToString();
            lbHex.Text = "#" + clr.R.ToString("X2") + clr.G.ToString("X2") + clr.B.ToString("X2");
        }

        private void cbChroma_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChroma.Checked)
            {
                Chroma.Start();
            }
            else
            {
                Chroma.Stop();
            }
        }

        private void cbGhostCapture_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGhostCapture.Checked)
            {
                SetWindowDisplayAffinity(this.Handle, WDA_EXCLUDEFROMCAPTURE);
            }
            else
            {
                SetWindowDisplayAffinity(this.Handle, 0);
            }
        }

        #region Destruct

        private static string sha256(string randomString)
        {
            HashAlgorithm hashAlgorithm = new SHA256Managed();
            string text = string.Empty;
            foreach (byte b in hashAlgorithm.ComputeHash(Encoding.ASCII.GetBytes(randomString)))
            {
                text += b.ToString("x2");
            }
            return text;
        }

        private async void btnDestruct_Click(object sender, EventArgs e)
        {
            if (cbUSNJournal.Checked)
            {
                Form1.runCommand("fsutil usn deletejournal /n c:");
                Form1.runCommand("fsutil usn deletejournal /n d:");
                Form1.runCommand("fsutil usn deletejournal /n e:");
                Form1.runCommand("fsutil usn deletejournal /n f:");
                Form1.runCommand("fsutil usn createjournal m=33909999 a=1 C:");
            }

            if (cbClearDNS.Checked)
            {
                Form1.runCommand("ipconfig /flushdns");
            }

            if (cbRestartServices.Checked)
            {
                Form1.runCommand("net stop DPS");
                Form1.runCommand("net stop PcaSvc");
                Form1.runCommand("net stop Dnscache");
                Form1.runCommand("net stop DiagTrack");
                Form1.runCommand("net stop eventlog");
                Form1.runCommand("net stop sysmain");
                Form1.runCommand("net stop DusmSvc");
                Thread.Sleep(1000);
                Form1.runCommand("net start DPS");
                Form1.runCommand("net start PcaSvc");
                Form1.runCommand("net start Dnscache");
                Form1.runCommand("net start DiagTrack");
                Form1.runCommand("net start eventlog");
                Form1.runCommand("net start sysmain");
            }

            if (cbShadows.Checked)
            {
                Form1.runCommand("vssadmin delete shadows /for=C: /all");
            }

            if (cbPrefetch.Checked) 
            {
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Windows\\Prefetch");
                FileInfo[] files = directoryInfo.GetFiles(friendlyName + "*");
                foreach (FileInfo fileInfo in files)
                {
                    File.Delete(fileInfo.FullName);
                }
            }

            if (cbTemp.Checked)
            {
                string tempDir = Path.GetTempPath();
                string[] files = Directory.GetFiles(tempDir);

                foreach (string file in files)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException)
                    {
                        // Handle any exceptions that occur during file deletion
                    }
                }
            }

            if (cbClearDumps.Checked)
            {
                Form1.runCommand("del /F /Q %APPDATA%\\Microsoft\\Windows\\Recent\\*");
                Form1.runCommand("del /F /Q C:\\Users\\%username%\\AppData\\Local\\CrashDumps\\*");
                Form1.runCommand("del /F /Q %APPDATA%\\Microsoft\\Windows\\Recent\\AutomaticDestinations\\*");
                Form1.runCommand("del /F /Q %APPDATA%\\Microsoft\\Windows\\Recent\\CustomDestinations\\*");
            }

            if (cbClearStrings.Checked)
            {
                Strings();
            }

            if (cbLAVCrasher.Checked)
            {
                string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                char[] array = new char[8];
                Random random = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = text[random.Next(text.Length)];
                }
                string text2 = new string(array);
                string str = text2;
                char[] array2 = array;
                string value = Form1.sha256(str + ((array2 != null) ? array2.ToString() : null));
                DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Windows\\Prefetch");
                FileInfo fileInfo = new FileInfo("C:\\Windows\\Prefetch\\CONSENT.EXE-" + text2.ToUpper() + ".pf");
                FileInfo[] files = directoryInfo.GetFiles("CONSENT.EXE-*");
                if (this.cbLAVCrasher.Checked)
                {
                    using (StreamWriter streamWriter = fileInfo.AppendText())
                    {
                        streamWriter.WriteLine(value);
                    }
                }
                try
                {
                    FileInfo[] array3 = files;
                    for (int j = 0; j < array3.Length; j++)
                    {
                        File.Delete(array3[j].FullName);
                    }
                }
                catch
                {
                }
            }
            await Task.Delay(1000);
            Process currentProcess = Process.GetCurrentProcess();
            SetProcessWorkingSetSize(currentProcess.Handle, -1, -1);
            currentProcess.Kill();
        }

        private static void runCommand(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Verb = "runas";
            process.Start();
            process.StandardInput.WriteLine(command);
            process.Close();
        }

        IEnumerable<long> paladin;
        static IntPtr[] explorer;
        static IntPtr[] Isass;
        static IntPtr[] searchindexer;
        public Mem MemLib = new Mem();
        public Random random = new Random();
        public string weqwe(int ewe)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, ewe).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void oof(string wq)
        {
            ServiceController serviceController = new ServiceController(wq);
            try
            {
                if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    serviceController.Stop();
                }
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch
            {

            }
        }

        public async void Strings()
        {
            oof("DPS");
            string exename = AppDomain.CurrentDomain.FriendlyName;
            DirectoryInfo pf = new DirectoryInfo(@"C:\windows\prefetch");
            FileInfo[] Files = pf.GetFiles(exename + "*");
            foreach (FileInfo files in Files)
            {
                File.Delete(files.FullName);
            }
            if (!MemLib.OpenProcess("javaw"))
            {

            }
            paladin = await MemLib.AoBScan(0, long.MaxValue, "41 6e 79 44 65 73 6b 2e 65 78 65");
            foreach (long add in paladin)
            {
                MemLib.WriteMemory(add.ToString("X"), "string", weqwe(23));
            }
            DotNetScanMemory_SmoLL dot = new DotNetScanMemory_SmoLL();
            explorer = dot.ScanArray(dot.GetPID("explorer"), "41 6e 79 44 65 73 6b 2e 65 78 65 2c 54 69 6d 65 2c 30");
            for (int i = 0; i < explorer.Count<IntPtr>(); i++)
            {

                dot.WriteArray(explorer[i], "20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20");
            }
            Isass = dot.ScanArray(dot.GetPID("Isass"), "41 6e 79 44 65 73 6b 2e 65 78 65 2c 54 69 6d 65 2c 30");
            for (int i = 0; i < Isass.Count<IntPtr>(); i++)
            {
                dot.WriteArray(Isass[i], "20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20");
            }
            searchindexer = dot.ScanArray(dot.GetPID("searchindexer"), "41 6e 79 44 65 73 6b 2e 65 78 65 2c 54 69 6d 65 2c 30");
            for (int i = 0; i < searchindexer.Count<IntPtr>(); i++)
            {
                dot.WriteArray(searchindexer[i], "20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20");
            }
        }

        #endregion

        private void label15_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            HideallMain();
            pnlClicker.Visible = true;
            PanelConfig.PanelAnimation(pnlClicker);
            this.ResumeLayout();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            HideallMain();
            pnlThrowpot.Visible = true;
            PanelConfig.PanelAnimation(pnlThrowpot);
            this.ResumeLayout();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            HideallMain();
            pnlVisuals.Visible = true;
            PanelConfig.PanelAnimation(pnlVisuals);
            this.ResumeLayout();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            HideallMain();
            pnlDestruct.Location = pnlVisuals.Location;
            pnlDestruct.Visible = true;
            PanelConfig.PanelAnimation(pnlDestruct);
            this.ResumeLayout();
        }
        #region Motion Detection
        private void sldMaximumPixels_Event_0(object sender, EventArgs e)
        {
            lbMaximumPixels.Text = (sldMaximumPixels.Int32_0 / 1F).ToString("Maximum Pixel Amount: 0");
        }

        private void sldMinimumReach_Event_0(object sender, EventArgs e)
        {
            lbMinimumReach.Text = (sldMinimumReach.Int32_0 / 100F).ToString("Minimum Reach: 0.##");
            if (sldMinimumReach.Int32_0 > sldMaximumReach.Int32_0)
            {
                sldMaximumReach.Int32_0 = sldMinimumReach.Int32_0;
            }
        }

        private void sldMaximumReach_Event_0(object sender, EventArgs e)
        {
            lbMaximumReach.Text = (sldMaximumReach.Int32_0 / 100F).ToString("Maximum Reach: 0.##");
            if (sldMaximumReach.Int32_0 < sldMinimumReach.Int32_0)
            {
                sldMinimumReach.Int32_0 = sldMaximumReach.Int32_0;
            }
        }

        private void UpdateGraphics_Tick(object sender, EventArgs e)
        {
            backBuffer.Graphics.Clear(Color.White);
            // Draw any controls that have requested a paint event
            foreach (Control control in this.Controls)
            {
                if (control.IsHandleCreated && control.Visible && control.Bounds.IntersectsWith(this.DisplayRectangle))
                {
                    DrawControl(backBuffer.Graphics, control);
                }
            }
            backBuffer.Render();

        }

        private void DrawControl(Graphics g, Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height, g);
            control.DrawToBitmap(bmp, control.ClientRectangle);
            g.DrawImage(bmp, control.Left, control.Top);
        }

        private void flatPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Chroma_Tick(object sender, EventArgs e)
        {
            Chroma.Interval = sldChromaInterval.Int32_0;
            // Calculate the next hue value within the 0-360 range
            hue = (hue + 1) % 360;

            // Convert the hue value to RGB
            Color chromaColor = ColorFromHSV(hue, 1.0, 1.0);

            // Apply the chroma color to the panel's background
            colorpreviewpanel.FillColor = chromaColor;
            colorpreviewpanel.Refresh();
            blackgradientpanel.FillColor = chromaColor;
            blackgradientpanel.Refresh();
            whitegradientpanel.FillColor3 = chromaColor;
            whitegradientpanel.FillColor4 = chromaColor;
            whitegradientpanel.Refresh();
            sldLCps.Color_4 = chromaColor;
            sldLCps.Refresh();
            sldExhaustChance.Color_4 = chromaColor;
            sldExhaustChance.Refresh();
            sldDropChance.Color_4 = chromaColor;
            sldDropChance.Refresh();
            sldExhaustDelay.Color_4 = chromaColor;
            sldExhaustDelay.Refresh();
            sldDropDelay.Color_4 = chromaColor;
            sldDropDelay.Refresh();
            sldBLChance.Color_4 = chromaColor;
            sldBLChance.Refresh();
            sldBLUpDelay.Color_4 = chromaColor;
            sldBLUpDelay.Refresh();
            sldBLDelay.Color_4 = chromaColor;
            sldBLDelay.Refresh();
            sldJitterChance.Color_4 = chromaColor;
            sldJitterChance.Refresh();
            sldJitterX.Color_4 = chromaColor;
            sldJitterX.Refresh();
            sldJitterY.Color_4 = chromaColor;
            sldJitterY.Refresh();
            sldJitterMinimumDelay.Color_4 = chromaColor;
            sldJitterMinimumDelay.Refresh();
            sldJitterMaximumDelay.Color_4 = chromaColor;
            sldJitterMaximumDelay.Refresh();
            sldMinimumDebounce.Color_4 = chromaColor;
            sldMinimumDebounce.Refresh();
            sldMaximumDebounce.Color_4 = chromaColor;
            sldMaximumDebounce.Refresh();
            sldCheckInterval.Color_4 = chromaColor;
            sldCheckInterval.Refresh();
            sldClickVolume.Color_4 = chromaColor;
            sldClickVolume.Refresh();
            sldPlayerDuration.Color_4 = chromaColor;
            sldPlayerDuration.Refresh();
            sldSoundAbnormalChance.Color_4 = chromaColor;
            sldSoundAbnormalChance.Refresh();
            sldSoundAbnormalDelay.Color_4 = chromaColor;
            sldSoundAbnormalDelay.Refresh();
            sldMinimumPixels.Color_4 = chromaColor;
            sldMinimumPixels.Refresh();
            sldMaximumPixels.Color_4 = chromaColor;
            sldMaximumPixels.Refresh();
            MainForm.MainF.sldMinimumReach.Color_4 = chromaColor;
            MainForm.MainF.sldMinimumReach.Refresh();
            MainForm.MainF.sldMaximumReach.Color_4 = chromaColor;
            MainForm.MainF.sldMaximumReach.Refresh();
            MainForm.MainF.sldChance.Color_4 = chromaColor;
            MainForm.MainF.sldChance.Refresh();
            sldChromaInterval.Color_4 = chromaColor;
            sldChromaInterval.Refresh();
            sldKurtosis.Color_4 = chromaColor;
            sldKurtosis.Refresh();

            // Checkboxes

            cbToggle.Color_7 = chromaColor;
            cbToggle.Color_2 = chromaColor;
            cbShiftRefill.Color_7 = chromaColor;
            cbShiftRefill.Color_2 = chromaColor;
            cbBreakBlocks.Color_7 = chromaColor;
            cbBreakBlocks.Color_2 = chromaColor;
            cbMenus.Color_7 = chromaColor;
            cbMenus.Color_2 = chromaColor;
            cbBlatant.Color_7 = chromaColor;
            cbBlatant.Color_2 = chromaColor;
            cbRMBLock.Color_7 = chromaColor;
            cbRMBLock.Color_2 = chromaColor;
            cbNohitdelay.Color_7 = chromaColor;
            cbNohitdelay.Color_2 = chromaColor;
            cbShiftDisable.Color_7 = chromaColor;
            cbShiftDisable.Color_2 = chromaColor;
            cbMoving.Color_7 = chromaColor;
            cbMoving.Color_2 = chromaColor;
            cbExtraRand.Color_7 = chromaColor;
            cbExtraRand.Color_2 = chromaColor;
            cbAlwaysOn.Color_7 = chromaColor;
            cbAlwaysOn.Color_2 = chromaColor;
            cbBlockhit.Color_7 = chromaColor;
            cbBlockhit.Color_2 = chromaColor;
            cbJitter.Color_7 = chromaColor;
            cbJitter.Color_2 = chromaColor;
            cbDebounceDelay.Color_7 = chromaColor;
            cbDebounceDelay.Color_2 = chromaColor;
            cbClickSounds.Color_7 = chromaColor;
            cbClickSounds.Color_2 = chromaColor;
            cbFadeSound.Color_7 = chromaColor;
            cbFadeSound.Color_2 = chromaColor;
            cbChroma.Color_7 = chromaColor;
            cbChroma.Color_2 = chromaColor;
            cbGhostCapture.Color_7 = chromaColor;
            cbGhostCapture.Color_2 = chromaColor;
            cbUSNJournal.Color_7 = chromaColor;
            cbUSNJournal.Color_2 = chromaColor;
            cbRegistry.Color_7 = chromaColor;
            cbRegistry.Color_2 = chromaColor;
            cbRestartServices.Color_7 = chromaColor;
            cbRestartServices.Color_2 = chromaColor;
            cbClearStrings.Color_7 = chromaColor;
            cbClearStrings.Color_2 = chromaColor;
            cbTemp.Color_7 = chromaColor;
            cbTemp.Color_2 = chromaColor;
            cbLAVCrasher.Color_7 = chromaColor;
            cbLAVCrasher.Color_2 = chromaColor;
            cbClearDNS.Color_7 = chromaColor;
            cbClearDNS.Color_2 = chromaColor;
            cbShadows.Color_7 = chromaColor;
            cbShadows.Color_2 = chromaColor;
            cbClearDumps.Color_7 = chromaColor;
            cbClearDumps.Color_2 = chromaColor;
            cbPrefetch.Color_7 = chromaColor;
            cbPrefetch.Color_2 = chromaColor;
            cbMotionCheck.Color_7 = chromaColor;
            cbMotionCheck.Color_2 = chromaColor;
            MainForm.MainF.cbReach.Color_7 = chromaColor;
            MainForm.MainF.cbReach.Color_2 = chromaColor;
            MainForm.MainF.cbMoving.Color_7 = chromaColor;
            MainForm.MainF.cbMoving.Color_2 = chromaColor;
            MainForm.MainF.cbSprint.Color_7 = chromaColor;
            MainForm.MainF.cbSprint.Color_2 = chromaColor;
            MainForm.MainF.cbPlayerOnly.Color_7 = chromaColor;
            MainForm.MainF.cbPlayerOnly.Color_2 = chromaColor;
            MainForm.MainF.cbBlatantReach.Color_7 = chromaColor;
            MainForm.MainF.cbBlatantReach.Color_2 = chromaColor;
            cbTaskbarHide.Color_7 = chromaColor;
            cbTaskbarHide.Color_2 = chromaColor;

            //Slots
            SlotL1.Color_7 = chromaColor;
            SlotL1.Color_2 = chromaColor;
            SlotL2.Color_7 = chromaColor;
            SlotL2.Color_2 = chromaColor;
            SlotL3.Color_7 = chromaColor;
            SlotL3.Color_2 = chromaColor;
            SlotL4.Color_7 = chromaColor;
            SlotL4.Color_2 = chromaColor;
            SlotL5.Color_7 = chromaColor;
            SlotL5.Color_2 = chromaColor;
            SlotL6.Color_7 = chromaColor;
            SlotL6.Color_2 = chromaColor;
            SlotL7.Color_7 = chromaColor;
            SlotL7.Color_2 = chromaColor;
            SlotL8.Color_7 = chromaColor;
            SlotL8.Color_2 = chromaColor;
            SlotL9.Color_7 = chromaColor;
            SlotL9.Color_2 = chromaColor;

            // Labels
            lbVersion.ForeColor = chromaColor;

            //Combo Boxes
            LeftConditionals.HoverState.BorderColor = chromaColor;
            LeftConditionals.FocusedState.BorderColor = chromaColor;
            LeftConditionals.Refresh();
            ClickSoundChoice.HoverState.BorderColor = chromaColor;
            ClickSoundChoice.FocusedState.BorderColor = chromaColor;
            ClickSoundChoice.Refresh();
            // Values
            lbR.Text = chromaColor.R.ToString();
            lbG.Text = chromaColor.G.ToString();
            lbB.Text = chromaColor.B.ToString();
            lbHex.Text = "#" + chromaColor.R.ToString("X2") + chromaColor.G.ToString("X2") + chromaColor.B.ToString("X2");
        }

        private static Color ColorFromHSV(double h, double s, double v)
        {
            int hi = Convert.ToInt32(Math.Floor(h / 60)) % 6;
            double f = h / 60 - Math.Floor(h / 60);

            double value = v * 255;
            int vint = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - s));
            int q = Convert.ToInt32(value * (1 - f * s));
            int t = Convert.ToInt32(value * (1 - (1 - f) * s));

            switch (hi)
            {
                case 0:
                    return Color.FromArgb(vint, t, p);
                case 1:
                    return Color.FromArgb(q, vint, p);
                case 2:
                    return Color.FromArgb(p, vint, t);
                case 3:
                    return Color.FromArgb(p, q, vint);
                case 4:
                    return Color.FromArgb(t, p, vint);
                default:
                    return Color.FromArgb(vint, p, q);
            }
        }

        private const int WS_EX_TOOLWINDOW = 0x80;
        private const int GWL_EXSTYLE = -20;

        private void cbTaskbarHide_CheckedChanged(object sender, EventArgs e)
        {
			base.ShowInTaskbar = !base.ShowInTaskbar;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void flatTrackBar1_Event_0(object sender, EventArgs e)
        {
            lbChromaInterval.Text = (sldChromaInterval.Int32_0 / 1F).ToString("Chroma Interval: 0");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Environment.Exit(0);
        }

        private void sldKurtosis_Event_0(object sender, EventArgs e)
        {
            lbKurtosis.Text = (sldKurtosis.Int32_0 / 100F).ToString("Kurtosis: 0.#");
        }

        private void sldMinimumPixels_Event_0(object sender, EventArgs e)
        {
            lbMinimumPixel.Text = (sldMinimumPixels.Int32_0 / 1F).ToString("Minimum Pixel Amount: 0");
        }
        #endregion

    }
}
