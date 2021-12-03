using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsWpfApp1
{
    class DbTermMeth : Papa
    {
        internal static void RefreshTerminal()
        {
            #region
            Say("# RefreshTerminal");
            int countOk = 0;
            int countLines = -1;
            try
            {
                DeleteAllTerminal();
            }
            catch (Exception ex) { SayRed(ex.Message); }
            var data = FileToArr(Path.Combine(dataInPath, "terminals.csv"));
            using (var context = new MyDataContext())
            {


                foreach (var dataLine in data)
                {
                    countLines += 1;
                    if (countLines > 0)
                    {
                        if (dataLine[0] == "") continue;

                        try
                        {
                            var terminal = new T_Terminal
                            {
                                DepartmentTerm = dataLine[0],
                                TermialTerm = dataLine[1],
                                ModelTerm = dataLine[2],
                                SerialNumberTerm = dataLine[3],
                                DateManufactureTerm = dataLine[4],
                                SoftTerm = dataLine[5],
                                ProducerTerm = dataLine[6],
                                RneRroTerm = dataLine[7],
                                SealingTerm = dataLine[8],
                                FiscalNumberTerm = dataLine[9],
                                OroSerialTerm = dataLine[10],
                                OroNumberTerm = dataLine[11],
                                TicketSerialTerm = dataLine[12],
                                Ticket1sheetTerm = dataLine[13],
                                TicketNumberTerm = dataLine[14],
                                SendingTerm = dataLine[15],
                                BooksArhivTerm = dataLine[16],
                                TicketsArhivTerm = dataLine[17],
                                ToRroTerm = dataLine[18],
                                OwnerRroTerm = dataLine[19],
                                RegisterTerm = dataLine[20],
                                FinishTerm = dataLine[21],

                            };

                            context.terminals.Add(terminal);
                            //Say($"+ term new {terminal.TermialTerm}");
                            countOk += 1;
                        }
                        catch (Exception ex) { SayRed($"{dataLine[0]} {ex.Message}"); }
                    }
                }
                context.SaveChanges();
            }
            SayGreen($"\nadd terminals {countOk} from {countLines}\n {countLines - countOk} erroros\n");
            #endregion
        }

        internal static void DeleteAllTerminal()
        {
            try
            {
                #region
                using (var context = new MyDataContext())
                {
                    var terminal = context.terminals;

                    context.terminals.RemoveRange(terminal);
                    context.SaveChanges();
                }
                #endregion
                Say("DeleteAllTerminal");
            }
            catch (Exception ex) { SayRed($"DeleteAllTerminal {ex.Message}"); }
        }

        internal static void DeleteOneTerminal(string term)
        {
            #region
            try
            {
                using (var context = new MyDataContext())
                {
                    var singleRec = context.terminals.FirstOrDefault(x => x.TermialTerm == term);// object your want to delete
                    context.terminals.Remove(singleRec);
                    context.SaveChanges();
                    Say($"del {term}");
                }
            }
            catch (Exception ex) { SayRed($"{term} {ex.Message}"); }
            #endregion
        }


        public static List<List<string>> GetAllTerm()
        {
            #region
            var outList = new List<List<string>>();
            using (var context = new MyDataContext())
            {
                var terminal = context.terminals;
                var w = terminal.ToList();
                foreach (var line in w)
                {
                    var lineVec = new List<string> {
                        line.DepartmentTerm,
                        line.TermialTerm,
                        line.ModelTerm,
                        line.SerialNumberTerm,
                        line.DateManufactureTerm,
                        line.SoftTerm,
                        line.ProducerTerm,
                        line.RneRroTerm,
                        line.SealingTerm,
                        line.FiscalNumberTerm,
                        line.OroSerialTerm,
                        line.OroNumberTerm,
                        line.TicketSerialTerm,
                        line.Ticket1sheetTerm,
                        line.TicketNumberTerm,
                        line.SendingTerm,
                        line.BooksArhivTerm,
                        line.TicketsArhivTerm,
                        line.ToRroTerm,
                        line.OwnerRroTerm,
                        line.RegisterTerm,
                        line.FinishTerm
                    };
                    outList.Add(lineVec);
                }

            }
            return outList;
            #endregion
        }

        private static List<string> GetOneTerm(string myTerm)
        {
            #region
            List<List<string>> outList = new List<List<string>>();
            using (var context = new MyDataContext())
            {
                var terminal = context.terminals;
                //var w = department.ToList();

                var lingVar = from term in terminal
                              where term.TermialTerm == myTerm
                              select
                              new
                              {
                                  DepartmentTerm = term.DepartmentTerm,
                                  TermialTerm = term.TermialTerm,
                                  ModelTerm = term.ModelTerm,
                                  SerialNumberTerm = term.SerialNumberTerm,
                                  DateManufactureTerm = term.DateManufactureTerm,
                                  SoftTerm = term.SoftTerm,
                                  ProducerTerm = term.ProducerTerm,
                                  RneRroTerm = term.RneRroTerm,
                                  SealingTerm = term.SealingTerm,
                                  FiscalNumberTerm = term.FiscalNumberTerm,
                                  OroSerialTerm = term.OroSerialTerm,
                                  OroNumberTerm = term.OroNumberTerm,
                                  TicketSerialTerm = term.TicketSerialTerm,
                                  Ticket1sheetTerm = term.Ticket1sheetTerm,
                                  TicketNumberTerm = term.TicketNumberTerm,
                                  SendingTerm = term.SendingTerm,
                                  BooksArhivTerm = term.BooksArhivTerm,
                                  TicketsArhivTerm = term.TicketsArhivTerm,
                                  ToRroTerm = term.ToRroTerm,
                                  OwnerRroTerm = term.OwnerRroTerm,
                                  RegisterTerm = term.RegisterTerm,
                                  FinishTerm = term.FinishTerm
                              };
                foreach (var term in lingVar)
                {
                    List<string> vec = new List<string>();

                    vec.Add(term.DepartmentTerm);
                    vec.Add(term.TermialTerm);
                    vec.Add(term.ModelTerm);
                    vec.Add(term.SerialNumberTerm);
                    vec.Add(term.DateManufactureTerm);
                    vec.Add(term.SoftTerm);
                    vec.Add(term.ProducerTerm);
                    vec.Add(term.RneRroTerm);
                    vec.Add(term.SealingTerm);
                    vec.Add(term.FiscalNumberTerm);
                    vec.Add(term.OroSerialTerm);
                    vec.Add(term.OroNumberTerm);
                    vec.Add(term.TicketSerialTerm);
                    vec.Add(term.Ticket1sheetTerm);
                    vec.Add(term.TicketNumberTerm);
                    vec.Add(term.SendingTerm);
                    vec.Add(term.BooksArhivTerm);
                    vec.Add(term.TicketsArhivTerm);
                    vec.Add(term.ToRroTerm);
                    vec.Add(term.OwnerRroTerm);
                    vec.Add(term.RegisterTerm);
                    vec.Add(term.FinishTerm);

                    outList.Add(vec);
                }
            };
            return outList[0];
            #endregion
        }


        internal static void AddOneTerminal(List<string> vec)
        {
            #region
            string dep = vec[0];
            Say("# AddOneTerminal");
            DeleteOneTerminal(dep);
            using (var context = new MyDataContext())
            {
                var terminal = new T_Terminal
                {
                    DepartmentTerm = vec[0],
                    TermialTerm = vec[1],
                    ModelTerm = vec[2],
                    SerialNumberTerm = vec[3],
                    DateManufactureTerm = vec[4],
                    SoftTerm = vec[5],
                    ProducerTerm = vec[6],
                    RneRroTerm = vec[7],
                    SealingTerm = vec[8],
                    FiscalNumberTerm = vec[9],
                    OroSerialTerm = vec[10],
                    OroNumberTerm = vec[11],
                    TicketSerialTerm = vec[12],
                    Ticket1sheetTerm = vec[13],
                    TicketNumberTerm = vec[14],
                    SendingTerm = vec[15],
                    BooksArhivTerm = vec[16],
                    TicketsArhivTerm = vec[17],
                    ToRroTerm = vec[18],
                    OwnerRroTerm = vec[19],
                    RegisterTerm = vec[20],
                    FinishTerm = vec[21]
                };

                context.terminals.Add(terminal);
                context.SaveChanges();
                Say($"+ term new {terminal.TermialTerm}");
            }
            #endregion
        }


        internal static List<string> GetLisTerm()
        {
            #region
            var outList = new List<string>();
            using (var context = new MyDataContext())
            {
                var terminal = context.terminals;
                var w = terminal.ToList();
                foreach (var line in w)
                {
                    outList.Add(line.TermialTerm);
                }

            }
            return outList;
            #endregion
        }

    }
}
