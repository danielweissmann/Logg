using System.Collections.Generic;
using System.Xml.Serialization;

namespace Logg
{
    [XmlRoot(ElementName = "LogEntries", IsNullable = false)]
    public class LogEntries : List<LogEntry> { }
}