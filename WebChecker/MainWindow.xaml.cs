using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using System.Threading;

namespace WebChecker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                  
        }

       
        List<ListRows> lstRows = new List<ListRows>();

        private void fornewthread(object tp)//string btn, string i
        {
            ThreadParam c = (ThreadParam)tp;
            HttpWorker httpWork = new HttpWorker();
            // foreach (ListRows lstRow in

            httpWork.WebReq(c.Name, c.Page, c.MaxPage, c.GridFile, c.NameExcange);//)
           /* {
                lstRows.Add(lstRow);
            }*/
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button1.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {                
                    
                    tp.Name = links.Link(button1.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button1.Content.ToString();


                    new System.Threading.Thread(() => { 
                     httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);
                    
                      });
               
                
                }
              
            }
        }
        public void ProgressHandler(List<ListRows> lst)
        {
            dataGrid.ItemsSource = lstRows;

            InitializeComponent();
        }
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (radioButton1.IsChecked == true)
                {
                    radioButton1.IsChecked = false;
                }
            }
            catch { }
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            radioButton.IsChecked = false;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button2.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button2.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button1.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button3.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button3.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button1.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button4.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button1.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button4.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button5.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button1.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button5.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button6.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button6.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button1.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button7.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button7.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button1.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button8.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button1.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button8.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button9.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button9.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button1.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button10.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button10.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button1.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            HttpWorker httpWork = new HttpWorker();
            List<Thread> threads = new List<Thread>();
            int page = httpWork.WebReqPages(links.Link(button11.Content.ToString()));
            if (page > 0)
            {
                ThreadParam tp = new ThreadParam();
                if (radioButton.IsChecked == true)
                {
                    tp.GridFile = true;
                }
                else
                {
                    tp.GridFile = false;
                }
                for (int i = 1; i <= page; i++)
                {

                    tp.Name = links.Link(button11.Content.ToString());
                    tp.Page = i.ToString();
                    tp.MaxPage = page.ToString();
                    tp.NameExcange = button1.Content.ToString();

                    Task.Run(() =>
                    {
                        Parallel.Invoke(() => {
                            httpWork.WebReq(tp.Name, tp.Page, tp.MaxPage, tp.GridFile, tp.NameExcange);

                        });
                    });

                }

            }
        }

        private void buttonAll_Click(object sender, RoutedEventArgs e)
        {
            Links links = new Links();
            List<ListRows> lstNewRows = new List<ListRows>();

            foreach (KeyValuePair<string, string> keyValue in links.LinkDict)
            {
                List<ListRows> lstR = new List<ListRows>();
                lstR = loadAll(keyValue.Value);
                foreach (ListRows lstRow in lstR)
                {
                    lstNewRows.Add(lstRow);
                }
                
            }

            if (radioButton.IsChecked == true)
            {
                this.dataGrid.ItemsSource = lstNewRows;

                InitializeComponent();

            }
            else
            {
                WriteExcel we = new WriteExcel();
                we.WriteDataInExcel(button9.Content.ToString(), lstNewRows);
            }


        }

        private List<ListRows> loadAll(string link)
        {
            lstRows = new List<ListRows>();
            HttpWorker httpWork = new HttpWorker();
            int page = httpWork.WebReqPages(link);
            for (int i = 1; i <= page; i++)
            {
               /* foreach (ListRows lstRow in httpWork.WebReq(link, page.ToString()))
                {
                    lstRows.Add(lstRow);
                }*/
            }

            return lstRows;

        }

   }
}
