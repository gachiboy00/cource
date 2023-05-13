using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace course
{
    public partial class Form1 : Form
    {
        private bool _isDragging = false;
        private Point _lastMousePos;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPC_Click(object sender, EventArgs e)
        {
            Button PCbtn = new Button();
            PCbtn.Image = course.Properties.Resources.pc;
            PCbtn.ImageAlign = ContentAlignment.MiddleCenter;
            PCbtn.Height = 40;
            PCbtn.Width = 40;
            int x = 100;
            int y = 100;
            PCbtn.Location = new Point(x, y);

            PCbtn.MouseDown += new MouseEventHandler(btn_MouseDown);
            PCbtn.MouseMove += new MouseEventHandler(btn_MouseMove);
            PCbtn.MouseUp += new MouseEventHandler(btn_MouseUp);
            PCbtn.MouseDown += new MouseEventHandler(btn_RightClik);

            this.Controls.Add(PCbtn);
        }


        private void routerbtn_Click(object sender, EventArgs e)
        {
            Button routerbtn = new Button();
            routerbtn.Image = course.Properties.Resources.router;
            routerbtn.ImageAlign = ContentAlignment.MiddleCenter;
            routerbtn.Height = 40;
            routerbtn.Width = 40;
            int x = 100;
            int y = 100;
            routerbtn.Location = new Point(x, y);

            routerbtn.MouseDown += new MouseEventHandler(btn_MouseDown);
            routerbtn.MouseMove += new MouseEventHandler(btn_MouseMove);
            routerbtn.MouseUp += new MouseEventHandler(btn_MouseUp);
            routerbtn.MouseDown += new MouseEventHandler(btn_RightClik);

            this.Controls.Add(routerbtn);
        }

        private void serverbtn_Click(object sender, EventArgs e)
        {
            Button serverbtn = new Button();
            serverbtn.Image = course.Properties.Resources.server;
            serverbtn.ImageAlign = ContentAlignment.MiddleCenter;
            serverbtn.Height = 40;
            serverbtn.Width = 40;
            int x = 100;
            int y = 100;
            serverbtn.Location = new Point(x, y);

            serverbtn.MouseDown += new MouseEventHandler(btn_MouseDown);
            serverbtn.MouseMove += new MouseEventHandler(btn_MouseMove);
            serverbtn.MouseUp += new MouseEventHandler(btn_MouseUp);
            serverbtn.MouseDown += new MouseEventHandler(btn_RightClik);            

            this.Controls.Add(serverbtn);
        }

        
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            _isDragging = true;
            _lastMousePos = e.Location;
            
            if (e.Button == MouseButtons.Left)
            {
                Control clickedControl = sender as Control;
                int controlIndex = this.Controls.IndexOf(clickedControl);
                // Do something with controlIndex
                textBox3.Text = controlIndex.ToString();
            }
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                int deltaX = e.X - _lastMousePos.X;
                int deltaY = e.Y - _lastMousePos.Y;


                for (int i = 0; i < this.Controls.Count; ++i)
                {
                    if (sender == this.Controls[i])
                    {
                        this.Controls[i].Left += deltaX;
                        this.Controls[i].Top += deltaY;
                    }
                }
                _lastMousePos = e.Location;
            }
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void btn_RightClik(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Создаем новое контекстное меню и добавляем пункты меню
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem item1 = new ToolStripMenuItem("Delete");
                contextMenuStrip.Items.Add(item1);

                // Добавляем обработчик события Click для пункта меню "Delete"
                item1.Click += (s, ev) =>
                {
                    // Удаляем кнопку из контейнера элементов управления
                    this.Controls.Remove(sender as Button);
                };

                // Отображаем контекстное меню
                contextMenuStrip.Show(sender as Control, e.Location);
            }
        }


        
        private void conbtn_Click(object sender, EventArgs e)
        {
            //// Получаем координаты первой кнопки
            //int x1 = this.Controls[int.Parse(textBox1.Text)].Location.X + this.Controls[int.Parse(textBox1.Text)].Width / 2;
            //int y1 = this.Controls[int.Parse(textBox1.Text)].Location.Y + this.Controls[int.Parse(textBox1.Text)].Height / 2;

            //// Получаем координаты второй кнопки
            //int x2 = this.Controls[int.Parse(textBox2.Text)].Location.X + this.Controls[int.Parse(textBox2.Text)].Width / 2;
            //int y2 = this.Controls[int.Parse(textBox2.Text)].Location.Y + this.Controls[int.Parse(textBox2.Text)].Height / 2;

            //// Создаем поверхность для рисования
            //Graphics g = this.CreateGraphics();

            //if (radioButton1.Checked)
            //{
            //    _pen.DashStyle = DashStyle.Solid;
            //    _pen.Color = Color.Black;
            //    g.DrawLine(_pen, x1, y1, x2, y2);
            //}


            //// Рисуем линию между кнопками
            ////g.DrawLine(_pen, x1, y1, x2, y2);
            
            if (int.TryParse(textBox1.Text, out int index1) && int.TryParse(textBox2.Text, out int index2))
            {
                // Проверяем, что индексы действительно представляют существующие контролы на форме
                if (index1 >= 0 && index1 < this.Controls.Count && index2 >= 0 && index2 < this.Controls.Count)
                {
                    // Получаем координаты первой кнопки
                    int x1 = this.Controls[index1].Location.X + this.Controls[index1].Width / 2;
                    int y1 = this.Controls[index1].Location.Y + this.Controls[index1].Height / 2;

                    // Получаем координаты второй кнопки
                    int x2 = this.Controls[index2].Location.X + this.Controls[index2].Width / 2;
                    int y2 = this.Controls[index2].Location.Y + this.Controls[index2].Height / 2;

                    // Создаем поверхность для рисования
                    using (Graphics g = this.CreateGraphics())
                    {
                        if (radioButton1.Checked)
                        {
                            // Создаем объект Pen со стилем Solid и цветом Black
                            using (Pen pen = new Pen(Color.Black,3.0f))
                            {
                                pen.DashStyle= DashStyle.Solid;
                                g.DrawLine(pen, x1, y1, x2, y2);
                            }
                        }
                        if (radioButton2.Checked)
                        {
                            // Создаем объект Pen со стилем Dot и цветом Black
                            using (Pen pen = new Pen(Color.Black, 3.0f))
                            {
                                pen.DashStyle = DashStyle.Dot;
                                g.DrawLine(pen, x1, y1, x2, y2);
                            }
                        }
                        if (radioButton3.Checked)
                        {
                            // Создаем объект Pen со стилем DashDot и цветом Black
                            using (Pen pen = new Pen(Color.Black, 3.0f))
                            {
                                pen.DashStyle = DashStyle.DashDot;
                                g.DrawLine(pen, x1, y1, x2, y2);
                            }
                        }
                        if (radioButton4.Checked)
                        {
                            // Создаем объект Pen со стилем DashDotDot и цветом Black
                            using (Pen pen = new Pen(Color.Black, 3.0f))
                            {
                                pen.DashStyle = DashStyle.DashDotDot;
                                g.DrawLine(pen, x1, y1, x2, y2);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверный индекс контрола.");
                }
            }
            else
            {
                MessageBox.Show("Введите корректный индекс контрола.");
            }
        }
    }
}
