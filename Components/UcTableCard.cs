using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CoffeeShopManagement.Models;

namespace CoffeeShopManagement.Components;

public class UcTableCard : UserControl
{
    private Table? _table;
    private bool _isSelected = false;
    private bool _isHovered = false;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Table? TableData
    {
        get => _table;
        set
        {
            _table = value;
            Invalidate();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            Invalidate();
        }
    }

    public UcTableCard()
    {
        DoubleBuffered = true;
        Size = new Size(175, 145);
        Margin = new Padding(10);
        Cursor = Cursors.Hand;
        BackColor = Color.Transparent;

        MouseEnter += (_, _) => { _isHovered = true; Invalidate(); };
        MouseLeave += (_, _) => { _isHovered = false; Invalidate(); };
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        if (_table == null) return;

        bool isOccupied = _table.Status == 1;
        Color statusColor = isOccupied ? UITheme.TableOccupied : UITheme.TableEmpty;
        Color cardBg = isOccupied ? UITheme.TableOccupiedBg : UITheme.Surface;
        Color borderColor = _isSelected ? UITheme.Accent : (_isHovered ? UITheme.Accent : UITheme.Border);
        int borderWidth = _isSelected ? 2 : 1;

        var rectCard = new Rectangle(2, 2, Width - 5, Height - 5);

        using var path = UITheme.GetRoundedPath(rectCard, 10);
        using var brushBg = new SolidBrush(cardBg);
        using var penBorder = new Pen(borderColor, borderWidth);

        g.FillPath(brushBg, path);
        g.DrawPath(penBorder, path);

        // 1. Tên Bàn
        using var fontName = new Font("Segoe UI", 12f, FontStyle.Bold);
        using var brushDark = new SolidBrush(UITheme.TextDark);
        g.DrawString(_table.Name, fontName, brushDark, new RectangleF(12, 12, Width - 24, 25));

        // 2. Khu vực
        using var fontArea = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        using var brushMuted = new SolidBrush(UITheme.TextMuted);
        var areaRect = new RectangleF(12, 39, Width - 24, 20);
        using var areaFormat = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.NoWrap,
            Trimming = StringTrimming.EllipsisCharacter
        };
        g.DrawString(_table.Area, fontArea, brushMuted, areaRect, areaFormat);

        // 3. Badge Trạng thái
        string statusText = isOccupied ? "Có khách" : "Trống";
        var badgeRect = new Rectangle(12, 68, 96, 22);
        using var badgePath = UITheme.GetRoundedPath(badgeRect, 6);
        using var badgeBg = new SolidBrush(isOccupied ? ColorTranslator.FromHtml("#F5D7CD") : UITheme.TableEmptyBg);
        using var badgePen = new Pen(statusColor, 1);
        using var fontBadge = new Font("Segoe UI", 8f, FontStyle.Bold);
        using var badgeBrush = new SolidBrush(statusColor);

        g.FillPath(badgeBg, badgePath);
        g.DrawPath(badgePen, badgePath);

        var sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        g.DrawString(statusText, fontBadge, badgeBrush, badgeRect, sfCenter);

        // 4. Số tiền tạm tính hoặc trạng thái chờ
        var bill = _table.Bills.FirstOrDefault(b => b.Status == 0);
        if (isOccupied && bill != null)
        {
            decimal sum = bill.Details.Sum(d => d.Quantity * d.UnitPrice);
            using var fontPrice = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            using var brushPrice = new SolidBrush(UITheme.TableOccupied);
            g.DrawString($"{sum:N0} đ", fontPrice, brushPrice, new RectangleF(12, 103, Width - 24, 22));
        }
        else
        {
            using var fontEmpty = new Font("Segoe UI", 7.5f, FontStyle.Italic);
            using var brushEmpty = new SolidBrush(ColorTranslator.FromHtml("#A39D95"));
            using var emptyFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoWrap,
                Trimming = StringTrimming.None
            };
            g.DrawString("Sẵn sàng phục vụ", fontEmpty, brushEmpty, new RectangleF(12, 103, Width - 24, 22), emptyFormat);
        }
    }
}
