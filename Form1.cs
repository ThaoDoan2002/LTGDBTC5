namespace BTC5
{
    public partial class Form1 : Form
    {
        int dx = 5, dy = 8;
        bool trangThaiBong;
        Point p;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trangThaiBong = false;
        }

        private void chamThanhNgang()
        {
            //Kiem tra 2 hinh chu nhat co giao nhau khong
            if (lbThanhNgang.Bounds.IntersectsWith(pic.Bounds))
            {
                dy = -dy;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pic.Left < 0 || pic.Right > ClientRectangle.Width)
            {
                dx = -dx;
            }
            else if (pic.Top < 0 || pic.Bottom > ClientRectangle.Height)
            {
                dy = -dy;
            }
            pic.Left += dx;
            pic.Top += dy;
            chamThanhNgang();
        }
        //Lam viec voi su kien ban phim nhung khong biet su dung cho doi tuong nao
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.S:
                    if (!trangThaiBong)
                    {
                        timer1.Enabled = true;
                        trangThaiBong = true;
                    }
                    else if (trangThaiBong)
                    {
                        timer1.Enabled = false;
                        trangThaiBong = false;
                    }
                    break;
                case Keys.Left:
                    lbThanhNgang.Left -= 8;
                    break;
                case Keys.Right:
                    lbThanhNgang.Left += 8;
                    break;
            }
            return true;
            //De goi su kien ban phim

        }

        private void lbThanhNgang_MouseDown(object sender, MouseEventArgs e)
        {
            p = e.Location;
        }

        private void lbThanhNgang_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lbThanhNgang.Left += e.Location.X - p.X;
                lbThanhNgang.Top += e.Location.Y - p.Y;
            }
        }
    }
}