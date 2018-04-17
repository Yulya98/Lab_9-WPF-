using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab_8
{
    public class QuerysToSql : IRepositpry
    {
        private CodeFirst db;

        public QuerysToSql( CodeFirst context)
        {
            this.db = context;
        }

        public void DeleteFromUsersWords()
        {
            var command = db.Database.ExecuteSqlCommand("Delete From UsersWords");
        }

        public IQueryable<UsersWords> SelectFromUsersWords()
        {
            IQueryable<UsersWords> command = from u in db.UsersWords
                                             select u;
            return command;
        }

        public IQueryable<int> SelectWordsId()
        {
            IQueryable<int> command = from u in db.Words
                                        select u.WordId;
            return command;
        }

        public IQueryable<int> SelectUsersId()
        {
            IQueryable<int> command = from u in db.Users
                                        select u.UserId;
            return command;
        }

        public void DeleteFromUsers()
        {
            db.Database.ExecuteSqlCommand("Delete From Users");
        }

        public void DeleteFromWords()
        {
            db.Database.ExecuteSqlCommand("Delete From Words");
        }

        public IQueryable<Users> SortedOnOneParametrs()
        {
            IQueryable<Users> command = from u in db.Users
                                        orderby u.UserName
                                        select u;
            return command;
        }

        public IQueryable<UsersWords> SortedOnTwoParametr()
        {
            IQueryable<UsersWords> command = from u in db.UsersWords
                                             orderby u.UserId, u.flag
                                             select u;
            return command;
        }

        public void Update(string UserName, string Password, string Id)
        {
            db.Database.ExecuteSqlCommand("Update Users set UserName = '" + UserName + "', password =" + Password + " where UserId = " + Id);
        }

        public void AddToUsersWords(UsersWords users)
        {
            db.UsersWords.Add(users);
        }

        public void AddToUsers(Users users)
        {
            db.Users.Add(users);
        }

        public void AddToWords(Words word)
        {
            db.Words.Add(word);
        }

        public void AddToUsersWordsFromLists(UnitOfWork unitOfWork)
        {
            IQueryable<int> listUsers = unitOfWork.Sql.SelectUsersId();
            IQueryable<int> listWords = unitOfWork.Sql.SelectWordsId();
            foreach (int i in listUsers)
            {
                foreach (int f in listWords)
                {
                    UsersWords usersWords = new UsersWords();
                    usersWords.UserId = i;
                    usersWords.WordId = f;
                    usersWords.flag = false;
                    unitOfWork.Sql.AddToUsersWords(usersWords);
                }
            }
        }

        public IQueryable<string> SelectFromUsersName()
        {
            IQueryable<string> command = from u in db.Users
                                      select u.UserName;
            return command;
        }

        public static bool Check(IQueryable<string> stringName,string str)
        {
            bool flag = false;
            foreach (string s in stringName)
            {
                if (s == str)
                    flag = true;
            }
            return flag;
        }

        public void AddToUsersAndCheck(string TextName, string TextPassword, UnitOfWork unitOfWork)
        {
            IQueryable<string> str = unitOfWork.Sql.SelectFromUsersName();
            bool flag = QuerysToSql.Check(str, TextName);
            if (!flag)
            {
                Users user = new Users();
                user.UserName = TextName;
                user.password = TextPassword;
                unitOfWork.Sql.AddToUsers(user);
                unitOfWork.Save();
            }
        }

        public IQueryable<Users> SelectUserObject()
        {
            IQueryable<Users> command = from u in db.Users
                                      select u;
            return command;
        }

        public IQueryable<Words> SelectWordsObject()
        {
            IQueryable<Words> command = from u in db.Words
                                        select u;
            return command;
        }

        public IQueryable<string> SelectWordFromWords()
        {
            IQueryable<string> command = from u in db.Words
                                        select u.Word;
            return command;
        }

        public void AddToWordsAndCheck(string NameOfWords,string Trunslate, UnitOfWork unitOfWork)
        {
            IQueryable<string> str = unitOfWork.Sql.SelectWordFromWords();
            bool flag = QuerysToSql.Check(str, NameOfWords);
            if (!flag)
            {
                Words word = new Words();
                word.Word = NameOfWords;
                word.Translate = Trunslate;
                unitOfWork.Sql.AddToWords(word);
                unitOfWork.Save();
            }
        }

        public  static void CheckAndUpdate(string UserName, string Password, string Id,UnitOfWork unitOfWork)
        {
            if(UserName != "")
            {
                if(Password != "")
                {
                    if(Id != "")
                    {
                        unitOfWork.Sql.Update(UserName, Password, Id);
                    }
                }
            }
        }
    }
}
