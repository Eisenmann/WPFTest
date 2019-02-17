using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Threading;


namespace WebChecker
{
    class HttpWorker
    {

        public int WebReqPages(string link)
        {
            int pages=0;
            List<ListRows> lstRows = new List<ListRows>();
            string sourceCode = String.Empty;
            //  try
            //  {
            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(link);
            webReq.Method = "GET";
            webReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            webReq.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
            webReq.Headers.Add(HttpRequestHeader.AcceptLanguage, "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
            webReq.Headers.Add(HttpRequestHeader.CacheControl, "max-age=0");
            // webReq.Connection = "keep-alive";
            webReq.Host = "www.interactivebrokers.com";
            webReq.Headers.Add("Upgrade-Insecure-Requests", "1");
            webReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0";
            // webReq.Timeout = 5000;

            HttpWebResponse webResp = (HttpWebResponse)webReq.GetResponse();

            Stream stream;
            switch (webResp.ContentEncoding.ToUpperInvariant())
            {
                case "GZIP":
                    stream = new GZipStream(webResp.GetResponseStream(), CompressionMode.Decompress);
                    break;
                case "DEFLATE":
                    stream = new DeflateStream(webResp.GetResponseStream(), CompressionMode.Decompress);
                    break;

                default:
                    stream = webResp.GetResponseStream();
                    stream.ReadTimeout = 100;
                    break;
            }
            // using (StreamReader stream = new StreamReader(webResp..GetResponseStream(), Encoding.UTF8))
            //  {
            // Выводим исходный код страницы
            StreamReader reader = new StreamReader(stream);
            sourceCode = reader.ReadToEnd();
            //   }
            pages = parcePages(sourceCode);

           // lstRows = parceTable(sourceCode);
            //  }
            //  catch { }
            return pages;
        }

        List<ListRows> lstRows = new List<ListRows>();
        List<List<ListRows>> lstRowsFull = new List<List<ListRows>>();
        MainWindow win = (MainWindow)App.Current.MainWindow;
        public void WebReq(string link, string page, string maxPage, bool grid, string NameExcange)
        {
            if(page=="1")
            {
                lstRowsFull = new List<List<ListRows>>();
            }
            string sourceCode = String.Empty;
            //  try
            //  {
            Parallel.Invoke(() =>
            {
                HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(link + "&p=&cc=&limit=100&page=" + page);
                webReq.Method = "GET";
                webReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                webReq.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                webReq.Headers.Add(HttpRequestHeader.AcceptLanguage, "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
                webReq.Headers.Add(HttpRequestHeader.CacheControl, "max-age=0");
                // webReq.Connection = "keep-alive";
                webReq.Host = "www.interactivebrokers.com";
                webReq.Headers.Add("Upgrade-Insecure-Requests", "1");
                webReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0";
                webReq.Timeout = 5000;

                HttpWebResponse webResp = (HttpWebResponse)webReq.GetResponse();

                Stream stream;
                switch (webResp.ContentEncoding.ToUpperInvariant())
                {
                    case "GZIP":
                        stream = new GZipStream(webResp.GetResponseStream(), CompressionMode.Decompress);
                        break;
                    case "DEFLATE":
                        stream = new DeflateStream(webResp.GetResponseStream(), CompressionMode.Decompress);
                        break;

                    default:
                        stream = webResp.GetResponseStream();
                        stream.ReadTimeout = 10000;
                        break;
                }
                // using (StreamReader stream = new StreamReader(webResp..GetResponseStream(), Encoding.UTF8))
                //  {
                // Выводим исходный код страницы
                StreamReader reader = new StreamReader(stream);
                sourceCode = reader.ReadToEnd();
                //   }
                //  parcePages(sourceCode);

                lstRows = parceTable(sourceCode);
                lstRowsFull.Add(lstRows);


                if (page == maxPage)
                {
                    List<ListRows> lstRow2 = new List<ListRows>();
                    if (grid) {

                        foreach (List<ListRows> lst in lstRowsFull)
                        {
                            foreach (ListRows lstR in lst)
                            { lstRow2.Add(lstR); }

                        }
                        win.Dispatcher.BeginInvoke(new ThreadStart(delegate { win.dataGrid.ItemsSource = lstRow2; }));
                        lstRowsFull = new List<List<ListRows>>();
                         
                    }
                    else {
                          WriteExcel we = new WriteExcel();
                        foreach (List<ListRows> lst in lstRowsFull)
                        {
                                foreach (ListRows lstR in lst)
                                { lstRow2.Add(lstR); }
                                                      
                        }
                        we.WriteDataInExcel(NameExcange, lstRow2);
                        lstRowsFull = new List<List<ListRows>>();
                    }
                }
                

            } );

            //return lstRows;
        }


        public int parcePages(string sourceCode)
        {
            string page = String.Empty;
            string result = String.Empty;
            int pages = 0;
            for (int i = 0; i <= sourceCode.Length; i++)
                if (i < sourceCode.Length - 23)
                {
                    if (sourceCode.Substring(i, 23).Contains("<ul class='pagination'>"))
                    {
                        while (!sourceCode.Substring(i, 5).Contains("</ul>"))
                        {
                            result += sourceCode.Substring(i, 1);
                            i++;
                        }
                    }
                }

            page = result;
            result = String.Empty;
            for (int i = 0; i <= page.Length; i++)
                if (i < page.Length - 5)
                {
                    if (page.Substring(i, 4).Contains("<li>"))
                    {
                        while (!page.Substring(i, 5).Contains("</li>"))
                        {
                            result += page.Substring(i, 1);
                            i++;
                        }
                    }
                }

            page = result;
            result = String.Empty;
            for (int i = 0; i <= page.Length; i++)
                if (i < page.Length - 4)
                {
                    if (page.Substring(i, 2).Contains("'>"))
                    {
                        while (!page.Substring(i, 4).Contains("</a>"))
                        {
                            result += page.Substring(i + 2, 1);
                            result = result.Replace("</","");
                            i++;
                        }
                    }
                }
            if (result != "")
            {
                pages = System.Convert.ToInt32(result);
            }
            else { pages = 0; }
            return pages;

        }

        public List<ListRows> parceTable(string sourceCode)
        {
            List<ListRows> lstRows = new List<ListRows>();
            string table = String.Empty;
            for (int i = 0; i <= sourceCode.Length - 1; i++)
                if (i < sourceCode.Length - 40)
                {
                    if (sourceCode.Substring(i, 40).Contains("<div class=\"table-responsive no-margin\">"))
                    {
                        while (!sourceCode.Substring(i, 8).Contains("</table>"))
                        {
                            table += sourceCode.Substring(i, 1);
                            i++;
                        }
                    }
                }

            lstRows = parceRows(table);

            return lstRows;

        }

        public void parceHeaders(string sourceCode)
        {

            string tableHeaders = String.Empty;
            for (int i = 0; i <= sourceCode.Length - 1; i++)
                if (i < sourceCode.Length - 8)
                {
                    if (sourceCode.Substring(i, 7).Contains("<thead>"))
                    {
                        while (!sourceCode.Substring(i, 8).Contains("</thead>"))
                        {
                            tableHeaders += sourceCode.Substring(i, 1);
                            i++;
                        }
                    }
                }
        }

        public List<ListRows> parceRows(string sourceCode)
        {

            List<ListRows> lstRows = new List<ListRows>();
            
            string tableRows = String.Empty;
            string result = String.Empty;
            for (int i = 0; i <= sourceCode.Length; i++)
            {
                if (i < sourceCode.Length - 8)
                {
                    if (sourceCode.Substring(i, 7).Contains("<tbody>"))
                    {
                        while (!sourceCode.Substring(i, 8).Contains("</tbody>"))
                        {
                            tableRows += sourceCode.Substring(i, 1);
                            i++;
                        }
                    }
                }
            }

          //   = tableRows;
            for (int i = 0; i <= tableRows.Length; i++)
            {
                if (i < tableRows.Length - 5)
                {
                    if (tableRows.Substring(i, 4).Contains("<tr>"))
                    {
                        while (!tableRows.Substring(i, 5).Contains("</tr>"))
                        {
                            result += tableRows.Substring(i, 1);
                            i++;
                        }
                    }
                }
            }

            tableRows = result;
            result = String.Empty;
            ListRows oneRow = new ListRows();
            int r = 0;
            for (int i = 0; i <= tableRows.Length; i++)
            {
                if (i < tableRows.Length - 5)
                {
                    if (tableRows.Substring(i, 4).Contains("<td>"))
                    {
                        
                        while (!tableRows.Substring(i, 5).Contains("</td>"))
                        {
                            result += tableRows.Substring(i, 1);
                            i++;
                            
                        }
                        r++;
                        if (r == 1)
                        {
                            oneRow.IBSymbol = result.Replace("<td>","");
                            result = String.Empty;
                        }
                        if (r == 2)
                        {
                            for (int j = 0; j <= result.Length; j++)
                            {
                                if (j < result.Length - 21)
                                {
                                    if (result.Substring(j, 21).Contains("class=\"linkexternal\">"))
                                    {

                                        while (!result.Substring(j, 4).Contains("</a>"))
                                        {
                                            oneRow.ProductDescription += result.Substring(j, 1);
                                            oneRow.ProductDescription = oneRow.ProductDescription.Replace("class=\"linkexternal\">","");
                                            j++;

                                        }
                                        
                                    }
                                }
                            }
                            result = String.Empty;
                        }
                        if (r == 3)
                        {
                            oneRow.Symbol = result.Replace("<td>", "");
                            result = String.Empty;
                        }
                        if (r == 4)
                        {
                            oneRow.Currency = result.Replace("<td>", "");
                            result = String.Empty;
                        }
                        if(r==4)
                        {
                            lstRows.Add(oneRow);
                            oneRow = new ListRows();
                            r = 0;
                        }
                    }
                }
            }

            return lstRows;
        }

    }

    public class ListRows
     {
        public string IBSymbol { get; set; }
        public string ProductDescription { get;set; }
        public string Symbol { get; set; }
        public string Currency { get; set; }
    }
}
