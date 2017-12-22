namespace VastGIS.RealEstateDB.Forms
{
    partial class frmCreateDB
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.btnDB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSR = new System.Windows.Forms.Button();
            this.txtSR = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库：";
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(60, 10);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(304, 21);
            this.txtDB.TabIndex = 1;
            // 
            // btnDB
            // 
            this.btnDB.Location = new System.Drawing.Point(369, 8);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(75, 23);
            this.btnDB.TabIndex = 2;
            this.btnDB.Text = "选择...";
            this.btnDB.UseVisualStyleBackColor = true;
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "坐标系：";
            // 
            // btnSR
            // 
            this.btnSR.Location = new System.Drawing.Point(369, 39);
            this.btnSR.Name = "btnSR";
            this.btnSR.Size = new System.Drawing.Size(75, 23);
            this.btnSR.TabIndex = 5;
            this.btnSR.Text = "选择...";
            this.btnSR.UseVisualStyleBackColor = true;
            this.btnSR.Click += new System.EventHandler(this.btnSR_Click);
            // 
            // txtSR
            // 
            this.txtSR.Location = new System.Drawing.Point(60, 41);
            this.txtSR.Name = "txtSR";
            this.txtSR.Size = new System.Drawing.Size(304, 21);
            this.txtSR.TabIndex = 4;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(267, 69);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "创建";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(369, 69);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCreateDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 104);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnSR);
            this.Controls.Add(this.txtSR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDB);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateDB";
            this.Text = "创建数据库";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Button btnDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSR;
        private System.Windows.Forms.TextBox txtSR;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
    }
}

