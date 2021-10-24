namespace ReactWinforms
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.inputControl1 = new ReactWinforms.InputControl();
      this.outputControl1 = new ReactWinforms.OutputControl();
      this.tableLayoutPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
      this.tableLayoutPanel.ColumnCount = 1;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel.Controls.Add(this.inputControl1, 0, 0);
      this.tableLayoutPanel.Controls.Add(this.outputControl1, 0, 1);
      this.tableLayoutPanel.ForeColor = System.Drawing.SystemColors.ControlText;
      this.tableLayoutPanel.Location = new System.Drawing.Point(2, 0);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 3;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.7277F));
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.2723F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(392, 505);
      this.tableLayoutPanel.TabIndex = 0;
      // 
      // inputControl1
      // 
      this.inputControl1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.inputControl1.Location = new System.Drawing.Point(3, 3);
      this.inputControl1.Name = "inputControl1";
      this.inputControl1.Size = new System.Drawing.Size(386, 60);
      this.inputControl1.TabIndex = 0;
      // 
      // outputControl1
      // 
      this.outputControl1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.outputControl1.Location = new System.Drawing.Point(3, 71);
      this.outputControl1.Name = "outputControl1";
      this.outputControl1.Size = new System.Drawing.Size(386, 64);
      this.outputControl1.TabIndex = 1;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(393, 506);
      this.Controls.Add(this.tableLayoutPanel);
      this.Name = "MainForm";
      this.Text = "ReactWin";
      this.tableLayoutPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private InputControl inputControl1;
    private OutputControl outputControl1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
  }
}

