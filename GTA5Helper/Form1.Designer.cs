namespace GTA5Helper
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            this.domainUpDown = new System.Windows.Forms.DomainUpDown();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Run:";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.Blue;
            this.buttonStart.Location = new System.Drawing.Point(244, 13);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 46);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "times";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "State:";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelState.Location = new System.Drawing.Point(108, 78);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(88, 39);
            this.labelState.TabIndex = 1;
            this.labelState.Text = "None";
            // 
            // log
            // 
            this.log.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.Location = new System.Drawing.Point(24, 133);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(316, 288);
            this.log.TabIndex = 3;
            // 
            // domainUpDown
            // 
            this.domainUpDown.CausesValidation = false;
            this.domainUpDown.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domainUpDown.Items.Add("9");
            this.domainUpDown.Items.Add("8");
            this.domainUpDown.Items.Add("7");
            this.domainUpDown.Items.Add("6");
            this.domainUpDown.Items.Add("5");
            this.domainUpDown.Items.Add("4");
            this.domainUpDown.Items.Add("3");
            this.domainUpDown.Items.Add("2");
            this.domainUpDown.Items.Add("1");
            this.domainUpDown.Location = new System.Drawing.Point(100, 13);
            this.domainUpDown.Name = "domainUpDown";
            this.domainUpDown.Size = new System.Drawing.Size(42, 47);
            this.domainUpDown.TabIndex = 4;
            this.domainUpDown.TabStop = false;
            this.domainUpDown.Text = "5";
            this.domainUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.domainUpDown_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 433);
            this.Controls.Add(this.domainUpDown);
            this.Controls.Add(this.log);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "GTA5 Helper Beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.DomainUpDown domainUpDown;
    }
}

