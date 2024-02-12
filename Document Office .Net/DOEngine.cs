using System.Collections.Generic;

namespace Document_Office.Net
{
    internal class DOElementEngine
    {
        public DOParagraph GenerateParagraphObject(List<IDOElement> elements)
        {
            // #[Podmieniam wszystkie wartości w jednym głównym DOParagraph]
            // #[Sprawdam czy wszystkie Run'y są podmienione poprawnie]

            // #[Tworzę nowy DOParagraph]
            var mainParagraph = new DOParagraph();

            foreach (DOParagraph element in elements)
            {
                // #[Kopiuję zawartość ze starego obiektu DOParagraph do nowego]
                mainParagraph.AddTarget(element.Target);
                mainParagraph.ParagraphProperties = element.ParagraphProperties;
                mainParagraph.IDOElementGuid = element.IDOElementGuid;

                // #[Pobieram ReplaceRunGuid, abym mógł się zorientować, który DORun podmienić]
                var replaceGUID = element.Replaceable.ReplaceRunGuid;
                foreach (DORun run in element.ListRuns)
                {
                    if (run.DORunGuid == replaceGUID)
                    {
                        DORun newRun = run.CloneDORun();
                        newRun.NewRunValues.Add(mainParagraph.Target, run.Text);
                        mainParagraph.AddRun(newRun);
                    }
                    mainParagraph.AddRun(run);
                }
            }

            var testt = mainParagraph;

            return mainParagraph;
        }
    }
}
