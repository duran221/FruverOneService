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
    Public Class OrderController
        Inherits System.Web.Http.ApiController

        Private db As New DBModel

        ' GET: api/Order
        Function GetOrders() As IQueryable(Of Order)
            Return db.Orders
        End Function

        ' GET: api/Order/5
        <ResponseType(GetType(Order))>
        Function GetOrder(ByVal id As Long) As IHttpActionResult
            Dim order As Order = db.Orders.Find(id)
            If IsNothing(order) Then
                Return NotFound()
            End If

            Return Ok(order)
        End Function

        ' PUT: api/Order/5
        <ResponseType(GetType(Void))>
        Function PutOrder(ByVal id As Long, ByVal order As Order) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = order.OrderID Then
                Return BadRequest()
            End If

            db.Entry(order).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (OrderExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Order
        <ResponseType(GetType(Order))>
        Function PostOrder(ByVal order As Order) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Orders.Add(order)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = order.OrderID}, order)
        End Function

        ' DELETE: api/Order/5
        <ResponseType(GetType(Order))>
        Function DeleteOrder(ByVal id As Long) As IHttpActionResult
            Dim order As Order = db.Orders.Find(id)
            If IsNothing(order) Then
                Return NotFound()
            End If

            db.Orders.Remove(order)
            db.SaveChanges()

            Return Ok(order)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function OrderExists(ByVal id As Long) As Boolean
            Return db.Orders.Count(Function(e) e.OrderID = id) > 0
        End Function
    End Class
End Namespace