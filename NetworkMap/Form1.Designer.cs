namespace NetworkMap
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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.canvas = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.EditorModeCB = new System.Windows.Forms.ToolStripComboBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.рольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.senderMode = new System.Windows.Forms.ToolStripMenuItem();
            this.TransporterMode = new System.Windows.Forms.ToolStripMenuItem();
            this.ReceiverMode = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.EditName = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.TransporterColor = new System.Windows.Forms.ToolStripButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.SenderColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.ReceiverColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SavePreferences = new System.Windows.Forms.ToolStripButton();
            this.LoadPreferences = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.BackColor = System.Drawing.Color.Black;
            toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.ContextMenuStrip = this.contextMenu;
            this.canvas.Location = new System.Drawing.Point(0, 25);
            this.canvas.Margin = new System.Windows.Forms.Padding(3, 27, 3, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1272, 668);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.EditorModeCB,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.TransporterColor,
            toolStripSeparator1,
            this.toolStripLabel3,
            this.SenderColor,
            this.toolStripSeparator3,
            this.toolStripLabel4,
            this.ReceiverColor,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.SavePreferences,
            this.LoadPreferences});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1272, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel1.Text = "Editor mode";
            // 
            // EditorModeCB
            // 
            this.EditorModeCB.Name = "EditorModeCB";
            this.EditorModeCB.Size = new System.Drawing.Size(121, 25);
            this.EditorModeCB.SelectedIndexChanged += new System.EventHandler(this.EditorModeCB_SelectedIndexChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рольToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(129, 48);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // рольToolStripMenuItem
            // 
            this.рольToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.senderMode,
            this.TransporterMode,
            this.ReceiverMode});
            this.рольToolStripMenuItem.Name = "рольToolStripMenuItem";
            this.рольToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.рольToolStripMenuItem.Text = "Роль";
            // 
            // senderMode
            // 
            this.senderMode.Name = "senderMode";
            this.senderMode.Size = new System.Drawing.Size(152, 22);
            this.senderMode.Text = "Отправитель";
            this.senderMode.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // TransporterMode
            // 
            this.TransporterMode.Name = "TransporterMode";
            this.TransporterMode.Size = new System.Drawing.Size(152, 22);
            this.TransporterMode.Text = "Передатчик";
            this.TransporterMode.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ReceiverMode
            // 
            this.ReceiverMode.Name = "ReceiverMode";
            this.ReceiverMode.Size = new System.Drawing.Size(152, 22);
            this.ReceiverMode.Text = "Приёмщик";
            this.ReceiverMode.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditName,
            this.EditDesc,
            this.EditLoc});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // EditLoc
            // 
            this.EditLoc.Name = "EditLoc";
            this.EditLoc.Size = new System.Drawing.Size(152, 22);
            this.EditLoc.Text = "Расположение";
            this.EditLoc.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // EditName
            // 
            this.EditName.Name = "EditName";
            this.EditName.Size = new System.Drawing.Size(152, 22);
            this.EditName.Text = "Имя";
            this.EditName.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // EditDesc
            // 
            this.EditDesc.Name = "EditDesc";
            this.EditDesc.Size = new System.Drawing.Size(152, 22);
            this.EditDesc.Text = "Описание";
            this.EditDesc.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // TransporterColor
            // 
            this.TransporterColor.BackColor = System.Drawing.Color.Black;
            this.TransporterColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TransporterColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TransporterColor.Name = "TransporterColor";
            this.TransporterColor.Size = new System.Drawing.Size(23, 22);
            this.TransporterColor.Text = "toolStripButton1";
            this.TransporterColor.Click += new System.EventHandler(this.ColorSelectorClick);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(109, 22);
            this.toolStripLabel2.Text = "Цвет передатчиков";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(102, 22);
            this.toolStripLabel3.Text = "Цвет отправителя";
            // 
            // SenderColor
            // 
            this.SenderColor.BackColor = System.Drawing.Color.Black;
            this.SenderColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SenderColor.ForeColor = System.Drawing.Color.Black;
            this.SenderColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SenderColor.Name = "SenderColor";
            this.SenderColor.Size = new System.Drawing.Size(23, 22);
            this.SenderColor.Text = "toolStripButton2";
            this.SenderColor.Click += new System.EventHandler(this.ColorSelectorClick);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel4.Text = "Цвет приёмника";
            // 
            // ReceiverColor
            // 
            this.ReceiverColor.BackColor = System.Drawing.Color.Black;
            this.ReceiverColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReceiverColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReceiverColor.Name = "ReceiverColor";
            this.ReceiverColor.Size = new System.Drawing.Size(23, 22);
            this.ReceiverColor.Text = "toolStripButton3";
            this.ReceiverColor.Click += new System.EventHandler(this.ColorSelectorClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // SavePreferences
            // 
            this.SavePreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SavePreferences.Image = ((System.Drawing.Image)(resources.GetObject("SavePreferences.Image")));
            this.SavePreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SavePreferences.Name = "SavePreferences";
            this.SavePreferences.Size = new System.Drawing.Size(23, 22);
            this.SavePreferences.Text = "toolStripButton1";
            this.SavePreferences.Click += new System.EventHandler(this.SavePreferences_Click);
            // 
            // LoadPreferences
            // 
            this.LoadPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadPreferences.Image = ((System.Drawing.Image)(resources.GetObject("LoadPreferences.Image")));
            this.LoadPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadPreferences.Name = "LoadPreferences";
            this.LoadPreferences.Size = new System.Drawing.Size(23, 22);
            this.LoadPreferences.Text = "toolStripButton2";
            this.LoadPreferences.Click += new System.EventHandler(this.LoadPreferences_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 693);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox EditorModeCB;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem рольToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem senderMode;
        private System.Windows.Forms.ToolStripMenuItem TransporterMode;
        private System.Windows.Forms.ToolStripMenuItem ReceiverMode;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditName;
        private System.Windows.Forms.ToolStripMenuItem EditDesc;
        private System.Windows.Forms.ToolStripMenuItem EditLoc;
        private System.Windows.Forms.ToolStripButton TransporterColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton SenderColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton ReceiverColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton SavePreferences;
        private System.Windows.Forms.ToolStripButton LoadPreferences;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

