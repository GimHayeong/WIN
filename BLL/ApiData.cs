using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL
{
    public class ApiData
    {
        

        public DataTable OpenApiSampleForJusoGoKr(string keyword, out string apiurlNcnt)
        {
            if (String.IsNullOrWhiteSpace(keyword))
            {
                apiurlNcnt = String.Empty;
                return null;
            }

            ApiConn api = new ApiConn();
            string currentPage = "1";  //현재 페이지
            string countPerPage = "1000"; //1페이지당 출력 갯수
            string confmKey = api.GetJusoGoKr();
            DataTable tblResult = null;

            string apiurl = $"http://www.juso.go.kr/addrlink/addrLinkApi.do?currentPage={currentPage}&countPerPage={countPerPage}&keyword={keyword}&confmKey={confmKey}";

            apiurlNcnt = apiurl + "\r\n";

            try
            {
                WebClient wc = new WebClient();

                XmlReader read = new XmlTextReader(wc.OpenRead(apiurl));

                DataSet ds = new DataSet();
                ds.ReadXml(read);

                tblResult = ds.Tables[0];

                DataRow[] rows = ds.Tables[0].Select();

                apiurlNcnt += rows[0]["totalCount"].ToString();

                if (rows[0]["totalCount"].ToString() != "0")
                {
                    tblResult = ds.Tables[1].DefaultView.ToTable(false, new string[] { "roadAddrPart1", "roadAddrPart2", "ZipNo" }); 
                }
                else
                {
                    tblResult = null;
                }
            }
            catch (Exception)
            {
            }

            return tblResult;
        }
    }
}
