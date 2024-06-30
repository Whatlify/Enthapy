using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enthapy;

namespace ns0;

public sealed class MainForm : UserControl
{
	[CompilerGenerated]
	private static MainForm mainForm_0;

	public static uint uint_0;

	private IContainer icontainer_0;
    private IContainer components;
    private Label label44;
    public FlatCheckBox cbMoving;
    private Label lbMaximumReach;
    public FlatTrackBar sldMaximumReach;
    public FlatCheckBox cbReach;
    private Label lbMinimumReach;
    private FlatPanel flatPanel1;
    private Label lbReachChance;
    public FlatTrackBar sldChance;
    private Label label1;
    public FlatCheckBox cbSprint;
    private Label label2;
    public FlatCheckBox cbPlayerOnly;
    private Label label3;
    public FlatCheckBox cbBlatantReach;
    public FlatTrackBar sldMinimumReach;

	public static MainForm MainF
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

	public MainForm()
	{
		InitializeComponent();
		MainF = this;
		Text = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 6);
        sldMinimumReach.Int32_0 = 300;
        sldMaximumReach.Int32_0 = 307;
        sldMinimumReach.Int32_1 = 300;
        sldMaximumReach.Int32_1 = 300;
        Task.Run(() => Locator.GetWindowThreadProcessId(Locator.FindWindow("LWJGL", null), out uint_0));
		Task.Run(delegate
		{
			Reach.Reach1();
		});
		Task.Run(delegate
		{
			Reach.Reach0();
		});
		method_0(bool_0: true);
	}

	public void method_0(bool bool_0)
	{
		IntPtr consoleWindow = Locator.GetConsoleWindow();
		if (bool_0)
		{
			Locator.ShowWindow(consoleWindow, 0);
		}
		else
		{
			Locator.ShowWindow(consoleWindow, 5);
		}
	}

	private void lblReach_Click(object sender, EventArgs e)
	{
		cbReach.Checked = !cbReach.Checked;
	}

	private void lblMoving_Click(object sender, EventArgs e)
	{
		cbMoving.Checked = !cbMoving.Checked;
	}

	private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		Hide();
		Reach.bool_0 = true;
		cbReach.Checked = false;
		foreach (Control control in Controls)
		{
			control.Dispose();
		}
		Task.Delay(1000).Wait();
		Dispose();
		Environment.Exit(1);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
            this.flatPanel1 = new FlatPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPlayerOnly = new FlatCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSprint = new FlatCheckBox();
            this.lbReachChance = new System.Windows.Forms.Label();
            this.sldChance = new FlatTrackBar();
            this.cbReach = new FlatCheckBox();
            this.label44 = new System.Windows.Forms.Label();
            this.sldMinimumReach = new FlatTrackBar();
            this.cbMoving = new FlatCheckBox();
            this.lbMinimumReach = new System.Windows.Forms.Label();
            this.lbMaximumReach = new System.Windows.Forms.Label();
            this.sldMaximumReach = new FlatTrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBlatantReach = new FlatCheckBox();
            this.flatPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flatPanel1
            // 
            this.flatPanel1.Color_0 = System.Drawing.Color.Empty;
            this.flatPanel1.Color_1 = System.Drawing.Color.Empty;
            this.flatPanel1.Color_2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.flatPanel1.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.flatPanel1.Controls.Add(this.label3);
            this.flatPanel1.Controls.Add(this.cbBlatantReach);
            this.flatPanel1.Controls.Add(this.label2);
            this.flatPanel1.Controls.Add(this.cbPlayerOnly);
            this.flatPanel1.Controls.Add(this.label1);
            this.flatPanel1.Controls.Add(this.cbSprint);
            this.flatPanel1.Controls.Add(this.lbReachChance);
            this.flatPanel1.Controls.Add(this.sldChance);
            this.flatPanel1.Controls.Add(this.cbReach);
            this.flatPanel1.Controls.Add(this.label44);
            this.flatPanel1.Controls.Add(this.sldMinimumReach);
            this.flatPanel1.Controls.Add(this.cbMoving);
            this.flatPanel1.Controls.Add(this.lbMinimumReach);
            this.flatPanel1.Controls.Add(this.lbMaximumReach);
            this.flatPanel1.Controls.Add(this.sldMaximumReach);
            this.flatPanel1.Location = new System.Drawing.Point(3, 3);
            this.flatPanel1.Name = "flatPanel1";
            this.flatPanel1.Padding_0 = new System.Windows.Forms.Padding(0);
            this.flatPanel1.Padding_1 = new System.Windows.Forms.Padding(0);
            this.flatPanel1.Single_0 = 1F;
            this.flatPanel1.Single_1 = 1F;
            this.flatPanel1.Single_2 = 1F;
            this.flatPanel1.Size = new System.Drawing.Size(315, 381);
            this.flatPanel1.TabIndex = 131;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 8.7F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(48, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 26);
            this.label2.TabIndex = 136;
            this.label2.Text = "Player Only";
            // 
            // cbPlayerOnly
            // 
            this.cbPlayerOnly.Boolean_0 = true;
            this.cbPlayerOnly.Color_0 = System.Drawing.Color.Empty;
            this.cbPlayerOnly.Color_1 = System.Drawing.Color.Empty;
            this.cbPlayerOnly.Color_2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbPlayerOnly.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbPlayerOnly.Color_4 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbPlayerOnly.Color_5 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbPlayerOnly.Color_6 = System.Drawing.Color.White;
            this.cbPlayerOnly.Color_7 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbPlayerOnly.Color_8 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbPlayerOnly.Color_9 = System.Drawing.Color.Empty;
            this.cbPlayerOnly.Int32_0 = 0;
            this.cbPlayerOnly.Int32_1 = 0;
            this.cbPlayerOnly.Int32_2 = 3;
            this.cbPlayerOnly.Location = new System.Drawing.Point(20, 233);
            this.cbPlayerOnly.Name = "cbPlayerOnly";
            this.cbPlayerOnly.Padding_0 = new System.Windows.Forms.Padding(0);
            this.cbPlayerOnly.Padding_1 = new System.Windows.Forms.Padding(0);
            this.cbPlayerOnly.Padding_2 = new System.Windows.Forms.Padding(0);
            this.cbPlayerOnly.Single_0 = 1F;
            this.cbPlayerOnly.Single_1 = 1F;
            this.cbPlayerOnly.Size = new System.Drawing.Size(21, 20);
            this.cbPlayerOnly.String_0 = "Center";
            this.cbPlayerOnly.String_1 = "";
            this.cbPlayerOnly.TabIndex = 135;
            this.cbPlayerOnly.Text = "flatCheckBox17";
            this.cbPlayerOnly.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 8.7F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(48, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 134;
            this.label1.Text = "Only On Sprint";
            // 
            // cbSprint
            // 
            this.cbSprint.Boolean_0 = true;
            this.cbSprint.Color_0 = System.Drawing.Color.Empty;
            this.cbSprint.Color_1 = System.Drawing.Color.Empty;
            this.cbSprint.Color_2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbSprint.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbSprint.Color_4 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbSprint.Color_5 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbSprint.Color_6 = System.Drawing.Color.White;
            this.cbSprint.Color_7 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbSprint.Color_8 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbSprint.Color_9 = System.Drawing.Color.Empty;
            this.cbSprint.Int32_0 = 0;
            this.cbSprint.Int32_1 = 0;
            this.cbSprint.Int32_2 = 3;
            this.cbSprint.Location = new System.Drawing.Point(20, 207);
            this.cbSprint.Name = "cbSprint";
            this.cbSprint.Padding_0 = new System.Windows.Forms.Padding(0);
            this.cbSprint.Padding_1 = new System.Windows.Forms.Padding(0);
            this.cbSprint.Padding_2 = new System.Windows.Forms.Padding(0);
            this.cbSprint.Single_0 = 1F;
            this.cbSprint.Single_1 = 1F;
            this.cbSprint.Size = new System.Drawing.Size(21, 20);
            this.cbSprint.String_0 = "Center";
            this.cbSprint.String_1 = "";
            this.cbSprint.TabIndex = 133;
            this.cbSprint.Text = "flatCheckBox17";
            this.cbSprint.UseVisualStyleBackColor = true;
            // 
            // lbReachChance
            // 
            this.lbReachChance.AutoSize = true;
            this.lbReachChance.Font = new System.Drawing.Font("Poppins", 8.7F);
            this.lbReachChance.ForeColor = System.Drawing.Color.White;
            this.lbReachChance.Location = new System.Drawing.Point(15, 121);
            this.lbReachChance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbReachChance.Name = "lbReachChance";
            this.lbReachChance.Size = new System.Drawing.Size(97, 26);
            this.lbReachChance.TabIndex = 132;
            this.lbReachChance.Text = "Chance: 80";
            // 
            // sldChance
            // 
            this.sldChance.Boolean_0 = false;
            this.sldChance.Boolean_1 = true;
            this.sldChance.Color_0 = System.Drawing.Color.Empty;
            this.sldChance.Color_1 = System.Drawing.Color.Empty;
            this.sldChance.Color_2 = System.Drawing.Color.Empty;
            this.sldChance.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.sldChance.Color_4 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.sldChance.Color_5 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.sldChance.Int32_0 = 80;
            this.sldChance.Int32_3 = 8;
            this.sldChance.Location = new System.Drawing.Point(20, 150);
            this.sldChance.Name = "sldChance";
            this.sldChance.ShowText = false;
            this.sldChance.Single_0 = 1F;
            this.sldChance.Single_1 = 1F;
            this.sldChance.Size = new System.Drawing.Size(275, 16);
            this.sldChance.TabIndex = 131;
            this.sldChance.Text = "flatTrackBar1";
            this.sldChance.Event_0 += new System.EventHandler(this.sldChance_Event_0);
            // 
            // cbReach
            // 
            this.cbReach.Boolean_0 = true;
            this.cbReach.Color_0 = System.Drawing.Color.Empty;
            this.cbReach.Color_1 = System.Drawing.Color.Empty;
            this.cbReach.Color_2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbReach.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbReach.Color_4 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbReach.Color_5 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbReach.Color_6 = System.Drawing.Color.White;
            this.cbReach.Color_7 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbReach.Color_8 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbReach.Color_9 = System.Drawing.Color.Empty;
            this.cbReach.Int32_0 = 0;
            this.cbReach.Int32_1 = 0;
            this.cbReach.Int32_2 = 3;
            this.cbReach.Location = new System.Drawing.Point(276, 12);
            this.cbReach.Name = "cbReach";
            this.cbReach.Padding_0 = new System.Windows.Forms.Padding(0);
            this.cbReach.Padding_1 = new System.Windows.Forms.Padding(0);
            this.cbReach.Padding_2 = new System.Windows.Forms.Padding(0);
            this.cbReach.Single_0 = 1F;
            this.cbReach.Single_1 = 1F;
            this.cbReach.Size = new System.Drawing.Size(21, 20);
            this.cbReach.String_0 = "Center";
            this.cbReach.String_1 = "";
            this.cbReach.TabIndex = 126;
            this.cbReach.Text = "flatCheckBox17";
            this.cbReach.UseVisualStyleBackColor = true;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Poppins", 8.7F);
            this.label44.ForeColor = System.Drawing.Color.White;
            this.label44.Location = new System.Drawing.Point(48, 179);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(109, 26);
            this.label44.TabIndex = 130;
            this.label44.Text = "Strafing Only";
            // 
            // sldMinimumReach
            // 
            this.sldMinimumReach.Boolean_0 = false;
            this.sldMinimumReach.Boolean_1 = true;
            this.sldMinimumReach.Color_0 = System.Drawing.Color.Empty;
            this.sldMinimumReach.Color_1 = System.Drawing.Color.Empty;
            this.sldMinimumReach.Color_2 = System.Drawing.Color.Empty;
            this.sldMinimumReach.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.sldMinimumReach.Color_4 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.sldMinimumReach.Color_5 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.sldMinimumReach.Int32_2 = 600;
            this.sldMinimumReach.Int32_3 = 8;
            this.sldMinimumReach.Location = new System.Drawing.Point(22, 39);
            this.sldMinimumReach.Name = "sldMinimumReach";
            this.sldMinimumReach.ShowText = false;
            this.sldMinimumReach.Single_0 = 1F;
            this.sldMinimumReach.Single_1 = 1F;
            this.sldMinimumReach.Size = new System.Drawing.Size(275, 16);
            this.sldMinimumReach.TabIndex = 124;
            this.sldMinimumReach.Text = "flatTrackBar1";
            this.sldMinimumReach.Event_0 += new System.EventHandler(this.sldMinimumReach_Event_0);
            // 
            // cbMoving
            // 
            this.cbMoving.Boolean_0 = true;
            this.cbMoving.Color_0 = System.Drawing.Color.Empty;
            this.cbMoving.Color_1 = System.Drawing.Color.Empty;
            this.cbMoving.Color_2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbMoving.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbMoving.Color_4 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbMoving.Color_5 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbMoving.Color_6 = System.Drawing.Color.White;
            this.cbMoving.Color_7 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbMoving.Color_8 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbMoving.Color_9 = System.Drawing.Color.Empty;
            this.cbMoving.Int32_0 = 0;
            this.cbMoving.Int32_1 = 0;
            this.cbMoving.Int32_2 = 3;
            this.cbMoving.Location = new System.Drawing.Point(20, 181);
            this.cbMoving.Name = "cbMoving";
            this.cbMoving.Padding_0 = new System.Windows.Forms.Padding(0);
            this.cbMoving.Padding_1 = new System.Windows.Forms.Padding(0);
            this.cbMoving.Padding_2 = new System.Windows.Forms.Padding(0);
            this.cbMoving.Single_0 = 1F;
            this.cbMoving.Single_1 = 1F;
            this.cbMoving.Size = new System.Drawing.Size(21, 20);
            this.cbMoving.String_0 = "Center";
            this.cbMoving.String_1 = "";
            this.cbMoving.TabIndex = 129;
            this.cbMoving.Text = "flatCheckBox17";
            this.cbMoving.UseVisualStyleBackColor = true;
            // 
            // lbMinimumReach
            // 
            this.lbMinimumReach.AutoSize = true;
            this.lbMinimumReach.Font = new System.Drawing.Font("Poppins", 8.7F);
            this.lbMinimumReach.ForeColor = System.Drawing.Color.White;
            this.lbMinimumReach.Location = new System.Drawing.Point(17, 10);
            this.lbMinimumReach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMinimumReach.Name = "lbMinimumReach";
            this.lbMinimumReach.Size = new System.Drawing.Size(171, 26);
            this.lbMinimumReach.TabIndex = 125;
            this.lbMinimumReach.Text = "Minimum Reach: 3.00";
            // 
            // lbMaximumReach
            // 
            this.lbMaximumReach.AutoSize = true;
            this.lbMaximumReach.Font = new System.Drawing.Font("Poppins", 8.7F);
            this.lbMaximumReach.ForeColor = System.Drawing.Color.White;
            this.lbMaximumReach.Location = new System.Drawing.Point(15, 64);
            this.lbMaximumReach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaximumReach.Name = "lbMaximumReach";
            this.lbMaximumReach.Size = new System.Drawing.Size(173, 26);
            this.lbMaximumReach.TabIndex = 128;
            this.lbMaximumReach.Text = "Maximum Reach: 3.07";
            // 
            // sldMaximumReach
            // 
            this.sldMaximumReach.Boolean_0 = false;
            this.sldMaximumReach.Boolean_1 = true;
            this.sldMaximumReach.Color_0 = System.Drawing.Color.Empty;
            this.sldMaximumReach.Color_1 = System.Drawing.Color.Empty;
            this.sldMaximumReach.Color_2 = System.Drawing.Color.Empty;
            this.sldMaximumReach.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.sldMaximumReach.Color_4 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.sldMaximumReach.Color_5 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.sldMaximumReach.Int32_2 = 600;
            this.sldMaximumReach.Int32_3 = 8;
            this.sldMaximumReach.Location = new System.Drawing.Point(20, 93);
            this.sldMaximumReach.Name = "sldMaximumReach";
            this.sldMaximumReach.ShowText = false;
            this.sldMaximumReach.Single_0 = 1F;
            this.sldMaximumReach.Single_1 = 1F;
            this.sldMaximumReach.Size = new System.Drawing.Size(275, 16);
            this.sldMaximumReach.TabIndex = 127;
            this.sldMaximumReach.Text = "flatTrackBar1";
            this.sldMaximumReach.Event_0 += new System.EventHandler(this.sldMaximumReach_Event_0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 8.7F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(48, 259);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 26);
            this.label3.TabIndex = 138;
            this.label3.Text = "Blatant Mode";
            // 
            // cbBlatantReach
            // 
            this.cbBlatantReach.Boolean_0 = true;
            this.cbBlatantReach.Color_0 = System.Drawing.Color.Empty;
            this.cbBlatantReach.Color_1 = System.Drawing.Color.Empty;
            this.cbBlatantReach.Color_2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbBlatantReach.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbBlatantReach.Color_4 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.cbBlatantReach.Color_5 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbBlatantReach.Color_6 = System.Drawing.Color.White;
            this.cbBlatantReach.Color_7 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
        this.cbBlatantReach.Color_8 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbBlatantReach.Color_9 = System.Drawing.Color.Empty;
            this.cbBlatantReach.Int32_0 = 0;
            this.cbBlatantReach.Int32_1 = 0;
            this.cbBlatantReach.Int32_2 = 3;
            this.cbBlatantReach.Location = new System.Drawing.Point(20, 259);
            this.cbBlatantReach.Name = "cbBlatantReach";
            this.cbBlatantReach.Padding_0 = new System.Windows.Forms.Padding(0);
            this.cbBlatantReach.Padding_1 = new System.Windows.Forms.Padding(0);
            this.cbBlatantReach.Padding_2 = new System.Windows.Forms.Padding(0);
            this.cbBlatantReach.Single_0 = 1F;
            this.cbBlatantReach.Single_1 = 1F;
            this.cbBlatantReach.Size = new System.Drawing.Size(21, 20);
            this.cbBlatantReach.String_0 = "Center";
            this.cbBlatantReach.String_1 = "";
            this.cbBlatantReach.TabIndex = 137;
            this.cbBlatantReach.Text = "flatCheckBox17";
            this.cbBlatantReach.UseVisualStyleBackColor = true;
            this.cbBlatantReach.CheckedChanged += new System.EventHandler(this.flatCheckBox1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.Controls.Add(this.flatPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(319, 390);
            this.flatPanel1.ResumeLayout(false);
            this.flatPanel1.PerformLayout();
            this.ResumeLayout(false);

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

    private void sldChance_Event_0(object sender, EventArgs e)
    {
        lbReachChance.Text = (sldChance.Int32_0 / 1F).ToString("Chance: 0");
    }

    private void flatCheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (cbBlatantReach.Checked)
        {
            sldMinimumReach.Int32_2 = 1000;
            sldMaximumReach.Int32_2 = 1000;
        }

        else
        {
            sldMinimumReach.Int32_2 = 600;
            sldMaximumReach.Int32_2 = 600;
        }
    }
}
