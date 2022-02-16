using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_ExoticOptions
{
    public class Simulator
    {
        protected double vol, r, S0, K, T;
        protected int Steps, Nsim;
        protected bool Iscall, Isantithetic, IsDeltaCV;
        protected bool IsMultithread;
        protected double[,] CVMatrix;

        protected int barrierstyle;
        protected double barrier, rebate;

        public double Volatility { get { return vol; } set { vol = value; } }  // Volatility (standard deviation) of the instrument
        public double Drift { get { return r; } set { r = value; } }      //  risk-free rate of the instrument
        public double SpotPrice { get { return S0; } set { S0 = value; } }   // Starting price for the simulation
        public double SprikePrice { get { return K; } set { K = value; } }   // Exercise price of the option
        public int StepNumber { get { return Steps; } set { Steps = value; } }  // Number of steps in the simulation       
        public double Tenor { get { return T; } set { T = value; } } //Tenor of the option
        public int TrialNumber { get { return Nsim; } set { Nsim = 2 * Convert.ToInt32(Math.Ceiling(0.5 * value)); } }   // Number of simulations
        public bool Side { get { return Iscall; } set { Iscall = value; } } // call or put
        public bool Antithetic { get { return Isantithetic; } set { Isantithetic = value; } }
        public bool Delta_ControlVariate { get { return IsDeltaCV; } set { IsDeltaCV = value; } }
        public bool Multithreading { get { return IsMultithread; } set { IsMultithread = value; } }
        public double[,] RandNumbers { get; set; }

        public static int CoreNumber = System.Environment.ProcessorCount;
        public int BarrierType { get { return barrierstyle; } set { barrierstyle = value; } }  //0: up and in; 1:up and out;  2:down and in; 3: down and out;
        public double RebateValue { get { return rebate; } set { rebate = value; } }
        public double BarrierPrice { get { return barrier; } set { barrier = value; } }

        //public double[,] Path { get { return PathMatrix; }}
        //public double[,] ControlV { get { return CVMatrix; } }

        //public double[] OptionValue { get { return OptionArray; } set { OptionArray = value; } }

        //int Nsim = 2 * Convert.ToInt32(Math.Ceiling(0.5 * this.Trials));



        public static int GetRandomSeed() //prevent random numbers from matching with each other
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }


        static Random rand = new Random(GetRandomSeed());

        public static double GetRandNumber(Random rnd)
        {
            double x1, x2, z3, w;
            do
            {
                x1 = 2 * rnd.NextDouble() - 1; //Generate two uniform random values; and change their interval to (-1,1)
                x2 = 2 * rnd.NextDouble() - 1;
                w = x1 * x1 + x2 * x2;
            } while (w > 1);              //If w > 1, repeat the first two steps, if not, continue
            return z3 = Math.Sqrt(-2 * Math.Log(w) / w) * x1;
        }



        //This method generates a matrix of random values that can be used when creating simulated prices.

        public double[,] GetRandMatrix()
        {

            double[,] matrix = new double[Nsim, Steps];

            if (IsMultithread == true)
            {

                int eachTaskload = Nsim / CoreNumber; //get how many tasks each core need to do
                List<int> TaskList = new List<int>();
                int rest = Nsim - eachTaskload * CoreNumber; //add the rest part of random matrix.

                for (int i = 0; i < (CoreNumber - 1); i++)
                {
                    TaskList.Add(eachTaskload);// 
                }
                TaskList.Add(eachTaskload + rest); //Let the last core do the rest task

                List<int> start = new List<int>();
                start.Add(0);

                for (int i = 0; i < (CoreNumber - 1); i++)
                {
                    start.Add(start[i] + TaskList[i]);
                }


                Parallel.For(0, CoreNumber, i => { GetRandInner(start[i], TaskList[i], matrix); });
            }
            else
            {
                for (int i = 0; i < Nsim; i++)
                {
                    for (int j = 0; j < Steps; j++)
                    {
                        matrix[i, j] = GetRandNumber(rand);
                    }
                }
            }

            return matrix;
        }


        private void GetRandInner(int start, int eachload, double[,] matrix)
        {

            for (int i = start; i < start + eachload; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    matrix[i, j] = GetRandNumber(rand);
                }
            }
        }



        public double[,] Anti_GetRandMatrix()
        {
            double[,] matrix = new double[Nsim, Steps];

            if (IsMultithread == true)
            {
                int eachTaskload = (Nsim / 2) / CoreNumber; //get how many tasks each core need to do
                List<int> TaskList = new List<int>();
                int rest = Nsim / 2 - eachTaskload * CoreNumber; //add the rest part of random matrix.

                for (int i = 0; i < (CoreNumber - 1); i++)
                {
                    TaskList.Add(eachTaskload);// 
                }
                TaskList.Add(eachTaskload + rest); //Let the last core do the rest task

                List<int> start = new List<int>();
                start.Add(0);

                for (int i = 0; i < (CoreNumber - 1); i++)
                {
                    start.Add(start[i] + TaskList[i]);
                }

                Parallel.For(0, CoreNumber, i => { Anti_GetRandInner(start[i], TaskList[i], matrix); });
            }
            else
            {
                for (int i = 0; i < Nsim / 2; i++)
                {
                    for (int j = 0; j < Steps; j++)
                    {
                        matrix[i, j] = GetRandNumber(rand);
                        matrix[i + Nsim / 2, j] = -matrix[i, j];
                    }
                }
            }
            return matrix;
        }



        private void Anti_GetRandInner(int start, int eachload, double[,] matrix)
        {
            for (int i = start; i < start + eachload; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    matrix[i, j] = GetRandNumber(rand);
                    matrix[i + Nsim / 2, j] = -matrix[i, j];
                }
            }
        }




        //public void InitializeRndMatrix()
        //{
        //    RandMatrix = new double[Nsim, Steps + 1];
        //    if (Isantithetic == true)
        //    {
        //        RandMatrix = Anti_GetRandMatrix();
        //    }
        //    else
        //    {

        //        RandMatrix = GetRandMatrix();
        //    }
        //}


        public double[,] SimulatedPrice()
        {
            double[,] Price = new double[Nsim, Steps + 1];
            double[,] ControlVt = new double[Nsim, Steps + 1];// Dimension Matrix and give it the first value 
            double dt = T / (double)Steps;  //Time step
            double delta, d1;
            double T1;

            if (IsMultithread == true)
            {
                int eachTaskload = Nsim / CoreNumber; //get how many tasks each core need to do
                List<int> TaskList = new List<int>();
                int rest = Nsim - eachTaskload * CoreNumber; //add the rest part of random matrix.

                for (int i = 0; i < (CoreNumber - 1); i++)
                {
                    TaskList.Add(eachTaskload);
                }
                TaskList.Add(eachTaskload + rest); //Let the last core do the rest task

                List<int> start = new List<int>();
                start.Add(0);

                for (int i = 0; i < (CoreNumber - 1); i++)
                {
                    start.Add(start[i] + TaskList[i]);
                }
                if (IsDeltaCV == true)
                {

                    Parallel.For(0, CoreNumber, i => { CV_SimulatedPriceInner(start[i], TaskList[i], Price, ControlVt); });
                }
                else
                {

                    Parallel.For(0, CoreNumber, i => { SimulatedPriceInner(start[i], TaskList[i], Price); });
                }


            }
            else
            {
                if (IsDeltaCV == true)
                {
                    for (int i = 0; i < Nsim; i++)
                    {
                        Price[i, 0] = S0;
                        ControlVt[i, 0] = 0;
                    }
                    if (Iscall == true)
                    {
                        for (int i = 0; i < Nsim; i++)
                        {

                            for (int j = 1; j < (Steps + 1); j++)
                            {
                                Price[i, j] = Price[i, j - 1] * Math.Exp((r - 0.5 * Math.Pow(vol, 2.0)) * dt + vol * Math.Sqrt(dt) * RandNumbers[i, j - 1]);
                                T1 = T - (j - 1) * dt;
                                d1 = (Math.Log(Price[i, j - 1] / K) + (r + vol * vol / 2.0) * T1) / (vol * Math.Sqrt(T1)); //calculte d1
                                delta = CDF(d1);   //calclute delta 
                                ControlVt[i, j] = ControlVt[i, j - 1] + delta * (Price[i, j] - Price[i, j - 1] * Math.Exp(r * dt));
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < Nsim; i++)
                        {
                            for (int j = 1; j < (Steps + 1); j++)
                            {
                                Price[i, j] = Price[i, j - 1] * Math.Exp((r - 0.5 * Math.Pow(vol, 2.0)) * dt + vol * Math.Sqrt(dt) * RandNumbers[i, j - 1]);
                                T1 = T - (j - 1) * dt;
                                d1 = (Math.Log(Price[i, j - 1] / K) + (r + vol * vol / 2.0) * T1) / (vol * Math.Sqrt(T1)); //calculte d1
                                delta = CDF(d1) - 1;   //calclute delta 
                                ControlVt[i, j] = ControlVt[i, j - 1] + delta * (Price[i, j] - Price[i, j - 1] * Math.Exp(r * dt));
                            }

                        }

                    }
                }
                else
                {
                    for (int i = 0; i < Nsim; i++)
                    {
                        Price[i, 0] = S0;
                        for (int j = 1; j < (Steps + 1); j++)
                        {
                            Price[i, j] = Price[i, j - 1] * Math.Exp((r - 0.5 * Math.Pow(vol, 2.0)) * dt + vol * Math.Sqrt(dt) * RandNumbers[i, j - 1]);

                        }
                    }
                }
            }
            CVMatrix = ControlVt;
            return Price;

        }



        private void SimulatedPriceInner(int start, int eachload, double[,] Price)
        {

            double dt = T / (double)Steps;  //Time step
            for (int i = start; i < start + eachload; i++)
            {
                Price[i, 0] = S0;
                for (int j = 1; j < (Steps + 1); j++)
                {
                    Price[i, j] = Price[i, j - 1] * Math.Exp((r - 0.5 * Math.Pow(vol, 2.0)) * dt + vol * Math.Sqrt(dt) * RandNumbers[i, j - 1]);
                }
            }
        }



        private void CV_SimulatedPriceInner(int start, int eachload, double[,] Price, double[,] ControlVt)
        {
            double dt = T / (double)Steps;  //Time step
            double delta, d1;
            double T1;

            if (Iscall == true)
            {
                for (int i = start; i < start + eachload; i++)
                {
                    Price[i, 0] = S0;
                    ControlVt[i, 0] = 0;
                    for (int j = 1; j < (Steps + 1); j++)
                    {
                        Price[i, j] = Price[i, j - 1] * Math.Exp((r - 0.5 * Math.Pow(vol, 2.0)) * dt + vol * Math.Sqrt(dt) * RandNumbers[i, j - 1]);
                        T1 = T - (j - 1) * dt;
                        d1 = (Math.Log(Price[i, j - 1] / K) + (r + vol * vol / 2.0) * T1) / (vol * Math.Sqrt(T1)); //calculte d1
                        delta = CDF(d1);   //calclute delta 
                        ControlVt[i, j] = ControlVt[i, j - 1] + delta * (Price[i, j] - Price[i, j - 1] * Math.Exp(r * dt));
                    }
                }
            }
            else
            {
                for (int i = start; i < start + eachload; i++)
                {
                    Price[i, 0] = S0;
                    ControlVt[i, 0] = 0;
                    for (int j = 1; j < (Steps + 1); j++)
                    {
                        Price[i, j] = Price[i, j - 1] * Math.Exp((r - 0.5 * Math.Pow(vol, 2.0)) * dt + vol * Math.Sqrt(dt) * RandNumbers[i, j - 1]);
                        T1 = T - (j - 1) * dt;
                        d1 = (Math.Log(Price[i, j - 1] / K) + (r + vol * vol / 2.0) * T1) / (vol * Math.Sqrt(T1)); //calculte d1
                        delta = CDF(d1) - 1;   //calclute delta 
                        ControlVt[i, j] = ControlVt[i, j - 1] + delta * (Price[i, j] - Price[i, j - 1] * Math.Exp(r * dt));
                    }
                }
            }
        }






        public static double CDF(double z)
        {
            double p = 0.3275911;
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            int sign;
            if (z < 0.0)
                sign = -1;
            else
                sign = 1;

            double x = Math.Abs(z) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * erf);
        }

    }
}
