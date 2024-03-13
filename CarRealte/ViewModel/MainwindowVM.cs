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
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using CarRealte.DB;
using System.Windows.Controls;

namespace CarRealte.ViewModel
{
    public class MainwindowVM : ViewModelBase
    {
        private readonly string TemplateDocFile = @"C:\Users\ardan\source\repos\CarRealte\CarRealte\Sourcess\Example.docx";
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }

            }
        }
        public ICommand trueAuto { get; set; }
        public ICommand falseAuto { get; set; }
        public ICommand ExportWord { get; set; }
        public MainwindowVM()
        {
            trueAuto = new RelayCommand(trueauto);
            falseAuto = new RelayCommand(falseauto);
            ExportWord = new RelayCommand(exportWord);
        }

        private void exportWord(object obj)
        {
            using (RetailAutoContext db = new RetailAutoContext())
            {
                var retail = db.ПредставлениеАрендаs.FirstOrDefault(ret => ret.IdАренды == _id);
                var Фамилия = retail.Фамилия;
                var Имя = retail.Имя;
                var Марка = retail.Марка;
                var Модель = retail.Модель;
                var Название = retail.НазваниеАренды;
                var Описание = retail.Описание;
                var Цена = retail.ЦенаАренды.ToString();

                var wordApp = new Word.Application();
                wordApp.Visible = false;
                try
                {
                    var wordDoc = wordApp.Documents.Open(TemplateDocFile);
                    ReplaceSubS("[Фамилия]", Фамилия, wordDoc);
                    ReplaceSubS("[Имя]", Имя, wordDoc);
                    ReplaceSubS("[Марка]", Марка, wordDoc);
                    ReplaceSubS("[Модель]", Модель, wordDoc);
                    ReplaceSubS("[Описание]", Описание, wordDoc);
                    ReplaceSubS("[Сумма]", Цена, wordDoc);
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    wordDoc.SaveAs(saveFileDialog.FileName);
                    wordApp.Visible = true;
                   
                }
                catch
                {
                    
                }

            }
        }
        private void ReplaceSubS(string stubToReplace, string text, Word.Document document)
        {
            var range = document.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text, Replace: Word.WdReplace.wdReplaceAll);
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
