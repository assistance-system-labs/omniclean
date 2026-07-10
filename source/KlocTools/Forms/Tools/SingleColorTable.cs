using System.Drawing;
using System.Windows.Forms;

namespace Klocman.Forms.Tools
{
    public class SingleColorTable : ProfessionalColorTable
    {
        public SingleColorTable(Color color)
        {
            SelectedColor = color;
        }

        public Color SelectedColor { get; set; }
        public override Color ToolStripGradientBegin => SelectedColor;
        public override Color ToolStripGradientMiddle => SelectedColor;
        public override Color ToolStripGradientEnd => SelectedColor;
        public override Color MenuStripGradientBegin => SelectedColor;
        public override Color MenuStripGradientEnd => SelectedColor;
        public override Color StatusStripGradientBegin => SelectedColor;
        public override Color StatusStripGradientEnd => SelectedColor;
    }
}
