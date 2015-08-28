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

        private const string randomText = "Loquar ut nescio in negari si noluit.\r\nHaec nam ipso suo sine hoc est.\r\nBonus de aequo is utile me datur docti du reges.\r\nTales vix menti verum pro age ullis ullos mei novum.\r\nRemovendo assentiar desumptae mea hoc.\r\nEquidem putarim sum mox quamvis usitata ibi.\r\nViris ubi age ceram fides recta tango.\r\nSolius at nequit du ii simili patere ingens de.\r\nAt se impetus me partium suppono si externo quinque scripta.\r\nMei dissimilem occasionem constanter jam corrigatur tur occurreret communibus.\r\n" +
"Qua vel hae student suppono tacitus corpore hominem.\r\nSi ei at ginabor ultimam invenit scripti minimum ob.\r\nDatur in atque de illam.\r\nMe si aliisque putantur revocare ii scriptum defectus.\r\nPosita ingens etenim dubias hae animae iis cum.\r\nMecum porro video ideas co re ipsos ac ut somno.\r\nCo ea quantitas id geometras intelligo praesenti profundum.\r\nLicet ideas im satis ex athei capax caput.\r\n" +
"Tunc ullo ut anno poni voce de haud.\r\nMallent prudens suo deumque qui sim invicem.\r\nSuum mo item inde de modi unde.\r\nSuo deo omni quia opus.\r\nCo an habent inesse semper.\r\nEt innatas dominum cogitem sperare sopitum in.\r\nSubstantia dei credidisse vim iis excogitent exhibentur sub.\r\n" +
"Quia item mens illi gi apti et rari.\r\nNon tam cap delaberer persuadet pertinere.\r\nMei datur vitam istis nolim imo aliam hac cum.\r\nSuperare deficere periculi ex ei.\r\nCommoveo experior co obturabo quanquam ii.\r\nFit magnis finiti simile ita negans semper aspexi.\r\nStabilire sequentia dei rea quaslibet dem dum intelligo continere chimaeram.\r\nIi nota vi ex fuit novo illa.\r\nEx lucis in situm ii tanta novam mecum.\r\n" +
"Neque fieri horum errem ab me eo credo.\r\nHanc sic meo quae ipsa.\r\nFal membrorum existenti conservet per sapientia dubitavit.\r\nApta gi de et enim gnum data.\r\nId quadratam ut archimede attingere re ne.\r\nHumanam infusum has iis veteris mei occasio replere istarum.\r\nEmanant poterit capaces at in numerum de exigere ob chartam.\r\n" +
"Du ii re meis opus iste co.\r\nVeritate ad loquendo ignorans excitari gi.\r\nInterire universo facilius ex at de conversa si.\r\nIs et facillimam varietates ne crediderim et supponatur.\r\nDei cum ideam plura sonum versa foret est sum pauca.\r\nMale haud imo ima una sola rogo sim quum.\r\nMultae de ex se summum ausint.\r\nCalebat agendam non cum cui ipsamet.\r\nQui anno omne hae vis sae meam unam vidi.\r\n" +
"Conatum dicamne agendam corpore suppono non etc sex.\r\nSequutus diversae formalis ne at.\r\nPutem vox miror voces athei longa ullam his.\r\nIncipit similia innatis hic res jam scripti.\r\nFal minuta fingam falsas cui melius.\r\nEns meo bere more unum cera fuse.\r\nCrediderim sic argumentis supponatur praesertim parentibus dei.\r\nEo suas id de an vero bile.\r\n" +
"Minus patet ac spero at ne serie vi aliud prona.\r\nJam creando dicendo calebat ima quosdam deo attendo sui.\r\nPictores hoc venturum dat sim affectus lus rerumque.\r\nPraecipuis conjunctam expectabam ad effecerunt quaerendum si.\r\nPraeterea praeterea industria referenda ad ha gi ad abducerem.\r\nConjectus mei continere qua lor inhaereat dem.\r\nUsu vix uno retinet saeculi quaenam poterit.\r\nDe meis ecce et rari alio an tale ideo ac.\r\nHa generali ab ea revocare infinite.\r\nPoterit si tacitus ad alteram to praeter at ipsamet erroris.\r\n" +
"Rum uno minima reipsa ipsius mea solius.\r\nIncrementi continuata pla affirmabam res.\r\nMeo sperare nam dei animali defectu.\r\nMoralis se in aggredi sciamus indutum ingenio re ostendi.\r\nLaborio mox ubi aliarum nostras.\r\nVideo hic denuo uno tango istam hoc iis.\r\nAd prout ac ausit vi fuere ha.\r\nSciatur quaenam ei si ii vi quidnam spondeo optimae.\r\n" +
"Virtutibus occurreret ab perfectius ob majestatis ex ei.\r\nSex ego uno locum lor clara istas.\r\nHaustam organis veritas pro sed.\r\nExtensarum imperfecta vox per propugnent cap utilitatis ero.\r\nTot callidus venturum pictores subducam appareat hae ubi.\r\nCunctaque admonitus tentassem to ii soliditas ha consistat concludam ad.\r\nEst ritas sae aut istam paulo reges terea serie fas.\r\n";
    }
}
