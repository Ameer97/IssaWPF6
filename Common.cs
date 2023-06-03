
using IssaWPF6.Dtos;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace IssaWPF6
{
    public class Common
    {
        public static string Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "reports");

        public static List<string> StomacheShoutCuts = new List<string>
        {
            "lower esophageal erosions (GERD LA class A) ",
            "normal ",
            "Patent lumen ",
            "Lax cardia (Hill grade 1) ",
            "Erythematous antral mucosa ",
            "Nodular antral mucosa  ",
            "Anterior wall ucler ",
            "Posterior wall ucler ",
            "Granular erythematous antral mucosa",
            "Prolapse pastropathy ",
            "normal gastric folds ",
            "Dyspepsia ",
            "Reflux symptoms ",
            "Anemia ",
            "Weight loss ",
            "H.pylori gastritis ? ",
            "multiple biopsies taken. ",
        };


        public static List<string> ColonsShoutCuts = new List<string>
        {
            "Up to cecum with ileal intubation: ",
            "Up to cecum: ",
            "Up to splenic flexure: ",
            "Normal looking mucosa, normal vascular pattern. no mass or polyp seen ",
            "erythematous congested mucosa, and loss of vascular pattern with superficial ulceration and easy touch bleeding ",
            "polypoidal mass, ugly looking with uclerated surface causing narrowing of the lumen. mx bx taken ",
            "Ca Colon ",
            "narrowing of the lumen ",
            "ulcerative colitis (Mayo subscore 1)",
            "multiple bx taken ",
        };

        public static string BinPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static void RenderColon(ColonDto f)
        {

            var parameters = new List<KeyValuDto>
            {
                new KeyValuDto{ Key = "Age", Value = f.Age },
                new KeyValuDto{ Key = "AnalInspection", Value = f.AnalInspection },
                new KeyValuDto{ Key = "Assistant", Value = f.Assistant },
                new KeyValuDto{ Key = "ClinicalData", Value = f.ClinicalData },
                new KeyValuDto{ Key = "ColonDetails", Value = f.ColonDetails },
                new KeyValuDto{ Key = "Conclusion", Value = f.Conclusion },
                new KeyValuDto{ Key = "Endoscopist", Value = f.Endoscopist },
                new KeyValuDto{ Key = "FileNo", Value = f.FileNo },
                new KeyValuDto{ Key = "PRExam", Value = f.PRExam },
                new KeyValuDto{ Key = "Gender", Value = f.Gender },
                new KeyValuDto{ Key = "Ileum", Value = f.Ileum },
                new KeyValuDto{ Key = "Name", Value = f.Name },
                new KeyValuDto{ Key = "Premedication", Value = f.Premedication },
                new KeyValuDto{ Key = "Preparation", Value = f.Preparation },
                new KeyValuDto{ Key = "Rectum", Value = f.Rectum },
                new KeyValuDto{ Key = "Scope", Value = f.Scope },
                new KeyValuDto{ Key = "Date", Value = f.Date },
                new KeyValuDto{ Key = "ReferredDoctor", Value = f.ReferredDoctor },
            };

            RenderReport(parameters);
        }



        public static void RenderOGD(StomachDto f)
        {


            var parameters = new List<KeyValuDto>
            {
                new KeyValuDto{ Key = "Name", Value = f.Name },
                new KeyValuDto{ Key = "Age", Value = f.Age },
                new KeyValuDto{ Key = "Gender", Value = f.Gender },
                new KeyValuDto{ Key = "FileNo", Value = f.FileNo },
                new KeyValuDto{ Key = "Date", Value = f.Date },
                new KeyValuDto{ Key = "Premedication", Value = f.Premedication },
                new KeyValuDto{ Key = "Scope", Value = f.Scope },
                new KeyValuDto{ Key = "ReferredDoctor", Value = f.ReferredDoctor },
                new KeyValuDto{ Key = "ClinicalData", Value = f.ClinicalData },
                new KeyValuDto{ Key = "GEJ", Value = f.GEJ },
                new KeyValuDto{ Key = "Esophagus", Value = f.Esophagus },
                new KeyValuDto{ Key = "StomachDetails", Value = f.StomachDetails },
                new KeyValuDto{ Key = "D1", Value = f.D1 },
                new KeyValuDto{ Key = "D2", Value = f.D2 },
                new KeyValuDto{ Key = "Conclusion", Value = f.Conclusion },
                new KeyValuDto{ Key = "Assistant", Value = f.Assistant },
                new KeyValuDto{ Key = "Endoscopist", Value = f.Endoscopist },
            };

            RenderReport(parameters, isColon: false);
        }

        public static void RenderReport(List<KeyValuDto> Parameters, bool isColon = true)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = string.Format(@"Reports\{0}.rdlc", isColon ? "colon" : "stomach");

            Parameters.ForEach(p => localReport.SetParameters(new ReportParameter(p.Key, p.Value)));


            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +
            "  <PageWidth>8.3in</PageWidth>" +
            "  <PageHeight>11.7in</PageHeight>" +
            "  <MarginTop>0.0in</MarginTop>" +
            "  <MarginLeft>0in</MarginLeft>" +
            "  <MarginRight>0in</MarginRight>" +
            "  <MarginBottom>0.0in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //Render the report
            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            if(!Directory.Exists(Path)) Directory.CreateDirectory(Path);
            var fullPath =System.IO.Path.Combine( Path , "a" + DateTime.Now.ToString("ssmmhhddMMyyyy") + ".pdf");
            File.WriteAllBytes(fullPath, renderedBytes);
            Process.Start(@"cmd.exe ", @"/c " + fullPath);

        }



        public static async Task SaveExcel<T>(List<T> dataList, string reportName = "excelFile", string exttension = ".xlsx") where T : new()
        {

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            await Task.Yield();
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);

            string excelName = $"/{reportName}-{DateTime.Now:yyyy-MM-dd_HH-mm-ss}{exttension}";
            var filePath = Path + excelName;
            var file = new FileInfo(filePath);

            using (var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(dataList, true);
                package.Save();
                Process.Start(@"cmd.exe ", @"/c " + filePath);

            }

        }
    }
}
