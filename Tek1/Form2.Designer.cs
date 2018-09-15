namespace Tek1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.sfd1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bReset = new System.Windows.Forms.Button();
            this.bSolve = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.ttSolve = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(500, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 54);
            this.button2.TabIndex = 1;
            this.button2.Tag = "1";
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(500, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 54);
            this.button3.TabIndex = 2;
            this.button3.Tag = "2";
            this.button3.Text = "2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(500, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 54);
            this.button4.TabIndex = 3;
            this.button4.Tag = "3";
            this.button4.Text = "3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(500, 205);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 54);
            this.button5.TabIndex = 4;
            this.button5.Tag = "4";
            this.button5.Text = "4";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(500, 265);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(55, 54);
            this.button6.TabIndex = 5;
            this.button6.Tag = "5";
            this.button6.Text = "5";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button2_Click);
            // 
            // ofd1
            // 
            this.ofd1.DefaultExt = "tx";
            this.ofd1.FileName = "9x7-1.tx";
            this.ofd1.Filter = "tx files (*.tx)|*.tx|All files (*.*)|*.*";
            this.ofd1.InitialDirectory = "U:\\repos\\Tek1\\Tek1\\bin\\Debug\\";
            this.ofd1.Title = "Open TEK file";
            // 
            // sfd1
            // 
            this.sfd1.CreatePrompt = true;
            this.sfd1.DefaultExt = "tx";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 450);
            this.panel1.TabIndex = 9;
            // 
            // bReset
            // 
            this.bReset.BackgroundImage = global::Tek1.Properties.Resources.reset1;
            this.bReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bReset.Location = new System.Drawing.Point(561, 353);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(54, 54);
            this.bReset.TabIndex = 8;
            this.ttSolve.SetToolTip(this.bReset, "Reset the puzzle");
            this.bReset.UseCompatibleTextRendering = true;
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bSolve
            // 
            this.bSolve.BackgroundImage = global::Tek1.Properties.Resources.solve;
            this.bSolve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bSolve.Location = new System.Drawing.Point(501, 353);
            this.bSolve.Name = "bSolve";
            this.bSolve.Size = new System.Drawing.Size(54, 54);
            this.bSolve.TabIndex = 7;
            this.ttSolve.SetToolTip(this.bSolve, "Solve the puzzle");
            this.bSolve.UseVisualStyleBackColor = true;
            this.bSolve.Click += new System.EventHandler(this.bSolveClick);
            // 
            // bSave
            // 
            this.bSave.BackgroundImage = global::Tek1.Properties.Resources.save_new;
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSave.Location = new System.Drawing.Point(745, 353);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(43, 43);
            this.bSave.TabIndex = 6;
            this.bSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttSolve.SetToolTip(this.bSave, "Save the current state to a file");
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bLoad
            // 
            this.bLoad.BackgroundImage = global::Tek1.Properties.Resources.open_new;
            this.bLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bLoad.Location = new System.Drawing.Point(696, 353);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(43, 43);
            this.bLoad.TabIndex = 0;
            this.bLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttSolve.SetToolTip(this.bLoad, "Load a new puzzle from a file");
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(619, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 129);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notes";
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(89, 82);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(30, 30);
            this.button10.TabIndex = 15;
            this.button10.Tag = "1";
            this.button10.Text = "5";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button1_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(15, 82);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(30, 30);
            this.button9.TabIndex = 14;
            this.button9.Tag = "1";
            this.button9.Text = "4";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(52, 56);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(30, 30);
            this.button8.TabIndex = 13;
            this.button8.Tag = "1";
            this.button8.Text = "3";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(89, 25);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(30, 30);
            this.button7.TabIndex = 12;
            this.button7.Tag = "1";
            this.button7.Text = "2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 11;
            this.button1.Tag = "1";
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.bSolve);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bLoad);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.SaveFileDialog sfd1;
        private System.Windows.Forms.Button bSolve;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip ttSolve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
    }
}