using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

/// <summary>
/// Summary description for DataProvider
/// </summary>
public class DataProvider
{
    //SqlDataReader
    //protected static string _connectionString = "server=.;database=Northwind;integrated security=true;";
    protected static string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected SqlConnection con;
    protected SqlDataAdapter adapter;
    protected SqlCommand command;

    public SqlConnection GetConnect()
    {
        return new SqlConnection(_connectionString);
    }
    public static string toMD5(string pass)
    {
        MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
        byte[] myPass = System.Text.Encoding.UTF8.GetBytes(pass);
        myPass = myMD5.ComputeHash(myPass);
        StringBuilder s = new StringBuilder();
        foreach (byte p in myPass)
        {
            s.Append(p.ToString("x").ToLower());
        }
        return s.ToString();
    }
    public static string ToMD5_v2(string str)
    {

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

        StringBuilder sbHash = new StringBuilder();

        foreach (byte b in bHash)
        {

            sbHash.Append(String.Format("{0:x2}", b));

        }
        return sbHash.ToString();

    }
    public static string ConnectionString
    {
        get
        {
            return _connectionString;
        }
        set
        {
            _connectionString = value;
        }
    }

    public void connect()
    {
        if (con == null)
            con = new SqlConnection(_connectionString);
        con.Open();
    }
    public void disconnect()
    {
        if (con != null)
            con.Close();
    }


    public DataTable Load_data(string procname)
    {
        SqlConnection con = GetConnect();
        con.Open();
        SqlCommand cmd = new SqlCommand(procname, con);
        cmd.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public IDataReader executeQuery(string sqlString)
    {
        command = new SqlCommand(sqlString, con);
        return command.ExecuteReader();
    }

    public void executeNonQuery(string sqlString)
    {
        command = new SqlCommand(sqlString, con);
        command.ExecuteNonQuery();
    }

    public object executeScalar(string sqlString)
    {
        command = new SqlCommand(sqlString, con);
        return command.ExecuteScalar();
    }

    protected ArrayList ConvertDataSetToArrayList(DataSet dataset)
    {
        ArrayList arr = new ArrayList();
        DataTable dt = dataset.Tables[0];
        int i, n = dt.Rows.Count;
        for (i = 0; i < n; i++)
        {
            object hs = GetDataFromDataRow(dt, i);
            arr.Add(hs);

        }
        return arr;
    }

    protected virtual object GetDataFromDataRow(DataTable dt, int i)
    {
        return null;
    }

    /// <summary>
    /// Run stored procedure.
    /// </summary>
    /// <param name="procName">Name of stored procedure.</param>
    /// <returns>Stored procedure return value.</returns>
    public int RunProc(string procName)
    {
        SqlCommand cmd = CreateCommand(procName, null);
        cmd.ExecuteNonQuery();
        this.Close();
        return (int)cmd.Parameters["ReturnValue"].Value;
    }

    /// <summary>
    /// Run stored procedure.
    /// </summary>
    /// <param name="procName">Name of stored procedure.</param>
    /// <param name="prams">Stored procedure params.</param>
    /// <returns>Stored procedure return value.</returns>
    public int RunProc(string procName, SqlParameter[] prams)
    {
        SqlCommand cmd = CreateCommand(procName, prams);
        cmd.ExecuteNonQuery();
        this.Close();
        return (int)cmd.Parameters["ReturnValue"].Value;
    }

    public static DataSet ThucThiStore_DataSet(string StoredProcedure, params SqlParameter[] Parameters)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection Conn = new SqlConnection(ConnectionString);
        SqlCommand Command = new SqlCommand(StoredProcedure, Conn);
        if (Parameters != null)
        {
            Command.Parameters.Clear();
            Command.Parameters.AddRange(Parameters);
        }
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(StoredProcedure, Conn);
        Command.CommandType = CommandType.StoredProcedure;
        da.SelectCommand = Command;
        try
        {
            Conn.Open();
            da.Fill(ds);
        }
        finally
        {
            if (Conn.State == ConnectionState.Open)
                Conn.Close();
            Conn.Dispose();
        }
        return ds;
    }

