using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

#if !RELEASE
[assembly: InternalsVisibleTo("Splunk.Client.Helpers")]
[assembly: InternalsVisibleTo("acceptance-tests")]
[assembly: InternalsVisibleTo("unit-tests")]
#endif