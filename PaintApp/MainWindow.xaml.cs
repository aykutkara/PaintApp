using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;


namespace PaintApp
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// cizgi kalınlığının değeri
        /// </summary>
        private int cizgi_kalinligi = 5;
        /// <summary>
        /// kalem rengini belirliyor.
        /// </summary>
        private Brush renk = Brushes.Black;
        /// <summary>
        /// mouse tıkladığımızda çizmesi için oluşturdum
        /// </summary>
        private bool ciziliyor = false;
        /// <summary>
        /// yaptıklarımızı silmek için oluşturdum.
        /// </summary>
        private bool siliniyor = false;
        /// <summary>
        /// cizgi butonuna tıklanınca aktif olsun diye oluşturdum
        /// </summary>
        private bool cizgi = false;
        /// <summary>
        /// daire butonuna tıklanınca aktif olsun diye oluşturdum
        /// </summary>
        private bool daire = false;
        /// <summary>
        /// kare butonuna tıklanınca aktif olsun diye oluşturdum
        /// </summary>
        private bool kare = false;
        /// <summary>
        /// çizgi kalınlığını akılda tutsun diye oluşturdum.
        /// </summary>
        private int tut = 7;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Kalem Rengini Seçen Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenkSec(object sender, RoutedEventArgs e)
        {
            ColorDialog renksecimi = new ColorDialog();
            renksecimi.ShowDialog();
            
        }
        /// <summary>
        /// Bu method Ellips sınıfını kullanarak cizgi kalınlığı ile çizim yaptırmayı sağlıyor.
        /// </summary>
        /// <param name="cizgi_rengi"></param>
        /// <param name="pozisyon"></param>
        private void cizgiKalinligi(Brush cizgi_rengi, Point pozisyon)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = cizgi_rengi;
            ellipse.Width = cizgi_kalinligi;
            ellipse.Height = cizgi_kalinligi;
            Canvas.SetTop(ellipse, pozisyon.Y);
            Canvas.SetLeft(ellipse, pozisyon.X);
            paintcanvas.Children.Add(ellipse);
        }
        /// <summary>
        /// çizimi başlatıyor
        /// </summary>
        Point start;
        /// <summary>
        /// çizimi bitiriyor
        /// </summary>
        Point end;
        /// <summary>
        /// mouse hareketlerime göre çizim yapması için oluşturdum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ciziliyor)
            {
                Point mousepozisyonu = e.GetPosition(paintcanvas);
                cizgiKalinligi(renk, mousepozisyonu);
            }
            if (siliniyor)
            {
                Point mousepozisyonu = e.GetPosition(paintcanvas);
                cizgiKalinligi(renk, mousepozisyonu);
            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }

        }
        /// <summary>
        /// mouse tıkladığımızda çizmeye başlması için oluşturdum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paintcanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(this);
        }
        /// <summary>
        /// mouse click ini bırakınca çizgi, daire ya da dikdörtgen çizimi bitsin ve görünsün diye oluşturdum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paintcanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (cizgi)
            {
                CizgiCizdir();
            }
            if (daire)
            {
                DaireCizdir();
            }
            if (kare)
            {
                KareCizdir();
            }
        }
        /// <summary>
        /// mouse un sol click ine basınca kalemin geçtiği yerleri çizsin diye oluşturdum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paintcanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ciziliyor = true;
        }
        /// <summary>
        /// mouse un sol click ini bıraktığımda çizmeyi de bırakması için ciziliyor değerini false yaptım.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paintcanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ciziliyor = false;
        }
        /// <summary>
        /// Butona basıldığında butondaki ıtem değeri kalınlığında çizgi kalınlığını belirledim ve cizgi,daire,kare yi false yaptım ki çalışmasın.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cizgi_kalinligi = 1;
            cizgi = false;
            daire = false;
            kare = false;
        }
        /// <summary>
        /// Butona basıldığında butondaki ıtem değeri kalınlığında çizgi kalınlığını belirledim ve cizgi,daire,kare yi false yaptım ki çalışmasın.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cizgi_kalinligi = 3;
            cizgi = false;
            daire = false;
            kare = false;
        }
        /// <summary>
        /// Butona basıldığında butondaki ıtem değeri kalınlığında çizgi kalınlığını belirledim ve cizgi,daire,kare yi false yaptım ki çalışmasın.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            cizgi_kalinligi = 5;
            cizgi = false;
            daire = false;
            kare = false;
        }
        /// <summary>
        /// Butona basıldığında butondaki ıtem değeri kalınlığında çizgi kalınlığını belirledim ve cizgi,daire,kare yi false yaptım ki çalışmasın.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            cizgi_kalinligi = 10;
            cizgi = false;
            daire = false;
            kare = false;
        }
        /// <summary>
        /// Butona basıldığında butondaki ıtem değeri kalınlığında çizgi kalınlığını belirledim ve cizgi,daire,kare yi false yaptım ki çalışmasın.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            cizgi_kalinligi = 15;
            cizgi = false;
            daire = false;
            kare = false;
        }
        /// <summary>
        /// Butona basıldığında butondaki ıtem değeri kalınlığında çizgi kalınlığını belirledim ve cizgi,daire,kare yi false yaptım ki çalışmasın.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            cizgi_kalinligi = 20;
            cizgi = false;
            daire = false;
            kare = false;
        }
        /// <summary>
        /// Paint uygulamasında yaptıpım çizimleri PNG formatında kaydetmek için oluşturdum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KaydetmeButonu(object sender, RoutedEventArgs e)
        {
            MessageBoxResult MsgBoxresult = System.Windows.MessageBox.Show("Dosya Kaydedilsin mi?", "Dosya kaydetmek istiyor musun", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (MsgBoxresult == MessageBoxResult.Yes)
            { 
               RenderTargetBitmap paintdosyasi_kaydet = new RenderTargetBitmap((int)paintcanvas.RenderSize.Width,
               (int)paintcanvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
               paintdosyasi_kaydet.Render(paintcanvas);

               var crop = new CroppedBitmap(paintdosyasi_kaydet, new Int32Rect(50, 50, 600, 600));

               BitmapEncoder pngEncoder = new PngBitmapEncoder();
               pngEncoder.Frames.Add(BitmapFrame.Create(crop));

               using (var fs = System.IO.File.OpenWrite("paint.png"))
               {
                   pngEncoder.Save(fs);
               }
            }
        }
        /// <summary>
        /// Yaptığım çizimleri geri almak için oluşturdum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeriAl(object sender, RoutedEventArgs e)
        {
            int sayi = paintcanvas.Children.Count;
            if (sayi > 0)
                paintcanvas.Children.RemoveAt(sayi - 1);
            
        }
        /// <summary>
        /// yaptığım işlemlerin tümünü silmek için oluşturdum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TumunuSil(object sender, RoutedEventArgs e)
        {
            paintcanvas.Children.Clear();
            paintcanvas.Background = Brushes.White;

        }
        /// <summary>
        /// Bu butonu basılınca çizgi çizilmesi için oluşturdum ve cizgiyi çizerken diğer değerler çalışmsaın diye false yaptım
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CizgiButon(object sender, RoutedEventArgs e)
        {
            ciziliyor = false;
            siliniyor = false;
            daire = false;
            kare = false;
            tut = cizgi_kalinligi;
            cizgi_kalinligi = 0;

            cizgi = true;
        }
        /// <summary>
        /// Bu butonu basılınca daire çizilmesi için oluşturdum ve daireyi çizerken diğer değerler çalışmsaın diye false yaptım
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DaireButon(object sender, RoutedEventArgs e)
        {
            siliniyor = false;
            ciziliyor = false;
            cizgi = false;
            kare = false;
            tut = cizgi_kalinligi;
            cizgi_kalinligi = 0;

            daire = true;
        }
        /// <summary>
        /// Bu butonu basılınca kare çizilmesi için oluşturdum ve kareyi çizerken diğer değerler çalışmsaın diye false yaptım
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KareButon(object sender, RoutedEventArgs e)
        {
            siliniyor = false;
            ciziliyor = false;
            cizgi = false;
            daire = false;
            tut = cizgi_kalinligi;
            cizgi_kalinligi = 0;

            kare = true;
        }
        /// <summary>
        /// Fareyi bıraktıktan sonra farenin geçtiği boyutta çizgiyi çizen method 
        /// </summary>
        private void CizgiCizdir()
        {
            Line yeniCizgi = new Line()
            {
                Stroke = Brushes.Blue,
                X1 = start.X,
                Y1 = start.Y - 50,
                X2 = end.X,
                Y2 = end.Y - 50
            };
            //cizilen çizgiyi canvas a ekler ve görürüz.
            paintcanvas.Children.Add(yeniCizgi);
        }
        /// <summary>
        /// Fareyi bıraktıktan sonra farenin geçtiği boyutta daireyi çizen method 
        /// </summary>
        private void DaireCizdir()
        {
            Ellipse yeniDaire = new Ellipse()
            {
                Fill = Brushes.Red,
                Height = 10,
                Width = 10
            };
            if (end.X >= start.X)
            {
                 //Dairenin sol kısmını tamamlar
                yeniDaire.SetValue(Canvas.LeftProperty, start.X);
                yeniDaire.Width = end.X - start.X;
            }
            else
            {
                yeniDaire.SetValue(Canvas.LeftProperty, end.X);
                yeniDaire.Width = start.X - end.X;
            }
            if (end.Y >= start.Y)
            {
                //Dairenin üst kısmını tamamlar
                yeniDaire.SetValue(Canvas.TopProperty, start.Y - 50);
                yeniDaire.Height = end.Y - start.Y;
            }
            else
            {
                yeniDaire.SetValue(Canvas.TopProperty, end.Y - 50);
                yeniDaire.Height = start.Y - end.Y;
            }
            //cizilen daireyi canvas a ekler ve görürüz.
            paintcanvas.Children.Add(yeniDaire);
        }
        private void KareCizdir()
        {
            Rectangle yeniKare = new Rectangle()
            {
                Fill = Brushes.Yellow,
            };

            if (end.X >= start.X)
            {
                //Karenin sol kısmını tamamlar
                yeniKare.SetValue(Canvas.LeftProperty, start.X);
                yeniKare.Width = end.X - start.X;
            }
            else
            {
                yeniKare.SetValue(Canvas.LeftProperty, end.X);
                yeniKare.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                //Karenin üst kısmını tamamlar
                yeniKare.SetValue(Canvas.TopProperty, start.Y - 50);
                yeniKare.Height = end.Y - start.Y;
            }
            else
            {
                yeniKare.SetValue(Canvas.TopProperty, end.Y - 50);
                yeniKare.Height = start.Y - end.Y;
            }
            //cizilen kareyi canvas a ekler ve görürüz.
            paintcanvas.Children.Add(yeniKare);
        }
        /// <summary>
        /// Boya butonuna tıklanınca arka plan rengini ayarlar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArkaPlanBoyasi(object sender, RoutedEventArgs e)
        {
            ColorDialog boyama = new ColorDialog();
            boyama.ShowDialog();
            paintcanvas.Background = Brushes.Green;

        }
        /// <summary>
        /// Kaleme tıklanınca çizim yapar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KalemButonu(object sender, RoutedEventArgs e)
        {
            //eğer tutulan değer 0 ise yapılan çizim görünmeyeceği için default olarak 7 ye ayarlamak için yazdım
            if (tut == 0)
            {
                cizgi_kalinligi = 7;
            }
            else
            {
                cizgi_kalinligi = tut;
            }
            //kalemle çizim yaparken cizgi,daire veya kare çizmemesi için değerlerini false yaptım
            cizgi = false;
            daire = false;
            kare = false;
        }
    }
}
