using System.Data;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GameBalls
{
    public class CreateBalls
    {
        protected Form1 form1;
        protected int x;
        protected int y;
        protected int width = 70;
        protected int height = 70;
        static Random random = new Random();
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
            x += random.Next(-30,30);
            y += random.Next(-15,15);
        }
        public void Move()
        {
            Clear();
            Go();
            Show();
        }
        public int ShowX()
        {
            return x;
        }
        public int ShowY()
        {
            return y;
        }

    }
    
    public class RandomBalls : CreateBalls
    {
        static Random random = new Random();
        public RandomBalls(Form1 form) : base(form)
        {
            x = random.Next(0, form.ClientSize.Width - width);
            y = random.Next(0, form.ClientSize.Height - height);
        }
    }
    
    public class MoveBall : RandomBalls
    {
        private Timer timer;
        public MoveBall(Form1 form) : base(form)
        {
            timer = new Timer();
            timer.Interval = 2;
            timer.Tick += Timer_Tick;
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
        }
        public bool FindBalls()
        {
           return x>= 0  && x + width <= form1.ClientSize.Width && y>=0 && y + height <= form1.ClientSize.Height;
        }
    }
}
