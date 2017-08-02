using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_7
{
    class RefLocals
    {
        public RefLocals()
        {
            ProcessAuthenticatedUsers();
            var s = new RectangleShape();
            var rect = new Rectangle(0, 0, 10, 20);
            s.Size = rect;
        }

        private void ProcessAuthenticatedUsers()
        {
            var users = new List<UserAuthentication>();
            for (int i = 0; i < 20; i++)
            {
                var user = new UserAuthentication("userName");
                ref UserAuthentication userRef = ref user;
                userRef.UserName = "userName" + i;
                users.Add(userRef);
            }
        }
    }

    class RectangleShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        Rectangle m_Size;
        public ref Rectangle Size { get { return ref m_Size; } }

        public ref int SetAndGetX(ref int x)
        {
            return ref x;
        }

    }
    struct UserAuthentication
    {
        public string UserName { get; set; }
        public Guid Token { get; set; }

        public UserAuthentication(string userName)
        {
            UserName = userName;
            Token = Guid.NewGuid();
        }
    }

}
