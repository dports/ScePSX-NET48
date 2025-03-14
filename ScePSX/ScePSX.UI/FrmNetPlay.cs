using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using ScePSX.Properties;

namespace ScePSX.UI;

public class FrmNetPlay : Form
{
	private IContainer components;

	private Button btncli;

	private TextBox tblocalip;

	private Label label1;

	private Label label2;

	private TextBox tbsrvip;

	private Button btnsrv;

	private Label labhint;

	public FrmNetPlay()
	{
		InitializeComponent();
		tblocalip.Text = GetSuitableIPv4Address();
		tbsrvip.Text = tblocalip.Text;
	}

	public string GetSuitableIPv4Address()
	{
		foreach (NetworkInterface item in (from nic in NetworkInterface.GetAllNetworkInterfaces()
			where nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback && !IsVirtualNetworkInterface(nic)
			orderby nic.Speed descending
			select nic).ToList())
		{
			List<IPAddress> source = (from addr in item.GetIPProperties().UnicastAddresses
				where addr.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(addr.Address)
				select addr.Address).ToList();
			if (source.Any())
			{
				return source.First().ToString();
			}
		}
		return null;
	}

	private static bool IsVirtualNetworkInterface(NetworkInterface nic)
	{
		string[] source = new string[5] { "VMware", "VirtualBox", "Hyper-V", "TAP-Windows", "vEthernet" };
		string description = nic.Description?.ToLowerInvariant() ?? "";
		string name = nic.Name?.ToLowerInvariant() ?? "";
		return source.Any((string keyword) => description.Contains(keyword.ToLowerInvariant()) || name.Contains(keyword.ToLowerInvariant()));
	}

	private void btncli_Click(object sender, EventArgs e)
	{
		if (FrmMain.Core != null)
		{
			FrmMain.Core.PsxBus.SIO.Close();
			FrmMain.Core.PsxBus.SIO.Active(isSrv: false, tblocalip.Text, tbsrvip.Text);
			labhint.Text = Resources.FrmNetPlay_btncli_Click_已启用客户机模式;
		}
	}

	private void btnsrv_Click(object sender, EventArgs e)
	{
		if (FrmMain.Core != null)
		{
			FrmMain.Core.PsxBus.SIO.Close();
			FrmMain.Core.PsxBus.SIO.Active(isSrv: true, tblocalip.Text, tbsrvip.Text);
			labhint.Text = Resources.FrmNetPlay_btnsrv_Click_已启用主机模式;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.btncli = new System.Windows.Forms.Button();
		this.tblocalip = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.tbsrvip = new System.Windows.Forms.TextBox();
		this.btnsrv = new System.Windows.Forms.Button();
		this.labhint = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.btncli.Location = new System.Drawing.Point(157, 163);
		this.btncli.Name = "btncli";
		this.btncli.Size = new System.Drawing.Size(101, 29);
		this.btncli.TabIndex = 0;
		this.btncli.Text = ScePSX.Properties.Resources.FrmNetPlay_InitializeComponent_作为客户机启动;
		this.btncli.UseVisualStyleBackColor = true;
		this.btncli.Click += new System.EventHandler(btncli_Click);
		this.tblocalip.Location = new System.Drawing.Point(25, 49);
		this.tblocalip.Name = "tblocalip";
		this.tblocalip.Size = new System.Drawing.Size(233, 23);
		this.tblocalip.TabIndex = 1;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(25, 22);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(127, 17);
		this.label1.TabIndex = 2;
		this.label1.Text = ScePSX.Properties.Resources.FrmNetPlay_InitializeComponent_作为主机时的IP地址;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(25, 95);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(115, 17);
		this.label2.TabIndex = 3;
		this.label2.Text = ScePSX.Properties.Resources.FrmNetPlay_InitializeComponent_目标主机的IP地址;
		this.tbsrvip.Location = new System.Drawing.Point(25, 121);
		this.tbsrvip.Name = "tbsrvip";
		this.tbsrvip.Size = new System.Drawing.Size(233, 23);
		this.tbsrvip.TabIndex = 4;
		this.btnsrv.Location = new System.Drawing.Point(25, 163);
		this.btnsrv.Name = "btnsrv";
		this.btnsrv.Size = new System.Drawing.Size(104, 29);
		this.btnsrv.TabIndex = 5;
		this.btnsrv.Text = ScePSX.Properties.Resources.FrmNetPlay_InitializeComponent_作为主机启动;
		this.btnsrv.UseVisualStyleBackColor = true;
		this.btnsrv.Click += new System.EventHandler(btnsrv_Click);
		this.labhint.AutoSize = true;
		this.labhint.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.labhint.Location = new System.Drawing.Point(25, 199);
		this.labhint.Name = "labhint";
		this.labhint.Size = new System.Drawing.Size(107, 19);
		this.labhint.TabIndex = 6;
		this.labhint.Text = ScePSX.Properties.Resources.FrmNetPlay_InitializeComponent_未启动网络对战;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(280, 225);
		base.Controls.Add(this.labhint);
		base.Controls.Add(this.btnsrv);
		base.Controls.Add(this.tbsrvip);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.tblocalip);
		base.Controls.Add(this.btncli);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "FrmNetPlay";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "NetPlay";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
