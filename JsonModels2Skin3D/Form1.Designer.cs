namespace JsonModels2Skin3D {
    partial class JsonModels2Skin3D {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.Versionlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.Font = new System.Drawing.Font("宋体", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectFileBtn.Location = new System.Drawing.Point(254, 12);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(291, 96);
            this.selectFileBtn.TabIndex = 0;
            this.selectFileBtn.Text = "选择文件";
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // Versionlabel
            // 
            this.Versionlabel.AutoSize = true;
            this.Versionlabel.Location = new System.Drawing.Point(712, 338);
            this.Versionlabel.Name = "Versionlabel";
            this.Versionlabel.Size = new System.Drawing.Size(76, 21);
            this.Versionlabel.TabIndex = 1;
            this.Versionlabel.Text = "v0.0.0";
            // 
            // JsonModels2Skin3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 368);
            this.Controls.Add(this.Versionlabel);
            this.Controls.Add(this.selectFileBtn);
            this.Name = "JsonModels2Skin3D";
            this.Text = "JsonModels2Skin3D";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.Label Versionlabel;
    }
}

