using System.Collections.Generic;

namespace Document_Office.Net
{
    public class DODocumentTemplate
    {
        public string FullPathWithFileName = "";
        public string NameDocument = "";
        public List<IDOElement> NewDocsElements = new List<IDOElement>();

        public DODocumentTemplate CopyDocumentTemplate()
        {
            DODocumentTemplate docTemplate = new DODocumentTemplate();
            docTemplate.NameDocument = NameDocument;
            docTemplate.FullPathWithFileName = FullPathWithFileName;
            docTemplate.NewDocsElements = NewDocsElements;
            return docTemplate;
        }
    }
}
