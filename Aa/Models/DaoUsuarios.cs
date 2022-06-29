using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aa.Models
{
    public class DaoUsuarios
    {
        public usuarios Autentica(string usuario, string password)
        {
            usuarios user = null;

            using (var db=new ModelAa())
            {
                var query = from u in db.usuarios
                            where u.usuario == usuario && u.password == password
                            select u;

                if(query.Count() > 0)
                {
                    user = query.First();
                }
            }
            
            return user;
        }
    }
}