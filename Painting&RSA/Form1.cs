using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        PaintInfo userInfo = new PaintInfo();
        List<Tuple<Point, Color,int>> PaintPointInfo = new List<Tuple<Point, Color,int>>();
        int count;
        private void PanelPainting_MouseDown(object sender, MouseEventArgs e)
        {
            ispaint = true;
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
                PaintPointInfo.Add(new Tuple<Point, Color,int>(e.Location, userInfo.brush.Color,userInfo.size));
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
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                encryptString(saveFileDialog.FileName);
            }
            count = PaintPointInfo.Count;
        }

        private void 解密ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PaintPointInfo.Count != count)
            {
                if (MessageBox.Show("是否保存绘制的图案？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Flies(.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        encryptString(saveFileDialog.FileName);
                    }
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Flies(.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                PaintPointInfo = decryptString(openFileDialog.FileName);
                redrawPicture(PaintPointInfo);
            }
        }

        private void encryptString(string filename)
        {
            string paintingData = string.Join(";", PaintPointInfo.Select(p => $"{p.Item1.X},{p.Item1.Y},{p.Item2.ToArgb()},{p.Item3}"));
            Aes aes = Aes.Create();
            byte[] AESDrawingData = AESEncryptStringToBytes(paintingData, aes.Key, aes.IV);
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                byte[] RSAEncryptedKey = rsa.Encrypt(aes.Key, false);
                byte[] RSAEncryptedIV = rsa.Encrypt(aes.IV, false);
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);
                string privateKeyFileName = $"privatekey_{Path.GetFileNameWithoutExtension(filename)}.txt";
                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(BitConverter.GetBytes(RSAEncryptedKey.Length), 0, sizeof(int));
                    fs.Write(RSAEncryptedKey, 0, RSAEncryptedKey.Length);
                    fs.Write(BitConverter.GetBytes(RSAEncryptedIV.Length), 0, sizeof(int));
                    fs.Write(RSAEncryptedIV, 0, RSAEncryptedIV.Length);
                    fs.Write(AESDrawingData, 0, AESDrawingData.Length);
                }
                using (StreamWriter sw = new StreamWriter(privateKeyFileName))
                {
                    sw.WriteLine(privateKey);
                }
            }
        }

        private List<Tuple<Point,Color,int>> decryptString(string filename)//读取RSA加密的Key和IV和绘图数据读取私钥对Key和IV进行解密，对绘图数据进行解密
        {
            byte[] RSAEncryptedKey = null;
            byte[] RSAEncryptedIV = null;
            byte[] AESDrawingData = null;
            string privateKeyFileName = $"privatekey_{Path.GetFileNameWithoutExtension(filename)}.txt";
            string privateKey = string.Empty;

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    byte[] lengthBytes = new byte[sizeof(int)];

                    fs.Read(lengthBytes, 0, sizeof(int));
                    int keyLength = BitConverter.ToInt32(lengthBytes, 0);
                    RSAEncryptedKey = new byte[keyLength];
                    fs.Read(RSAEncryptedKey, 0, keyLength);

                    fs.Read(lengthBytes, 0, sizeof(int));
                    int ivLength = BitConverter.ToInt32(lengthBytes, 0);
                    RSAEncryptedIV = new byte[ivLength];
                    fs.Read(RSAEncryptedIV, 0, ivLength);

                    AESDrawingData = new byte[fs.Length - fs.Position];
                    fs.Read(AESDrawingData, 0, AESDrawingData.Length);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                using (StreamReader sr = new StreamReader(privateKeyFileName))
                {
                    privateKey = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            byte[] key = null;
            byte[] iv = null;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                key = rsa.Decrypt(RSAEncryptedKey, false);
                iv = rsa.Decrypt(RSAEncryptedIV, false);
            }
            byte[] drawingBytes = AESDecryptData(AESDrawingData, key, iv);
            string drawingData = Encoding.UTF8.GetString(drawingBytes);


            List<Tuple<Point,Color,int>> paintPointInfo = new List<Tuple<Point, Color, int>>();
            foreach (string info in drawingData.Split(';'))
            {
                string[] parts = info.Split(',');
                int x = int.Parse(parts[0]);
                int y = int.Parse(parts[1]);
                int size = int.Parse(parts[3]);
                Color color = Color.FromArgb(int.Parse(parts[2]));
                paintPointInfo.Add(new Tuple<Point, Color,int>(new Point(x, y), color, size));
            }
            return paintPointInfo;
        }
        private void redrawPicture(List<Tuple<Point, Color, int>> PaintPointInfo)//根据绘图数据重新绘制图片
        {
            PaintInfo userInfo2 = new PaintInfo();
            Graphics graphics = PanelPainting.CreateGraphics();
            graphics.Clear(Color.White);
            foreach (var paintpointinfo in PaintPointInfo)
            {
                userInfo2.brush.Color = paintpointinfo.Item2;
                userInfo2.size = paintpointinfo.Item3;
                graphics.FillEllipse(userInfo2.brush, paintpointinfo.Item1.X - userInfo2.size / 2, paintpointinfo.Item1.Y - userInfo2.size / 2, userInfo2.size, userInfo2.size);
            }
            
            //清空当前画板，从头到尾遍历PaintPointInfo的数据，把图案从头到尾复现出来
        }
        private byte[] AESEncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
        private byte[] AESDecryptData(byte[] data, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] decryptedData = new byte[data.Length];
                            int decryptedByteCount = cs.Read(decryptedData, 0, decryptedData.Length);
                            Array.Resize(ref decryptedData, decryptedByteCount);
                            return decryptedData;
                        }
                    }
                }
            }
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

