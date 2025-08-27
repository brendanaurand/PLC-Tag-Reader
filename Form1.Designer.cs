namespace Demo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tmrPLCHeartbeat = new System.Windows.Forms.Timer(components);
            btnHeartBeat = new Button();
            labelTagName = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // btnHeartBeat
            // 
            btnHeartBeat.Location = new Point(75, 87);
            btnHeartBeat.Name = "btnHeartBeat";
            btnHeartBeat.Size = new Size(94, 29);
            btnHeartBeat.TabIndex = 0;
            btnHeartBeat.Text = "HeartBeat";
            btnHeartBeat.UseVisualStyleBackColor = true;
            // 
            // labelTagName
            // 
            labelTagName.AutoSize = true;
            labelTagName.Location = new Point(502, 163);
            labelTagName.Name = "labelTagName";
            labelTagName.Size = new Size(79, 20);
            labelTagName.TabIndex = 1;
            labelTagName.Text = "Tag Status:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(267, 146);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(279, 123);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 3;
            label1.Text = "IP Adress: ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(480, 133);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(60, 123);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(labelTagName);
            Controls.Add(btnHeartBeat);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer tmrPLCHeartbeat;
        private Button btnHeartBeat;
        private Label labelTagName;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}
