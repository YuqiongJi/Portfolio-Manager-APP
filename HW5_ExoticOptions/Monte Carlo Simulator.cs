using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace HW5_ExoticOptions
{

    public partial class Form1 : Form
    {
        static double S0_text, vol_text, r_text, K_text, T_text;
        static int step_text, trial_text;
        static double optionvalue, delta, gamma, vega, theta, rho, standarderror;
        static int CoreNumber = System.Environment.ProcessorCount;
        static int option_index,barrier_index;

 

        public Form1()
        {
            InitializeComponent();

        }


        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            bool S0_bol = double.TryParse(textBoxS0.Text, out S0_text);
            bool K_bol = double.TryParse(textBoxK.Text, out K_text);
            bool r_bol = double.TryParse(textBoxr.Text, out r_text);
            bool vol_bol = double.TryParse(textBoxVolatility.Text, out vol_text);
            bool T_bol = double.TryParse(textBoxT.Text, out T_text);
            bool trial_bol = int.TryParse(textBoxTrials.Text, out trial_text);
            bool step_bol = int.TryParse(textBoxStep.Text, out step_text);



            if (S0_bol && K_bol && r_bol && vol_bol && T_bol && trial_bol && step_bol)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                option_index = comboBox1.SelectedIndex;
                barrier_index = comboBox2.SelectedIndex;


                if (checkBoxmultithread.Checked == true)
                {
                    Thread t1 = new Thread(new ThreadStart(Calc));
                    t1.Start();
                    t1.Join();

                }
                else
                {
                    Calc();
                }

                label1.Text = Convert.ToString(optionvalue);

                label2.Text = Convert.ToString(delta);
                label3.Text = Convert.ToString(gamma);
                label4.Text = Convert.ToString(vega);
                label5.Text = Convert.ToString(theta);
                label6.Text = Convert.ToString(rho);
                label7.Text = Convert.ToString(standarderror);
                label12.Text = Convert.ToString(CoreNumber);

                watch.Stop();
                labeltimer.Text = watch.Elapsed.Hours.ToString() + " h: "
                    + watch.Elapsed.Minutes.ToString() + " min: "
                    + watch.Elapsed.Seconds.ToString() + " s: "
                    + watch.Elapsed.Milliseconds.ToString() + " ms";
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        public void IncreProgress(int i)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int>(IncreProgress), new object[] { i });
                return;

            }
            progressBar1.Value = i;
        }


        public void Calc()
        {

            IncreProgress(20);

            #region European Option
            if (option_index == 0)
            {
                EuropeanOptions OptInstance = new EuropeanOptions()

                {

                    SpotPrice = S0_text,
                    SprikePrice = K_text,
                    Drift = r_text,
                    Volatility = vol_text,
                    Tenor = T_text,
                    TrialNumber = trial_text,
                    StepNumber = step_text,

                };
                if (radioButtoncall.Checked == true)
                {
                    OptInstance.Side = true;
                }
                else if (radioButtonput.Checked == true)
                {
                    OptInstance.Side = false;
                }
                else
                {
                    MessageBox.Show("Please select an option type!");
                }

                if (checkBoxanti.Checked == true)
                {
                    OptInstance.Antithetic = true;
                    OptInstance.RandNumbers = OptInstance.Anti_GetRandMatrix();
                }
                else
                {
                    OptInstance.Antithetic = false;
                    OptInstance.RandNumbers = OptInstance.GetRandMatrix();
                }

                IncreProgress(50);

                OptInstance.Delta_ControlVariate = checkBoxdeltaCV.Checked;

                OptInstance.Multithreading = checkBoxmultithread.Checked;

                optionvalue = OptInstance.OptionPrice();

                IncreProgress(70);

                delta = OptInstance.GetDelta();
                gamma = OptInstance.GetGamma();
                vega = OptInstance.GetVega();

                IncreProgress(90);

                theta = OptInstance.GetTheta();
                rho = OptInstance.GetRho();
                standarderror = OptInstance.StandardError();


                IncreProgress(100);

            }
            #endregion European Option
            #region Asian Option
            else if (option_index == 1)
            {
                AsianOptions OptInstance = new AsianOptions()

                {

                    SpotPrice = S0_text,
                    SprikePrice = K_text,
                    Drift = r_text,
                    Volatility = vol_text,
                    Tenor = T_text,
                    TrialNumber = trial_text,
                    StepNumber = step_text,

                };
                if (radioButtoncall.Checked == true)
                {
                    OptInstance.Side = true;
                }
                else if (radioButtonput.Checked == true)
                {
                    OptInstance.Side = false;
                }
                else
                {
                    MessageBox.Show("Please select an option type!");
                }

                if (checkBoxanti.Checked == true)
                {
                    OptInstance.Antithetic = true;
                    OptInstance.RandNumbers = OptInstance.Anti_GetRandMatrix();
                }
                else
                {
                    OptInstance.Antithetic = false;
                    OptInstance.RandNumbers = OptInstance.GetRandMatrix();
                }

                IncreProgress(50);

                OptInstance.Delta_ControlVariate = checkBoxdeltaCV.Checked;

                OptInstance.Multithreading = checkBoxmultithread.Checked;

                optionvalue = OptInstance.OptionPrice();

                IncreProgress(70);

                delta = OptInstance.GetDelta();
                gamma = OptInstance.GetGamma();
                vega = OptInstance.GetVega();

                IncreProgress(90);
                theta = OptInstance.GetTheta();
                rho = OptInstance.GetRho();
                standarderror = OptInstance.StandardError();


                IncreProgress(100);
            }
            #endregion Asian Option

            #region Digital Option
            else if (option_index ==2)
            {
                DigitalOptions OptInstance = new DigitalOptions()

                {

                    SpotPrice = S0_text,
                    SprikePrice = K_text,
                    Drift = r_text,
                    Volatility = vol_text,
                    Tenor = T_text,
                    TrialNumber = trial_text,
                    StepNumber = step_text,
                    RebateValue = Convert.ToDouble(textBoxrebate.Text)

            };

                if (radioButtoncall.Checked == true)
                {
                    OptInstance.Side = true;
                }
                else if (radioButtonput.Checked == true)
                {
                    OptInstance.Side = false;
                }
                else
                {
                    MessageBox.Show("Please select an option type!");
                }

                if (checkBoxanti.Checked == true)
                {
                    OptInstance.Antithetic = true;
                    OptInstance.RandNumbers = OptInstance.Anti_GetRandMatrix();
                }
                else
                {
                    OptInstance.Antithetic = false;
                    OptInstance.RandNumbers = OptInstance.GetRandMatrix();
                }

                IncreProgress(50);

                OptInstance.Delta_ControlVariate = checkBoxdeltaCV.Checked;

                OptInstance.Multithreading = checkBoxmultithread.Checked;

                optionvalue = OptInstance.OptionPrice();

                IncreProgress(70);

                delta = OptInstance.GetDelta();
                gamma = OptInstance.GetGamma();
                vega = OptInstance.GetVega();

                IncreProgress(90);
                theta = OptInstance.GetTheta();
                rho = OptInstance.GetRho();
                standarderror = OptInstance.StandardError();


                IncreProgress(100);
            }
            #endregion Digital Option

            #region Barrier Option
            else if (option_index ==3)
            {
                BarrierOptions OptInstance = new BarrierOptions()

                {

                    SpotPrice = S0_text,
                    SprikePrice = K_text,
                    Drift = r_text,
                    Volatility = vol_text,
                    Tenor = T_text,
                    TrialNumber = trial_text,
                    StepNumber = step_text,
                    BarrierPrice = Convert.ToDouble(textBoxbarrier.Text)

                };


                if (radioButtoncall.Checked == true)
                {
                    OptInstance.Side = true;
                }
                else if (radioButtonput.Checked == true)
                {
                    OptInstance.Side = false;
                }
                else
                {
                    MessageBox.Show("Please select an option type!");
                }

                if (barrier_index==0)
                {
                    OptInstance.BarrierType = 0;
                    
                }
                else if (barrier_index == 1)
                {
                    OptInstance.BarrierType = 1;
                    
                }
                else if (barrier_index == 2)
                {
                    OptInstance.BarrierType = 2;
                    
                }
                else if (barrier_index == 3)
                {
                    OptInstance.BarrierType = 3;
                    
                }
                else
                {
                    MessageBox.Show("Please select a Barrier Type!");
                }


                if (checkBoxanti.Checked == true)
                {
                    OptInstance.Antithetic = true;
                    OptInstance.RandNumbers = OptInstance.Anti_GetRandMatrix();
                }
                else
                {
                    OptInstance.Antithetic = false;
                    OptInstance.RandNumbers = OptInstance.GetRandMatrix();
                }

                IncreProgress(50);

                OptInstance.Delta_ControlVariate = checkBoxdeltaCV.Checked;

                OptInstance.Multithreading = checkBoxmultithread.Checked;

                optionvalue = OptInstance.OptionPrice();

                if (optionvalue == 0)
                {
                    MessageBox.Show("Please enter a valid Barrier!");
                }


                IncreProgress(70);

                delta = OptInstance.GetDelta();
                gamma = OptInstance.GetGamma();
                vega = OptInstance.GetVega();

                IncreProgress(90);
                theta = OptInstance.GetTheta();
                rho = OptInstance.GetRho();
                standarderror = OptInstance.StandardError();


                IncreProgress(100);


            }
            #endregion Barrier Option

            #region Lookback Option
            else if (option_index == 4)
            {
                LookbackOptions OptInstance = new LookbackOptions()

                {

                    SpotPrice = S0_text,
                    SprikePrice = K_text,
                    Drift = r_text,
                    Volatility = vol_text,
                    Tenor = T_text,
                    TrialNumber = trial_text,
                    StepNumber = step_text,

                };
                if (radioButtoncall.Checked == true)
                {
                    OptInstance.Side = true;
                }
                else if (radioButtonput.Checked == true)
                {
                    OptInstance.Side = false;
                }
                else
                {
                    MessageBox.Show("Please select an option type!");
                }

                if (checkBoxanti.Checked == true)
                {
                    OptInstance.Antithetic = true;
                    OptInstance.RandNumbers = OptInstance.Anti_GetRandMatrix();
                }
                else
                {
                    OptInstance.Antithetic = false;
                    OptInstance.RandNumbers = OptInstance.GetRandMatrix();
                }

                IncreProgress(50);

                OptInstance.Delta_ControlVariate = checkBoxdeltaCV.Checked;

                OptInstance.Multithreading = checkBoxmultithread.Checked;

                optionvalue = OptInstance.OptionPrice();

                IncreProgress(70);

                delta = OptInstance.GetDelta();
                gamma = OptInstance.GetGamma();
                vega = OptInstance.GetVega();

                IncreProgress(90);
                theta = OptInstance.GetTheta();
                rho = OptInstance.GetRho();
                standarderror = OptInstance.StandardError();


                IncreProgress(100);
            }
            #endregion Lookback Option

            #region Range Option
            else
            {
                RangeOptions OptInstance = new RangeOptions()
                {

                    SpotPrice = S0_text,
                    SprikePrice = K_text,
                    Drift = r_text,
                    Volatility = vol_text,
                    Tenor = T_text,
                    TrialNumber = trial_text,
                    StepNumber = step_text,

                };

                OptInstance.Side = true;
       

                if (checkBoxanti.Checked == true)
                {
                    OptInstance.Antithetic = true;
                    OptInstance.RandNumbers = OptInstance.Anti_GetRandMatrix();
                }
                else
                {
                    OptInstance.Antithetic = false;
                    OptInstance.RandNumbers = OptInstance.GetRandMatrix();
                }

                IncreProgress(50);

                OptInstance.Delta_ControlVariate = checkBoxdeltaCV.Checked;

                OptInstance.Multithreading = checkBoxmultithread.Checked;

                optionvalue = OptInstance.OptionPrice();

                IncreProgress(70);

                delta = OptInstance.GetDelta();
                gamma = OptInstance.GetGamma();
                vega = OptInstance.GetVega();

                IncreProgress(90);
                theta = OptInstance.GetTheta();
                rho = OptInstance.GetRho();
                standarderror = OptInstance.StandardError();


                IncreProgress(100);
            }

            #endregion Range Option


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxrebate.Clear();
            textBoxbarrier.Clear();

            if (comboBox1.SelectedIndex == 0)
            {
                textBoxrebate.Enabled = false;
                comboBox2.Enabled = false;
                textBoxbarrier.Enabled = false;
                radioButtoncall.Enabled = true;
                radioButtonput.Enabled = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBoxrebate.Enabled = false;
                comboBox2.Enabled = false;
                textBoxbarrier.Enabled = false;
                radioButtoncall.Enabled = true;
                radioButtonput.Enabled = true;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBoxrebate.Enabled = true;
                comboBox2.Enabled = false;
                textBoxbarrier.Enabled = false;
                radioButtoncall.Enabled = true;
                radioButtonput.Enabled = true;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textBoxrebate.Enabled = false;
                comboBox2.Enabled = true;
                textBoxbarrier.Enabled = true;
                radioButtoncall.Enabled = true;
                radioButtonput.Enabled = true;

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                textBoxrebate.Enabled = false;
                comboBox2.Enabled = false;
                textBoxbarrier.Enabled = false;
                radioButtoncall.Enabled = true;
                radioButtonput.Enabled = true;
            }
            else
            {
                textBoxrebate.Enabled = false;
                comboBox2.Enabled = false;
                textBoxbarrier.Enabled = false;
                radioButtoncall.Enabled = false;
                radioButtonput.Enabled = false;
            }
        }

 
        private void textBoxS0_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxS0.Text, out double S0_text))
            {
                textBoxS0.BackColor = Color.White;
            }
            else
            {
                textBoxS0.BackColor = Color.Pink;
            }
        }

        private void textBoxK_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxK.Text, out double K_text))
            {
                textBoxK.BackColor = Color.White;
            }
            else
            {
                textBoxK.BackColor = Color.Pink;
            }
        }

        private void textBoxr_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxr.Text, out double r_text))
            {
                textBoxr.BackColor = Color.White;
            }
            else
            {
                textBoxr.BackColor = Color.Pink;
            }
        }

        private void textBoxVolatility_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxVolatility.Text, out double vol_text))
            {
                textBoxVolatility.BackColor = Color.White;
            }
            else
            {
                textBoxVolatility.BackColor = Color.Pink;
            }
        }

        private void textBoxT_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxT.Text, out double T_text))
            {
                textBoxT.BackColor = Color.White;
            }
            else
            {
                textBoxT.BackColor = Color.Pink;
            }
        }

        private void textBoxTrials_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(textBoxTrials.Text, out int trial_text))
            {
                textBoxTrials.BackColor = Color.White;
            }
            else
            {
                textBoxTrials.BackColor = Color.Pink;
            }
        }

        private void textBoxStep_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxStep.Text, out int step_text))
            {
                textBoxStep.BackColor = Color.White;
            }
            else
            {
                textBoxStep.BackColor = Color.Pink;
            }
        }

    }
}
