namespace ReactWinforms.WinformControlls
{
  partial class InputControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.inputTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // inputTextBox
      // 
      this.inputTextBox.Location = new System.Drawing.Point(3, 26);
      this.inputTextBox.Name = "inputTextBox";
      this.inputTextBox.Size = new System.Drawing.Size(305, 20);
      this.inputTextBox.TabIndex = 0;
      this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(78, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Winforms-Input";
      // 
      // InputControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.inputTextBox);
      this.Name = "InputControl";
      this.Size = new System.Drawing.Size(311, 110);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox inputTextBox;
    private System.Windows.Forms.Label label1;
  }
}
