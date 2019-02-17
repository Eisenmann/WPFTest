using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace WebChecker
{
    class WriteExcel
    {
        public void WriteDataInExcel(string fileName, List<ListRows> lstRows)
        {
            foreach (ListRows lst in lstRows)
            {
                File.AppendAllText(fileName + ".csv", lst.IBSymbol+","+lst.ProductDescription+","+lst.Symbol+","+lst.Currency+Environment.NewLine);
            }
        }
               

    }
}
