
namespace PLC_Slave_System
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.ExcelbarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.ViewpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewpanelControl)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(190, 736);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Element1";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ExcelbarButtonItem});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(939, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.ExcelbarButtonItem);
            // 
            // ExcelbarButtonItem
            // 
            this.ExcelbarButtonItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.ExcelbarButtonItem.Caption = "設備資料匯入";
            this.ExcelbarButtonItem.Id = 0;
            this.ExcelbarButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ExcelbarButtonItem.ImageOptions.Image")));
            this.ExcelbarButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ExcelbarButtonItem.ImageOptions.LargeImage")));
            this.ExcelbarButtonItem.Name = "ExcelbarButtonItem";
            this.ExcelbarButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.ExcelbarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExcelbarButtonItem_ItemClick);
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ExcelbarButtonItem});
            this.fluentFormDefaultManager1.MaxItemId = 1;
            // 
            // ViewpanelControl
            // 
            this.ViewpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ViewpanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewpanelControl.Location = new System.Drawing.Point(190, 31);
            this.ViewpanelControl.Name = "ViewpanelControl";
            this.ViewpanelControl.Size = new System.Drawing.Size(749, 736);
            this.ViewpanelControl.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 767);
            this.Controls.Add(this.ViewpanelControl);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form";
            this.NavigationControl = this.accordionControl1;
            this.Text = "PLC_Slave_System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewpanelControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraEditors.PanelControl ViewpanelControl;
        private DevExpress.XtraBars.BarButtonItem ExcelbarButtonItem;
        private System.Windows.Forms.Timer timer1;
    }
}