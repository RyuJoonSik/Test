using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace MyTest5
{
    public partial class Form1 : Form
    {
        private bool sw;
        private Thread randTh, progTh;
        private int x, y;
        
        public Form1()
        {
            InitializeComponent();
        }

        // Thread로 수행할 작업
       
        private void Count()
        {
            while (sw)
            {
                // 1초 간격으로 난수 생성
                Random r = new Random();
                x = r.Next(1, 100);
                y = r.Next(1, 100);
                Thread.Sleep(1000);
            }
        }

        private void Prog()
        {
            while (sw)
            {
                // 만들어진 난수값 대입
                progressBar1.Value = x;
                label1.Text = progressBar1.Value.ToString();
                verticalProgressBar1.Value = y;
                label2.Text = verticalProgressBar1.Value.ToString();
            }
        }

        private void btnStartThread_Click(object sender, EventArgs e)
        {
            randTh = new Thread(Count); // 난수생성 스레드
            progTh = new Thread(Prog); // 난수값 대입 스레드
            sw = true; // sw가 true 조건동안만 작동
            randTh.Start();
            progTh.Start();
        }

        private void btnStopThread_Click_1(object sender, EventArgs e)
        {
            // false시 스레드 정지
            sw = false;
        }
    }
}
