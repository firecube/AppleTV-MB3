using ARSoft.Tools.Net.Dns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AppleTV_MB3.DnsRelay
{
    public class Server : IDisposable
    {
        DnsServer server;

        string domainToSpoof;
        IPAddress ipAddress;

        public Server(string domainToSpoof, IPAddress ipAddress)
        {
            this.domainToSpoof = domainToSpoof;
            this.ipAddress = ipAddress;

            server = new DnsServer(IPAddress.Any, 10, 10, ProcessQuery);
        }

        public void Start()
        {
            server.Start();
        }

        private DnsMessageBase ProcessQuery(DnsMessageBase message, IPAddress clientAddress, ProtocolType protocol)
        {
            message.IsQuery = false;

            DnsMessage query = message as DnsMessage;

            if ((query != null) && (query.Questions.Count == 1))
            {
                DnsQuestion question = query.Questions[0];

                if (question.Name.Equals(domainToSpoof, StringComparison.InvariantCultureIgnoreCase))
                {
                    query.AnswerRecords.Add(new ARecord(domainToSpoof, 3600, ipAddress));
                    query.ReturnCode = ReturnCode.NoError;
                    return query;
                }
                else
                {
                    // send query to upstream server
                    DnsMessage answer = DnsClient.Default.Resolve(question.Name, question.RecordType, question.RecordClass);

                    // if got an answer, copy it to the message sent to the client
                    if (answer != null)
                    {
                        foreach (DnsRecordBase record in (answer.AnswerRecords))
                        {
                            query.AnswerRecords.Add(record);
                        }
                        foreach (DnsRecordBase record in (answer.AdditionalRecords))
                        {
                            query.AnswerRecords.Add(record);
                        }

                        query.ReturnCode = ReturnCode.NoError;
                        return query;
                    }
                }
            }

            // Not a valid query or upstream server did not answer correct
            message.ReturnCode = ReturnCode.ServerFailure;
            return message;
        }

        public void Dispose()
        {
            server.Stop();
        }
    }
}
