using ClosedXML.Excel;
using Microsoft.Win32;
using OnlineExamUI.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace OnlineExamUI.Helpers
{
    public static class ExcelExporter
    {
        public static void WriteToExcel<T>(IEnumerable<T> list)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                FileName = "Adlar.xlsx",
                Title = "Exsport"
            };

            bool? dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == true)
            {
                using (var wb = new XLWorkbook())
                {
                    DataTable dt = new DataTable();

                    Type type = typeof(T);
                    Type attributeType = typeof(ExportAttribute);

                    PropertyInfo[] allPropInfos=type.GetProperties();

                    List<PropertyInfo> exportedPropInfos = new List<PropertyInfo>();

                    foreach (var propertyInfo in allPropInfos)
                    {
                        ExportAttribute attribute =(ExportAttribute) propertyInfo.GetCustomAttribute(attributeType);
                        if(attribute!=null)
                        {
                            exportedPropInfos.Add(propertyInfo);
                            dt.Columns.Add(attribute.Name);
                        }
                    }

                    foreach (var item in list)
                    {
                        List<object> values = new List<object>();

                        foreach(var propertyInfo in exportedPropInfos)
                        {
                           object value = propertyInfo.GetValue(item);
                           values.Add(value);
                        }

                        dt.Rows.Add(values.ToArray());
                    }


                    var worksheet = wb.Worksheets.Add(dt, "Məlumatlar");

                    worksheet.Rows().AdjustToContents();
                    worksheet.Columns().AdjustToContents();

                    wb.SaveAs(saveFileDialog.FileName);
                }
            }

        }
    }
}
