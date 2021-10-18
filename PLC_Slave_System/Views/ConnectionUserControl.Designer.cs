
namespace PLC_Slave_System.Views
{
    partial class ConnectionUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState1 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState2 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState3 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState4 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState5 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState6 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState7 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState8 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            this.DevicegroupControl = new DevExpress.XtraEditors.GroupControl();
            this.Location_OnepanelControl = new DevExpress.XtraEditors.PanelControl();
            this.Location_OnelabelControl = new DevExpress.XtraEditors.LabelControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGauge1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.Location_OnestateIndicatorComponent = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.Location_TwopanelControl = new DevExpress.XtraEditors.PanelControl();
            this.Location_TwolabelControl = new DevExpress.XtraEditors.LabelControl();
            this.gaugeControl2 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.Location_TwostateIndicatorGauge = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.Location_TwostateIndicatorComponent = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            ((System.ComponentModel.ISupportInitialize)(this.DevicegroupControl)).BeginInit();
            this.DevicegroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Location_OnepanelControl)).BeginInit();
            this.Location_OnepanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location_OnestateIndicatorComponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location_TwopanelControl)).BeginInit();
            this.Location_TwopanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Location_TwostateIndicatorGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location_TwostateIndicatorComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // DevicegroupControl
            // 
            this.DevicegroupControl.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.DevicegroupControl.AppearanceCaption.Options.UseFont = true;
            this.DevicegroupControl.Controls.Add(this.Location_OnepanelControl);
            this.DevicegroupControl.Controls.Add(this.Location_TwopanelControl);
            this.DevicegroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevicegroupControl.Location = new System.Drawing.Point(0, 0);
            this.DevicegroupControl.Name = "DevicegroupControl";
            this.DevicegroupControl.Size = new System.Drawing.Size(240, 107);
            this.DevicegroupControl.TabIndex = 1;
            this.DevicegroupControl.Text = "DeviceName";
            // 
            // Location_OnepanelControl
            // 
            this.Location_OnepanelControl.Controls.Add(this.Location_OnelabelControl);
            this.Location_OnepanelControl.Controls.Add(this.gaugeControl1);
            this.Location_OnepanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location_OnepanelControl.Location = new System.Drawing.Point(2, 23);
            this.Location_OnepanelControl.Name = "Location_OnepanelControl";
            this.Location_OnepanelControl.Size = new System.Drawing.Size(236, 41);
            this.Location_OnepanelControl.TabIndex = 7;
            // 
            // Location_OnelabelControl
            // 
            this.Location_OnelabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.Location_OnelabelControl.Appearance.Options.UseFont = true;
            this.Location_OnelabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Location_OnelabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location_OnelabelControl.Location = new System.Drawing.Point(40, 2);
            this.Location_OnelabelControl.Name = "Location_OnelabelControl";
            this.Location_OnelabelControl.Size = new System.Drawing.Size(194, 37);
            this.Location_OnelabelControl.TabIndex = 1;
            this.Location_OnelabelControl.Text = "xxx.xxx.xxx.xxx";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(2, 2);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(38, 37);
            this.gaugeControl1.TabIndex = 0;
            // 
            // stateIndicatorGauge1
            // 
            this.stateIndicatorGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 26, 25);
            this.stateIndicatorGauge1.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.Location_OnestateIndicatorComponent});
            this.stateIndicatorGauge1.Name = "stateIndicatorGauge1";
            // 
            // Location_OnestateIndicatorComponent
            // 
            this.Location_OnestateIndicatorComponent.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.Location_OnestateIndicatorComponent.Name = "stateIndicatorComponent1";
            this.Location_OnestateIndicatorComponent.Size = new System.Drawing.SizeF(200F, 200F);
            this.Location_OnestateIndicatorComponent.StateIndex = 1;
            indicatorState1.Name = "State1";
            indicatorState1.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight1;
            indicatorState2.Name = "State2";
            indicatorState2.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight2;
            indicatorState3.Name = "State3";
            indicatorState3.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight3;
            indicatorState4.Name = "State4";
            indicatorState4.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight4;
            this.Location_OnestateIndicatorComponent.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState1,
            indicatorState2,
            indicatorState3,
            indicatorState4});
            // 
            // Location_TwopanelControl
            // 
            this.Location_TwopanelControl.Controls.Add(this.Location_TwolabelControl);
            this.Location_TwopanelControl.Controls.Add(this.gaugeControl2);
            this.Location_TwopanelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Location_TwopanelControl.Location = new System.Drawing.Point(2, 64);
            this.Location_TwopanelControl.Name = "Location_TwopanelControl";
            this.Location_TwopanelControl.Size = new System.Drawing.Size(236, 41);
            this.Location_TwopanelControl.TabIndex = 6;
            // 
            // Location_TwolabelControl
            // 
            this.Location_TwolabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.Location_TwolabelControl.Appearance.Options.UseFont = true;
            this.Location_TwolabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Location_TwolabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location_TwolabelControl.Location = new System.Drawing.Point(40, 2);
            this.Location_TwolabelControl.Name = "Location_TwolabelControl";
            this.Location_TwolabelControl.Size = new System.Drawing.Size(194, 37);
            this.Location_TwolabelControl.TabIndex = 2;
            this.Location_TwolabelControl.Text = "xxx.xxx.xxx.xxx";
            // 
            // gaugeControl2
            // 
            this.gaugeControl2.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.gaugeControl2.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.Location_TwostateIndicatorGauge});
            this.gaugeControl2.Location = new System.Drawing.Point(2, 2);
            this.gaugeControl2.Name = "gaugeControl2";
            this.gaugeControl2.Size = new System.Drawing.Size(38, 37);
            this.gaugeControl2.TabIndex = 1;
            // 
            // Location_TwostateIndicatorGauge
            // 
            this.Location_TwostateIndicatorGauge.Bounds = new System.Drawing.Rectangle(6, 6, 26, 25);
            this.Location_TwostateIndicatorGauge.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.Location_TwostateIndicatorComponent});
            this.Location_TwostateIndicatorGauge.Name = "Location_TwostateIndicatorGauge";
            // 
            // Location_TwostateIndicatorComponent
            // 
            this.Location_TwostateIndicatorComponent.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.Location_TwostateIndicatorComponent.Name = "stateIndicatorComponent1";
            this.Location_TwostateIndicatorComponent.Size = new System.Drawing.SizeF(200F, 200F);
            this.Location_TwostateIndicatorComponent.StateIndex = 0;
            indicatorState5.Name = "State1";
            indicatorState5.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight1;
            indicatorState6.Name = "State2";
            indicatorState6.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight2;
            indicatorState7.Name = "State3";
            indicatorState7.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight3;
            indicatorState8.Name = "State4";
            indicatorState8.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight4;
            this.Location_TwostateIndicatorComponent.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState5,
            indicatorState6,
            indicatorState7,
            indicatorState8});
            // 
            // ConnectionUserControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DevicegroupControl);
            this.Name = "ConnectionUserControl";
            this.Size = new System.Drawing.Size(240, 107);
            ((System.ComponentModel.ISupportInitialize)(this.DevicegroupControl)).EndInit();
            this.DevicegroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Location_OnepanelControl)).EndInit();
            this.Location_OnepanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location_OnestateIndicatorComponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location_TwopanelControl)).EndInit();
            this.Location_TwopanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Location_TwostateIndicatorGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location_TwostateIndicatorComponent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl DevicegroupControl;
        private DevExpress.XtraEditors.PanelControl Location_OnepanelControl;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent Location_OnestateIndicatorComponent;
        private DevExpress.XtraEditors.PanelControl Location_TwopanelControl;
        private DevExpress.XtraEditors.LabelControl Location_OnelabelControl;
        private DevExpress.XtraEditors.LabelControl Location_TwolabelControl;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl2;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge Location_TwostateIndicatorGauge;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent Location_TwostateIndicatorComponent;
    }
}
