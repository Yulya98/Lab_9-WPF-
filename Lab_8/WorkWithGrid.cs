using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Lab_8
{
    public class WorkWithGrid
    {
        public static DataTable ShowToGrid(UnitOfWork unit)
        {
            IQueryable<Words> spis = unit.Sql.SelectWordsObject();
            DataTable table = new DataTable();
            List<string[]> data = new List<string[]>();
            table.Columns.Add("WordId");
            table.Columns.Add("Translate");
            table.Columns.Add("Word");
            foreach (var str in spis)
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = str.WordId.ToString();
                data[data.Count - 1][1] = str.Translate.ToString();
                data[data.Count - 1][2] = str.Word.ToString();
            }
            foreach (string[] s in data)
            {
                table.Rows.Add(s);
            }
            return table;
        }

        public static DataTable ShowUsers(UnitOfWork unitOfWork)
        {
            var spis = unitOfWork.Sql.SelectUserObject();
            DataTable table = new DataTable();
            List<string[]> data = new List<string[]>();
            table.Columns.Add("UserId");
            table.Columns.Add("UserName");
            table.Columns.Add("password");
            foreach (var str in spis)
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = str.UserId.ToString();
                data[data.Count - 1][1] = str.UserName.ToString();
                data[data.Count - 1][2] = str.password.ToString();
            }
            foreach (string[] s in data)
            {
                table.Rows.Add(s);
            }
            return table;
        }

        public static DataTable SortedOn1(UnitOfWork unit)
        {
            IQueryable<Users> spis = unit.Sql.SortedOnOneParametrs();
            DataTable table = new DataTable();
            List<string[]> data = new List<string[]>();
            table.Columns.Add("UserId");
            table.Columns.Add("UserName");
            table.Columns.Add("password");
            foreach (var str in spis)
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = str.UserId.ToString();
                data[data.Count - 1][1] = str.UserName.ToString();
                data[data.Count - 1][2] = str.password.ToString();
            }
            foreach (string[] s in data)
            {
                table.Rows.Add(s);
            }
            return table;
        }

        public static DataTable SortedOn2(UnitOfWork unit)
        {
            IQueryable<UsersWords> spis = unit.Sql.SortedOnTwoParametr();
            DataTable table = new DataTable();
            List<string[]> data = new List<string[]>();
            table.Columns.Add("UserId");
            table.Columns.Add("WordId");
            table.Columns.Add("flag");
            foreach (var str in spis)
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = str.UserId.ToString();
                data[data.Count - 1][1] = str.WordId.ToString();
                data[data.Count - 1][2] = str.flag.ToString();
            }
            foreach (string[] s in data)
            {
                table.Rows.Add(s);
            }
            return table;
        }

        public static DataTable ShowToGridOsersWords(UnitOfWork unitOfWork)
        {
            DataTable table = new DataTable();
            List<string[]> data = new List<string[]>();
            var wordsUsers = unitOfWork.Sql.SelectFromUsersWords();
            table.Columns.Add("UserId");
            table.Columns.Add("WordId");
            table.Columns.Add("flag");
            foreach (var str in wordsUsers)
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = str.UserId.ToString();
                data[data.Count - 1][1] = str.WordId.ToString();
                data[data.Count - 1][2] = str.flag.ToString();
            }
            foreach (string[] s in data)
            {
                table.Rows.Add(s);
            }
            return table;
        }
    }
}
