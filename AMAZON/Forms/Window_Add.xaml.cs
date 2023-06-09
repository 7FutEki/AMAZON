﻿using AMAZON.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AMAZON.Forms
{
    /// <summary>
    /// Логика взаимодействия для Window_Add.xaml
    /// </summary>
    public partial class Window_Add : Window
    {
        public Product Product { get; set; }
        public Window_Add()
        {
            InitializeComponent();
            Product = new Product();
            DataContext = Product;
            Product.Id = Guid.NewGuid();
        }
        public Window_Add(Product product)
        {
            InitializeComponent();
            Product = product;
            DataContext = Product;
        }
            private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_madeQr_Click(object sender, RoutedEventArgs e)
        {
            
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(tb_id.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qr = qrCode.GetGraphic(150);
            qr_im.Source= Convert(qr);
        }
        public BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
    }
}
