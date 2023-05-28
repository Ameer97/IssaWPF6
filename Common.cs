
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

        //public static void Preview(object id, ReportClass cr, bool colon = true)
        //{
        //    var directory = colon ? "colon" : "stomache";
        //    var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + directory + "\\";
        //    var file = id + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf";
        //    var filename = path + file;
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);

        //    var ggg = path + file;
        //    cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, ggg);
        //    Process.Start(filename);
        //}


        /// <summary>
        /// References:
        /// </summary>
        public static void RenderReport(List<KeyValuDto> Parameters, bool isColon = true)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = string.Format(BinPath + @"\Reports\{0}.rdlc", isColon ? "colon" : "stomach");

            Parameters.ForEach(p => localReport.SetParameters(new ReportParameter(p.Key, p.Value)));



            //A method that returns a collection for our report
            //Note: A report can have multiple data sources
            //List<Employee> employeeCollection = GetData();

            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer
            //ReportDataSource reportDataSource = new ReportDataSource("EmployeeCollection", employeeCollection);
            //localReport.DataSources.Add(reportDataSource);

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


            //Clear the response stream and write the bytes to the outputstream
            //Set content-disposition to "attachment" so that user is prompted to take an action
            //on the file (open or save)
            //Response.Clear();
            //Response.ContentType = mimeType;
            //Response.AddHeader("content-disposition", "attachment; filename=foo." + fileNameExtension);
            //Response.BinaryWrite(renderedBytes);
            //Response.End();

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
