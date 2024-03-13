using CarRealte.DB;
using OfficeOpenXml;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;

namespace CarRealte.ViewModel
{
    public class MainwindowVM : ViewModelBase
    {
        
        public ICommand trueAuto { get; set; }
        public ICommand falseAuto { get; set; }
        public MainwindowVM()
        {
            trueAuto = new RelayCommand(trueauto);
            falseAuto = new RelayCommand(falseauto);
        }

        private void falseauto(object obj)
        {
            using (RetailAutoContext db = new RetailAutoContext())
            {
                // Получаем доступные машины из базы данных
                var autofalse = db.НеДоступныеМашиныs.ToArray();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    // Добавляем новый лист в Excel файл
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("CarDetails");

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Гос знак";
                    worksheet.Cells[1, 2].Value = "Марка";
                    worksheet.Cells[1, 3].Value = "Модель";
                    worksheet.Cells[1, 4].Value = "Цвет";
                    worksheet.Cells[1, 5].Value = "Кузов";
                    worksheet.Cells[1, 6].Value = "КПП";
                    // Добавьте другие заголовки столбцов, если необходимо

                    // Заполняем данные из списка car
                    int row = 2; // Начинаем с второй строки (после заголовка)
                    foreach (var carDetail in autofalse)
                    {
                        worksheet.Cells[row, 1].Value = carDetail.LicensePlate;
                        worksheet.Cells[row, 2].Value = carDetail.BrandName;
                        worksheet.Cells[row, 3].Value = carDetail.ModelName;
                        worksheet.Cells[row, 4].Value = carDetail.ColorName;
                        worksheet.Cells[row, 5].Value = carDetail.BodyTypeName;
                        worksheet.Cells[row, 6].Value = carDetail.TransmissionType;
                        // Добавьте другие данные в соответствующие столбцы, если необходимо
                        row++;
                    }

                    // Сохраняем файл Excel на диск
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog.FilterIndex = 1;
                        saveFileDialog.RestoreDirectory = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Сохраняем файл Excel на выбранное место
                            FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(excelFile);
                        }
                    }
                }

            }
        }

        private void trueauto(object obj)
        {

            using (RetailAutoContext db = new RetailAutoContext())
            {
                // Получаем доступные машины из базы данных
                var autotrue = db.ДоступныеМашиныs.ToArray();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    // Добавляем новый лист в Excel файл
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("CarDetails");

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Гос знак";
                    worksheet.Cells[1, 2].Value = "Марка";
                    worksheet.Cells[1, 3].Value = "Модель";
                    worksheet.Cells[1, 4].Value = "Цвет";
                    worksheet.Cells[1, 5].Value = "Кузов";
                    worksheet.Cells[1, 6].Value = "КПП";
                    // Добавьте другие заголовки столбцов, если необходимо

                    // Заполняем данные из списка car
                    int row = 2; // Начинаем с второй строки (после заголовка)
                    foreach (var carDetail in autotrue)
                    {
                        worksheet.Cells[row, 1].Value = carDetail.LicensePlate;
                        worksheet.Cells[row, 2].Value = carDetail.BrandName;
                        worksheet.Cells[row, 3].Value = carDetail.ModelName;
                        worksheet.Cells[row, 4].Value = carDetail.ColorName;
                        worksheet.Cells[row, 5].Value = carDetail.BodyTypeName;
                        worksheet.Cells[row, 6].Value = carDetail.TransmissionType;
                        // Добавьте другие данные в соответствующие столбцы, если необходимо
                        row++;
                    }

                    // Сохраняем файл Excel на диск
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog.FilterIndex = 1;
                        saveFileDialog.RestoreDirectory = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Сохраняем файл Excel на выбранное место
                            FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(excelFile);
                        }
                    }
                }

            }

        }
    }
}
