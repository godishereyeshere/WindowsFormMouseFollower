using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseFollowerApp
{
    public partial class MainForm : Form
    {
        // تعریف یک PictureBox به نام monsterPictureBox
        private PictureBox monsterPictureBox;

        public MainForm()
        {
            InitializeComponent();
            InitializeMonster();
        }

        private void InitializeMonster()
        {
            // ایجاد یک PictureBox جدید و تنظیم خصوصیات آن
            monsterPictureBox = new PictureBox
            {
                Size = new Size(50, 50), // اندازه PictureBox
                BackColor = Color.Transparent, // رنگ پس‌زمینه PictureBox
                Location = new Point(0, 0), // مکان اولیه PictureBox
                Cursor = Cursors.Hand // شکل ماوس هنگامی که روی PictureBox قرار می‌گیرد
            };

            // رسم شکل در PictureBox
            DrawMonster();

            // اضافه کردن رویداد MouseMove به فرم
            this.MouseMove += MainForm_MouseMove;

            // اضافه کردن PictureBox به فرم
            Controls.Add(monsterPictureBox);
        }

        private void DrawMonster()
        {
            // ایجاد یک Bitmap جدید برای نگه‌داری تصویر
            Bitmap monsterImage = new Bitmap(monsterPictureBox.Width, monsterPictureBox.Height);

            // استفاده از GDI+ برای رسم دایره در Bitmap
            using (Graphics g = Graphics.FromImage(monsterImage))
            {
                g.FillEllipse(Brushes.Green, 0, 0, monsterPictureBox.Width, monsterPictureBox.Height);
            }

            // تنظیم تصویر PictureBox به Bitmap
            monsterPictureBox.Image = monsterImage;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            // تغییر مکان PictureBox به مکان جدید ماوس
            monsterPictureBox.Location = e.Location;
        }
    }
    }
