using GameBalls;

namespace CatchMe2WinFormsApp
{
    public partial class Form1 : Form
    {
        private List<RandomMoveBall> balls;
        private int countMouse = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackColor = Color.White;
            balls = new List<RandomMoveBall>();
            for (int i = 0; i < 10; i++)
            {
                var moveBall = new RandomMoveBall(this);
                balls.Add(moveBall);
                balls[i].Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (balls[i].FindBallsMouse(e.X, e.Y) && !balls[i].isTimerStatus())
                {
                    balls[i].Stop();
                    if (balls[i].FindBalls())
                    {
                        countMouse++;
                        label1.Text = countMouse.ToString();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                balls[i].Clear();
            }
            BackColor = Color.White;
        }
    }
}
