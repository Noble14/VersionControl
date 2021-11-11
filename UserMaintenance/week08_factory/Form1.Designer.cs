
namespace week08_factory
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this._panelMenu = new System.Windows.Forms.Panel();
            this._buttonCar = new System.Windows.Forms.Button();
            this._buttonBall = new System.Windows.Forms.Button();
            this._labelComingNext = new System.Windows.Forms.Label();
            this._buttonColorPick = new System.Windows.Forms.Button();
            this._buttonPresent = new System.Windows.Forms.Button();
            this.buttonBox = new System.Windows.Forms.Button();
            this.buttonRibbon = new System.Windows.Forms.Button();
            this._panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanel.Location = new System.Drawing.Point(0, 170);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 280);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // _panelMenu
            // 
            this._panelMenu.Controls.Add(this._labelComingNext);
            this._panelMenu.Controls.Add(this.buttonRibbon);
            this._panelMenu.Controls.Add(this.buttonBox);
            this._panelMenu.Controls.Add(this._buttonColorPick);
            this._panelMenu.Controls.Add(this._buttonPresent);
            this._panelMenu.Controls.Add(this._buttonBall);
            this._panelMenu.Controls.Add(this._buttonCar);
            this._panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelMenu.Location = new System.Drawing.Point(0, 0);
            this._panelMenu.Name = "_panelMenu";
            this._panelMenu.Size = new System.Drawing.Size(800, 164);
            this._panelMenu.TabIndex = 1;
            // 
            // _buttonCar
            // 
            this._buttonCar.Location = new System.Drawing.Point(4, 4);
            this._buttonCar.Name = "_buttonCar";
            this._buttonCar.Size = new System.Drawing.Size(75, 93);
            this._buttonCar.TabIndex = 0;
            this._buttonCar.Text = "CAR";
            this._buttonCar.UseVisualStyleBackColor = true;
            this._buttonCar.Click += new System.EventHandler(this._buttonCar_Click);
            // 
            // _buttonBall
            // 
            this._buttonBall.Location = new System.Drawing.Point(85, 4);
            this._buttonBall.Name = "_buttonBall";
            this._buttonBall.Size = new System.Drawing.Size(75, 93);
            this._buttonBall.TabIndex = 0;
            this._buttonBall.Text = "BALL";
            this._buttonBall.UseVisualStyleBackColor = true;
            this._buttonBall.Click += new System.EventHandler(this._buttonBall_Click);
            // 
            // _labelComingNext
            // 
            this._labelComingNext.AutoSize = true;
            this._labelComingNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelComingNext.Location = new System.Drawing.Point(298, 4);
            this._labelComingNext.Name = "_labelComingNext";
            this._labelComingNext.Size = new System.Drawing.Size(110, 20);
            this._labelComingNext.TabIndex = 1;
            this._labelComingNext.Text = "Coming Next";
            // 
            // _buttonColorPick
            // 
            this._buttonColorPick.BackColor = System.Drawing.Color.ForestGreen;
            this._buttonColorPick.Location = new System.Drawing.Point(85, 103);
            this._buttonColorPick.Name = "_buttonColorPick";
            this._buttonColorPick.Size = new System.Drawing.Size(75, 28);
            this._buttonColorPick.TabIndex = 0;
            this._buttonColorPick.UseVisualStyleBackColor = false;
            this._buttonColorPick.Click += new System.EventHandler(this._buttonColorPick_Click);
            // 
            // _buttonPresent
            // 
            this._buttonPresent.Location = new System.Drawing.Point(166, 4);
            this._buttonPresent.Name = "_buttonPresent";
            this._buttonPresent.Size = new System.Drawing.Size(75, 93);
            this._buttonPresent.TabIndex = 0;
            this._buttonPresent.Text = "PRESENT";
            this._buttonPresent.UseVisualStyleBackColor = true;
            this._buttonPresent.Click += new System.EventHandler(this._buttonPresent_Click);
            // 
            // buttonBox
            // 
            this.buttonBox.BackColor = System.Drawing.Color.Red;
            this.buttonBox.Location = new System.Drawing.Point(166, 103);
            this.buttonBox.Name = "buttonBox";
            this.buttonBox.Size = new System.Drawing.Size(75, 28);
            this.buttonBox.TabIndex = 0;
            this.buttonBox.UseVisualStyleBackColor = false;
            this.buttonBox.Click += new System.EventHandler(this._buttonColorPick_Click);
            // 
            // buttonRibbon
            // 
            this.buttonRibbon.BackColor = System.Drawing.Color.Yellow;
            this.buttonRibbon.Location = new System.Drawing.Point(166, 133);
            this.buttonRibbon.Name = "buttonRibbon";
            this.buttonRibbon.Size = new System.Drawing.Size(75, 28);
            this.buttonRibbon.TabIndex = 0;
            this.buttonRibbon.UseVisualStyleBackColor = false;
            this.buttonRibbon.Click += new System.EventHandler(this._buttonColorPick_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._panelMenu);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this._panelMenu.ResumeLayout(false);
            this._panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Panel _panelMenu;
        private System.Windows.Forms.Label _labelComingNext;
        private System.Windows.Forms.Button _buttonBall;
        private System.Windows.Forms.Button _buttonCar;
        private System.Windows.Forms.Button _buttonColorPick;
        private System.Windows.Forms.Button _buttonPresent;
        private System.Windows.Forms.Button buttonRibbon;
        private System.Windows.Forms.Button buttonBox;
    }
}

