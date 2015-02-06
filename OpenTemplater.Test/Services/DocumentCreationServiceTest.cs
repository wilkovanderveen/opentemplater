using NUnit.Framework;
using OpenTemplater.Services;
using OpenTemplater.Services.CreationStrategies;
using Rhino.Mocks;

namespace OpenTemplater.Test.Services
{
    [TestFixture]
    public class DocumentCreationServiceTest
    {
        [Test]
        public void DoSomething()
        {
            var mockRepository = new MockRepository();
            var mockColorService = mockRepository.Stub<IColorService>();
            var mockFontService = mockRepository.Stub<IFontService>();
            var mockUnitConverter = mockRepository.Stub<IUnitConversionService>();

            var context = new DocumentContext(mockColorService, mockFontService);
            var elementCreationService = new ElementCreationService(mockUnitConverter, context);


            var documentCreationService = new DocumentCreationService(context, elementCreationService);
        }
    }
}