    /// <summary>
    /// Run stored procedure.
    /// </summary>
    /// <param name="procName">Name of stored procedure.</param>
    /// <param name="dataReader">Return result of procedure.</param>
    public void RunProc(string procName, out SqlDataReader dataReader)
    {
        SqlCommand cmd = CreateCommand(procName, null);
        dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
    }

    /// <summary>
    /// Run stored procedure.
    /// </summary>
    /// <param name="procName">Name of stored procedure.</param>
    /// <param name="prams">Stored procedure params.</param>
    /// <param name="dataReader">Return result of procedure.</param>
    public void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
    {
        SqlCommand cmd = CreateCommand(procName, prams);
        dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
    }

    public int RunProcDS(string procName, SqlParameter[] prams, out DataSet dataSet)
    {
        SqlCommand cmd = CreateCommand(procName, prams);
        SqlDataAdapter dad = new SqlDataAdapter(cmd);
        DataSet dst = new DataSet();
        dad.Fill(dst, "CurrentItems");
        dataSet = dst;
        this.Close();
        return (int)cmd.Parameters["ReturnValue"].Value;
    }

    public int RunProcDS(string procName, out DataSet dataSet)
    {
        SqlCommand cmd = CreateCommand(procName);
        SqlDataAdapter dad = new SqlDataAdapter(cmd);
        DataSet dst = new DataSet();
        dad.Fill(dst, "CurrentItems");
        dataSet = dst;
        this.Close();
        return (int)cmd.Parameters["ReturnValue"].Value;
    }

