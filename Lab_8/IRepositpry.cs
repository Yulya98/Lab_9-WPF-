using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    interface IRepositpry
    {
        void DeleteFromUsers();

        IQueryable<int> SelectUsersId();

        IQueryable<int> SelectWordsId();

        void DeleteFromWords();

        IQueryable<Users> SortedOnOneParametrs();

        IQueryable<UsersWords> SortedOnTwoParametr();

        void Update(string UserName, string Password, string Id);

        void DeleteFromUsersWords();

        IQueryable<UsersWords> SelectFromUsersWords();

        void AddToUsersWords(UsersWords users);

        void AddToUsers(Users users);

        void AddToWords(Words word);

        void AddToUsersWordsFromLists(UnitOfWork unitOfWork);

        IQueryable<string> SelectFromUsersName();

        void AddToUsersAndCheck(string TextName, string TextPassword, UnitOfWork unitOfWork);

        IQueryable<Users> SelectUserObject();

        IQueryable<Words> SelectWordsObject();

        IQueryable<string> SelectWordFromWords();

        void AddToWordsAndCheck(string NameOfWords, string Trunslate,UnitOfWork unitOfWork);
    }
}
