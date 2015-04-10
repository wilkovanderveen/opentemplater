using NUnit.Framework;
using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Test
{
    [TestFixture]
    public class RenderTest
    {
        [Test]
        public void DoSomething()
        {
            var document = new DocumentElement();
            document.Author = "MyFirstAuthor";
            PageElement myPageElement = new PageElement {Width = 2000, Height = 1500, Key = "MyFirstPage"};
            myPageElement.Elements.Add(new RectangleElement()
            {
                Width = 150,
                Height = 150,
                XPosition = 20,
                YPosition = 20,
                BorderColor = new CMYKColor(0.2f,0.3f,0.5f,1),
                Color = new CMYKColor(0, 0, 0, 1),
                BorderWidth = 2
            });

            myPageElement.Elements.Add(new RectangleElement()
            {
                Width = 150,
                Height = 150,
                XPosition = 20,
                YPosition = 190,
                BorderColor = new CMYKColor(0.2f, 0.3f, 0.5f, 1),
                Color = new CMYKColor(1, 0, 0, 0),
                BorderWidth = 2
            });

            myPageElement.Elements.Add(new RectangleElement()
            {
                Width = 150,
                Height = 150,
                XPosition = 190,
                YPosition = 190,
                BorderColor = new CMYKColor(0.2f, 0.3f, 0.5f, 1),
                Color = new CMYKColor(0, 1, 0, 0),
                BorderWidth = 2
            });

            myPageElement.Elements.Add(new RectangleElement()
            {
                Width = 150,
                Height = 150,
                XPosition = 190,
                YPosition = 20,
                BorderColor = new CMYKColor(0.2f, 0.3f, 0.5f, 1),
                Color = new CMYKColor(0, 0, 1, 0),
                BorderWidth = 20
            });

            PageElement mySecondPageElement = new PageElement() {Width = 1500, Height = 1000, Key = "MySecondPage"};
            mySecondPageElement.Elements.Add(new LineElement()
            {
                Color = new CMYKColor(0.5f, 0.5f, 0f, 0f),
                Height = 30,
                Width = 30,
                XPosition = 20,
                YPosition = 100,
                LineWidth = 2
            });

            document.Pages.Add(myPageElement);
            document.Pages.Add(mySecondPageElement);


            var pdfRenderService = new PdfRenderService();

            pdfRenderService.Render(document);
        }
    }
}