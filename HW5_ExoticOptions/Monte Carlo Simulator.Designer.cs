namespace HW5_ExoticOptions
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
            this.labelS0 = new System.Windows.Forms.Label();
            this.textBoxS0 = new System.Windows.Forms.TextBox();
            this.labelK = new System.Windows.Forms.Label();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.labelr = new System.Windows.Forms.Label();
            this.textBoxr = new System.Windows.Forms.TextBox();
            this.labelTenor = new System.Windows.Forms.Label();
            this.textBoxT = new System.Windows.Forms.TextBox();
            this.labelVolatility = new System.Windows.Forms.Label();
            this.textBoxVolatility = new System.Windows.Forms.TextBox();
            this.textBoxTrials = new System.Windows.Forms.TextBox();
            this.labelTrial = new System.Windows.Forms.Label();
            this.labelSteps = new System.Windows.Forms.Label();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.radioButtoncall = new System.Windows.Forms.RadioButton();
            this.radioButtonput = new System.Windows.Forms.RadioButton();
            this.labeloptionprice = new System.Windows.Forms.Label();
            this.labeldelta = new System.Windows.Forms.Label();
            this.labelGamma = new System.Windows.Forms.Label();
            this.labelVega = new System.Windows.Forms.Label();
            this.labelTheta = new System.Windows.Forms.Label();
            this.labelsderror = new System.Windows.Forms.Label();
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelRho = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxanti = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labeltimer = new System.Windows.Forms.Label();
            this.checkBoxdeltaCV = new System.Windows.Forms.CheckBox();
            this.checkBoxmultithread = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxrebate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxbarrier = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelS0
            // 
            this.labelS0.AutoSize = true;
            this.labelS0.Location = new System.Drawing.Point(69, 230);
            this.labelS0.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelS0.Name = "labelS0";
            this.labelS0.Size = new System.Drawing.Size(105, 25);
            this.labelS0.TabIndex = 0;
            this.labelS0.Text = "SpotPrice";
            // 
            // textBoxS0
            // 
            this.textBoxS0.Location = new System.Drawing.Point(206, 229);
            this.textBoxS0.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxS0.Name = "textBoxS0";
            this.textBoxS0.Size = new System.Drawing.Size(225, 31);
            this.textBoxS0.TabIndex = 1;
            this.textBoxS0.TextChanged += new System.EventHandler(this.textBoxS0_TextChanged);
            // 
            // labelK
            // 
            this.labelK.AutoSize = true;
            this.labelK.Location = new System.Drawing.Point(60, 278);
            this.labelK.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(116, 25);
            this.labelK.TabIndex = 2;
            this.labelK.Text = "StrikePrice";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(206, 277);
            this.textBoxK.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(225, 31);
            this.textBoxK.TabIndex = 3;
            this.textBoxK.TextChanged += new System.EventHandler(this.textBoxK_TextChanged);
            // 
            // labelr
            // 
            this.labelr.AutoSize = true;
            this.labelr.Location = new System.Drawing.Point(125, 329);
            this.labelr.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelr.Name = "labelr";
            this.labelr.Size = new System.Drawing.Size(51, 25);
            this.labelr.TabIndex = 4;
            this.labelr.Text = "Drift";
            // 
            // textBoxr
            // 
            this.textBoxr.Location = new System.Drawing.Point(206, 325);
            this.textBoxr.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxr.Name = "textBoxr";
            this.textBoxr.Size = new System.Drawing.Size(225, 31);
            this.textBoxr.TabIndex = 5;
            this.textBoxr.TextChanged += new System.EventHandler(this.textBoxr_TextChanged);
            // 
            // labelTenor
            // 
            this.labelTenor.AutoSize = true;
            this.labelTenor.Location = new System.Drawing.Point(108, 370);
            this.labelTenor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTenor.Name = "labelTenor";
            this.labelTenor.Size = new System.Drawing.Size(68, 25);
            this.labelTenor.TabIndex = 6;
            this.labelTenor.Text = "Tenor";
            // 
            // textBoxT
            // 
            this.textBoxT.Location = new System.Drawing.Point(206, 372);
            this.textBoxT.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(225, 31);
            this.textBoxT.TabIndex = 7;
            this.textBoxT.TextChanged += new System.EventHandler(this.textBoxT_TextChanged);
            // 
            // labelVolatility
            // 
            this.labelVolatility.AutoSize = true;
            this.labelVolatility.Location = new System.Drawing.Point(83, 419);
            this.labelVolatility.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVolatility.Name = "labelVolatility";
            this.labelVolatility.Size = new System.Drawing.Size(93, 25);
            this.labelVolatility.TabIndex = 8;
            this.labelVolatility.Text = "Volatility";
            // 
            // textBoxVolatility
            // 
            this.textBoxVolatility.Location = new System.Drawing.Point(206, 419);
            this.textBoxVolatility.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxVolatility.Name = "textBoxVolatility";
            this.textBoxVolatility.Size = new System.Drawing.Size(225, 31);
            this.textBoxVolatility.TabIndex = 9;
            this.textBoxVolatility.TextChanged += new System.EventHandler(this.textBoxVolatility_TextChanged);
            // 
            // textBoxTrials
            // 
            this.textBoxTrials.Location = new System.Drawing.Point(206, 468);
            this.textBoxTrials.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxTrials.Name = "textBoxTrials";
            this.textBoxTrials.Size = new System.Drawing.Size(225, 31);
            this.textBoxTrials.TabIndex = 10;
            this.textBoxTrials.TextChanged += new System.EventHandler(this.textBoxTrials_TextChanged);
            // 
            // labelTrial
            // 
            this.labelTrial.AutoSize = true;
            this.labelTrial.Location = new System.Drawing.Point(41, 468);
            this.labelTrial.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTrial.Name = "labelTrial";
            this.labelTrial.Size = new System.Drawing.Size(135, 25);
            this.labelTrial.TabIndex = 11;
            this.labelTrial.Text = "Trial Number";
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(109, 514);
            this.labelSteps.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(67, 25);
            this.labelSteps.TabIndex = 12;
            this.labelSteps.Text = "Steps";
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(206, 514);
            this.textBoxStep.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(225, 31);
            this.textBoxStep.TabIndex = 13;
            this.textBoxStep.TextChanged += new System.EventHandler(this.textBoxStep_TextChanged);
            // 
            // radioButtoncall
            // 
            this.radioButtoncall.AutoSize = true;
            this.radioButtoncall.Location = new System.Drawing.Point(218, 568);
            this.radioButtoncall.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.radioButtoncall.Name = "radioButtoncall";
            this.radioButtoncall.Size = new System.Drawing.Size(80, 29);
            this.radioButtoncall.TabIndex = 14;
            this.radioButtoncall.TabStop = true;
            this.radioButtoncall.Text = "Call";
            this.radioButtoncall.UseVisualStyleBackColor = true;
            // 
            // radioButtonput
            // 
            this.radioButtonput.AutoSize = true;
            this.radioButtonput.Location = new System.Drawing.Point(327, 568);
            this.radioButtonput.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.radioButtonput.Name = "radioButtonput";
            this.radioButtonput.Size = new System.Drawing.Size(75, 29);
            this.radioButtonput.TabIndex = 15;
            this.radioButtonput.TabStop = true;
            this.radioButtonput.Text = "Put";
            this.radioButtonput.UseVisualStyleBackColor = true;
            // 
            // labeloptionprice
            // 
            this.labeloptionprice.AutoSize = true;
            this.labeloptionprice.Location = new System.Drawing.Point(571, 207);
            this.labeloptionprice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labeloptionprice.Name = "labeloptionprice";
            this.labeloptionprice.Size = new System.Drawing.Size(136, 25);
            this.labeloptionprice.TabIndex = 16;
            this.labeloptionprice.Text = "Option Price:";
            // 
            // labeldelta
            // 
            this.labeldelta.AutoSize = true;
            this.labeldelta.Location = new System.Drawing.Point(639, 247);
            this.labeldelta.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labeldelta.Name = "labeldelta";
            this.labeldelta.Size = new System.Drawing.Size(68, 25);
            this.labeldelta.TabIndex = 17;
            this.labeldelta.Text = "Delta:";
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Location = new System.Drawing.Point(615, 283);
            this.labelGamma.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Size = new System.Drawing.Size(92, 25);
            this.labelGamma.TabIndex = 18;
            this.labelGamma.Text = "Gamma:";
            // 
            // labelVega
            // 
            this.labelVega.AutoSize = true;
            this.labelVega.Location = new System.Drawing.Point(639, 322);
            this.labelVega.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVega.Name = "labelVega";
            this.labelVega.Size = new System.Drawing.Size(68, 25);
            this.labelVega.TabIndex = 19;
            this.labelVega.Text = "Vega:";
            // 
            // labelTheta
            // 
            this.labelTheta.AutoSize = true;
            this.labelTheta.Location = new System.Drawing.Point(634, 362);
            this.labelTheta.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTheta.Name = "labelTheta";
            this.labelTheta.Size = new System.Drawing.Size(73, 25);
            this.labelTheta.TabIndex = 20;
            this.labelTheta.Text = "Theta:";
            // 
            // labelsderror
            // 
            this.labelsderror.AutoSize = true;
            this.labelsderror.Location = new System.Drawing.Point(549, 432);
            this.labelsderror.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelsderror.Name = "labelsderror";
            this.labelsderror.Size = new System.Drawing.Size(158, 25);
            this.labelsderror.TabIndex = 21;
            this.labelsderror.Text = "Standard Error:";
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimulate.Location = new System.Drawing.Point(722, 558);
            this.buttonSimulate.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(215, 59);
            this.buttonSimulate.TabIndex = 22;
            this.buttonSimulate.Text = "Simulate";
            this.buttonSimulate.UseVisualStyleBackColor = true;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(735, 208);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(735, 248);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(735, 284);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(735, 324);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(735, 363);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 25);
            this.label5.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(735, 432);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 25);
            this.label7.TabIndex = 28;
            // 
            // labelRho
            // 
            this.labelRho.AutoSize = true;
            this.labelRho.Location = new System.Drawing.Point(650, 399);
            this.labelRho.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRho.Name = "labelRho";
            this.labelRho.Size = new System.Drawing.Size(57, 25);
            this.labelRho.TabIndex = 29;
            this.labelRho.Text = "Rho:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 400);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 573);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 25);
            this.label9.TabIndex = 33;
            this.label9.Text = "Call or Put ?";
            // 
            // checkBoxanti
            // 
            this.checkBoxanti.AutoSize = true;
            this.checkBoxanti.Location = new System.Drawing.Point(549, 32);
            this.checkBoxanti.Name = "checkBoxanti";
            this.checkBoxanti.Size = new System.Drawing.Size(358, 29);
            this.checkBoxanti.TabIndex = 34;
            this.checkBoxanti.Text = "Use antithetic variance reduction";
            this.checkBoxanti.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(642, 468);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 25);
            this.label10.TabIndex = 35;
            this.label10.Text = "Time:";
            // 
            // labeltimer
            // 
            this.labeltimer.AutoSize = true;
            this.labeltimer.Location = new System.Drawing.Point(735, 468);
            this.labeltimer.Name = "labeltimer";
            this.labeltimer.Size = new System.Drawing.Size(0, 25);
            this.labeltimer.TabIndex = 36;
            // 
            // checkBoxdeltaCV
            // 
            this.checkBoxdeltaCV.AutoSize = true;
            this.checkBoxdeltaCV.Location = new System.Drawing.Point(549, 78);
            this.checkBoxdeltaCV.Name = "checkBoxdeltaCV";
            this.checkBoxdeltaCV.Size = new System.Drawing.Size(342, 29);
            this.checkBoxdeltaCV.TabIndex = 37;
            this.checkBoxdeltaCV.Text = "Use delta based control variate";
            this.checkBoxdeltaCV.UseVisualStyleBackColor = true;
            // 
            // checkBoxmultithread
            // 
            this.checkBoxmultithread.AutoSize = true;
            this.checkBoxmultithread.Location = new System.Drawing.Point(549, 123);
            this.checkBoxmultithread.Name = "checkBoxmultithread";
            this.checkBoxmultithread.Size = new System.Drawing.Size(224, 29);
            this.checkBoxmultithread.TabIndex = 38;
            this.checkBoxmultithread.Text = "Use Multithreading";
            this.checkBoxmultithread.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(538, 506);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 25);
            this.label11.TabIndex = 39;
            this.label11.Text = "Number of Core:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(734, 508);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 25);
            this.label12.TabIndex = 40;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 642);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1092, 57);
            this.progressBar1.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(47, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 25);
            this.label13.TabIndex = 42;
            this.label13.Text = "Option Type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "European Option",
            "Asian Option",
            "Digital Option",
            "Barrier Option",
            "Lookback Option",
            "Range Option"});
            this.comboBox1.Location = new System.Drawing.Point(206, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(225, 33);
            this.comboBox1.TabIndex = 43;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Up and In",
            "Up and Out",
            "Down and In",
            "Down and Out"});
            this.comboBox2.Location = new System.Drawing.Point(206, 82);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(225, 33);
            this.comboBox2.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(45, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 25);
            this.label15.TabIndex = 50;
            this.label15.Text = "Barrier Type";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(94, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 25);
            this.label14.TabIndex = 44;
            this.label14.Text = "Rebate";
            // 
            // textBoxrebate
            // 
            this.textBoxrebate.Location = new System.Drawing.Point(206, 178);
            this.textBoxrebate.Name = "textBoxrebate";
            this.textBoxrebate.Size = new System.Drawing.Size(225, 31);
            this.textBoxrebate.TabIndex = 46;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(98, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 25);
            this.label16.TabIndex = 47;
            this.label16.Text = "Barrier";
            // 
            // textBoxbarrier
            // 
            this.textBoxbarrier.Location = new System.Drawing.Point(206, 130);
            this.textBoxbarrier.Name = "textBoxbarrier";
            this.textBoxbarrier.Size = new System.Drawing.Size(225, 31);
            this.textBoxbarrier.TabIndex = 48;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 743);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBoxbarrier);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxrebate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.checkBoxmultithread);
            this.Controls.Add(this.checkBoxdeltaCV);
            this.Controls.Add(this.labeltimer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBoxanti);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelRho);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSimulate);
            this.Controls.Add(this.labelsderror);
            this.Controls.Add(this.labelTheta);
            this.Controls.Add(this.labelVega);
            this.Controls.Add(this.labelGamma);
            this.Controls.Add(this.labeldelta);
            this.Controls.Add(this.labeloptionprice);
            this.Controls.Add(this.radioButtonput);
            this.Controls.Add(this.radioButtoncall);
            this.Controls.Add(this.textBoxStep);
            this.Controls.Add(this.labelSteps);
            this.Controls.Add(this.labelTrial);
            this.Controls.Add(this.textBoxTrials);
            this.Controls.Add(this.textBoxVolatility);
            this.Controls.Add(this.labelVolatility);
            this.Controls.Add(this.textBoxT);
            this.Controls.Add(this.labelTenor);
            this.Controls.Add(this.textBoxr);
            this.Controls.Add(this.labelr);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.labelK);
            this.Controls.Add(this.textBoxS0);
            this.Controls.Add(this.labelS0);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Montle Carlo Simulation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelS0;
        private System.Windows.Forms.TextBox textBoxS0;
        private System.Windows.Forms.Label labelK;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.Label labelr;
        private System.Windows.Forms.TextBox textBoxr;
        private System.Windows.Forms.Label labelTenor;
        private System.Windows.Forms.TextBox textBoxT;
        private System.Windows.Forms.Label labelVolatility;
        private System.Windows.Forms.TextBox textBoxVolatility;
        private System.Windows.Forms.TextBox textBoxTrials;
        private System.Windows.Forms.Label labelTrial;
        private System.Windows.Forms.Label labelSteps;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.RadioButton radioButtoncall;
        private System.Windows.Forms.RadioButton radioButtonput;
        private System.Windows.Forms.Label labeloptionprice;
        private System.Windows.Forms.Label labeldelta;
        private System.Windows.Forms.Label labelGamma;
        private System.Windows.Forms.Label labelVega;
        private System.Windows.Forms.Label labelTheta;
        private System.Windows.Forms.Label labelsderror;
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelRho;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxanti;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labeltimer;
        private System.Windows.Forms.CheckBox checkBoxdeltaCV;
        private System.Windows.Forms.CheckBox checkBoxmultithread;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxrebate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxbarrier;
    }
}

