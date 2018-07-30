using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfApp
{
    /// <summary>
    /// WinExcel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WinExcel : Window
    {
        public WinExcel()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xApp;
            Excel._Workbook xWB;
            Excel._Worksheet xSheet;
            Excel.Range xRange;


            try
            {
                // 1. 엑셀시작
                xApp = new Excel.Application();
                xApp.Visible = true;

                // 2. 워크북 / 활성 워크시트
                xWB = (Excel._Workbook)(xApp.Workbooks.Add(Missing.Value));
                xSheet = (Excel._Worksheet)xWB.ActiveSheet;

                // 3. 워크시트의 첫번째 행에 열이름
                xSheet.Cells[1, 1] = "First Name";
                xSheet.Cells[1, 2] = "Last Name";
                xSheet.Cells[1, 3] = "Full Name";
                xSheet.Cells[1, 4] = "Salary";

                // 4. 워크시트 첫번째 행의 모양
                xSheet.get_Range("A1", "D1").Font.Bold = true;
                xSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                // 5. 데이터 (FirstName 과 LastName)
                string[,] saNames = new string[5, 2];

                saNames[0, 0] = "John";
                saNames[0, 1] = "Smith";
                saNames[1, 0] = "Tom";
                saNames[1, 1] = "Brown";
                saNames[2, 0] = "Sue";
                saNames[2, 1] = "Thomas";
                saNames[3, 0] = "Jane";
                saNames[3, 1] = "Jones";
                saNames[4, 0] = "Adam";
                saNames[4, 1] = "Johnson";

                // 6. A2:B6 의 범위의 셀에 5.의 데이터 입력
                xSheet.get_Range("A2", "B6").Value2 = saNames;

                // 7. C2:C6 의 범위의 셀에 A2:B6 의 범위의 셀의 값 공백문자열로 연결하여 데이터 입력
                xRange = xSheet.get_Range("C2", "C6");
                xRange.Formula = "=A2 & \" \" & B2";

                // 8. D2:D6 범위의 셀에 0 ~ 100000 사이의 임의의 값을 $형식으로 입력
                xRange = xSheet.get_Range("D2", "D6");
                xRange.Formula = "=RAND()*100000";
                xRange.NumberFormat = "$0.00";

                // 9. A1:D1 범위의 셀 자동맞춤
                xRange = xSheet.get_Range("A1", "D1");
                xRange.EntireColumn.AutoFit();

                // 10. 판매데이터를 입력하고 관련 차트 삽입
                DisplayQuarterlySales(xSheet);

                xApp.Visible = true;
                xApp.UserControl = true;

                #region 엑셀 저장하고 닫기
                /*
                xWB.SaveAs($"excelChartExam{DateTime.Now}.xls"
                    , Excel.XlFileFormat.xlWorkbookNormal
                    , Missing.Value
                    , Missing.Value
                    , Missing.Value
                    , Missing.Value
                    , Excel.XlSaveAsAccessMode.xlExclusive
                    , Missing.Value
                    , Missing.Value
                    , Missing.Value
                    , Missing.Value
                    , Missing.Value);
                xWB.Close(true, Missing.Value, Missing.Value);
                xApp.Quit();
                */
                #endregion

                releaseObject(xSheet);
                releaseObject(xWB);
                releaseObject(xApp);
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }

        /// <summary>
        /// 판매 데이터 입력후 차트 추가
        /// </summary>
        /// <param name="sheet"></param>
        private void DisplayQuarterlySales(Excel._Worksheet sheet)
        {
            Excel._Workbook xWB;
            Excel.Series xSeries;
            Excel.Range xRange;
            Excel._Chart xChart;

            String sMsg;
            int iNumQtrs;

            //Determine how many quarters to display data for.
            for (iNumQtrs = 4; iNumQtrs >= 2; iNumQtrs--)
            {
                sMsg = "Enter sales data for ";
                sMsg = String.Concat(sMsg, iNumQtrs);
                sMsg = String.Concat(sMsg, " quarter(s)?");

                MessageBoxResult dlg = MessageBox.Show(sMsg, "Quarterly Sales?", MessageBoxButton.YesNo);
                if (dlg == MessageBoxResult.Yes)
                    break;
            }

            sMsg = "Displaying data for ";
            sMsg = String.Concat(sMsg, iNumQtrs);
            sMsg = String.Concat(sMsg, " quarter(s).");

            MessageBox.Show(sMsg, "Quarterly Sales");

            // E1셀부터 4열 확장한 범위의 셀에 판매데이터 헤더를 비스듬하게 입력
            xRange = sheet.get_Range("E1", "E1").get_Resize(Missing.Value, iNumQtrs);
            xRange.Formula = "=\"Q\" & COLUMN()-4 & CHAR(10) & \"Sales\"";
            xRange.Orientation = 38;
            xRange.WrapText = true;
            xRange.Interior.ColorIndex = 36;

            // E2:E6범위부터 4열 확장한 범위의 셀에 0~100 사이의  첫번째 판매데이터값을 $형식으로 입력
            xRange = sheet.get_Range("E2", "E6").get_Resize(Missing.Value, iNumQtrs);
            xRange.Formula = "=RAND()*100";
            xRange.NumberFormat = "$0.00";

            // E1:E6범위부터 4열 확장한 범위의 셀 외곽선 모양
            xRange = sheet.get_Range("E1", "E6").get_Resize(Missing.Value, iNumQtrs);
            xRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

            // E8셀부터 4열 확장한 범위의 셀에 E2:E6범위부터 4열 확장한 범위의 각 열의 합계를 입력
            xRange = sheet.get_Range("E8", "E8").get_Resize(Missing.Value, iNumQtrs);
            xRange.Formula = "=SUM(E2:E6)";
            xRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble;
            xRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThick;

            // 활성시트의 워크북에 차트생성
            xWB = (Excel._Workbook)sheet.Parent;
            xChart = (Excel._Chart)xWB.Charts.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            // E2:E6범위부터 4열 확장한 범위의 데이터로 차트 데이터 만들기
            //xRange = sheet.get_Range("E2:E6", Missing.Value).get_Resize(Missing.Value, iNumQtrs);
            xRange = sheet.get_Range("E2:E6").get_Resize(Missing.Value, iNumQtrs);
            xChart.ChartWizard(xRange
                             , Excel.XlChartType.xl3DColumn
                             , Missing.Value
                             , Excel.XlRowCol.xlColumns
                             , Missing.Value
                             , Missing.Value
                             , Missing.Value
                             , Missing.Value
                             , Missing.Value
                             , Missing.Value
                             , Missing.Value);
            
            // 마법사에서 차트데이터 설정시 누락된 데이터가 있어 한번 더 설정해 줌
            xChart.SetSourceData(xRange, Excel.XlRowCol.xlColumns);

            // 차트범례(Q1 ~ Q4) / X축(Last Name)
            xSeries = (Excel.Series)xChart.SeriesCollection(1);
            xSeries.XValues = sheet.get_Range("A2", "A6");

            for (int iRet = 1; iRet <= iNumQtrs; iRet++)
            {
                xSeries = (Excel.Series)xChart.SeriesCollection(iRet);
                String seriesName;
                seriesName = "=\"Q";
                seriesName = String.Concat(seriesName, iRet);
                seriesName = String.Concat(seriesName, "\"");
                xSeries.Name = seriesName;
            }

            xChart.Location(Excel.XlChartLocation.xlLocationAsObject, sheet.Name);

            // 차트 시작위치를 10번째 행, 2번째 열로 옮김
            xRange = (Excel.Range)sheet.Rows.get_Item(10, Missing.Value);
            sheet.Shapes.Item("Chart 1").Top = (float)(double)xRange.Top;
            xRange = (Excel.Range)sheet.Columns.get_Item(2, Missing.Value);
            sheet.Shapes.Item("Chart 1").Left = (float)(double)xRange.Left;
        }

        private void releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch(Exception ex)
            {
                obj = null;
                MessageBox.Show($"개체를 해제하는 동안 예외 발생: {ex}");
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
