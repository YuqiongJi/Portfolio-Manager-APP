using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_ExoticOptions
{
    public class DigitalOptions:Simulator
    {
        public static double beta1 = -1.0;

        public double[] OptionList()
        {

            double[,] S = SimulatedPrice();

            double[] OptList = new double[Nsim];

            if (IsDeltaCV == true)
            {

                if (Iscall == true)
                {
                    for (int i = 0; i < Nsim; i++)
                    {
                        if(S[i, Steps] - K > 0)
                        {
                            OptList[i] = rebate + beta1 * CVMatrix[i, Steps];
                        }
                        else
                        {
                            OptList[i] = 0 + beta1 * CVMatrix[i, Steps];
                        }
                        
                    }
                }
                else
                {

                    for (int i = 0; i < Nsim; i++)
                    {
                        if (K - S[i, Steps] > 0)
                        {
                            OptList[i] = rebate + beta1 * CVMatrix[i, Steps];
                        }
                        else
                        {
                            OptList[i] = 0 + beta1 * CVMatrix[i, Steps];
                        }
                       

                    }

                }
            }
            else
            {
                if (Iscall == true)
                {

                    for (int i = 0; i < Nsim; i++)
                    {
                        if (S[i, Steps] - K > 0)
                        {

                            OptList[i] = rebate;
                        }
                        else
                        {
                            OptList[i] = 0;
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < Nsim; i++)
                    {
                        if (K - S[i, Steps] > 0)
                        {
                            OptList[i] = rebate;
                        }
                        else
                        {
                            OptList[i] = 0;
                        }
                    }
                }
            }

            return OptList;
        }



        //Calculate Option Value
        public double OptionPrice()
        {
            double C;
            double Sum_CT = 0.0;
            double[] Optionlist = OptionList();

            for (int i = 0; i < Nsim; i++)
            {
                Sum_CT += Optionlist[i];
            }
            C = Math.Exp(-r * T) * (Sum_CT / (double)Nsim);
            return C;
        }



        //Calculate the standard error

        public double StandardError()
        {
            double SD;
            double SE;
            double d = 0;
            double C0 = OptionPrice();
            double[] Optionlist = OptionList();
            if (Isantithetic == false)
            {
                for (int i = 0; i < Nsim; i++)
                {
                    d += Math.Pow(Math.Exp(-r * T) * Optionlist[i] - C0, 2.0);
                }

                SD = Math.Sqrt(d / (Nsim - 1));
                SE = SD / Math.Sqrt(Nsim);
            }
            else
            {
                double[] pair = new double[Nsim / 2];
                for (int i = 0; i < Nsim / 2; i++)
                {
                    pair[i] = Math.Exp(-r * T) * (Optionlist[i] + Optionlist[i + Nsim / 2]) / 2.0;
                }

                for (int i = 0; i < Nsim / 2; i++)
                {
                    d += Math.Pow(pair[i] - C0, 2.0);
                }
                double variance = d / (double)((Nsim / 2) - 1);
                SE = Math.Sqrt(variance / (double)(Nsim / 2));

            }
            return SE;
        }


        public double GetDelta()
        {

            #region instance 1
            DigitalOptions E1 = new DigitalOptions();
            E1.SpotPrice = this.SpotPrice * (1 + 0.001);
            E1.SprikePrice = SprikePrice;
            E1.Drift = Drift;
            E1.Volatility = Volatility;
            E1.Tenor = Tenor;
            E1.TrialNumber = TrialNumber;
            E1.StepNumber = StepNumber;
            E1.Side = Side;
            E1.Delta_ControlVariate = Delta_ControlVariate;
            E1.Antithetic = Antithetic;
            E1.Multithreading = Multithreading;
            E1.RandNumbers = RandNumbers;
            E1.RebateValue = RebateValue;

            #endregion instance 1
            #region instance 2
            DigitalOptions E2 = new DigitalOptions();
            E2.SpotPrice = this.SpotPrice * (1 - 0.001);
            E2.SprikePrice = SprikePrice;
            E2.Drift = Drift;
            E2.Volatility = Volatility;
            E2.Tenor = Tenor;
            E2.TrialNumber = TrialNumber;
            E2.StepNumber = StepNumber;
            E2.Side = Side;
            E2.Delta_ControlVariate = Delta_ControlVariate;
            E2.Antithetic = Antithetic;
            E2.Multithreading = Multithreading;
            E2.RandNumbers = RandNumbers;
            E2.RebateValue = RebateValue;
            #endregion instance 2

            return (E1.OptionPrice() - E2.OptionPrice()) / (0.002 * SpotPrice);

        }
        public double GetGamma()
        {
            #region instance 1
            DigitalOptions E1 = new DigitalOptions();
            E1.SpotPrice = this.SpotPrice * (1 + 0.001);
            E1.SprikePrice = SprikePrice;
            E1.Drift = Drift;
            E1.Volatility = Volatility;
            E1.Tenor = Tenor;
            E1.TrialNumber = TrialNumber;
            E1.StepNumber = StepNumber;
            E1.Side = Side;
            E1.Delta_ControlVariate = Delta_ControlVariate;
            E1.Antithetic = Antithetic;
            E1.Multithreading = Multithreading;
            E1.RandNumbers = RandNumbers;
            E1.RebateValue = RebateValue;


            #endregion instance 1
            #region instance 2
            DigitalOptions E2 = new DigitalOptions();
            E2.SpotPrice = this.SpotPrice * (1 - 0.001);
            E2.SprikePrice = SprikePrice;
            E2.Drift = Drift;
            E2.Volatility = Volatility;
            E2.Tenor = Tenor;
            E2.TrialNumber = TrialNumber;
            E2.StepNumber = StepNumber;
            E2.Side = Side;
            E2.Delta_ControlVariate = Delta_ControlVariate;
            E2.Antithetic = Antithetic;
            E2.Multithreading = Multithreading;
            E2.RandNumbers = RandNumbers;
            E2.RebateValue = RebateValue;
            #endregion instance 2

            return (E1.OptionPrice() - 2 * OptionPrice() + E2.OptionPrice()) / Math.Pow(0.001 * SpotPrice, 2);

        }

        public double GetVega()
        {
            #region instance 1
            DigitalOptions E1 = new DigitalOptions();
            E1.SpotPrice = this.SpotPrice;
            E1.SprikePrice = SprikePrice;
            E1.Drift = Drift;
            E1.Volatility = Volatility * (1 + 0.001);
            E1.Tenor = Tenor;
            E1.TrialNumber = TrialNumber;
            E1.StepNumber = StepNumber;
            E1.Side = Side;
            E1.Delta_ControlVariate = Delta_ControlVariate;
            E1.Antithetic = Antithetic;
            E1.Multithreading = Multithreading;
            E1.RandNumbers = RandNumbers;
            E1.RebateValue = RebateValue;

            #endregion instance 1
            #region instance 2
            DigitalOptions E2 = new DigitalOptions();
            E2.SpotPrice = this.SpotPrice;
            E2.SprikePrice = SprikePrice;
            E2.Drift = Drift;
            E2.Volatility = Volatility * (1 - 0.001);
            E2.Tenor = Tenor;
            E2.TrialNumber = TrialNumber;
            E2.StepNumber = StepNumber;
            E2.Side = Side;
            E2.Delta_ControlVariate = Delta_ControlVariate;
            E2.Antithetic = Antithetic;
            E2.Multithreading = Multithreading;
            E2.RandNumbers = RandNumbers;
            E2.RebateValue = RebateValue;
            #endregion instance 2
            return (E1.OptionPrice() - E2.OptionPrice()) / (0.002 * Volatility);

        }
        public double GetTheta()
        {
            #region instance 1
            DigitalOptions E1 = new DigitalOptions();
            E1.SpotPrice = this.SpotPrice;
            E1.SprikePrice = SprikePrice;
            E1.Drift = Drift;
            E1.Volatility = Volatility;
            E1.Tenor = Tenor * (1 + 0.001);
            E1.TrialNumber = TrialNumber;
            E1.StepNumber = StepNumber;
            E1.Side = Side;
            E1.Delta_ControlVariate = Delta_ControlVariate;
            E1.Antithetic = Antithetic;
            E1.Multithreading = Multithreading;
            E1.RandNumbers = RandNumbers;
            E1.RebateValue = RebateValue;
            #endregion instance 1
            return (E1.OptionPrice() - OptionPrice()) / (0.001 * Tenor);


        }
        public double GetRho()
        {
            #region instance 1
            DigitalOptions E1 = new DigitalOptions();
            E1.SpotPrice = this.SpotPrice;
            E1.SprikePrice = SprikePrice;
            E1.Drift = Drift * (1 + 0.001);
            E1.Volatility = Volatility;
            E1.Tenor = Tenor;
            E1.TrialNumber = TrialNumber;
            E1.StepNumber = StepNumber;
            E1.Side = Side;
            E1.Delta_ControlVariate = Delta_ControlVariate;
            E1.Antithetic = Antithetic;
            E1.Multithreading = Multithreading;
            E1.RandNumbers = RandNumbers;
            E1.RebateValue = RebateValue;

            #endregion instance 1
            #region instance 2
            DigitalOptions E2 = new DigitalOptions();
            E2.SpotPrice = this.SpotPrice;
            E2.SprikePrice = SprikePrice;
            E2.Drift = Drift * (1 - 0.001);
            E2.Volatility = Volatility;
            E2.Tenor = Tenor;
            E2.TrialNumber = TrialNumber;
            E2.StepNumber = StepNumber;
            E2.Side = Side;
            E2.Delta_ControlVariate = Delta_ControlVariate;
            E2.Antithetic = Antithetic;
            E2.Multithreading = Multithreading;
            E2.RandNumbers = RandNumbers;
            E2.RebateValue = RebateValue;
            #endregion instance 2
            return (E1.OptionPrice() - E2.OptionPrice()) / (0.002 * Drift);


        }
    }
}
