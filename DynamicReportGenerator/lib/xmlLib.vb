Imports System.Xml
Public Class xmlLib
    Public Shared Sub createMySettingsXmlFile(ByVal fileName As String)
        If IO.File.Exists(fileName) Then
            IO.File.Delete(fileName)
        End If
        Dim document As New XmlDocument()
        Dim dec As XmlDeclaration = document.CreateXmlDeclaration("1.0", "utf-8", "yes")
        document.AppendChild(dec)
        Dim DocRoot As XmlElement
        DocRoot = document.CreateElement("MySettings")
        document.AppendChild(DocRoot)
        document.Save(fileName)
    End Sub

    Public Shared Sub addReportToXmlFile(ByVal reportName As String, ByVal reportCategory As String, ByVal sql As String, ByVal connectionString As String, ByVal dbms As String, ByVal fileName As String)
        If Not IO.File.Exists(fileName) Then
            createMySettingsXmlFile(fileName)
        End If

        Dim document As New XmlDocument()
        document.Load(fileName)

        Dim report As XmlElement = document.CreateElement("Report")
        Dim nameAttrib As XmlAttribute = document.CreateAttribute("name") : nameAttrib.InnerText = reportName
        Dim categoryXmlElement As XmlNode = document.CreateElement("ReportCategory") : categoryXmlElement.InnerText = reportCategory
        Dim sqlXmlElement As XmlNode = document.CreateElement("SqlStatement") : sqlXmlElement.InnerText = sql
        Dim connectionStringXmlElement As XmlNode = document.CreateElement("ConnectionString") : connectionStringXmlElement.InnerText = Enc.Encrypt(connectionString, reportName)
        Dim dbmsXmlElement As XmlNode = document.CreateElement("dbms") : dbmsXmlElement.InnerText = dbms

        report.Attributes.Append(nameAttrib)
        report.AppendChild(categoryXmlElement)
        report.AppendChild(sqlXmlElement)
        report.AppendChild(connectionStringXmlElement)
        report.AppendChild(dbmsXmlElement)

        Dim node As XmlElement = document.SelectSingleNode("MySettings/Reports")
        If node Is Nothing Then
            Dim e As XmlElement = document.CreateElement("Reports")
            document.SelectSingleNode("MySettings").AppendChild(e)
            node = document.SelectSingleNode("MySettings/Reports")
        End If
        node.AppendChild(report)
        document.Save(fileName)
    End Sub

    Public Shared Sub removeReport(ByVal name As String, ByVal fileName As String)
        Dim document As New XmlDocument()
        document.Load(fileName)

        For Each node As XmlElement In document.SelectNodes("MySettings/Reports/Report[@name='" + name + "']")
            node.ParentNode.RemoveChild(node)
        Next

        document.Save(fileName)
    End Sub
    Public Shared Function getCategoriesNames(ByVal fileName As String) As String()
        Dim result As New List(Of String)
        For Each key As String In getCategories(fileName).Keys
            result.Add(key)
        Next

        Return If(result.Count = 0, Nothing, result.ToArray)
    End Function
    Public Shared Function getReportsNames(ByVal fileName As String) As String()
        Dim result As New List(Of String)
        Dim cats As Hashtable = getCategories(fileName)
        For Each key As String In cats.Keys
            For Each rep As Report In cats(key)
                result.Add(rep.NAME)
            Next
        Next
        
        Return If(result.Count = 0, Nothing, result.ToArray)
    End Function

    Public Shared Function getCategories(ByVal fileName As String) As Hashtable
        Dim categories As New Hashtable

        Dim document As New XmlDocument()
        document.Load(fileName)

        Dim connStr As String
        Dim name As String
        Dim category As String
        Dim sql As String
        Dim dbms As String

        Dim reportsNode As XmlNodeList = document.SelectNodes("MySettings/Reports/Report")
        For Each Report As XmlElement In reportsNode
            name = Report.Attributes("name").InnerText
            category = Report.ChildNodes(0).InnerText.ToLower
            sql = Report.ChildNodes(1).InnerText.ToLower
            connStr = Report.ChildNodes(2).InnerText.ToLower
            dbms = Report.ChildNodes(2).InnerText.ToLower

            Dim obj As New Report(name, category, sql, connStr, dbms)
            Dim reps As List(Of Report)
            If categories(category) Is Nothing Then
                reps = New List(Of Report)
                reps.Add(obj)
                categories.Add(category, reps)
            Else
                reps = CType(categories(category), List(Of Report))
                reps.Add(obj)
            End If
        Next

        Return categories
    End Function

    Public Shared Function getReportDetails(ByVal name As String, ByVal fileName As String) As Report
        Dim report As New Report()
        Dim document As New XmlDocument()
        document.Load(fileName)

        Dim node As XmlElement = document.SelectSingleNode("MySettings/Reports/Report[@name='" + name + "']")
        If node Is Nothing Then
            Return Nothing
        Else
            report.NAME = node.GetAttribute("name")
            report.CATEGORY = node.ChildNodes(0).InnerText
            report.SQL = node.ChildNodes(1).InnerText
            report.CONNECTION_STRING = Enc.Decrypt(node.ChildNodes(2).InnerText, report.NAME)
            report.dbms = node.ChildNodes(3).InnerText
            Return report
        End If
    End Function








    Public Shared Function fillGridByXmlReports(ByRef gridViewObj As DataGridView, ByVal fileName As String) As Boolean
        Try
            Dim document As New XmlDocument()
            document.Load(fileName)
            
            Dim rowCounter As Integer = 0
            Dim firstRow As Boolean = True
            Dim val As String = ""
            Dim selectedNodes As XmlNodeList = document.SelectNodes("MySettings/Reports/Report")
            Dim row As New List(Of String)
            For Each node As XmlNode In selectedNodes
                row.Clear()
                If firstRow Then
                    gridViewObj.Columns.Add(node.Attributes("name").LocalName, node.Attributes("name").LocalName)
                End If
                row.Add(node.Attributes("name").InnerText)
                For i As Integer = 0 To node.ChildNodes.Count - 1
                    If firstRow Then
                        gridViewObj.Columns.Add(node.ChildNodes(i).LocalName, node.ChildNodes(i).LocalName)
                        If i = 3 Then ' connection
                            gridViewObj.Columns(i).ReadOnly = True
                        End If

                    End If
                    row.Add(node.ChildNodes(i).InnerText)

                Next
                gridViewObj.Rows.Add(row.ToArray)
                gridViewObj.Item(rowCounter, 0).Style.BackColor = Color.YellowGreen
                gridViewObj.Item(rowCounter, 0).Style.ForeColor = Color.DarkRed

                If firstRow Then
                    firstRow = False
                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    ' this block for database connections
    Public Shared Sub addPgsqlConnectionToXmlFile(ByVal connectionName As String, ByVal userid As String, ByVal password As String, ByVal host As String, ByVal dbname As String, ByVal port As String, ByVal fileName As String)

        Dim document As New XmlDocument()
        Dim ReportsNode As XmlElement
        Dim MySettingsNode As XmlElement
        Dim id As Integer

        document.Load(fileName)

        Dim root As XmlElement = document.SelectSingleNode("MySettings/PostgresqlConnections")
        If root Is Nothing Then
            MySettingsNode = document.SelectSingleNode("MySettings")
            ReportsNode = document.CreateElement("PostgresqlConnections")
            MySettingsNode.AppendChild(ReportsNode)
            root = document.SelectSingleNode("MySettings/PostgresqlConnections")
        End If

        Try
            id = Integer.Parse(root.ChildNodes(root.ChildNodes.Count - 1).Attributes("id").InnerText) + 1
        Catch ex As Exception
            id = 1
        End Try

        ' CONNECTION STRING
        Dim userIdNode As XmlNode = document.CreateElement("UserId") : userIdNode.InnerText = userid
        Dim passwordNode As XmlNode = document.CreateElement("Password") : passwordNode.InnerText = Enc.Encrypt(password, userIdNode.InnerText)
        Dim hostNode As XmlNode = document.CreateElement("Host") : hostNode.InnerText = host
        Dim dbnNode As XmlNode = document.CreateElement("DatabaseName") : dbnNode.InnerText = dbname
        Dim portNode As XmlNode = document.CreateElement("Port") : portNode.InnerText = port


        Dim newConnection As XmlNode = document.CreateElement("pgsqlConnection")
        Dim idXmlAttr = document.CreateAttribute("name") : idXmlAttr.InnerText = connectionName : newConnection.Attributes.Append(idXmlAttr)

        newConnection.AppendChild(userIdNode)
        newConnection.AppendChild(passwordNode)
        newConnection.AppendChild(hostNode)
        newConnection.AppendChild(dbnNode)
        newConnection.AppendChild(portNode)

        root.AppendChild(newConnection)
        document.Save(fileName)

    End Sub

    Public Shared Sub removeAllReports(ByVal fileName As String)
        Dim document As New XmlDocument()
        document.Load(fileName)
        Dim p As String = "MySettings/Reports/Report"
        For Each node As XmlElement In document.SelectNodes(p)
            node.ParentNode.RemoveChild(node)
        Next

        document.Save(fileName)
    End Sub
    Public Shared Sub removePostgresqlConnection(ByVal name As String)
        RemoveFromXml(name, "MySettings/PostgresqlConnections/pgsqlConnection", consts.MY_SETTINGS_OUTPUT_FILE)
    End Sub

    Private Shared Sub RemoveFromXml(ByVal name As String, ByVal xmlPath As String, ByVal fileName As String)
        Dim document As New XmlDocument()
        document.Load(fileName)
        Dim p As String = xmlPath + "[@name='" + name + "']"
        For Each node As XmlElement In document.SelectNodes(p)
            node.ParentNode.RemoveChild(node)
        Next

        document.Save(fileName)
    End Sub
    Public Shared Function getAllPgsqlConnections() As String()
        Return getAttributesFromPath("MySettings/PostgresqlConnections/pgsqlConnection", "name", consts.MY_SETTINGS_OUTPUT_FILE)
    End Function
    Private Shared Function getAttributesFromPath(ByVal xmlPath As String, ByVal attributeName As String, ByVal fileName As String) As String()
        Dim result As New List(Of String)
        Dim document As New XmlDocument()
        document.Load(fileName)
        For Each node As XmlElement In document.SelectNodes(xmlPath)
            result.Add(node.Attributes(attributeName).InnerText)
        Next
        Return If(result.Count = 0, Nothing, result.ToArray)
    End Function


    Public Shared Sub modifyPgsqlConnection(ByRef ctrl As ListBox, ByRef usr As TextBox, ByRef password As TextBox, ByRef host As TextBox, ByRef dbname As TextBox, ByRef port As TextBox, ByVal fileName As String)
        Dim document As New XmlDocument()
        document.Load(fileName)

        If Not ctrl.SelectedItem Is Nothing Then
            Dim nodes As XmlElement = document.SelectSingleNode("MySettings/PostgresqlConnections/pgsqlConnection[@name='" + ctrl.SelectedItem.ToString + "']")
            nodes.ChildNodes(0).InnerText = usr.Text
            nodes.ChildNodes(1).InnerText = Enc.Encrypt(password.Text, usr.Text)
            nodes.ChildNodes(2).InnerText = host.Text
            nodes.ChildNodes(3).InnerText = dbname.Text
            nodes.ChildNodes(4).InnerText = port.Text
        End If
        document.Save(fileName)
    End Sub
    Public Shared Sub modifyPgsqlConnection(ByVal name As String, ByRef usr As TextBox, ByRef password As TextBox, ByRef host As TextBox, ByRef dbname As TextBox, ByRef port As TextBox, ByVal fileName As String)
        Dim document As New XmlDocument()
        document.Load(fileName)


        Dim nodes As XmlElement = document.SelectSingleNode("MySettings/PostgresqlConnections/pgsqlConnection[@name='" + name + "']")
        nodes.ChildNodes(0).InnerText = usr.Text
        nodes.ChildNodes(1).InnerText = Enc.Encrypt(password.Text, usr.Text)
        nodes.ChildNodes(2).InnerText = host.Text
        nodes.ChildNodes(3).InnerText = dbname.Text
        nodes.ChildNodes(4).InnerText = port.Text

        document.Save(fileName)
    End Sub

    Public Shared Sub fillPostgresqlGUIFromXml(ByRef ctrl As ListBox, ByRef usr As TextBox, ByRef password As TextBox, ByRef host As TextBox, ByRef dbname As TextBox, ByRef port As TextBox, ByVal fileName As String)
        Dim document As New XmlDocument()
        document.Load(fileName)

        If Not ctrl.SelectedItem Is Nothing Then
            Dim nodes As XmlElement = document.SelectSingleNode("MySettings/PostgresqlConnections/pgsqlConnection[@name='" + ctrl.SelectedItem.ToString + "']")
            usr.Text = nodes.ChildNodes(0).InnerText
            password.Text = Enc.Decrypt(nodes.ChildNodes(1).InnerText, usr.Text)
            host.Text = nodes.ChildNodes(2).InnerText
            dbname.Text = nodes.ChildNodes(3).InnerText
            port.Text = nodes.ChildNodes(4).InnerText
        End If

    End Sub
    Public Shared Function isThisReportInXmlFile(ByVal name As String, ByVal fileName As String) As Boolean
        Dim document As New XmlDocument()
        document.Load(fileName)
        Dim node As XmlElement = document.SelectSingleNode("MySettings/Reports/Report[@name='" + name + "']")
        Return If(node Is Nothing, False, True)
        
    End Function
End Class
