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
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace course
{
    public partial class Form1 : Form
    {
        private bool _isDragging = false;
        private Point _lastMousePos;
        private System.Timers.Timer _timer;

        public Form1()
        {
            InitializeComponent();

            this._timer = new System.Timers.Timer(1000);
            this._timer.Elapsed += TimerElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                using (Graphics g = this.CreateGraphics())
                {
                    g.Clear(Form1.DefaultBackColor);
                }
                foreach (var obj in this.Controls)
                {
                   if (obj is NetworkButton)
                   {
                       int x = (obj as NetworkButton).Location.X + (obj as NetworkButton).Width / 2;
                       int y = (obj as NetworkButton).Location.Y + (obj as NetworkButton).Height / 2;
                        foreach (int id in (obj as NetworkButton)._connection_with_buttons)
                       {
                            NetworkButton networkButton = GetButtonById(id);
                            int x1 = networkButton.Location.X + networkButton.Width / 2;
                            int y1 = networkButton.Location.Y + networkButton.Height / 2;

                            using (Graphics g = this.CreateGraphics())
                            {
                                if (radioButton1.Checked)
                                {
                                    // Создаем объект Pen со стилем Solid и цветом Black
                                    using (Pen pen = new Pen(Color.Black, 3.0f))
                                    {
                                        pen.DashStyle = DashStyle.Solid;
                                        g.DrawLine(pen, x1, y1, x, y);
                                    }
                                }
                                if (radioButton2.Checked)
                                {
                                    // Создаем объект Pen со стилем Dot и цветом Black
                                    using (Pen pen = new Pen(Color.Black, 3.0f))
                                    {
                                        pen.DashStyle = DashStyle.Dot;
                                        g.DrawLine(pen, x1, y1, x, y);
                                    }
                                }
                                if (radioButton3.Checked)
                                {
                                    // Создаем объект Pen со стилем DashDot и цветом Black
                                    using (Pen pen = new Pen(Color.Black, 3.0f))
                                    {
                                        pen.DashStyle = DashStyle.DashDot;
                                        g.DrawLine(pen, x1, y1, x, y);
                                    }
                                }
                                if (radioButton4.Checked)
                                {
                                    // Создаем объект Pen со стилем DashDotDot и цветом Black
                                    using (Pen pen = new Pen(Color.Black, 3.0f))
                                    {
                                        pen.DashStyle = DashStyle.DashDotDot;
                                        g.DrawLine(pen, x1, y1, x, y);
                                    }
                                }
                            }
                        }
                   }
                }
            }));
        }

        private NetworkButton GetButtonById(int id)
        {
            foreach(var obj in this.Controls)
            {
                if (obj is NetworkButton)
                    if ((obj as NetworkButton).Id == id) 
                        return (NetworkButton)obj;
            }
            return null;
        }

        private void AddedEventHandlerForButton(Button button)
        {
            button.MouseDown += new MouseEventHandler(btn_MouseDown);
            button.MouseMove += new MouseEventHandler(btn_MouseMove);
            button.MouseUp += new MouseEventHandler(btn_MouseUp);
            button.MouseDown += new MouseEventHandler(btn_RightClik);
        }

        private void btnPC_Click(object sender, EventArgs e)
        {
            Button PCbtn = new ButtonComputer();
            AddedEventHandlerForButton(PCbtn);
            this.Controls.Add(PCbtn);
        }


        private void routerbtn_Click(object sender, EventArgs e)
        {
            Button routerbtn = new ButtonRouter();
            AddedEventHandlerForButton(routerbtn);
            this.Controls.Add(routerbtn);
        }

        private void serverbtn_Click(object sender, EventArgs e)
        {
            Button serverbtn = new ButtonServer();
            AddedEventHandlerForButton(serverbtn);
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

        private void btn_MouseUp(object sender, MouseEventArgs e) => _isDragging = false;

        private void btn_RightClik(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Создаем новое контекстное меню и добавляем пункты меню
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem item0 = new ToolStripMenuItem("Properties");
                contextMenuStrip.Items.Add(item0);
                ToolStripMenuItem item1 = new ToolStripMenuItem("Delete");
                contextMenuStrip.Items.Add(item1);

                // Added event Click for "Properties" in item0
                item0.Click += (s, ev) =>
                {
                    List<NetworkButton> buttons = new List<NetworkButton>();
                    foreach (int id in (sender as NetworkButton)._connection_with_buttons)
                    {
                        NetworkButton networkButton = GetButtonById(id);
                        buttons.Add(networkButton);
                    }
                    PropsForm propertiesForm = new PropsForm(sender as NetworkButton, buttons);
                    propertiesForm.ShowDialog();
                };

                // Добавляем обработчик события Click для пункта меню "Delete"
                item1.Click += (s, ev) =>
                {
                    // Удаляем кнопку из контейнера элементов управления
                    foreach (var obj in this.Controls)
                        if (obj is NetworkButton)
                            (obj as NetworkButton).DisconnectWithButton(sender as NetworkButton);

                    this.Controls.Remove(sender as Button);
                };

                // Отображаем контекстное меню
                contextMenuStrip.Show(sender as Control, e.Location);
            }
        }


        
        private void conbtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int index1) && int.TryParse(textBox2.Text, out int index2))
            {
                NetworkButton button = GetButtonById(index1);
                NetworkButton button2 = GetButtonById(index2);
                if (button != null && button2 != null)
                {
                    if (button.IsInSameNetwork(button2))
                    {
                        button.ConnectWithButton(button2);
                        button2.ConnectWithButton(button);
                    }
                    else
                        MessageBox.Show("Проверьте IP или MAC-адрес оборудования");
                }
                else 
                    MessageBox.Show("Введите корректный индекс контрола.");
                
            }
        }
    }
}
