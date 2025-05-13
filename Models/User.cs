using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProSoft.Models
{
    public class User
    {
        public int Id { get; set; }             // Thêm nếu chưa có
        public string Username { get; set; }    // Thêm nếu chưa có
        public string Password { get; set; }
        public string Role { get; set; }        // "Admin", "ThuNgan", ...
    }
}
