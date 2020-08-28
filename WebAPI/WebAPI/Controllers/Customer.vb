Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class Customer
        Inherits ApiController

        ' GET: api/Customer
        Public Function GetValues() As IEnumerable(Of String)
            Return New String() {"value1", "value2"}
        End Function

        ' GET: api/Customer/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/Customer
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Customer/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Customer/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace