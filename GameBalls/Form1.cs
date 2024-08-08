using System.Runtime.CompilerServices;

namespace GameBalls
{
    public partial class Form1 : Form
    {
        List<MoveBall> balls;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackColor = Color.White;
            balls = new List<MoveBall>();
            for (int i = 0; i < 10; i++)
            {
                var moveBall = new MoveBall(this);
                balls.Add(moveBall);
                balls[i].Start();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var count = 0;
            for (int i = 0; i < 10; i++)
            {
                balls[i].Stop();
                if (balls[i].FindBalls())
                {
                    count++;
                }
            }
            MessageBox.Show($"���������� ������� ������� ������� �������: {count.ToString()}");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                balls[i].Clear();
            }
            BackColor = Color.White;
        }
    }
}
