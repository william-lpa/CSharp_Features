using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinqDeferredAvaliation
{
    class LinqDeferredAvaliation
    {
        private List<SessaoLeilao> leiloes;

        public LinqDeferredAvaliation()
        {
            leiloes = CarregarSessoes();
        }

        public void GenerateCriticalReport()
        {
            var filteredList = GetLeiloesOcorridosNaUltimaHora();


            filteredList = filteredList.OrderByDescending(x => x.NumeroSala);

            var thread = new Thread(() => ProcessReport(filteredList));
            thread.Start();
            UserDeleteRegisterBeforeReportFinish(4);
            thread.Join();
        }

        private void ProcessReport(IEnumerable<SessaoLeilao> filteredList)
        {
            Thread.Sleep(3000); //some I/O Processing
            filteredList.ToList().ForEach(x => Console.WriteLine(string.Concat(x.NumeroSala, "-", x.Codigo)));
            Console.WriteLine($"Quantidade:{filteredList.Count()}");
        }

        private void UserDeleteRegisterBeforeReportFinish(int index)
        {
            leiloes.RemoveAt(index);
        }

        private IEnumerable<SessaoLeilao> GetLeiloesOcorridosNaUltimaHora()
        {
            return leiloes.Where(x => x.DataHoraUltimaOferta.Hour == DateTime.Now.Hour - 1);
        }
        private List<SessaoLeilao> CarregarSessoes()
        {
            var arrange = new List<SessaoLeilao>(15);
            for (int i = 0; i < 15; i++)
            {
                arrange.Add(
                    new SessaoLeilao()
                    {
                        NumeroSala = i.ToString(),
                        Valor = Convert.ToDecimal(i),
                        DataHoraUltimaOferta = DateTime.Now.AddHours(-1)
                    });
            }
            return arrange;
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
