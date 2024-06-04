using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Painting_RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool ispaint = false;
        //Point previousPoint = new Point(0, 0);
        PaintInfo userInfo = new PaintInfo();
        private void PanelPainting_MouseDown(object sender, MouseEventArgs e)
        {
            ispaint = true;
            //previousPoint = e.Location;
        }

        private void PanelPainting_MouseUp(object sender, MouseEventArgs e)
        {
            ispaint = false;
        }

        private void PanelPainting_MouseMove(object sender, MouseEventArgs e)
        {
            if (ispaint == true)
            {
                Graphics graphics = PanelPainting.CreateGraphics();
                graphics.FillEllipse(userInfo.brush, e.X - userInfo.size / 2, e.Y - userInfo.size / 2, userInfo.size, userInfo.size);
                //graphics.FillRectangle(userInfo.brush,e.X- userInfo.size / 2, e.Y-userInfo.size / 2, userInfo.size, userInfo.size);
            }
        }

        private void 粗线条ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInfo.size = PaintInfo.largeSize;
            粗线条ToolStripMenuItem.Checked = true;
            中线条ToolStripMenuItem.Checked = false;
            细线条ToolStripMenuItem.Checked = false;
        }

        private void 中线条ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInfo.size = PaintInfo.middleSize;
            粗线条ToolStripMenuItem.Checked = false;
            中线条ToolStripMenuItem.Checked = true;
            细线条ToolStripMenuItem.Checked = false;
        }

        private void 细线条ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInfo.size = PaintInfo.smallSize;
            粗线条ToolStripMenuItem.Checked = false;
            中线条ToolStripMenuItem.Checked = false;
            细线条ToolStripMenuItem.Checked = true;
        }
        private void 红色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInfo.pen.Color = Color.Red;
            userInfo.brush.Color = Color.Red;
            红色ToolStripMenuItem.Checked = true;
            黑色ToolStripMenuItem.Checked = false;
            自定义颜色ToolStripMenuItem.Checked = false;

        }

        private void 黑色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInfo.pen.Color = Color.Black;
            userInfo.brush.Color = Color.Black;
            红色ToolStripMenuItem.Checked = false;
            黑色ToolStripMenuItem.Checked = true;
            自定义颜色ToolStripMenuItem.Checked = false;
        }
        private void 自定义颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                userInfo.pen.Color = colorDialog.Color;
                userInfo.brush.Color = colorDialog.Color;
            }
            红色ToolStripMenuItem.Checked = false;
            黑色ToolStripMenuItem.Checked = false;
            自定义颜色ToolStripMenuItem.Checked = true;
        }

        private void 加密ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Flies(.txt)|*.txt";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                getOriginalString();
                encryptString();
                saveTextFile();
            }
        }

        private void 解密ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Flies(.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openTextFile();
                decryptString();
                redrawPicture();                             
            }
        }
        private void getOriginalString()
        {

        }

        private void encryptString()
        {

        }
        private void saveTextFile()
        {

        }
        private void openTextFile()
        {

        } 
        private void decryptString()
        {

        }
        private void redrawPicture()
        {

        }
    }
    class PaintInfo
    {
        public Pen pen;
        public SolidBrush brush;
        public int size;
        public const int smallSize = 8;
        public const int middleSize = 12;
        public const int largeSize = 20;
        public PaintInfo()
        {
            pen = new Pen(Color.Black, largeSize);
            brush = new SolidBrush(Color.Black);
            size = smallSize;
        }
    }
}
