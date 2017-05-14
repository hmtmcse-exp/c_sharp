namespace ScaffoldGenerator
{
    partial class Form1
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
            if (disposing && (components != null))
            {
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
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.displayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataType = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddUpdateButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(12, 44);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(293, 20);
            this.name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Display Name";
            // 
            // displayName
            // 
            this.displayName.Location = new System.Drawing.Point(12, 94);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(293, 20);
            this.displayName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Error Massage";
            // 
            // errorMessage
            // 
            this.errorMessage.Location = new System.Drawing.Point(12, 143);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(293, 20);
            this.errorMessage.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data Types";
            // 
            // dataType
            // 
            this.dataType.FormattingEnabled = true;
            this.dataType.Location = new System.Drawing.Point(12, 193);
            this.dataType.Name = "dataType";
            this.dataType.Size = new System.Drawing.Size(290, 21);
            this.dataType.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(327, 44);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(553, 520);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // AddUpdateButton
            // 
            this.AddUpdateButton.Location = new System.Drawing.Point(15, 483);
            this.AddUpdateButton.Name = "AddUpdateButton";
            this.AddUpdateButton.Size = new System.Drawing.Size(290, 23);
            this.AddUpdateButton.TabIndex = 4;
            this.AddUpdateButton.Text = "Add";
            this.AddUpdateButton.UseVisualStyleBackColor = true;
            this.AddUpdateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 541);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(290, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(15, 512);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(290, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.Clear);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 593);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddUpdateButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox displayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox errorMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dataType;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button AddUpdateButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button clearButton;
    }
}

