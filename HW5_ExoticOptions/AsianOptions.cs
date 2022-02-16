using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_ExoticOptions
{
    public class AsianOptions:Simulator
    {
        public static double beta1 = -1.0;

        public double[] OptionList()
        {

            double[,] S = SimulatedPrice();

            double[] OptList = new double[Nsim];

            double[] SMean = new double[Nsim];

            

            for (int i = 0; i < Nsim; i++)
            {
                double sum = 0;

                for (int j = 0; j < Steps + 1; j++)
                {
                    sum += S[i, j];
                }
                SMean[i] = sum / (double)(Steps + 1);
            }


            if (IsDeltaCV == true)
            {

                if (Iscall == true)
                {
                    for (int i = 0; i < Nsim; i++)
                    {
                        OptList[i] = Math.Max(SMean[i] - K, 0) + beta1 * CVMatrix[i, Steps];
                    }
                }
                else
                {

                    for (int i = 0; i < Nsim; i++)
                    {
                        OptList[i] = Math.Max(K - SMean[i], 0) + beta1 * CVMatrix[i, Steps];

                    }

                }
            }
            else
            {
                if (Iscall == true)
                {

                    for (int i = 0; i < Nsim; i++)
                    {
                        OptList[i] = Math.Max(SMean[i] - K, 0);

                    }
                }
                else
                {
                    for (int i = 0; i < Nsim; i++)
                    {
                        OptList[i] = Math.Max(K - SMean[i], 0);

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
            AsianOptions A1 = new AsianOptions();
            A1.SpotPrice = this.SpotPrice * (1 + 0.001);
            A1.SprikePrice = SprikePrice;
            A1.Drift = Drift;
            A1.Volatility = Volatility;
            A1.Tenor = Tenor;
            A1.TrialNumber = TrialNumber;
            A1.StepNumber = StepNumber;
            A1.Side = Side;
            A1.Delta_ControlVariate = Delta_ControlVariate;
            A1.Antithetic = Antithetic;
            A1.Multithreading = Multithreading;
            A1.RandNumbers = RandNumbers;

            #endregion instance 1
            #region instance 2
            AsianOptions A2 = new AsianOptions();
            A2.SpotPrice = this.SpotPrice * (1 - 0.001);
            A2.SprikePrice = SprikePrice;
            A2.Drift = Drift;
            A2.Volatility = Volatility;
            A2.Tenor = Tenor;
            A2.TrialNumber = TrialNumber;
            A2.StepNumber = StepNumber;
            A2.Side = Side;
            A2.Delta_ControlVariate = Delta_ControlVariate;
            A2.Antithetic = Antithetic;
            A2.Multithreading = Multithreading;
            A2.RandNumbers = RandNumbers;
            #endregion instance 2

            return (A1.OptionPrice() - A2.OptionPrice()) / (0.002 * SpotPrice);

        }
        public double GetGamma()
        {
            #region instance 1
            AsianOptions A1 = new AsianOptions();
            A1.SpotPrice = this.SpotPrice * (1 + 0.001);
            A1.SprikePrice = SprikePrice;
            A1.Drift = Drift;
            A1.Volatility = Volatility;
            A1.Tenor = Tenor;
            A1.TrialNumber = TrialNumber;
            A1.StepNumber = StepNumber;
            A1.Side = Side;
            A1.Delta_ControlVariate = Delta_ControlVariate;
            A1.Antithetic = Antithetic;
            A1.Multithreading = Multithreading;
            A1.RandNumbers = RandNumbers;


            #endregion instance 1
            #region instance 2
            AsianOptions A2 = new AsianOptions();
            A2.SpotPrice = this.SpotPrice * (1 - 0.001);
            A2.SprikePrice = SprikePrice;
            A2.Drift = Drift;
            A2.Volatility = Volatility;
            A2.Tenor = Tenor;
            A2.TrialNumber = TrialNumber;
            A2.StepNumber = StepNumber;
            A2.Side = Side;
            A2.Delta_ControlVariate = Delta_ControlVariate;
            A2.Antithetic = Antithetic;
            A2.Multithreading = Multithreading;
            A2.RandNumbers = RandNumbers;
            #endregion instance 2

            return (A1.OptionPrice() - 2 * OptionPrice() + A2.OptionPrice()) / Math.Pow(0.001 * SpotPrice, 2);

        }

        public double GetVega()
        {
            #region instance 1
            AsianOptions A1 = new AsianOptions();
            A1.SpotPrice = this.SpotPrice;
            A1.SprikePrice = SprikePrice;
            A1.Drift = Drift;
            A1.Volatility = Volatility * (1 + 0.001);
            A1.Tenor = Tenor;
            A1.TrialNumber = TrialNumber;
            A1.StepNumber = StepNumber;
            A1.Side = Side;
            A1.Delta_ControlVariate = Delta_ControlVariate;
            A1.Antithetic = Antithetic;
            A1.Multithreading = Multithreading;
            A1.RandNumbers = RandNumbers;


            #endregion instance 1
            #region instance 2
            AsianOptions A2 = new AsianOptions();
            A2.SpotPrice = this.SpotPrice;
            A2.SprikePrice = SprikePrice;
            A2.Drift = Drift;
            A2.Volatility = Volatility * (1 - 0.001);
            A2.Tenor = Tenor;
            A2.TrialNumber = TrialNumber;
            A2.StepNumber = StepNumber;
            A2.Side = Side;
            A2.Delta_ControlVariate = Delta_ControlVariate;
            A2.Antithetic = Antithetic;
            A2.Multithreading = Multithreading;
            A2.RandNumbers = RandNumbers;
            #endregion instance 2
            return (A1.OptionPrice() - A2.OptionPrice()) / (0.002 * Volatility);

        }
        public double GetTheta()
        {

            #region instance 1
            AsianOptions A1 = new AsianOptions();
            A1.SpotPrice = this.SpotPrice;
            A1.SprikePrice = SprikePrice;
            A1.Drift = Drift;
            A1.Volatility = Volatility;
            A1.Tenor = Tenor * (1 + 0.001);
            A1.TrialNumber = TrialNumber;
            A1.StepNumber = StepNumber;
            A1.Side = Side;
            A1.Delta_ControlVariate = Delta_ControlVariate;
            A1.Antithetic = Antithetic;
            A1.Multithreading = Multithreading;
            A1.RandNumbers = RandNumbers;
            #endregion instance 1
            return (A1.OptionPrice() - OptionPrice()) / (0.001 * Tenor);

        }
        public double GetRho()
        {
            #region instance 1
            AsianOptions A1 = new AsianOptions();
            A1.SpotPrice = this.SpotPrice;
            A1.SprikePrice = SprikePrice;
            A1.Drift = Drift * (1 + 0.001);
            A1.Volatility = Volatility;
            A1.Tenor = Tenor;
            A1.TrialNumber = TrialNumber;
            A1.StepNumber = StepNumber;
            A1.Side = Side;
            A1.Delta_ControlVariate = Delta_ControlVariate;
            A1.Antithetic = Antithetic;
            A1.Multithreading = Multithreading;
            A1.RandNumbers = RandNumbers;


            #endregion instance 1
            #region instance 2
            AsianOptions A2 = new AsianOptions();
            A2.SpotPrice = this.SpotPrice;
            A2.SprikePrice = SprikePrice;
            A2.Drift = Drift * (1 - 0.001);
            A2.Volatility = Volatility;
            A2.Tenor = Tenor;
            A2.TrialNumber = TrialNumber;
            A2.StepNumber = StepNumber;
            A2.Side = Side;
            A2.Delta_ControlVariate = Delta_ControlVariate;
            A2.Antithetic = Antithetic;
            A2.Multithreading = Multithreading;
            A2.RandNumbers = RandNumbers;
            #endregion instance 2
            return (A1.OptionPrice() - A2.OptionPrice()) / (0.002 * Drift);


        }
    }
}
