using System;
using System.Collections.Generic;

namespace Document_Office.Net
{
    public class DODocumentTemplate
    {
        public string FullPathWithFileName = "";
        public string NameDocument = "";
        public List<DOParagraph> DocsParagraphElements = new List<DOParagraph>();
        public List<DOTable> DocsTableElements = new List<DOTable>();
        public List<IDOElement> NewDocsElements = new List<IDOElement>();

        public DODocumentTemplate() { }

        public DODocumentTemplate(string documentName, string fullDocumentName)
        {
            NameDocument = documentName;
            FullPathWithFileName = fullDocumentName;
        }

        public DODocumentTemplate CopyDocumentTemplate()
        {
            DODocumentTemplate docTemplate = new DODocumentTemplate();
            docTemplate.NameDocument = NameDocument;
            docTemplate.FullPathWithFileName = FullPathWithFileName;
            //docTemplate.DocsElements = DocsElements;
            return docTemplate;
        }
    }
}
