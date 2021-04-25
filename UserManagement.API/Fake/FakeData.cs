using Bogus;// fake data i.in bogus indirdik nuget package den
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Models;

namespace UserManagement.API.Fake
{
    public static class FakeData //static yaptık
    {
        private static List<User> _users;
        public static List<User> GetUsers(int number)
        {
            if (_users==null) // herseferinda farklı fakedata gelmemesi için boş kontrolü yap
            {
                _users = new Faker<User>()
               .RuleFor(u => u.Id, f => f.IndexFaker + 1) //user'ın Id si için fakerin indexfaker'ını atadım. 1 den başlasın
               .RuleFor(u => u.FirstName, f => f.Name.FirstName())
               .RuleFor(u => u.LastName, f => f.Name.LastName())
               .RuleFor(u => u.Address, f => f.Address.FullAddress())
               .Generate(number); //kaç tane data üretileceği, dinamik biz girelim
            }
           
            return _users;
        }
    }
}
