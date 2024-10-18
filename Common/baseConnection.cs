using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Common
{
    public class baseConnection
    {
        protected static string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected SqlConnection con;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;

        public static SqlConnection GetConnect()
        {
            return new SqlConnection(_connectionString);
        }
        public static DataTable Load_data(string procname)
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
        public static DataTable load_data_param(string procname, params SqlParameter[] prams)
        {
            SqlConnection cnn = GetConnect();
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
        public static baseResponseSingle add_data_param(string procname, params SqlParameter[] prams)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(procname, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (prams.Length > 0)
            {
                cmd.Parameters.AddRange(prams);
            }
            cmd.Parameters.Add("@Code", SqlDbType.Int).Value = 0;
            cmd.Parameters["@Code"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            baseResponseSingle res = new baseResponseSingle();
            res.Code = (cmd.Parameters["@Code"].Value.ToString() != "" ? int.Parse(cmd.Parameters["@Code"].Value.ToString()) : -1);
            res.result = "Success";

            con.Close();

            return res;
        }
    }
}