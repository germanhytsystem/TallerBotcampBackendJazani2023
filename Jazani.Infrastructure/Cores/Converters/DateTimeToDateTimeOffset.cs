using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Cores.Converters
{
    public class DateTimeToDateTimeOffset:ValueConverter<DateTime, DateTimeOffset>
    {
        public DateTimeToDateTimeOffset(): base (
            dateTime => DateTimeOffset.UtcNow,
            dateTimeOffset => dateTimeOffset.DateTime
            )
        {
            
        }

    }
}
