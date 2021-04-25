using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Fake;
using UserManagement.API.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")] //ekledik ve [controller] ile controller ismi dinamik geldi
    public class UserController: ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(100); ///userları aldık fakedata classından

        // /api/user
        //public string Get()
        //{
        //    return "Get Users";
        //}

        // /api/user
        public List<User> test() //isim Get olmak zorunda DEĞİL
        {
            return _users;
        } 

        [HttpGet("{a}")] //yukarıdaki ile karışmaması için bunun {a} parametresi beklediğini belirttim
        // /api/user/7 bekler ancak ?id=7 olmaz
        public User test1(int a) // {a} ile parametredeki int a aynı isimli ve type olmalı:  {id} ise id beklemeli {a} ise a
        {
            var user = _users.FirstOrDefault(x => x.Id == a);
            return user;
        }
        
        [HttpPost] //defalt değil eklenmeli ayrıca metod ismi Post olmak zorunda değil
        public User Post([FromBody]User user) //requestin body kısmında User nesnesi bekliyorum demek = [[FromBody]User]
        {
            _users.Add(user);
            return user;
        }

        [HttpPut] //defalt değil eklenmeli ayrıca metod ismi Put olmak zorunda değil
        public User Put([FromBody]User user) //requestin body kısmında User nesnesi bekliyorum demek = [[FromBody]User]
        {
            //ef kullanmadığım için şuan önce userı bulup sonra teker teker propları değiştireceğiz
            var editedUser = _users.FirstOrDefault(x => x.Id == user.Id);
            editedUser.FirstName = user.FirstName;
            editedUser.LastName = user.LastName;
            editedUser.Address = user.Address;

            return user;
        }

        [HttpDelete("{id}")] // id bekliyorum aynı isimli int id ile
        public void Delete(int id) //ismi delete olmak zorunda değil
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);
        }
    }
}
