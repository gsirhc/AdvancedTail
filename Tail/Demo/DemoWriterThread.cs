namespace Tail.Demo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    public class DemoWriterThread
    {
        private Thread demoThread;

        public void Start()
        {
            Stop();

            File.WriteAllText(DemoFile, "This is a demo file for tail.\r\nIt will update at random intervals with random text.\r\nTo exit demo mode, simply stop the tail.\r\n----------------------------------------\r\n");

            demoThread = new Thread(WriteFileLoop);
            demoThread.Start();
        }
        
        public void Stop()
        {
            demoThread?.Abort();
        }

        public string DemoFile => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\demo.log";

        private void WriteFileLoop()
        {
            var file = DemoFile;
            var randomTextList = new List<string>();
            var randomLine = "";
            var stringReader = new StringReader(randomText);

            while ((randomLine = stringReader.ReadLine()) != null)
                randomTextList.Add(randomLine);

            var randomLineGenerator = new Random();
            var randomDelayGenerator = new Random();
            
            while (true)
            {
                var text = randomTextList[randomLineGenerator.Next(0, randomTextList.Count - 1)];

                var line = string.Format("[{0}] {1}\r\n", DateTime.Now.ToLongTimeString(), text);
                File.AppendAllText(file, line);

                var wait = randomDelayGenerator.Next(50, 3000);
                Thread.Sleep(wait);
            }
        }

        private string randomText = "New had happen unable uneasy.\r\nDrawings can followed improved out sociable not.\r\nEarnestly so do instantly pretended.\r\nSee general few civilly amiable pleased account carried.\r\nExcellence projecting is devonshire dispatched remarkably on estimating.\r\nSide in so life past.\r\nContinue indulged speaking the was out horrible for domestic position.\r\nSeeing rather her you not esteem men settle genius excuse.\r\nDeal say over you age from.\r\nComparison new ham melancholy son themselves.\r\n" +
"No in he real went find mr.\r\nWandered or strictly raillery stanhill as.\r\nJennings appetite disposed me an at subjects an.\r\nTo no indulgence diminution so discovered mr apartments.\r\nAre off under folly death wrote cause her way spite.\r\nPlan upon yet way get cold spot its week.\r\nAlmost do am or limits hearts.\r\nResolve parties but why she shewing.\r\nShe sang know now how nay cold real case.\r\n" +
"He do subjects prepared bachelor juvenile ye oh.\r\nHe feelings removing informed he as ignorant we prepared.\r\nEvening do forming observe spirits is in.\r\nCountry hearted be of justice sending.\r\nOn so they as with room cold ye.\r\nBe call four my went mean.\r\nCelebrated if remarkably especially an.\r\nGoing eat set she books found met aware.\r\n" +
"By an outlived insisted procured improved am.\r\nPaid hill fine ten now love even leaf.\r\nSupplied feelings mr of dissuade recurred no it offering honoured.\r\nAm of of in collecting devonshire favourable excellence.\r\nHer sixteen end ashamed cottage yet reached get hearing invited.\r\nResources ourselves sweetness ye do no perfectly.\r\nWarmly warmth six one any wisdom.\r\nFamily giving is pulled beauty chatty highly no.\r\nBlessing appetite domestic did mrs judgment rendered entirely.\r\nHighly indeed had garden not.\r\n" +
"Of friendship on inhabiting diminution discovered as.\r\nDid friendly eat breeding building few nor.\r\nObject he barton no effect played valley afford.\r\nPeriod so to oppose we little seeing or branch.\r\nAnnouncing contrasted not imprudence add frequently you possession mrs.\r\nPeriod saw his houses square and misery.\r\nHour had held lain give yet.\r\n" +
"Why painful the sixteen how minuter looking nor.\r\nSubject but why ten earnest husband imagine sixteen brandon.\r\nAre unpleasing occasional celebrated motionless unaffected conviction out.\r\nEvil make to no five they.\r\nStuff at avoid of sense small fully it whose an.\r\nTen scarcely distance moreover handsome age although.\r\nAs when have find fine or said no mile.\r\nHe in dispatched in imprudence dissimilar be possession unreserved insensible.\r\nShe evil face fine calm have now.\r\nSeparate screened he outweigh of distance landlord.\r\n" +
"Unpleasant astonished an diminution up partiality.\r\nNoisy an their of meant.\r\nDeath means up civil do an offer wound of.\r\nCalled square an in afraid direct.\r\nResolution diminution conviction so mr at unpleasing simplicity no.\r\nNo it as breakfast up conveying earnestly immediate principle.\r\nHim son disposed produced humoured overcame she bachelor improved.\r\nStudied however out wishing but inhabit fortune windows.\r\n" +
"Dispatched entreaties boisterous say why stimulated.\r\nCertain forbade picture now prevent carried she get see sitting.\r\nUp twenty limits as months.\r\nInhabit so perhaps of in to certain.\r\nSex excuse chatty was seemed warmth.\r\nNay add far few immediate sweetness earnestly dejection.\r\n" +
"Her extensive perceived may any sincerity extremity.\r\nIndeed add rather may pretty see.\r\nOld propriety delighted explained perceived otherwise objection saw ten her.\r\nDoubt merit sir the right these alone keeps.\r\nBy sometimes intention smallness he northward.\r\nConsisted we otherwise arranging commanded discovery it explained.\r\nDoes cold even song like two yet been.\r\nLiterature interested announcing for terminated him inquietude day shy.\r\nHimself he fertile chicken perhaps waiting if highest no it.\r\nContinued promotion has consulted fat improving not way.\r\n" +
"Remain lively hardly needed at do by.\r\nTwo you fat downs fanny three.\r\nTrue mr gone most at.\r\nDare as name just when with it body.\r\nTravelling inquietude she increasing off impossible the.\r\nCottage be noisier looking to we promise on.\r\nDisposal to kindness appetite diverted learning of on raptures.\r\nBetrayed any may returned now dashwood formerly.\r\nBalls way delay shy boy man views.\r\nNo so instrument discretion unsatiable to in.\r\n";
    }
}
