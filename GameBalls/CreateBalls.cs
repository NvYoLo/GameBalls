using System.Data;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GameBalls
{
    public class CreateBalls
    {
        protected Form1 form1;
        protected int vx = 5;
        protected int vy = -5;
        protected int x;
        protected int y;
        protected int width = 70;
        protected int height = 70;
        protected Random random = new Random();
        public CreateBalls(Form1 form)
        {
            form1 = form;
        }
        public void Show()
        {
            var graph = form1.CreateGraphics();
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(x, y, width, height);
            graph.FillEllipse(brush, rectangle);
        }

        public void Clear()
        {
            var graph = form1.CreateGraphics();
            var brush = Brushes.White;
            var rectangle = new Rectangle(x, y, width, height);
            graph.FillEllipse(brush, rectangle);
        }

        public void Go()
        {
            x += vx;
            y += vy;
        }
        public void Move()
        {
            Clear();
            Go();
            Show();
        }

    }
    
    public class RandomBalls : CreateBalls
    {
        
        public RandomBalls(Form1 form) : base(form)
        {
            x = random.Next(0, form.ClientSize.Width - width);
            y = random.Next(0, form.ClientSize.Height - height);
        }
    }
    public class RandomMoveBall : MoveBall
    {
        
        public RandomMoveBall(Form1 form) : base(form)
        {
            vx = random.Next(-5, 6);
            vy = random.Next(-5, 5);
        }
    }

    public class MoveBall : RandomBalls
    {
        private Timer timer;
        private bool isRunning;
        public MoveBall(Form1 form) : base(form)
        {
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
            isRunning = false;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }

        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
            isRunning = true;
        }
        public bool isTimerStatus()
        {
            return isRunning;
        }
        public bool FindBalls()
        {
           return x>= 0  && x + width <= form1.ClientSize.Width && y>=0 && y + height <= form1.ClientSize.Height;
        }
        public bool FindBallsMouse(int mouseX, int mouseY)
        {
            if (mouseX >= x && mouseX <= x + width && mouseY >= y && mouseY <= y + height) return true;
            return false;
        }
    }
}
