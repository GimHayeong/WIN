using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    ///   + System.Data.SqlClient : SQL 서버 공급자. SQL 7.0 이상 버전에 연결.
    ///   + System.Data.OracleClient : Oracle 공급자. Oracle 8.1.7 이상 버전에 연결.
    ///   + System.Data.OleDb : OLE DB 공급자. OLE DB를 통해 DBMS에 연결.
    ///   + System.Data.Odbc : ODBC 공급자. ODBC를 통해 DBMS에 연결.
    ///   
    ///   + Connection : 데이터 소스와 연결
    ///   + Command : SQL 명령이나 저장프로시저 실행
    ///   + DataReader : 읽기전용. 전진전용 결과셋.
    ///   + DataAdapter : 데이터 원본을 읽거나 수정.
    /// </summary>
    /// <remarks>
    ///   + 연결문자열
    ///     - DataSource (Server) : 연결할 SQL 서버의 인스턴스명. 로컬인스턴스이면 (local). {접두어.}서버명{:포트번호}
    ///     - Initial Catalog (Database) : 최초 접속할 데이터베이스명
    ///     - Intergrated Security (Trusted_Connection) : 윈도우인증모드 사용여부. 디폴트 false(ID/PW필요)
    ///     - User ID : 로그인 계정
    ///     - Password (Pwd)  : 로그인 계정 비밀번호
    ///     - Packet Size : 패킷사이즈. 디폴트 8192
    ///     - Connect Timeout : 접속시도제한시간
    /// </remarks>

    public class DbConn
    {
        private const string CONNECTION_STRING = "Server=e8d4d7f2-e078-4050-bc66-a91e01804b58.sqlserver.sequelizer.com;Database=dbe8d4d7f2e0784050bc66a91e01804b58;User ID = ntizhdbffmvyfhby; Password=PYUvoTGjrbGHExLf2UQwnSzGW4F7Sx7sruBmh7WTnkLqJBNWYUgyHMT5ynGtmJy2;";
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = CONNECTION_STRING;
            return conn;
        }

        public string GetConnectionString()
        {
            return CONNECTION_STRING;
        }
    }
}
