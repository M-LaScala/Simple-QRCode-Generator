using QRCoder;

namespace SimpleQRCodeGenerator
{
    public partial class Form1 : Form
    {

        public string? path = null;
        public int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (path == null)
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    DialogResult result = folderBrowserDialog.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                    {
                        string selectedFolderPath = folderBrowserDialog.SelectedPath;

                        path = selectedFolderPath;
                    }
                }
            }

            pictureBox1.Image.Save(path + @$"\QRCode{count++}.jpg");
            MessageBox.Show("Salvo Com sucesso!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            textBox1.Text = null;
        }

    }
}