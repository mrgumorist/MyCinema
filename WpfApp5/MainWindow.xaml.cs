using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Drawing;
using Brushes = System.Windows.Media.Brushes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> buttons = new List<Button>();


        int currentfilm = 0;
        const int PriceOfWatchingFilm = 50;
        const string Film3Name = "Divchuna v pavutinni";
        const string Film2Name = "Vdovu";
        const string Film1Name = "Zlochin Grindelvanlda";
        DateTime dateStartofFilm = new DateTime(2018, 11, 21);
        DateTime DateEntOf1 = new DateTime(2018, 12, 9);
        DateTime DateEntOf2 = new DateTime(2018, 12, 10);
        DateTime DateEntOf3 = new DateTime(2018, 12, 11);
        const string TimeOf1Film = "1,45 hour";
        const string TimeOf2Film = "1,95 hour";
        const string TimeOf3Film = "2 hour";
        int temp = 0;
        List<Button> buttonsoffilms = new List<Button>();
        List<string> strlist1 = new List<string>();
        List<string> strlist2 = new List<string>();
        List<string> strlist3 = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //button 2
            if (DateTime.Now.Day <= DateEntOf2.Day || DateTime.Now.Month <= DateEntOf2.Month)
            {
                Kek.IsEnabled = true;
                if (temp != 1)
                {
                    foreach (var item in ds.Children)
                    {
                        if (item is Button)
                        {
                            buttons.Add(item as Button);

                        }
                    }
                    temp = 1;
                }

                foreach (var item in buttons)
                {
                    item.IsEnabled = true;
                    item.Background = Brushes.White;
                }
                foreach (var item in buttons)
                {


                    foreach (var item1 in strlist2)
                    {
                        if ((string)item.Content == item1)
                        {
                            item.Background = Brushes.Red;
                        }

                    }






                }


                //delete this code




                currentfilm = 2;
                PrintInfoFilm(currentfilm);
            }

            else
            {
                MessageBox.Show("Time of watching film ended! Please wait new films");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Button 3
            if (DateTime.Now.Day <= DateEntOf3.Day|| DateTime.Now.Month<= DateEntOf3.Month)
            {
                Kek.IsEnabled = true;
                if (temp != 1)
                {
                    foreach (var item in ds.Children)
                    {
                        if (item is Button)
                        {
                            buttons.Add(item as Button);

                        }
                    }
                    temp = 1;
                }

                foreach (var item in buttons)
                {
                    item.IsEnabled = true;
                    item.Background = Brushes.White;
                }
                foreach (var item in buttons)
                {


                    foreach (var item1 in strlist3)
                    {
                        if ((string)item.Content == item1)
                        {
                            item.Background = Brushes.Red;
                        }

                    }






                }
                currentfilm = 3;
                PrintInfoFilm(currentfilm);
            }
            else
            {
                MessageBox.Show("Time of watching film ended! Please wait new films");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //button 1
            if (DateTime.Now.Day <= DateEntOf1.Day || DateTime.Now.Month <= DateEntOf1.Month)
            {
                Kek.IsEnabled = true;
                if (temp != 1)
                {
                foreach (var item in ds.Children)
                {
                    if (item is Button)
                    {
                        buttons.Add(item as Button);

                    }
                }
                temp = 1;
             }

                foreach (var item in buttons)
            {
                item.IsEnabled = true;
                item.Background = Brushes.White;
            }
            foreach (var item in buttons)
            {


                foreach (var item1 in strlist1)
                {
                    if ((string)item.Content == item1)
                    {
                        item.Background = Brushes.Red;
                    }

                }






            }
            currentfilm = 1;
            PrintInfoFilm(currentfilm);
        }
            else
            {
                MessageBox.Show("Time of watching film ended! Please wait new films");
            }
        }

        private void PrintInfoFilm(int num)
        {
            if(num ==1)
            {
                Textinfo.Text = "Name: " +Film1Name + '\n' + "Date start for watching :"+ dateStartofFilm.ToShortDateString()+ '\n'+"Date ends of watching film: "+DateEntOf1.ToShortDateString() + '\n'+"Time of watching of film: "+TimeOf1Film;
            }
            if(num==2)
            {
                Textinfo.Text = "Name: " + Film2Name + '\n' + "Date start for watching :" + dateStartofFilm.ToShortDateString() + '\n' + "Date ends of watching film: " + DateEntOf2.ToShortDateString() + '\n' + "Time of watching of film: " + TimeOf2Film;
            }
            if(num==3)
            {
                Textinfo.Text = "Name: " + Film3Name + '\n' + "Date start for watching :" + dateStartofFilm.ToShortDateString() + '\n' + "Date ends of watching film: " + DateEntOf3.ToShortDateString() + '\n' + "Time of watching of film: " + TimeOf2Film;
            }
            int totalcount = 0;
            foreach (var item in buttons)
            {
                if(item.Background==Brushes.Red)
                {
                    totalcount++;
                }
            }
            Textinfo.Text += '\n' + "Prcice by 1 seat = 50 grn";
            Textinfo.Text += '\n' + "Total count of reserved seats " + totalcount+'\n';
            Textinfo.Text += "Total price of reserved seats = " + totalcount * PriceOfWatchingFilm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintInfoFilm(currentfilm);
            if (currentfilm == 1)
            {
                if ((sender as Button).Background != Brushes.Red)
                {
                    strlist1.Add((string)(sender as Button).Content);
                    (sender as Button).Background = Brushes.Red;
                    return;
                }
                else (sender as Button).Background = Brushes.White;
                strlist1.Remove((string)(sender as Button).Content);
            }
            else if (currentfilm == 2)
            {
                if ((sender as Button).Background != Brushes.Red)
                {
                    strlist2.Add((string)((sender as Button).Content));
                    (sender as Button).Background = Brushes.Red;
                    return;
                }
                (sender as Button).Background = Brushes.White;
                strlist2.Remove((string)((sender as Button).Content));
                
            }
            else
            {
                if ((sender as Button).Background != Brushes.Red)
                {
                    strlist3.Add((string)(sender as Button).Content);
                    (sender as Button).Background = Brushes.Red;
                    
                    return;
                }


                else (sender as Button).Background = Brushes.White;
                strlist3.Remove((string)(sender as Button).Content);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Grid.GetColumn(Button1) != 0)
            {
                Grid.SetColumn(Button1, Grid.GetColumn(Button1) - 1);
            }
            else
            {
                Grid.SetColumn(Button1, 2);
            }
            if (Grid.GetColumn(Button2) != 0)
            {
                Grid.SetColumn(Button2, Grid.GetColumn(Button2) - 1);
            }
            else
            {
                Grid.SetColumn(Button2, 2);
            }
            if (Grid.GetColumn(Button3) != 0)
            {
                Grid.SetColumn(Button3, Grid.GetColumn(Button3) - 1);
            }
            else
            {
                Grid.SetColumn(Button3, 2);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (Grid.GetColumn(Button1) != 2)
            {
                Grid.SetColumn(Button1, Grid.GetColumn(Button1) + 1);
            }
            else
            {
                Grid.SetColumn(Button1, 0);
            }
            if (Grid.GetColumn(Button2) != 2)
            {
                Grid.SetColumn(Button2, Grid.GetColumn(Button2) + 1);
            }
            else
            {
                Grid.SetColumn(Button2, 0);
            }
            if (Grid.GetColumn(Button3) != 2)
            {
                Grid.SetColumn(Button3, Grid.GetColumn(Button3) + 1);
            }
            else
            {
                Grid.SetColumn(Button3, 0);
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            //PRINT
            DateTime a = new DateTime();
            a = DateTime.Now;
            string firstText;
           
            string secondText;
            if(currentfilm==1)
            {
                secondText = Film1Name;
                firstText = string.Join(",", strlist1);
            }
            else if( currentfilm==2)
            {
                secondText = Film2Name;
                firstText = string.Join(",", strlist2);
            }
             else
            {
                secondText = Film3Name;
                firstText = string.Join(",", strlist3);
            }
            string Date = a.ToShortDateString();
            PointF NumberSeat = new PointF(180f, 350f);
            PointF NameFilm = new PointF(255f, 240f);
            PointF DateF = new PointF(470f, 350f);
            string imageFilePath = @"Ticket\tik.jpg";
     
            Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(imageFilePath);//load the image file

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Arial", 45))
                {

                    graphics.DrawString(secondText, arialFont, System.Drawing.Brushes.Red, NameFilm);
                    graphics.DrawString(Date, arialFont, System.Drawing.Brushes.Red, DateF);
                }
                if (firstText.Length <= 11)
                {
                    using (Font arialFont = new Font("Arial", 45))
                    {
                        graphics.DrawString(firstText, arialFont, System.Drawing.Brushes.Red, NumberSeat);
                    }
                }
                else if (firstText.Length <= 22)
                {
                    using (Font arialFont = new Font("Arial", 22))
                    {
                        graphics.DrawString(firstText, arialFont, System.Drawing.Brushes.Red, NumberSeat);
                    }
                }
                else 
                {
                    using (Font arialFont = new Font("Arial", 10))
                    {
                        graphics.DrawString(firstText, arialFont, System.Drawing.Brushes.Red, NumberSeat);
                    }
                }
            }
            string imageFilePath2 = @"Ticket\tikoutput.jpg";
            bitmap.Save(imageFilePath2);
             MessageBox.Show(@"Tiket was created ! Find it in WpfApp5\WpfApp5\bin\Debug\Ticket\Ticket\tikoutput.jpg");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //  deserealization
            XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
            try
            {

                using (FileStream fs = new FileStream("thirtfilm.xml", FileMode.OpenOrCreate))
                {
                    strlist3 = (List<string>)formatter.Deserialize(fs);
                }
            }
            catch
            {
                MessageBox.Show("File is nullarable! It s not proble");
            }
            try
            {

                using (FileStream fs = new FileStream("firstfilm.xml", FileMode.OpenOrCreate))
                {
                    strlist1 = (List<string>)formatter.Deserialize(fs);
                }

            }
            catch
            {
                MessageBox.Show("File is nullarable! It s not proble");
            }
            try
            {

                using (FileStream fs = new FileStream("secondfilm.xml", FileMode.OpenOrCreate))
                {
                    strlist2 = (List<string>)formatter.Deserialize(fs);
                }

            }
            catch
            {
                MessageBox.Show("File is nullarable! It s not proble");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //serealization
            XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
            using (FileStream fs = new FileStream("firstfilm.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, strlist1);
            }
            using (FileStream fs = new FileStream("secondfilm.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, strlist2);
            }
            using (FileStream fs = new FileStream("thirtfilm.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, strlist3);
            }

        }
    }
}
