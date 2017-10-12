using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace Mifare_Tool.Templates
{
    [TemplatePart(Name = ROOT_PART, Type = typeof(Border))]
    [TemplatePart(Name = HOST_PART, Type = typeof(Grid))]
    public sealed class LinkTile : Button
    {
        private const string ROOT_PART = "Root";
        private const string HOST_PART = "ContentHost";

        public LinkTile()
        {
            this.DefaultStyleKey = typeof(LinkTile);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var root = (Border)GetTemplateChild(ROOT_PART);
            var contentHost = (Grid)GetTemplateChild(HOST_PART);

            root.SizeChanged += (s, e) =>
            {
                contentHost.Width = contentHost.Height = root.Height = root.ActualWidth;
            };
        }

        public static DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(LinkTile), PropertyMetadata.Create(string.Empty));

        public static DependencyProperty GlyphProperty = DependencyProperty.Register("Glyph", typeof(string), typeof(LinkTile), PropertyMetadata.Create(string.Empty));

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }
    }
}
