namespace MapProjector
{
    partial class MapProjectorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private MapProjectorDataSource dataSource;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (this.saveAsToolStripMenuItem != null)
                {
                    this.saveAsToolStripMenuItem.Click -= saveAsToolStripMenuItem_Click;
                }
                if (this.orthographicToolStripMenuItem != null)
                {
                    this.orthographicToolStripMenuItem.Click -= projectionToolStripMenuItem_Click;
                }
                if (this.plateCarreeToolStripMenuItem != null)
                {
                    this.plateCarreeToolStripMenuItem.Click -= projectionToolStripMenuItem_Click;
                }
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
            MapProjector.Projections.Orthographic orthographic1 = new MapProjector.Projections.Orthographic();
            MapProjector.Projections.PlateCarree plateCarree1 = new MapProjector.Projections.PlateCarree();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseProjectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orthographicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plateCarreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.northLabel = new System.Windows.Forms.Label();
            this.eastLabel = new System.Windows.Forms.Label();
            this.westLabel = new System.Windows.Forms.Label();
            this.southLabel = new System.Windows.Forms.Label();
            this.boundsGroupBox = new System.Windows.Forms.GroupBox();
            this.westTextBox = new MapProjector.NumericTextBox();
            this.dataSource = new MapProjector.MapProjectorDataSource();
            this.northTextBox = new MapProjector.NumericTextBox();
            this.southTextBox = new MapProjector.NumericTextBox();
            this.eastTextBox = new MapProjector.NumericTextBox();
            this.intervalGroupBox = new MapProjector.RadioGroupBox<double>();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton0_5 = new System.Windows.Forms.RadioButton();
            this.projectButton = new System.Windows.Forms.Button();
            this.paperGroupBox = new MapProjector.RadioGroupBox<PaperSize>();
            this.xLabel = new System.Windows.Forms.Label();
            this.customPaperSizeNumericTextBox2 = new MapProjector.NumericTextBox();
            this.customPaperSizeNumericTextBox1 = new MapProjector.NumericTextBox();
            this.customPaperButton = new System.Windows.Forms.RadioButton();
            this.a2PaperButton = new System.Windows.Forms.RadioButton();
            this.a3PaperButton = new System.Windows.Forms.RadioButton();
            this.a4PaperButton = new System.Windows.Forms.RadioButton();
            this.resultsGroupBox = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.orientationText = new System.Windows.Forms.TextBox();
            this.orientationLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.boundsGroupBox.SuspendLayout();
            this.intervalGroupBox.SuspendLayout();
            this.paperGroupBox.SuspendLayout();
            this.resultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.chooseProjectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(701, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // chooseProjectionToolStripMenuItem
            // 
            this.chooseProjectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orthographicToolStripMenuItem,
            this.plateCarreeToolStripMenuItem});
            this.chooseProjectionToolStripMenuItem.Name = "chooseProjectionToolStripMenuItem";
            this.chooseProjectionToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.chooseProjectionToolStripMenuItem.Text = "Choose Projection";
            // 
            // orthographicToolStripMenuItem
            // 
            this.orthographicToolStripMenuItem.Name = "orthographicToolStripMenuItem";
            this.orthographicToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.orthographicToolStripMenuItem.Tag = orthographic1;
            this.orthographicToolStripMenuItem.Text = "Orthographic";
            // 
            // plateCarreeToolStripMenuItem
            // 
            this.plateCarreeToolStripMenuItem.Name = "plateCarreeToolStripMenuItem";
            this.plateCarreeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.plateCarreeToolStripMenuItem.Tag = plateCarree1;
            this.plateCarreeToolStripMenuItem.Text = "Plate Carrée";
            // 
            // northLabel
            // 
            this.northLabel.AutoSize = true;
            this.northLabel.Location = new System.Drawing.Point(6, 22);
            this.northLabel.Name = "northLabel";
            this.northLabel.Size = new System.Drawing.Size(40, 13);
            this.northLabel.TabIndex = 2;
            this.northLabel.Text = "North:";
            // 
            // eastLabel
            // 
            this.eastLabel.AutoSize = true;
            this.eastLabel.Location = new System.Drawing.Point(6, 100);
            this.eastLabel.Name = "eastLabel";
            this.eastLabel.Size = new System.Drawing.Size(31, 13);
            this.eastLabel.TabIndex = 8;
            this.eastLabel.Text = "East:";
            // 
            // westLabel
            // 
            this.westLabel.AutoSize = true;
            this.westLabel.Location = new System.Drawing.Point(6, 74);
            this.westLabel.Name = "westLabel";
            this.westLabel.Size = new System.Drawing.Size(36, 13);
            this.westLabel.TabIndex = 6;
            this.westLabel.Text = "West:";
            // 
            // southLabel
            // 
            this.southLabel.AutoSize = true;
            this.southLabel.Location = new System.Drawing.Point(6, 48);
            this.southLabel.Name = "southLabel";
            this.southLabel.Size = new System.Drawing.Size(41, 13);
            this.southLabel.TabIndex = 4;
            this.southLabel.Text = "South:";
            // 
            // boundsGroupBox
            // 
            this.boundsGroupBox.Controls.Add(this.westTextBox);
            this.boundsGroupBox.Controls.Add(this.southLabel);
            this.boundsGroupBox.Controls.Add(this.northTextBox);
            this.boundsGroupBox.Controls.Add(this.southTextBox);
            this.boundsGroupBox.Controls.Add(this.northLabel);
            this.boundsGroupBox.Controls.Add(this.westLabel);
            this.boundsGroupBox.Controls.Add(this.eastTextBox);
            this.boundsGroupBox.Controls.Add(this.eastLabel);
            this.boundsGroupBox.Location = new System.Drawing.Point(0, 24);
            this.boundsGroupBox.Name = "boundsGroupBox";
            this.boundsGroupBox.Size = new System.Drawing.Size(157, 126);
            this.boundsGroupBox.TabIndex = 9;
            this.boundsGroupBox.TabStop = false;
            this.boundsGroupBox.Text = "Bounds";
            // 
            // westTextBox
            // 
            this.westTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSource, "West", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.westTextBox.Font = new System.Drawing.Font("Consolas", 9F);
            this.westTextBox.Location = new System.Drawing.Point(54, 71);
            this.westTextBox.MaximumValue = 180;
            this.westTextBox.MaxLength = 4;
            this.westTextBox.MinimumValue = -180;
            this.westTextBox.Name = "westTextBox";
            this.westTextBox.Size = new System.Drawing.Size(54, 22);
            this.westTextBox.TabIndex = 5;
            this.westTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.westTextBox.Value = 0D;
            // 
            // dataSource
            // 
            this.dataSource.CartCoordsOutput = null;
            this.dataSource.CustomPaperSizeDim1 = 0D;
            this.dataSource.CustomPaperSizeDim2 = 0D;
            this.dataSource.East = 0D;
            this.dataSource.Interval = 1D;
            this.dataSource.North = 0D;
            this.dataSource.Orientation = MapProjector.Orientation.Landscape;
            this.dataSource.PaperSize = MapProjector.PaperSize.A3;
            this.dataSource.Projection = null;
            this.dataSource.South = 0D;
            this.dataSource.West = 0D;
            // 
            // northTextBox
            // 
            this.northTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSource, "North", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.northTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.northTextBox.Location = new System.Drawing.Point(54, 19);
            this.northTextBox.MaximumValue = 90;
            this.northTextBox.MaxLength = 2;
            this.northTextBox.MinimumValue = 0;
            this.northTextBox.Name = "northTextBox";
            this.northTextBox.Size = new System.Drawing.Size(54, 22);
            this.northTextBox.TabIndex = 1;
            this.northTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.northTextBox.Value = 0D;
            // 
            // southTextBox
            // 
            this.southTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSource, "South", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.southTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.southTextBox.Location = new System.Drawing.Point(54, 45);
            this.southTextBox.MaximumValue = 90;
            this.southTextBox.MaxLength = 3;
            this.southTextBox.MinimumValue = -90;
            this.southTextBox.Name = "southTextBox";
            this.southTextBox.Size = new System.Drawing.Size(54, 22);
            this.southTextBox.TabIndex = 3;
            this.southTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.southTextBox.Value = 0D;
            // 
            // eastTextBox
            // 
            this.eastTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSource, "East", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.eastTextBox.Font = new System.Drawing.Font("Consolas", 9F);
            this.eastTextBox.Location = new System.Drawing.Point(54, 97);
            this.eastTextBox.MaximumValue = 180;
            this.eastTextBox.MaxLength = 4;
            this.eastTextBox.MinimumValue = -180;
            this.eastTextBox.Name = "eastTextBox";
            this.eastTextBox.Size = new System.Drawing.Size(54, 22);
            this.eastTextBox.TabIndex = 7;
            this.eastTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eastTextBox.Value = 0D;
            //
            // intervalGroupBox
            //
            this.intervalGroupBox.Controls.Add(this.radioButton10);
            this.intervalGroupBox.Controls.Add(this.radioButton5);
            this.intervalGroupBox.Controls.Add(this.radioButton2);
            this.intervalGroupBox.Controls.Add(this.radioButton1);
            this.intervalGroupBox.Controls.Add(this.radioButton0_5);
            this.intervalGroupBox.Location = new System.Drawing.Point(0, 156);
            this.intervalGroupBox.Name = "intervalGroupBox";
            this.intervalGroupBox.Size = new System.Drawing.Size(157, 134);
            this.intervalGroupBox.TabIndex = 10;
            this.intervalGroupBox.TabStop = false;
            this.intervalGroupBox.Text = "Interval";
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(6, 111);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(37, 17);
            this.radioButton10.TabIndex = 4;
            this.radioButton10.Tag = 10D;
            this.radioButton10.Text = "10";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 88);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(31, 17);
            this.radioButton5.TabIndex = 3;
            this.radioButton5.Tag = 5D;
            this.radioButton5.Text = "5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 65);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(31, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Tag = 2D;
            this.radioButton2.Text = "2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(31, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = 1D;
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton0_5
            // 
            this.radioButton0_5.AutoSize = true;
            this.radioButton0_5.Location = new System.Drawing.Point(6, 19);
            this.radioButton0_5.Name = "radioButton0_5";
            this.radioButton0_5.Size = new System.Drawing.Size(40, 17);
            this.radioButton0_5.TabIndex = 0;
            this.radioButton0_5.Tag = 0.5D;
            this.radioButton0_5.Text = "0.5";
            this.radioButton0_5.UseVisualStyleBackColor = true;
            // 
            // projectButton
            // 
            this.projectButton.Location = new System.Drawing.Point(6, 417);
            this.projectButton.Name = "projectButton";
            this.projectButton.Size = new System.Drawing.Size(145, 22);
            this.projectButton.TabIndex = 12;
            this.projectButton.Text = "Project";
            this.projectButton.UseVisualStyleBackColor = true;
            //
            // paperGroupBox
            //
            this.paperGroupBox.Controls.Add(this.xLabel);
            this.paperGroupBox.Controls.Add(this.customPaperSizeNumericTextBox2);
            this.paperGroupBox.Controls.Add(this.customPaperSizeNumericTextBox1);
            this.paperGroupBox.Controls.Add(this.customPaperButton);
            this.paperGroupBox.Controls.Add(this.a2PaperButton);
            this.paperGroupBox.Controls.Add(this.a3PaperButton);
            this.paperGroupBox.Controls.Add(this.a4PaperButton);
            this.paperGroupBox.Location = new System.Drawing.Point(0, 296);
            this.paperGroupBox.Name = "paperGroupBox";
            this.paperGroupBox.Size = new System.Drawing.Size(157, 115);
            this.paperGroupBox.TabIndex = 11;
            this.paperGroupBox.TabStop = false;
            this.paperGroupBox.Text = "Paper Size (mm)";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(103, 95);
            this.xLabel.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(12, 13);
            this.xLabel.TabIndex = 10;
            this.xLabel.Text = "x";
            // 
            // customPaperSizeNumericTextBox2
            // 
            this.customPaperSizeNumericTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSource, "CustomPaperSizeDim2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.customPaperSizeNumericTextBox2.Enabled = false;
            this.customPaperSizeNumericTextBox2.Font = new System.Drawing.Font("Consolas", 9F);
            this.customPaperSizeNumericTextBox2.Location = new System.Drawing.Point(118, 89);
            this.customPaperSizeNumericTextBox2.MaximumValue = 9999;
            this.customPaperSizeNumericTextBox2.MaxLength = 4;
            this.customPaperSizeNumericTextBox2.MinimumValue = 0;
            this.customPaperSizeNumericTextBox2.Name = "customPaperSizeNumericTextBox2";
            this.customPaperSizeNumericTextBox2.Size = new System.Drawing.Size(33, 22);
            this.customPaperSizeNumericTextBox2.TabIndex = 5;
            this.customPaperSizeNumericTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.customPaperSizeNumericTextBox2.Value = 0D;
            // 
            // customPaperSizeNumericTextBox1
            // 
            this.customPaperSizeNumericTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSource, "CustomPaperSizeDim1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.customPaperSizeNumericTextBox1.Enabled = false;
            this.customPaperSizeNumericTextBox1.Font = new System.Drawing.Font("Consolas", 9F);
            this.customPaperSizeNumericTextBox1.Location = new System.Drawing.Point(67, 89);
            this.customPaperSizeNumericTextBox1.MaximumValue = 9999;
            this.customPaperSizeNumericTextBox1.MaxLength = 4;
            this.customPaperSizeNumericTextBox1.MinimumValue = 0;
            this.customPaperSizeNumericTextBox1.Name = "customPaperSizeNumericTextBox1";
            this.customPaperSizeNumericTextBox1.Size = new System.Drawing.Size(33, 22);
            this.customPaperSizeNumericTextBox1.TabIndex = 4;
            this.customPaperSizeNumericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.customPaperSizeNumericTextBox1.Value = 0D;
            // 
            // customPaperButton
            // 
            this.customPaperButton.AutoSize = true;
            this.customPaperButton.Location = new System.Drawing.Point(6, 90);
            this.customPaperButton.Name = "customPaperButton";
            this.customPaperButton.Size = new System.Drawing.Size(64, 17);
            this.customPaperButton.TabIndex = 3;
            this.customPaperButton.Tag = MapProjector.PaperSize.Custom;
            this.customPaperButton.Text = "Custom";
            this.customPaperButton.UseVisualStyleBackColor = true;
            // 
            // a2PaperButton
            // 
            this.a2PaperButton.AutoSize = true;
            this.a2PaperButton.Location = new System.Drawing.Point(6, 67);
            this.a2PaperButton.Name = "a2PaperButton";
            this.a2PaperButton.Size = new System.Drawing.Size(94, 17);
            this.a2PaperButton.TabIndex = 2;
            this.a2PaperButton.Tag = MapProjector.PaperSize.A2;
            this.a2PaperButton.Text = "A2 (594 x 420)";
            this.a2PaperButton.UseVisualStyleBackColor = true;
            // 
            // a3PaperButton
            // 
            this.a3PaperButton.AutoSize = true;
            this.a3PaperButton.Checked = true;
            this.a3PaperButton.Location = new System.Drawing.Point(6, 44);
            this.a3PaperButton.Name = "a3PaperButton";
            this.a3PaperButton.Size = new System.Drawing.Size(94, 17);
            this.a3PaperButton.TabIndex = 1;
            this.a3PaperButton.TabStop = true;
            this.a3PaperButton.Tag = MapProjector.PaperSize.A3;
            this.a3PaperButton.Text = "A3 (420 x 297)";
            this.a3PaperButton.UseVisualStyleBackColor = true;
            // 
            // a4PaperButton
            // 
            this.a4PaperButton.AutoSize = true;
            this.a4PaperButton.Location = new System.Drawing.Point(6, 21);
            this.a4PaperButton.Name = "a4PaperButton";
            this.a4PaperButton.Size = new System.Drawing.Size(94, 17);
            this.a4PaperButton.TabIndex = 0;
            this.a4PaperButton.Tag = MapProjector.PaperSize.A4;
            this.a4PaperButton.Text = "A4 (297 x 210)";
            this.a4PaperButton.UseVisualStyleBackColor = true;
            // 
            // resultsGroupBox
            // 
            this.resultsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsGroupBox.Controls.Add(this.richTextBox1);
            this.resultsGroupBox.Controls.Add(this.orientationText);
            this.resultsGroupBox.Controls.Add(this.orientationLabel);
            this.resultsGroupBox.Location = new System.Drawing.Point(163, 24);
            this.resultsGroupBox.Name = "resultsGroupBox";
            this.resultsGroupBox.Size = new System.Drawing.Size(538, 421);
            this.resultsGroupBox.TabIndex = 13;
            this.resultsGroupBox.TabStop = false;
            this.resultsGroupBox.Text = "Results";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSource, "CartCoordsOutput", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(9, 47);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(517, 368);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // orientationText
            // 
            this.orientationText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSource, "Orientation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.orientationText.Enabled = false;
            this.orientationText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orientationText.Location = new System.Drawing.Point(114, 19);
            this.orientationText.MaxLength = 2;
            this.orientationText.Name = "orientationText";
            this.orientationText.Size = new System.Drawing.Size(72, 22);
            this.orientationText.TabIndex = 0;
            // 
            // orientationLabel
            // 
            this.orientationLabel.AutoSize = true;
            this.orientationLabel.Location = new System.Drawing.Point(6, 22);
            this.orientationLabel.Name = "orientationLabel";
            this.orientationLabel.Size = new System.Drawing.Size(102, 13);
            this.orientationLabel.TabIndex = 12;
            this.orientationLabel.Text = "Paper Orientation:";
            // 
            // MapProjectorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 445);
            this.Controls.Add(this.resultsGroupBox);
            this.Controls.Add(this.intervalGroupBox);
            this.Controls.Add(this.projectButton);
            this.Controls.Add(this.paperGroupBox);
            this.Controls.Add(this.boundsGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(706, 480);
            this.Name = "MapProjectorWindow";
            this.Text = "MapProjector";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.boundsGroupBox.ResumeLayout(false);
            this.boundsGroupBox.PerformLayout();
            this.resultsGroupBox.ResumeLayout(false);
            this.resultsGroupBox.PerformLayout();
            this.intervalGroupBox.ResumeLayout(false);
            this.intervalGroupBox.PerformLayout();
            this.paperGroupBox.ResumeLayout(false);
            this.paperGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chooseProjectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orthographicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plateCarreeToolStripMenuItem;
        private NumericTextBox northTextBox;
        private System.Windows.Forms.Label northLabel;
        private System.Windows.Forms.Label eastLabel;
        private NumericTextBox eastTextBox;
        private System.Windows.Forms.Label westLabel;
        private NumericTextBox westTextBox;
        private System.Windows.Forms.Label southLabel;
        private NumericTextBox southTextBox;
        private System.Windows.Forms.GroupBox boundsGroupBox;
        private RadioGroupBox<double> intervalGroupBox;
        private System.Windows.Forms.RadioButton radioButton0_5;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button projectButton;
        private RadioGroupBox<PaperSize> paperGroupBox;
        private System.Windows.Forms.RadioButton customPaperButton;
        private System.Windows.Forms.RadioButton a2PaperButton;
        private System.Windows.Forms.RadioButton a3PaperButton;
        private System.Windows.Forms.RadioButton a4PaperButton;
        private System.Windows.Forms.Label xLabel;
        private NumericTextBox customPaperSizeNumericTextBox2;
        private NumericTextBox customPaperSizeNumericTextBox1;
        private System.Windows.Forms.GroupBox resultsGroupBox;
        private System.Windows.Forms.TextBox orientationText;
        private System.Windows.Forms.Label orientationLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}

