namespace RunConti
{
	partial class FormMain
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.listBoxComs = new System.Windows.Forms.ListBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewPatterns = new System.Windows.Forms.ListView();
            this.chPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPattern = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPatternExec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripAddPattern = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.prioUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxCommand = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStripAddPattern.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxComs
            // 
            this.listBoxComs.AllowDrop = true;
            this.listBoxComs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxComs.FormattingEnabled = true;
            this.listBoxComs.ItemHeight = 15;
            this.listBoxComs.Location = new System.Drawing.Point(14, 227);
            this.listBoxComs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxComs.Name = "listBoxComs";
            this.listBoxComs.Size = new System.Drawing.Size(848, 109);
            this.listBoxComs.TabIndex = 1;
            this.listBoxComs.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxComs_DragDrop);
            this.listBoxComs.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxComs_DragEnter);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.BackColor = System.Drawing.Color.Black;
            this.textBoxLog.ForeColor = System.Drawing.Color.Gold;
            this.textBoxLog.Location = new System.Drawing.Point(14, 367);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(848, 236);
            this.textBoxLog.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Command   %F→Full path / %f→full path w/o file extention";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Drop files here to run above command";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Console";
            // 
            // listViewPatterns
            // 
            this.listViewPatterns.CheckBoxes = true;
            this.listViewPatterns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPriority,
            this.chName,
            this.chPattern,
            this.chPatternExec,
            this.chCommand});
            this.listViewPatterns.ContextMenuStrip = this.contextMenuStripAddPattern;
            this.listViewPatterns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPatterns.FullRowSelect = true;
            this.listViewPatterns.GridLines = true;
            this.listViewPatterns.HideSelection = false;
            this.listViewPatterns.Location = new System.Drawing.Point(3, 3);
            this.listViewPatterns.Name = "listViewPatterns";
            this.listViewPatterns.Size = new System.Drawing.Size(836, 159);
            this.listViewPatterns.TabIndex = 5;
            this.listViewPatterns.UseCompatibleStateImageBehavior = false;
            this.listViewPatterns.View = System.Windows.Forms.View.Details;
            this.listViewPatterns.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewPatterns_ItemChecked);
            // 
            // chPriority
            // 
            this.chPriority.Text = "Priority";
            this.chPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPriority.Width = 40;
            // 
            // chName
            // 
            this.chName.Text = "Pattern Name";
            this.chName.Width = 95;
            // 
            // chPattern
            // 
            this.chPattern.Text = "Match Pattern (Regex)";
            this.chPattern.Width = 202;
            // 
            // chPatternExec
            // 
            this.chPatternExec.Text = "Checker tool";
            this.chPatternExec.Width = 139;
            // 
            // chCommand
            // 
            this.chCommand.Text = "Command";
            this.chCommand.Width = 300;
            // 
            // contextMenuStripAddPattern
            // 
            this.contextMenuStripAddPattern.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddPattern,
            this.editToolStripMenuItem,
            this.tsmiDelPattern,
            this.toolStripSeparator1,
            this.prioUpToolStripMenuItem});
            this.contextMenuStripAddPattern.Name = "contextMenuStripAddPattern";
            this.contextMenuStripAddPattern.Size = new System.Drawing.Size(135, 98);
            this.contextMenuStripAddPattern.Text = "パターン追加";
            this.contextMenuStripAddPattern.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripAddPattern_Opening);
            // 
            // tsmiAddPattern
            // 
            this.tsmiAddPattern.Image = global::RunConti.Properties.Resources.Plus;
            this.tsmiAddPattern.Name = "tsmiAddPattern";
            this.tsmiAddPattern.Size = new System.Drawing.Size(134, 22);
            this.tsmiAddPattern.Text = "パターン追加";
            this.tsmiAddPattern.Click += new System.EventHandler(this.tsmiAddPattern_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::RunConti.Properties.Resources.Pen;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.editToolStripMenuItem.Text = "修正";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // tsmiDelPattern
            // 
            this.tsmiDelPattern.Image = global::RunConti.Properties.Resources.Eraser;
            this.tsmiDelPattern.Name = "tsmiDelPattern";
            this.tsmiDelPattern.Size = new System.Drawing.Size(134, 22);
            this.tsmiDelPattern.Text = "パターン削除";
            this.tsmiDelPattern.Click += new System.EventHandler(this.tsmiDelPattern_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // prioUpToolStripMenuItem
            // 
            this.prioUpToolStripMenuItem.Image = global::RunConti.Properties.Resources.prioup;
            this.prioUpToolStripMenuItem.Name = "prioUpToolStripMenuItem";
            this.prioUpToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.prioUpToolStripMenuItem.Text = "優先上げる";
            this.prioUpToolStripMenuItem.Click += new System.EventHandler(this.prioUpToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(850, 193);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.comboBoxCommand);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(842, 165);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Command";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(10, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Example";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(13, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(826, 16);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "cwebp -q 45 -alpha_q 90 %F -o %f.webp";
            // 
            // comboBoxCommand
            // 
            this.comboBoxCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCommand.FormattingEnabled = true;
            this.comboBoxCommand.Location = new System.Drawing.Point(13, 50);
            this.comboBoxCommand.Name = "comboBoxCommand";
            this.comboBoxCommand.Size = new System.Drawing.Size(826, 23);
            this.comboBoxCommand.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listViewPatterns);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(842, 165);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pattern Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 616);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.listBoxComs);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "RunConti";
            this.contextMenuStripAddPattern.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListBox listBoxComs;
		private System.Windows.Forms.TextBox textBoxLog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView listViewPatterns;
		private System.Windows.Forms.ColumnHeader chPriority;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chPattern;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ComboBox comboBoxCommand;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripAddPattern;
		private System.Windows.Forms.ToolStripMenuItem tsmiAddPattern;
		private System.Windows.Forms.ToolStripMenuItem tsmiDelPattern;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader chPatternExec;
		private System.Windows.Forms.ColumnHeader chCommand;
		private System.Windows.Forms.ToolStripMenuItem prioUpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}

