using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CoffeeShopManagement.Components;

public class RjButton : Button
{
    private int _borderSize = 0;
    private int _borderRadius = 8;
    private Color _borderColor = UITheme.Border;
    private Color _originalBgColor;
    private Color _hoverBgColor;
    private bool _isHovered = false;

    [Category("Custom Properties")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BorderSize
    {
        get => _borderSize;
        set { _borderSize = value; Invalidate(); }
    }

    [Category("Custom Properties")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = value; Invalidate(); }
    }

    [Category("Custom Properties")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color BorderColor
    {
        get => _borderColor;
        set { _borderColor = value; Invalidate(); }
    }

    [Category("Custom Properties")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color HoverBackColor
    {
        get => _hoverBgColor;
        set => _hoverBgColor = value;
    }

    public RjButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Size = new Size(130, 38);
        BackColor = UITheme.Primary;
        ForeColor = Color.White;
        Font = UITheme.FontBold;
        Cursor = Cursors.Hand;
        UseMnemonic = false;
        _originalBgColor = BackColor;
        _hoverBgColor = UITheme.PrimaryHover;

        MouseEnter += (_, _) => { _isHovered = true; Invalidate(); };
        MouseLeave += (_, _) => { _isHovered = false; Invalidate(); };
    }

    protected override void OnBackColorChanged(EventArgs e)
    {
        base.OnBackColorChanged(e);
        if (!_isHovered) _originalBgColor = BackColor;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        var g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var rectSurface = ClientRectangle;
        var rectBorder = Rectangle.Inflate(rectSurface, -_borderSize, -_borderSize);
        int smoothSize = 2;
        if (_borderSize > 0) smoothSize = _borderSize;

        Color currentBg = _isHovered && Enabled ? _hoverBgColor : BackColor;

        if (_borderRadius > 2)
        {
            using var pathSurface = UITheme.GetRoundedPath(rectSurface, _borderRadius);
            using var pathBorder = UITheme.GetRoundedPath(rectBorder, _borderRadius - _borderSize);
            using var penSurface = new Pen(Parent?.BackColor ?? UITheme.CanvasBg, smoothSize);
            using var penBorder = new Pen(_borderColor, _borderSize);
            using var brushBg = new SolidBrush(currentBg);

            Region = new Region(pathSurface);
            g.FillPath(brushBg, pathSurface);
            g.DrawPath(penSurface, pathSurface);

            if (_borderSize >= 1)
            {
                g.DrawPath(penBorder, pathBorder);
            }
        }
        else
        {
            using var brushBg = new SolidBrush(currentBg);
            g.FillRectangle(brushBg, rectSurface);
            if (_borderSize >= 1)
            {
                using var penBorder = new Pen(_borderColor, _borderSize);
                g.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
            }
        }

        // Draw Text
        var textFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis;
        Color textCol = Enabled ? ForeColor : Color.Gray;
        TextRenderer.DrawText(g, Text, Font, rectSurface, textCol, textFlags);
    }
}

