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
            labelPartNumber = new Label();
            textBox1 = new TextBox();
            labelIPAddress = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            labelTriggerTag = new Label();
            SuspendLayout();
            // 
            // btnHeartBeat
            // 
            btnHeartBeat.Location = new Point(106, 129);
            btnHeartBeat.Name = "btnHeartBeat";
            btnHeartBeat.Size = new Size(94, 29);
            btnHeartBeat.TabIndex = 0;
            btnHeartBeat.Text = "HeartBeat";
            btnHeartBeat.UseVisualStyleBackColor = true;
            // 
            // labelPartNumber
            // 
            labelPartNumber.AutoSize = true;
            labelPartNumber.Location = new Point(121, 73);
            labelPartNumber.Name = "labelPartNumber";
            labelPartNumber.Size = new Size(79, 20);
            labelPartNumber.TabIndex = 1;
            labelPartNumber.Text = "Part Number:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(75, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // labelIPAddress
            // 
            labelIPAddress.AutoSize = true;
            labelIPAddress.Location = new Point(124, 20);
            labelIPAddress.Name = "labelIPAddress";
            labelIPAddress.Size = new Size(76, 20);
            labelIPAddress.TabIndex = 3;
            labelIPAddress.Text = "IP Adress: ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(75, 96);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(75, 164);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(262, 43);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 6;
            // 
            // labelTriggerTag
            // 
            labelTriggerTag.AutoSize = true;
            labelTriggerTag.Location = new Point(262, 20);
            labelTriggerTag.Name = "labelTriggerTag";
            labelTriggerTag.Size = new Size(86, 20);
            labelTriggerTag.TabIndex = 7;
            labelTriggerTag.Text = "Trigger Tag:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(labelTriggerTag);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(labelIPAddress);
            Controls.Add(textBox1);
            Controls.Add(labelPartNumber);
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
        private TextBox textBox1;
        private Label labelIPAddress;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label labelTriggerTag;
        public Label labelPartNumber;
    }
}
