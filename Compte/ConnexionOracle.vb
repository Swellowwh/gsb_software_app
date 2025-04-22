Imports System.Data.Odbc

Public Class ConnectionOracle

    Private Shared _connection As OdbcConnection

    Private Const ConnectionString As String = "DSN=CnxOracleFermeD25;UID=slam7;PWD=slam7;"

    Public Shared Function GetConnection() As OdbcConnection

        If _connection Is Nothing Then

            _connection = New OdbcConnection(ConnectionString)

        End If

        If _connection.State = ConnectionState.Closed Then

            Try

                _connection.Open()

            Catch ex As OdbcException

                MessageBox.Show("Erreur lors de l'ouverture de la connexion : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Throw

            End Try

        End If

        Return _connection

    End Function

    Public Shared Sub CloseConnection()

        If _connection IsNot Nothing AndAlso _connection.State <> ConnectionState.Closed Then

            _connection.Close()

        End If

    End Sub

End Class

