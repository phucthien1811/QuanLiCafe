using System.Drawing;

namespace QuanLiCafe.Helpers
{
    public static class TableStatusHelper
    {
        public static Color GetColorByStatus(string status)
        {
            return status switch
            {
                "Free" => Color.LightGray,
                "Serving" => Color.LightGreen,
                "Closed" => Color.DarkGray,
                _ => Color.White
            };
        }

        public static string GetStatusText(string status)
        {
            return status switch
            {
                "Free" => "Tr?ng",
                "Serving" => "?ang ph?c v?",
                "Closed" => "?óng",
                _ => status
            };
        }
    }
}
