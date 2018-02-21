Public Class ConnStrGen
    Private connStrs As Hashtable

    Public Sub New()
        Dim type As String
        Dim subType As String
        Me.connStrs = New Hashtable
        ' Sql Server Connections Strings
        type = "SQL-SERVER"
        subType = ".NET Framework Data Provider for SQL Server"
        Me.connStrs.Add(type + subType + "Standard Security", "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;")
        Me.connStrs.Add(type + subType + "Standard Security alternative syntax", "Server=myServerAddress;Database=myDataBase;User ID=myUsername;Password=myPassword;Trusted_Connection=False;")
        Me.connStrs.Add(type + subType + "Trusted Connection", "Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;")
        Me.connStrs.Add(type + subType + "Trusted Connection alternative syntax", "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;")
        Me.connStrs.Add(type + subType + "Connecting to an SQL Server instance", "Server=myServerName\theInstanceName;Database=myDataBase;Trusted_Connection=True;")
        Me.connStrs.Add(type + subType + "Trusted Connection from a CE device", "Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;User ID=myDomain\myUsername;Password=myPassword;")
        Me.connStrs.Add(type + subType + "Connect via an IP address", "Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;")
        Me.connStrs.Add(type + subType + "Enabling MARS (multiple active result sets)", "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True; MultipleActiveResultSets=true;")
        Me.connStrs.Add(type + subType + "Attach a database file on connect to a local SQL Server Express instance", "Server=.\SQLExpress;AttachDbFilename=c:\asd\qwe\mydbfile.mdf;Database=dbname; Trusted_Connection=Yes;")
        Me.connStrs.Add(type + subType + "Attach a database file, located in the data directory, on connect to a local SQL Server Express instance", "Server=.\SQLExpress;AttachDbFilename=|DataDirectory|mydbfile.mdf; Database=dbname;Trusted_Connection=Yes;")
        Me.connStrs.Add(type + subType + "Using an User Instance on a local SQL Server Express instance", "Data Source=.\SQLExpress;Integrated Security=true; AttachDbFilename=|DataDirectory|\mydb.mdf;User Instance=true;")
        Me.connStrs.Add(type + subType + "Database mirroring", "Data Source=myServerAddress;Failover Partner=myMirrorServerAddress;Initial Catalog=myDataBase;Integrated Security=True;")
        Me.connStrs.Add(type + subType + "Asynchronous processing", "Server=myServerAddress;Database=myDataBase;Integrated Security=True;Asynchronous Processing=True;")

        subType = "SQL Server Native Client 10.0 OLE DB Provider"
        Me.connStrs.Add(type + subType + "Standard security", "Provider=SQLNCLI10;Server=myServerAddress;Database=myDataBase;Uid=myUsername; Pwd=myPassword;")
        Me.connStrs.Add(type + subType + "Trusted connection", "Provider=SQLNCLI10;Server=myServerAddress;Database=myDataBase; Trusted_Connection=yes;")
        Me.connStrs.Add(type + subType + "Connecting to an SQL Server instance", "Provider=SQLNCLI10;Server=myServerName\theInstanceName;Database=myDataBase; Trusted_Connection=yes;")
        Me.connStrs.Add(type + subType + "Enabling MARS (multiple active result sets)", "Provider=SQLNCLI10;Server=myServerAddress;Database=myDataBase; Trusted_Connection=yes;MARS Connection=True;")
        Me.connStrs.Add(type + subType + "Encrypt data sent over network", "Provider=SQLNCLI10;Server=myServerAddress;Database=myDataBase; Trusted_Connection=yes;Encrypt=yes;")
        Me.connStrs.Add(type + subType + "Attach a database file on connect to a local SQL Server Express instance", "Provider=SQLNCLI10;Server=.\SQLExpress;AttachDbFilename=c:\asd\qwe\mydbfile.mdf; Database=dbname; Trusted_Connection=Yes;")
        Me.connStrs.Add(type + subType + "Attach a database file, located in the data directory, on connect to a local SQL Server Express instance", "Provider=SQLNCLI10;Server=.\SQLExpress;AttachDbFilename=|DataDirectory|mydbfile.mdf; Database=dbname;Trusted_Connection=Yes;")
        Me.connStrs.Add(type + subType + "Database mirroring", "Provider=SQLNCLI10;Data Source=myServerAddress;Failover Partner=myMirrorServerAddress;Initial Catalog=myDataBase;Integrated Security=True;")

        subType = ".NET Framework Data Provider for OLE DB"
        Me.connStrs.Add(type + subType + "Bridging to SQL Native Client OLE DB", "Provider=SQLNCLI10;Server=myServerAddress;Database=myDataBase;Uid=myUsername; Pwd=myPassword;")

        subType = "SQL Server Native Client 10.0 ODBC Driver"
        Me.connStrs.Add(type + subType + "Standard security", "Driver={SQL Server Native Client 10.0};Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;")
        Me.connStrs.Add(type + subType + "Trusted Connection", "Driver={SQL Server Native Client 10.0};Server=myServerAddress;Database=myDataBase;Trusted_Connection=yes;")
        Me.connStrs.Add(type + subType + "Connecting to an SQL Server instance", "Driver={SQL Server Native Client 10.0};Server=myServerName\theInstanceName; Database=myDataBase;Trusted_Connection=yes;")
        Me.connStrs.Add(type + subType + "Enabling MARS (multiple active result sets)", "Driver={SQL Server Native Client 10.0};Server=myServerAddress;Database=myDataBase;Trusted_Connection=yes; MARS_Connection=yes;")
        Me.connStrs.Add(type + subType + "Encrypt data sent over network", "Driver={SQL Server Native Client 10.0};Server=myServerAddress;Database=myDataBase; Trusted_Connection=yes;Encrypt=yes;")
        Me.connStrs.Add(type + subType + "Attach a database file on connect to a local SQL Server Express instance", "Driver={SQL Server Native Client 10.0};Server=.\SQLExpress; AttachDbFilename=c:\asd\qwe\mydbfile.mdf; Database=dbname;Trusted_Connection=Yes;")
        Me.connStrs.Add(type + subType + "Attach a database file, located in the data directory, on connect to a local SQL Server Express instance", "Driver={SQL Server Native Client 10.0};Server=.\SQLExpress;AttachDbFilename=|DataDirectory|mydbfile.mdf; Database=dbname;Trusted_Connection=Yes;")
        Me.connStrs.Add(type + subType + "Database mirroring", "Driver={SQL Server Native Client 10.0};Server=myServerAddress;Failover_Partner=myMirrorServerAddress;Database=myDataBase; Trusted_Connection=yes;")

        subType = ".NET Framework Data Provider for ODBC"
        Me.connStrs.Add(type + subType + "Bridging to SQL Native Client 10.0 ODBC Driver", "Driver={SQL Server Native Client 10.0};Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;")

        subType = "SQLXML 4.0 OLEDB Provider"
        Me.connStrs.Add(type + subType + "Using SQL Server Native Client provider", "Provider=SQLXMLOLEDB.4.0;Data Provider=SQLNCLI10;Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;")
        Me.connStrs.Add(type + subType + "XXXXXXXXXX", "YYYYYYYYYYYYY")
        Me.connStrs.Add(type + subType + "XXXXXXXXXX", "YYYYYYYYYYYYY")
        Me.connStrs.Add(type + subType + "XXXXXXXXXX", "YYYYYYYYYYYYY")
        Me.connStrs.Add(type + subType + "XXXXXXXXXX", "YYYYYYYYYYYYY")
        Me.connStrs.Add(type + subType + "XXXXXXXXXX", "YYYYYYYYYYYYY")




    End Sub
End Class