    /// <summary>
    /// Create command object used to call stored procedure.
    /// </summary>
    /// <param name="procName">Name of stored procedure.</param>
    /// <param name="prams">Params to stored procedure.</param>
    /// <returns>Command object.</returns>
    private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
    {
        // make sure connection is open
        Open();

        //command = new SqlCommand( sprocName, new SqlConnection( ConfigManager.DALConnectionString ) );
        SqlCommand cmd = new SqlCommand(procName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // add proc parameters
        if (prams != null)
        {
            foreach (SqlParameter parameter in prams)
                cmd.Parameters.Add(parameter);
        }

        // return param
        cmd.Parameters.Add(
            new SqlParameter("ReturnValue", SqlDbType.Int, 4,
            ParameterDirection.ReturnValue, false, 0, 0,
            string.Empty, DataRowVersion.Default, null));

        return cmd;
    }
    private SqlCommand CreateCommand(string procName)
    {
        // make sure connection is open
        Open();

        //command = new SqlCommand( sprocName, new SqlConnection( ConfigManager.DALConnectionString ) );
        SqlCommand cmd = new SqlCommand(procName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // return param
        cmd.Parameters.Add(
            new SqlParameter("ReturnValue", SqlDbType.Int, 4,
            ParameterDirection.ReturnValue, false, 0, 0,
            string.Empty, DataRowVersion.Default, null));

        return cmd;
    }

    /// <summary>
    /// Open the connection.
    /// </summary>
    private void Open()
    {
        // open connection
        if (con == null)
        {
            con = new SqlConnection(_connectionString);

        }
        if (con.State == ConnectionState.Closed)
            con.Open();
    }

    /// <summary>
    /// Close the connection.
    /// </summary>
    public void Close()
    {
        if (con != null || con.State == ConnectionState.Open)
            con.Close();
    }

    /// <summary>
    /// Release resources.
    /// </summary>
    public void Dispose()
    {
        // make sure connection is closed
        if (con != null)
        {
            con.Dispose();
            con = null;
        }
    }

    /// <summary>
    /// Make input param.
    /// </summary>
    /// <param name="ParamName">Name of param.</param>
    /// <param name="DbType">Param type.</param>
    /// <param name="Size">Param size.</param>
    /// <param name="Value">Param value.</param>
    /// <returns>New parameter.</returns>
    public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
    {
        return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
    }

    /// <summary>
    /// Make input param.
    /// </summary>
    /// <param name="ParamName">Name of param.</param>
    /// <param name="DbType">Param type.</param>
    /// <param name="Size">Param size.</param>
    /// <returns>New parameter.</returns>
    public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
    {
        return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
    }

    /// <summary>
    /// Make stored procedure param.
    /// </summary>
    /// <param name="ParamName">Name of param.</param>
    /// <param name="DbType">Param type.</param>
    /// <param name="Size">Param size.</param>
    /// <param name="Direction">Parm direction.</param>
    /// <param name="Value">Param value.</param>
    /// <returns>New parameter.</returns>
    public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
    {
        SqlParameter param;

        if (Size > 0)
            param = new SqlParameter(ParamName, DbType, Size);
        else
            param = new SqlParameter(ParamName, DbType);

        param.Direction = Direction;
        if (!(Direction == ParameterDirection.Output && Value == null))
            param.Value = Value;

        return param;
    }

    public string GetErrorMessage(int errorCode)
    {
        DataSet dst = (DataSet)System.Web.HttpContext.Current.Cache["Messages"];
        if (dst == null)
            CreateErrorMessages();

        dst = (DataSet)System.Web.HttpContext.Current.Cache["Messages"];
        string filterExpr = "ErrorCode = '" + errorCode.ToString() + "'";
        DataTable dtbl = dst.Tables["Messages"];
        DataRow[] drows = dtbl.Select(filterExpr);

        return drows[0]["ErrorMessage"].ToString();
    }

    /// <summary>
    /// Create a dataset object contains all error 
    /// messages and push it into application cache.
    /// </summary>
    private void CreateErrorMessages()
    {
        DataSet dst = new DataSet();
        SqlConnection conn = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand("spGetAllErrorMessage", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter dad = new SqlDataAdapter(cmd);
        dad.Fill(dst, "Messages");

        System.Web.HttpContext.Current.Cache.Insert("Messages", dst);

    }
    public static string GetConnection()
    {
        return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    }

    public static DataTable Select(string sql)
    {
        SqlConnection oCon = new SqlConnection(GetConnection());
        oCon.Open();
        SqlCommand oCmd = new SqlCommand(sql, oCon);
        DataTable dt = new DataTable();
        SqlDataReader oRead = oCmd.ExecuteReader();
        dt.Load(oRead);
        return dt;
    }
    public DataTable load_data_param(string procname, params SqlParameter[] prams)
    {
        SqlConnection cnn = new SqlConnection(GetConnection());
        cnn.Open();
        SqlCommand cmd = new SqlCommand(procname, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        if (prams.Length > 0)
        {
            cmd.Parameters.AddRange(prams);
        }
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnn.Close();
        return dt;
    }
    public void exeproc(string procname, params SqlParameter[] prams)
    {
        SqlConnection con = GetConnect();
        con.Open();
        SqlCommand cmd = new SqlCommand(procname, con);
        cmd.CommandType = CommandType.StoredProcedure;
        if (prams.Length > 0)
        {
            cmd.Parameters.AddRange(prams);
        }
        cmd.ExecuteNonQuery();
        con.Close();
        //return prams[0].Value.ToString();
    }

    public static DataTable QueryToDataTable(string strSQL)
    {
        DataTable dtbTmp = new DataTable();
        SqlConnection conn = new SqlConnection(_connectionString);
        try
        {
            conn.Open(); // Mở kết nối
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn); // Tạo một Adapter
            DataSet ds = new DataSet();// Tạo DataSet
            da.Fill(ds, "GetData");// Đổ dữ liệu DataSet
            dtbTmp = ds.Tables[0];// Tạo DataTable từ dataSet
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);// Bắt lỗi
        }
        finally
        {
            conn.Close();// Đóng kết nối
        }
        return dtbTmp;
    }
    private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵầấ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"

        };

    public static string locDau(string str)
    {

        for (int i = 1; i < VietnameseSigns.Length; i++)
        {

            for (int j = 0; j < VietnameseSigns[i].Length; j++)

                str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            str = str.Replace("“", "").Replace("”", "").Replace(":", "").Replace("/", "").Replace("?", "").Replace("\"", "").Replace("'", "");
            str = str.Replace(" ", "-").ToLower();
        }

        return str;

    }
    public static string locDau_v2(string str)
    {

        for (int i = 1; i < VietnameseSigns.Length; i++)
        {

            for (int j = 0; j < VietnameseSigns[i].Length; j++)

                str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            str = str.Replace("“", "").Replace("”", " ").Replace(":", " ").Replace("/", " ").Replace("?", " ").Replace("-", " ");
            str = str.Trim().Replace(" ", "-").Replace("&", "").ToLower();
        }

        return str;

    }
    public static string catTen(string str, int sokytu, string themcuoi)
    {
        string sp_name = str;
        if (sp_name.Length > sokytu)
        {
            int vitri = 0;
            for (int i = sokytu; i < sp_name.Length; i++)
            {
                if (sp_name[i].ToString() == " ") { vitri = i; break; } else { vitri = sp_name.Length; }
            }
            sp_name = sp_name.Substring(0, vitri) + themcuoi;
        }
        return str;
    }
    private static string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
    private static string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
    // Hàm đọc số thành chữ
    public static string DocTienBangChu(long SoTien, string strTail)
    {
        int lan, i;
        long so;
        string KetQua = "", tmp = "";
        int[] ViTri = new int[6];
        if (SoTien < 0) return "Số tiền âm !";
        if (SoTien == 0) return "Không đồng !";
        if (SoTien > 0)
        {
            so = SoTien;
        }
        else
        {
            so = -SoTien;
        }
        //Kiểm tra số quá lớn
        if (SoTien > 8999999999999999)
        {
            SoTien = 0;
            return "";
        }
        ViTri[5] = (int)(so / 1000000000000000);
        so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
        ViTri[4] = (int)(so / 1000000000000);
        so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
        ViTri[3] = (int)(so / 1000000000);
        so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
        ViTri[2] = (int)(so / 1000000);
        ViTri[1] = (int)((so % 1000000) / 1000);
        ViTri[0] = (int)(so % 1000);
        if (ViTri[5] > 0)
        {
            lan = 5;
        }
        else if (ViTri[4] > 0)
        {
            lan = 4;
        }
        else if (ViTri[3] > 0)
        {
            lan = 3;
        }
        else if (ViTri[2] > 0)
        {
            lan = 2;
        }
        else if (ViTri[1] > 0)
        {
            lan = 1;
        }
        else
        {
            lan = 0;
        }
        for (i = lan; i >= 0; i--)
        {
            tmp = DocSo3ChuSo(ViTri[i]);
            KetQua += tmp;
            if (ViTri[i] != 0) KetQua += Tien[i];
            if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
        }
        if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
        KetQua = KetQua.Trim() + strTail;
        return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
    }
    // Hàm đọc số có 3 chữ số
    private static string DocSo3ChuSo(int baso)
    {
        int tram, chuc, donvi;
        string KetQua = "";
        tram = (int)(baso / 100);
        chuc = (int)((baso % 100) / 10);
        donvi = baso % 10;
        if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
        if (tram != 0)
        {
            KetQua += ChuSo[tram] + " trăm";
            if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
        }
        if ((chuc != 0) && (chuc != 1))
        {
            KetQua += ChuSo[chuc] + " mươi";
            if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
        }
        if (chuc == 1) KetQua += " mười";
        switch (donvi)
        {
            case 1:
                if ((chuc != 0) && (chuc != 1))
                {
                    KetQua += " mốt";
                }
                else
                {
                    KetQua += ChuSo[donvi];
                }
                break;
            case 5:
                if (chuc == 0)
                {
                    KetQua += ChuSo[donvi];
                }
                else
                {
                    KetQua += " lăm";
                }
                break;
            default:
                if (donvi != 0)
                {
                    KetQua += ChuSo[donvi];
                }
                break;
        }
        return KetQua;
    }
    public static string Bo_key(string str)
    {
        str = str.Substring(2);
        return str;
    }
    public static string Bo_key1(string str)
    {
        str = str.Substring(2, 2);
        return str;
    }
    public static string Bo_key2(string str)
    {
        str = str.Substring(5);
        return str;
    }
    public static string Lay_key(string str)
    {
        str = str.Substring(0, 1);
        return str;
    }
    public string RemoveUnicode(string inputText, bool sqlSearch)
    {
        string stFormD = inputText.Normalize(System.Text.NormalizationForm.FormD);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string str = "";
        for (int i = 0; i <= stFormD.Length - 1; i++)
        {
            UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
            if (uc == UnicodeCategory.NonSpacingMark == false)
            {
                if (stFormD[i] == 'đ')
                    str = "d";
                else if (stFormD[i] == 'Đ')
                    str = "D";
                else
                    str = stFormD[i].ToString();

                if (sqlSearch) str = ReplaceCharSet(str);
                sb.Append(str);
            }
        }
        return sb.ToString().ToLower();
    }

    public string ReplaceCharSet(string input)
    {
        string charSet = input.ToLower();
        if (charSet == "a")
            return "[aàảãáạăằẳẵắặâầẩẫấậ]";
        else if (charSet == "e")
            return "[eèẻẽéẹêềểễếệ]";
        else if (charSet == "i")
            return "[iìỉĩíị]";
        else if (charSet == "o")
            return "[oòỏõóọôồổỗốộơờởỡớợ]";
        else if (charSet == "u")
            return "[uùủũúụưừửữứự]";
        else if (charSet == "y")
            return "[yỳỷỹýỵ]";
        else if (charSet == "d")
            return "[dđ]";
        return charSet;
    }


    public static string EncryptString(string Message, string Passphrase)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

        // Buoc 1: Bam chuoi su dung MD5

        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

        // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

        // Step 3. Cai dat bo ma hoa
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;

        // Step 4. Convert chuoi (Message) thanh dang byte[]
        byte[] DataToEncrypt = UTF8.GetBytes(Message);

        // Step 5. Ma hoa chuoi
        try
        {
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }

        // Step 6. Tra ve chuoi da ma hoa bang thuat toan Base64
        return Convert.ToBase64String(Results);
    }

