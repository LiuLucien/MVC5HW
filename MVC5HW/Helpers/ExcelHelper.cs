using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;


namespace MVC5HW.Helpers
{
    public class ExcelHelper
    {
        public static MemoryStream 匯出Excel<T>(IEnumerable<T> obj1, T obj2)
        {
            MemoryStream ms = new MemoryStream();
            HSSFWorkbook workbook = new HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("Sheet1");

            //取得T2的Type
            Type t = obj2.GetType();

            //利用GetProperties()找出T2的所有屬性
            for (int i = 0; i < t.GetProperties().Length; i++)
            {
                sheet.SetColumnWidth(i, 20 * 256);
                //從第0個Cell開始，把屬性的名稱設進去。
                sheet.CreateRow(0).CreateCell(i)
                  .SetCellValue(t.GetProperties()[i].Name);
            }

            int count = 1;
            foreach (T d in obj1)
            {
                for (int i = 0; i < t.GetProperties().Length; i++)
                {
                    sheet.CreateRow(count).CreateCell(i)
.SetCellValue(Convert.ToString(t.GetProperties()[i].GetValue(d, null)));
                }
                count++;
            }
            workbook.Write(ms);
            return ms;
        }
    }
}