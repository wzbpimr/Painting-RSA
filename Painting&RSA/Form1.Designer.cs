namespace Painting_RSA
{
    partial class Form1
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
            this.PanelPainting = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线条粗细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粗线条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中线条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.细线条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线条颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.红色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.黑色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加密ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解密ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelPainting.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelPainting
            // 
            this.PanelPainting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelPainting.AutoSize = true;
            this.PanelPainting.Controls.Add(this.menuStrip1);
            this.PanelPainting.Location = new System.Drawing.Point(0, 0);
            this.PanelPainting.Name = "PanelPainting";
            this.PanelPainting.Size = new System.Drawing.Size(1280, 720);
            this.PanelPainting.TabIndex = 0;
            this.PanelPainting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelPainting_MouseDown);
            this.PanelPainting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelPainting_MouseMove);
            this.PanelPainting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelPainting_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘图ToolStripMenuItem,
            this.加密ToolStripMenuItem,
            this.解密ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 绘图ToolStripMenuItem
            // 
            this.绘图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.线条粗细ToolStripMenuItem,
            this.线条颜色ToolStripMenuItem});
            this.绘图ToolStripMenuItem.Name = "绘图ToolStripMenuItem";
            this.绘图ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.绘图ToolStripMenuItem.Text = "绘图";
            // 
            // 线条粗细ToolStripMenuItem
            // 
            this.线条粗细ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.粗线条ToolStripMenuItem,
            this.中线条ToolStripMenuItem,
            this.细线条ToolStripMenuItem});
            this.线条粗细ToolStripMenuItem.Name = "线条粗细ToolStripMenuItem";
            this.线条粗细ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.线条粗细ToolStripMenuItem.Text = "线条粗细";
            // 
            // 粗线条ToolStripMenuItem
            // 
            this.粗线条ToolStripMenuItem.Name = "粗线条ToolStripMenuItem";
            this.粗线条ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.粗线条ToolStripMenuItem.Text = "粗线条";
            this.粗线条ToolStripMenuItem.Click += new System.EventHandler(this.粗线条ToolStripMenuItem_Click);
            // 
            // 中线条ToolStripMenuItem
            // 
            this.中线条ToolStripMenuItem.Name = "中线条ToolStripMenuItem";
            this.中线条ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.中线条ToolStripMenuItem.Text = "中线条";
            this.中线条ToolStripMenuItem.Click += new System.EventHandler(this.中线条ToolStripMenuItem_Click);
            // 
            // 细线条ToolStripMenuItem
            // 
            this.细线条ToolStripMenuItem.Checked = true;
            this.细线条ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.细线条ToolStripMenuItem.Name = "细线条ToolStripMenuItem";
            this.细线条ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.细线条ToolStripMenuItem.Text = "细线条";
            this.细线条ToolStripMenuItem.Click += new System.EventHandler(this.细线条ToolStripMenuItem_Click);
            // 
            // 线条颜色ToolStripMenuItem
            // 
            this.线条颜色ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.红色ToolStripMenuItem,
            this.黑色ToolStripMenuItem,
            this.自定义颜色ToolStripMenuItem});
            this.线条颜色ToolStripMenuItem.Name = "线条颜色ToolStripMenuItem";
            this.线条颜色ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.线条颜色ToolStripMenuItem.Text = "线条颜色";
            // 
            // 红色ToolStripMenuItem
            // 
            this.红色ToolStripMenuItem.Name = "红色ToolStripMenuItem";
            this.红色ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.红色ToolStripMenuItem.Text = "红色";
            this.红色ToolStripMenuItem.Click += new System.EventHandler(this.红色ToolStripMenuItem_Click);
            // 
            // 黑色ToolStripMenuItem
            // 
            this.黑色ToolStripMenuItem.Checked = true;
            this.黑色ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.黑色ToolStripMenuItem.Name = "黑色ToolStripMenuItem";
            this.黑色ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.黑色ToolStripMenuItem.Text = "黑色";
            this.黑色ToolStripMenuItem.Click += new System.EventHandler(this.黑色ToolStripMenuItem_Click);
            // 
            // 自定义颜色ToolStripMenuItem
            // 
            this.自定义颜色ToolStripMenuItem.Name = "自定义颜色ToolStripMenuItem";
            this.自定义颜色ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.自定义颜色ToolStripMenuItem.Text = "自定义颜色";
            this.自定义颜色ToolStripMenuItem.Click += new System.EventHandler(this.自定义颜色ToolStripMenuItem_Click);
            // 
            // 加密ToolStripMenuItem
            // 
            this.加密ToolStripMenuItem.Name = "加密ToolStripMenuItem";
            this.加密ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.加密ToolStripMenuItem.Text = "加密并保存";
            this.加密ToolStripMenuItem.Click += new System.EventHandler(this.加密ToolStripMenuItem_Click);
            // 
            // 解密ToolStripMenuItem
            // 
            this.解密ToolStripMenuItem.Name = "解密ToolStripMenuItem";
            this.解密ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.解密ToolStripMenuItem.Text = "解密并打开";
            this.解密ToolStripMenuItem.Click += new System.EventHandler(this.解密ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.PanelPainting);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "画板";
            this.PanelPainting.ResumeLayout(false);
            this.PanelPainting.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelPainting;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线条粗细ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粗线条ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中线条ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线条颜色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 红色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 黑色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加密ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解密ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 细线条ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义颜色ToolStripMenuItem;
    }
}

