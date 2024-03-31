using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDUsingAPI.Models;

namespace CRUDUsingAPI.Controllers
{
    public class UserDataController : ApiController
    {
        private MyDBEntities _db = new MyDBEntities();

        public List<tblUser> GetUserData()
        {
           
            return _db.tblUsers.ToList();
        }
        
        public int PostUserData(tblUser user)
        {
            if (user.uname != "" && user.ucity != "")
            {
                try
                {
                    _db.tblUsers.Add(user);
                    _db.SaveChanges();
                    int id = _db.tblUsers.OrderByDescending(a => a.Id).FirstOrDefault().Id;
                    return id;//saved succesfully
                }
                catch
                {
                    return 0; //error
                }
            }
            else
            {
                //-1 - please enter data
                return -1;
            }
        }

        public int PutUserData(int id,tblUser user)
        {
            if (id!=0 && user.uname != "" && user.ucity != "")
            {
                try
                {
                    tblUser tu = _db.tblUsers.Find(id);
                    tu.uname = user.uname;
                    tu.ucity = user.ucity;
                    _db.SaveChanges();
                    return 1;//saved succesfully
                }
                catch
                {
                    return 0; //error
                }
            }
            else
            {
                //-1 - please enter data
                return -1;
            }
        }

      
        public int DeleteData(int id)
        {
            if (id > 0)
            {
                try
                {
                    tblUser tu = _db.tblUsers.Find(id);
                    _db.tblUsers.Remove(tu);
                    _db.SaveChanges();
                    return 1;//saved succesfully
                }
                catch
                {
                    return 0; //error
                }
            }
            else
            {
                //-1 - please enter data
                return -1;
            }
        }


    }
}
