
Public Class Form1

    Dim myConnection As New Odbc.OdbcConnection
    Dim myCommand As New Odbc.OdbcCommand
    Dim myReader As Odbc.OdbcDataReader
    Dim myAdapter As Odbc.OdbcDataAdapter
    Dim myBuilder As Odbc.OdbcCommandBuilder
    Dim connString As String
    Dim donnee As DataTable

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'FERME DE SERVEUR
        'connString = "Driver={Microsoft ODBC for Oracle};CONNECTSTRING=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.0.23.80)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));Uid=MESGUEN3;Pwd=Estran;"
        'SERVEUR DE TEST
        'connString = "Driver={Microsoft ODBC for Oracle};CONNECTSTRING=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.0.220.100)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORAPROF)));Uid=SCOTT;Pwd=tiger;"
        connString = "DSN=TEST2024;Uid=SCOTT;Pwd=Iroise29;"
        'connString = "DSN=FERME;Uid=SCOTT;Pwd=tiger;"

        myConnection.ConnectionString = connString

        Try
            myConnection.Open()
            MessageBox.Show("Connexion Oracle Réussie")
        Catch ex As Odbc.OdbcException
            MessageBox.Show(ex.Message)
        End Try

        Dim query As String = "SELECT table_name FROM user_tables"
        myCommand.Connection = myConnection
        myCommand.CommandText = query
        myReader = myCommand.ExecuteReader

        While myReader.Read
            NomBox.Items.Add(myReader.GetString(0))
        End While

    End Sub

    'Je suis olivier
    Private Sub NomBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NomBox.SelectedIndexChanged

        Dim table_name As String = NomBox.SelectedItem.ToString()
        Dim query As String = "SELECT * FROM " & table_name
        donnee = New DataTable
        myAdapter = New Odbc.OdbcDataAdapter(query, myConnection)
        myBuilder = New Odbc.OdbcCommandBuilder(myAdapter)
        myAdapter.Fill(donnee)
        SocGrid.DataSource = donnee

    End Sub


End Class
