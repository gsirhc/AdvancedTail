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

            demoThread = new Thread(WriteFileLoop);
            demoThread.Start();
        }
        
        private void Stop()
        {
            demoThread?.Abort();
        }

        private void WriteFileLoop()
        {
            var file = Assembly.GetExecutingAssembly().Location + "demo.log";
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

                var line = string.Format("[{0}] {1}", DateTime.Now.ToShortTimeString(), text);
                File.AppendAllText(file, line);

                Thread.Sleep(randomDelayGenerator.Next(1000, 30000));
            }
        }

        private string randomText = "New had happen unable uneasy. Drawings can followed improved out sociable not. Earnestly so do instantly pretended. See general few civilly amiable pleased account carried. Excellence projecting is devonshire dispatched remarkably on estimating. Side in so life past. Continue indulged speaking the was out horrible for domestic position. Seeing rather her you not esteem men settle genius excuse. Deal say over you age from. Comparison new ham melancholy son themselves. \r\n" +
"No in he real went find mr. Wandered or strictly raillery stanhill as. Jennings appetite disposed me an at subjects an. To no indulgence diminution so discovered mr apartments. Are off under folly death wrote cause her way spite. Plan upon yet way get cold spot its week. Almost do am or limits hearts. Resolve parties but why she shewing. She sang know now how nay cold real case. \r\n" +
"He do subjects prepared bachelor juvenile ye oh. He feelings removing informed he as ignorant we prepared. Evening do forming observe spirits is in. Country hearted be of justice sending. On so they as with room cold ye. Be call four my went mean. Celebrated if remarkably especially an. Going eat set she books found met aware. \r\n" +
"By an outlived insisted procured improved am. Paid hill fine ten now love even leaf. Supplied feelings mr of dissuade recurred no it offering honoured. Am of of in collecting devonshire favourable excellence. Her sixteen end ashamed cottage yet reached get hearing invited. Resources ourselves sweetness ye do no perfectly. Warmly warmth six one any wisdom. Family giving is pulled beauty chatty highly no. Blessing appetite domestic did mrs judgment rendered entirely. Highly indeed had garden not. \r\n" +
"Of friendship on inhabiting diminution discovered as. Did friendly eat breeding building few nor. Object he barton no effect played valley afford. Period so to oppose we little seeing or branch. Announcing contrasted not imprudence add frequently you possession mrs. Period saw his houses square and misery. Hour had held lain give yet. \r\n" +
"Why painful the sixteen how minuter looking nor. Subject but why ten earnest husband imagine sixteen brandon. Are unpleasing occasional celebrated motionless unaffected conviction out. Evil make to no five they. Stuff at avoid of sense small fully it whose an. Ten scarcely distance moreover handsome age although. As when have find fine or said no mile. He in dispatched in imprudence dissimilar be possession unreserved insensible. She evil face fine calm have now. Separate screened he outweigh of distance landlord. \r\n" +
"Unpleasant astonished an diminution up partiality. Noisy an their of meant. Death means up civil do an offer wound of. Called square an in afraid direct. Resolution diminution conviction so mr at unpleasing simplicity no. No it as breakfast up conveying earnestly immediate principle. Him son disposed produced humoured overcame she bachelor improved. Studied however out wishing but inhabit fortune windows. \r\n" +
"Dispatched entreaties boisterous say why stimulated. Certain forbade picture now prevent carried she get see sitting. Up twenty limits as months. Inhabit so perhaps of in to certain. Sex excuse chatty was seemed warmth. Nay add far few immediate sweetness earnestly dejection. \r\n" +
"Her extensive perceived may any sincerity extremity. Indeed add rather may pretty see. Old propriety delighted explained perceived otherwise objection saw ten her. Doubt merit sir the right these alone keeps. By sometimes intention smallness he northward. Consisted we otherwise arranging commanded discovery it explained. Does cold even song like two yet been. Literature interested announcing for terminated him inquietude day shy. Himself he fertile chicken perhaps waiting if highest no it. Continued promotion has consulted fat improving not way. \r\n" +
"Remain lively hardly needed at do by. Two you fat downs fanny three. True mr gone most at. Dare as name just when with it body. Travelling inquietude she increasing off impossible the. Cottage be noisier looking to we promise on. Disposal to kindness appetite diverted learning of on raptures. Betrayed any may returned now dashwood formerly. Balls way delay shy boy man views. No so instrument discretion unsatiable to in. \r\n";
    }
}
