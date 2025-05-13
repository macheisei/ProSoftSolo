


namespace ProSoft.Models
{
    public class CurrentUser
    {
        public static int UserId { get; set; }
        public static int Id { get; set; }  // Thêm thuộc tính Id
        public static string? Username { get; set; } = string.Empty;
        public static string? Role { get; set; } = string.Empty; // Admin, Thu ngân, v.v.

        // Optional: các thông tin khác nếu cần
        public static string? FullName { get; set; } = string.Empty;
        public static DateTime LoginTime { get; set; }

        // Gọi khi đăng nhập thành công
        public static void SetUser(int userId, string username, string role, string fullName = "")
        {
            UserId = userId;
            Username = username;
            Role = role;
            FullName = fullName;
            LoginTime = DateTime.Now;
        }

        // Gọi khi đăng xuất
        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
            FullName = null;
            LoginTime = DateTime.MinValue;
        }
    }

}
