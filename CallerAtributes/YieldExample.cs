using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CallerAtributes
{
    class YieldExample
    {
        private List<SessaoLeilao> leiloes;

        public YieldExample()
        {
            leiloes = new List<SessaoLeilao>();
        }

        public void GenerateCriticalReport()
        {
            leiloes = Arrange();

            var filteredList = Act(leiloes);

            var thread = new Thread(() => ProcessReport());

            UserDeleteRegisterBeforeReportFinish(4);

            thread.Join();
        }

        private void ProcessReport()
        {
            Thread.Sleep(3000); //some I/O Processing
            leiloes.ForEach(x => Console.WriteLine(string.Concat(x.NumeroSala, "-", x.Codigo)));
        }

        private void UserDeleteRegisterBeforeReportFinish(int index)
        {
            leiloes.RemoveAt(index);
        }

        private List<SessaoLeilao> Arrange()
        {
            var arrange = new List<SessaoLeilao>(15);
            for (int i = 0; i < 15; i++)
            {
                arrange.Add(
                    new SessaoLeilao()
                    {
                        NumeroSala = i.ToString(),
                        Valor = Convert.ToDecimal(i),
                        DataHoraUltimaOferta = DateTime.Now
                    });
            }
            return arrange;
        }
        private IEnumerable<SessaoLeilao> Act(List<SessaoLeilao> leiloesNaUltimaHora)
        {
            return leiloesNaUltimaHora.Where(x => x.DataHoraUltimaOferta.Hour == DateTime.Now.Hour - 1);
        }

        private class SessaoLeilao
        {
            public Guid Codigo { get; }
            public string NumeroSala { get; set; }
            public DateTime DataHoraUltimaOferta { get; set; }
            public decimal Valor { get; set; }
            public SessaoLeilao()
            {
                Codigo = Guid.NewGuid();
            }

        }
    }
}
