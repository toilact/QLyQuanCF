using System.Drawing;
using System.Drawing.Drawing2D;

namespace CoffeeShopManagement.Components;

public static class UITheme
{
    // Bảng màu Espresso Warm Craft
    public static readonly Color Primary = ColorTranslator.FromHtml("#3D2817");
    public static readonly Color PrimaryHover = ColorTranslator.FromHtml("#533821");
    public static readonly Color Accent = ColorTranslator.FromHtml("#C68B59");
    public static readonly Color AccentHover = ColorTranslator.FromHtml("#D89B67");
    public static readonly Color CanvasBg = ColorTranslator.FromHtml("#F7F5F2");
    public static readonly Color Surface = Color.White;
    public static readonly Color Border = ColorTranslator.FromHtml("#E8E2D9");
    public static readonly Color TextDark = ColorTranslator.FromHtml("#2B2520");
    public static readonly Color TextMuted = ColorTranslator.FromHtml("#7D756D");
    public static readonly Color Danger = ColorTranslator.FromHtml("#C85A32");
    public static readonly Color DangerHover = ColorTranslator.FromHtml("#B24B27");

    // Trạng thái bàn
    public static readonly Color TableEmpty = ColorTranslator.FromHtml("#4E7C59");
    public static readonly Color TableEmptyBg = ColorTranslator.FromHtml("#EDF5EF");
    public static readonly Color TableOccupied = ColorTranslator.FromHtml("#C85A32");
    public static readonly Color TableOccupiedBg = ColorTranslator.FromHtml("#FBF1ED");

    // Fonts chuẩn Segoe UI
    public static readonly Font FontDisplay = new("Segoe UI", 16f, FontStyle.Bold);
    public static readonly Font FontHeader = new("Segoe UI", 12f, FontStyle.Bold);
    public static readonly Font FontRegular = new("Segoe UI", 9.5f, FontStyle.Regular);
    public static readonly Font FontBold = new("Segoe UI", 9.5f, FontStyle.Bold);
    public static readonly Font FontSmall = new("Segoe UI", 8.5f, FontStyle.Regular);

    // Vẽ hình chữ nhật bo tròn góc
    public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
    {
        var path = new GraphicsPath();
        if (radius <= 0)
        {
            path.AddRectangle(rect);
            return path;
        }

        int d = radius * 2;
        path.StartFigure();
        path.AddArc(rect.X, rect.Y, d, d, 180, 90);
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    // Tùy biến DataGridView chuẩn hiện đại, chống AI Slop
    public static void ApplyModernGridStyle(DataGridView grid)
    {
        grid.BackgroundColor = Surface;
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.GridColor = Border;
        grid.EnableHeadersVisualStyles = false;
        grid.RowHeadersVisible = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.AllowUserToResizeRows = false;

        // Header
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECE7E1");
        grid.ColumnHeadersDefaultCellStyle.ForeColor = TextDark;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
        grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        grid.ColumnHeadersHeight = 40;

        // Rows
        grid.RowTemplate.Height = 38;
        grid.DefaultCellStyle.BackColor = Surface;
        grid.DefaultCellStyle.ForeColor = TextDark;
        grid.DefaultCellStyle.Font = FontRegular;
        grid.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
        grid.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#EBE2D8");
        grid.DefaultCellStyle.SelectionForeColor = TextDark;

        // Alternating Rows
        grid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FAF8F5");
    }
}

