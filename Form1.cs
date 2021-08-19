using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractCore.Controller;

namespace OcrApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSelectImageFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog files = new OpenFileDialog();
            //For any other formats
            files.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            files.Multiselect = true;
            if (files.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = files.FileName;

            }
            GetImagesInfo(files);
        }

        private void GetImagesInfo(OpenFileDialog files)
        {
            List<string> path = new List<string>();
            List<string> fileName = new List<string>();

            foreach (var imagePath in files.FileNames)            
                path.Add(imagePath);

            foreach (var imageFileName in files.SafeFileNames)
                fileName.Add(imageFileName);

            OcrAppController.OcrFiles(path, fileName);
        }
    }
}
