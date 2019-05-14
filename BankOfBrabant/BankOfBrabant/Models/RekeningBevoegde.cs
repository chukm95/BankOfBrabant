using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    enum RekeningRelaties    {        HOUDER = 0x01,        MEDEHOUDER = 0x02,        GEMACHTIGDE = 0x03    }    class RekeningBevoegde    {        public ulong KlantID        {            get;            private set;        }        public ulong RekeningID        {            get;            private set;        }        public RekeningRelaties Relatie        {            get;            set;        }        public RekeningBevoegde()        {        }        public RekeningBevoegde(ulong klantId, ulong rekeningId, RekeningRelaties relatie)        {            KlantID = klantId;            RekeningID = rekeningId;            Relatie = relatie;        }        public RekeningBevoegde(DataRow row)        {            KlantID = (ulong)(long)row["KlantID"];            RekeningID = (ulong)(long)row["RekeningID"];            Relatie = (RekeningRelaties)(byte)(sbyte)row["Relatie"];        }    }
}