    public static string DecryptString(string Message, string Passphrase)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

        // Step 1. Bam chuoi su dung MD5

        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

        // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

        // Step 3. Cai dat bo giai ma
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;

        // Step 4. Convert chuoi (Message) thanh dang byte[]
        byte[] DataToDecrypt = Convert.FromBase64String(Message);

        // Step 5. Bat dau giai ma chuoi
        try
        {
            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
        }
        finally
        {
            // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }

        // Step 6. Tra ve ket qua bang dinh dang UTF8
        return UTF8.GetString(Results);
    }
    public static string GetUniqueFileName(string name, string savePath, string ext)
    {

        name = name.Replace(ext, "").Replace(" ", "_");
        name = System.Text.RegularExpressions.Regex.Replace(name, @"[^\w\s]", "");

        var newName = name;
        var i = 0;
        if (System.IO.File.Exists(savePath + newName + ext))
        {

            do
            {
                i++;
                newName = name + "_" + i;

            }
            while (System.IO.File.Exists(savePath + newName + ext));

        }

        return newName;


    }
    public static string cat_chuoi(string chuoi, int sokt)
    {
        if (chuoi.Length > sokt)
        {
            int vitri = 0;
            for (int i = sokt; i < chuoi.Length; i++)
            {
                if (chuoi[i].ToString() == " ") { vitri = i; break; } else { vitri = chuoi.Length; }
            }
            chuoi = chuoi.Substring(0, vitri) + "...";
        }

        return chuoi;
    }

}