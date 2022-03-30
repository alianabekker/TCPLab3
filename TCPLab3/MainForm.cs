using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TCPLab3.StateMachine;

namespace TCPLab3
{
    public partial class MainForm : Form
    {
        Random rnd = new Random(DateTime.Now.Second);
        public MainForm()
        {
            InitializeComponent();
            SumVector();
            SumS1();
            SumS2();
            SumS3();
        }

        void SumVector()
        {
            sumS0S1S3.Text = (S0.Value + S1.Value + S2.Value).ToString().Replace(',', '.'); 
        }
        void SumS1()
        {
            sumS0.Text = (S0S0.Value + S0S1.Value + S0S2.Value).ToString().Replace(',', '.');
        }
        void SumS2()
        {
            sumS1.Text = (S1S0.Value + S1S1.Value + S1S2.Value).ToString().Replace(',', '.');
        }

        void SumS3()
        {
            sumS2.Text = (S2S0.Value + S2S1.Value + S2S2.Value).ToString().Replace(',','.');
        }

        private void S0_ValueChanged(object sender, EventArgs e)
        {
            SumVector(); 
        }

        private void S1_ValueChanged(object sender, EventArgs e)
        {
            SumVector();
        }

        private void S2_ValueChanged(object sender, EventArgs e)
        {
            SumVector();
        }

        private void S0S0_ValueChanged(object sender, EventArgs e)
        {
            SumS1();
        }

        private void S0S1_ValueChanged(object sender, EventArgs e)
        {
            SumS1();
        }

        private void S0S2_ValueChanged(object sender, EventArgs e)
        {
            SumS1();
        }

        private void S1S1_ValueChanged(object sender, EventArgs e)
        {
            SumS2();
        }

        private void S1S2_ValueChanged(object sender, EventArgs e)
        {
            SumS2();
        }

        private void S2S2_ValueChanged(object sender, EventArgs e)
        {
            SumS3();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (CheckEnterData())
                Simulation();
        }

        bool CheckEnterData()
        {
            if (sumS0S1S3.Text != "1.00" && sumS0S1S3.Text != "1.0" && sumS0S1S3.Text != "1")
            {
                MessageBox.Show("Сумма вероятностей в векторе начальных вероятностей не равна 1!");
                return false;
            }
            if (sumS0.Text != "1.00")
            {
                MessageBox.Show("Сумма вероятностей переходов из S0 в матрице начальных вероятностей переходов не равна 1!");
                return false;
            }
            if (sumS1.Text != "1.00")
            {
                MessageBox.Show("Сумма вероятностей переходов из S1 в матрице начальных вероятностей переходов не равна 1!");
                return false;
            }
            if (sumS2.Text != "1.00" && sumS2.Text != "1.0" && sumS2.Text != "1")
            {
                MessageBox.Show("Сумма вероятностей переходов из S2 в матрице начальных вероятностей переходов не равна 1!");
                return false;
            }

            return true; 
        }

        void Simulation() 
        {
            List<StateMachine> states = new List<StateMachine>
            {
                new StateMachine(0, new List<Transition>{ new Transition(0, 0, (double)S0S0.Value), new Transition(1, (double)S0S0.Value, (double)S0S0.Value + (double)S0S1.Value), new Transition(2, (double)S0S1.Value, (double)S0S0.Value + (double)S0S1.Value + (double)S0S2.Value)}),
                new StateMachine(1, new List<Transition>{new Transition(1, 0, (double)S1S1.Value), new Transition(2, (double)S1S1.Value, (double)S1S1.Value + (double)S1S2.Value)}),
                new StateMachine(2, new List<Transition>{ new Transition(2, 0, (double)S2S2.Value)})
            };
            List<string> resultStr = new List<string>();
            List<int> generalCountsShoot = new List<int>(); 
            int generalCountShoot = 0; 

            int countRepeat = (int)nudCountRepeat.Value;
            for(int i = 0; i< countRepeat; i++)
            {
                var result = DoExperiment(states);
                generalCountShoot += result.Item1;
                resultStr.Add(result.Item2);
                generalCountsShoot.Add(result.Item1);
            }

            var resultForm = new ResultForm(generalCountsShoot,resultStr,(double)generalCountShoot/(double)countRepeat);
            resultForm.Show();
        }

        (int,string) DoExperiment(List<StateMachine> states)
        {
            //вычисляем начальное состояние
            var pStartState = rnd.NextDouble();
            int currentState = 0;
            int countShoot = 0;

            if (pStartState < (double)S0.Value)
                currentState = 0;
            else if (pStartState > (double)S0.Value && pStartState < (double)S0.Value + (double)S1.Value)
                currentState = 1;
            else currentState = 2;

            string result = "S"+ currentState;

            int i = 0; 
            //пока цель не будет поражена, продолжаем стрелять
            while (currentState != 2)
            {
                countShoot++;
                var pShoot = rnd.NextDouble(); //генерируем новую вероятность
                var curState = states.FirstOrDefault(x => x.State == currentState);
                //получаем новое состояние, в которое перейдём из текущего
                currentState = curState.Transitions.FirstOrDefault(x => pShoot >= x.startP && pShoot <= x.endP).state;
                //добавляем новое состояние в результирующую строку
                result += "(" + pShoot.ToString("0.##") +") -> S" + currentState;
                i++; 
            }
            return (countShoot, result);
        }
    }
}
