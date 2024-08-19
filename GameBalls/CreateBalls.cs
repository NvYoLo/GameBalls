using System.Data;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GameBalls
{
    public class CreateBalls
    {
        protected Form form1;
        protected int vx = 10;
        protected int vy = 10;
        protected int centerX;
        protected int centerY;
        protected int radius = 25;
        protected Random random = new Random();
        public CreateBalls(Form form)
        {
            form1 = form;
        }
        public void Show()
        {
            var graph = form1.CreateGraphics();
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(centerX, centerY, radius, radius);
            graph.FillEllipse(brush, rectangle);
        }

        public void Clear()
        {
            var graph = form1.CreateGraphics();
            var brush = Brushes.White;
            var rectangle = new Rectangle(centerX, centerY, radius, radius);
            graph.FillEllipse(brush, rectangle);
        }

        public void Go()
        {
            centerX += vx;
            centerY += vy;
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
        
        public RandomBalls(Form form) : base(form)
        {
            centerX = random.Next(0, form.ClientSize.Width - radius);
            centerY = random.Next(0, form.ClientSize.Height - radius);
        }
    }
    public class RandomMoveBall : MoveBall
    {
        
        public RandomMoveBall(Form form) : base(form)
        {
            vx = random.Next(-5, 6);
            vy = random.Next(-5, 5);
        }
    }

    public class MoveBall : RandomBalls
    {
        private Timer timer;
        private bool isRunning;
        public MoveBall(Form form) : base(form)
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
           return centerX>= 0  && centerX + radius <= form1.ClientSize.Width && centerY>=0 && centerY + radius <= form1.ClientSize.Height;
        }
        public bool FindBallsMouse(int mouseX, int mouseY)
        {
            if (mouseX >= centerX && mouseX <= centerX + radius && mouseY >= centerY && mouseY <= centerY + radius) return true;
            return false;
        }
    }
}
