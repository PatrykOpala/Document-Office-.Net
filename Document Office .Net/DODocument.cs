using System;
using System.Collections.Generic;

namespace Document_Office.Net
{
    internal struct DODocument
    {
        private List<IDOElement> documentElements;

        public DODocument(DocumentFormat.OpenXml.Wordprocessing.Paragraph wordParagraph) => documentElements = new List<IDOElement>();

        public void AddElement(IDOElement element) => documentElements.Add(element);

        public List<IDOElement> GetElements() => documentElements;
    }
}
