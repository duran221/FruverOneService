Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports WebAPI

Namespace Controllers
    Public Class CustomerController
        Inherits System.Web.Http.ApiController

        Private db As New DBModel

        ' GET: api/Customer
        Function GetCustomers() As IQueryable(Of Customer)
            Return db.Customers
        End Function

        ' GET: api/Customer/5
        <ResponseType(GetType(Customer))>
        Function GetCustomer(ByVal id As Integer) As IHttpActionResult
            Dim customer As Customer = db.Customers.Find(id)
            If IsNothing(customer) Then
                Return NotFound()
            End If

            Return Ok(customer)
        End Function

        ' PUT: api/Customer/5
        <ResponseType(GetType(Void))>
        Function PutCustomer(ByVal id As Integer, ByVal customer As Customer) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = customer.CustomerID Then
                Return BadRequest()
            End If

            db.Entry(customer).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (CustomerExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Customer
        <ResponseType(GetType(Customer))>
        Function PostCustomer(ByVal customer As Customer) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Customers.Add(customer)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = customer.CustomerID}, customer)
        End Function

        ' DELETE: api/Customer/5
        <ResponseType(GetType(Customer))>
        Function DeleteCustomer(ByVal id As Integer) As IHttpActionResult
            Dim customer As Customer = db.Customers.Find(id)
            If IsNothing(customer) Then
                Return NotFound()
            End If

            db.Customers.Remove(customer)
            db.SaveChanges()

            Return Ok(customer)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function CustomerExists(ByVal id As Integer) As Boolean
            Return db.Customers.Count(Function(e) e.CustomerID = id) > 0
        End Function
    End Class
End Namespace