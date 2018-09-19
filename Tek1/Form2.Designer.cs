﻿namespace Tek1
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
            this.ttSolve = new System.Windows.Forms.ToolTip(this.components);
            this.button13 = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.bSolve = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.split = new System.Windows.Forms.SplitContainer();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(15, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 54);
            this.button2.TabIndex = 1;
            this.button2.Tag = "1";
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button_ToggleValue_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(15, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 54);
            this.button3.TabIndex = 2;
            this.button3.Tag = "2";
            this.button3.Text = "2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button_ToggleValue_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(15, 150);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 54);
            this.button4.TabIndex = 3;
            this.button4.Tag = "3";
            this.button4.Text = "3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button_ToggleValue_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(15, 210);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(56, 54);
            this.button5.TabIndex = 4;
            this.button5.Tag = "4";
            this.button5.Text = "4";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button_ToggleValue_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(15, 270);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(56, 54);
            this.button6.TabIndex = 5;
            this.button6.Tag = "5";
            this.button6.Text = "5";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button_ToggleValue_Click);
            // 
            // ofd1
            // 
            this.ofd1.DefaultExt = "tx";
            this.ofd1.FileName = "9x7-1.tx";
            this.ofd1.Filter = "tx files (*.tx)|*.tx|All files (*.*)|*.*";
            this.ofd1.Title = "Open TEK file";
            // 
            // sfd1
            // 
            this.sfd1.CreatePrompt = true;
            this.sfd1.DefaultExt = "tx";
            // 
            // button13
            // 
            this.button13.BackgroundImage = global::Tek1.Properties.Resources.rstore23;
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button13.Location = new System.Drawing.Point(400, 250);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(54, 54);
            this.button13.TabIndex = 14;
            this.ttSolve.SetToolTip(this.button13, "Restore a snapshot");
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // bSave
            // 
            this.bSave.BackgroundImage = global::Tek1.Properties.Resources.save_new;
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSave.Location = new System.Drawing.Point(390, 112);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(44, 43);
            this.bSave.TabIndex = 6;
            this.bSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttSolve.SetToolTip(this.bSave, "Save the current state to a file");
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // button12
            // 
            this.button12.BackgroundImage = global::Tek1.Properties.Resources.snappie2;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button12.Location = new System.Drawing.Point(340, 250);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(54, 54);
            this.button12.TabIndex = 13;
            this.ttSolve.SetToolTip(this.button12, "Save a snapshot");
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // bLoad
            // 
            this.bLoad.BackgroundImage = global::Tek1.Properties.Resources.open_new;
            this.bLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bLoad.Location = new System.Drawing.Point(340, 112);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(44, 43);
            this.bLoad.TabIndex = 0;
            this.bLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttSolve.SetToolTip(this.bLoad, "Load a new puzzle from a file");
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bSolve
            // 
            this.bSolve.BackgroundImage = global::Tek1.Properties.Resources.solve;
            this.bSolve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bSolve.Location = new System.Drawing.Point(17, 436);
            this.bSolve.Name = "bSolve";
            this.bSolve.Size = new System.Drawing.Size(54, 54);
            this.bSolve.TabIndex = 7;
            this.ttSolve.SetToolTip(this.bSolve, "Solve the puzzle");
            this.bSolve.UseVisualStyleBackColor = true;
            this.bSolve.Click += new System.EventHandler(this.bSolveClick);
            // 
            // button11
            // 
            this.button11.BackgroundImage = global::Tek1.Properties.Resources.backspace;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Location = new System.Drawing.Point(108, 270);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(54, 54);
            this.button11.TabIndex = 12;
            this.ttSolve.SetToolTip(this.button11, "Undo the last change");
            this.button11.UseCompatibleTextRendering = true;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // bReset
            // 
            this.bReset.BackgroundImage = global::Tek1.Properties.Resources.reset1;
            this.bReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bReset.Location = new System.Drawing.Point(340, 169);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(54, 54);
            this.bReset.TabIndex = 8;
            this.ttSolve.SetToolTip(this.bReset, "Reset the puzzle");
            this.bReset.UseCompatibleTextRendering = true;
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(93, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 129);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notes";
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(88, 82);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(30, 29);
            this.button10.TabIndex = 15;
            this.button10.Tag = "1";
            this.button10.Text = "5";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.ToggleNoteButton_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(15, 82);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(30, 29);
            this.button9.TabIndex = 14;
            this.button9.Tag = "1";
            this.button9.Text = "4";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.ToggleNoteButton_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(52, 55);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(30, 29);
            this.button8.TabIndex = 13;
            this.button8.Tag = "1";
            this.button8.Text = "3";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ToggleNoteButton_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(88, 25);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(30, 29);
            this.button7.TabIndex = 12;
            this.button7.Tag = "1";
            this.button7.Text = "2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ToggleNoteButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 29);
            this.button1.TabIndex = 11;
            this.button1.Tag = "1";
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ToggleNoteButton_Click);
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.SizeChanged += new System.EventHandler(this.panel1_Resize);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.button14);
            this.split.Panel2.Controls.Add(this.button13);
            this.split.Panel2.Controls.Add(this.groupBox1);
            this.split.Panel2.Controls.Add(this.bSave);
            this.split.Panel2.Controls.Add(this.button12);
            this.split.Panel2.Controls.Add(this.button6);
            this.split.Panel2.Controls.Add(this.bLoad);
            this.split.Panel2.Controls.Add(this.bSolve);
            this.split.Panel2.Controls.Add(this.button11);
            this.split.Panel2.Controls.Add(this.button5);
            this.split.Panel2.Controls.Add(this.button2);
            this.split.Panel2.Controls.Add(this.bReset);
            this.split.Panel2.Controls.Add(this.button3);
            this.split.Panel2.Controls.Add(this.button4);
            this.split.Size = new System.Drawing.Size(800, 552);
            this.split.SplitterDistance = 334;
            this.split.TabIndex = 10;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(340, 362);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 11;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 552);
            this.Controls.Add(this.split);
            this.KeyPreview = true;
            this.Name = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.SaveFileDialog sfd1;
        private System.Windows.Forms.Button bSolve;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.ToolTip ttSolve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.Button button14;
    }
}