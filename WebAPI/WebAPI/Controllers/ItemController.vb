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
    Public Class ItemController
        Inherits System.Web.Http.ApiController

        Private db As New DBModel

        ' GET: api/Item
        Function GetItems() As IQueryable(Of Item)
            Return db.Items
        End Function

        ' GET: api/Item/5
        <ResponseType(GetType(Item))>
        Function GetItem(ByVal id As Integer) As IHttpActionResult
            Dim item As Item = db.Items.Find(id)
            If IsNothing(item) Then
                Return NotFound()
            End If

            Return Ok(item)
        End Function

        ' PUT: api/Item/5
        <ResponseType(GetType(Void))>
        Function PutItem(ByVal id As Integer, ByVal item As Item) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = item.ItemID Then
                Return BadRequest()
            End If

            db.Entry(item).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (ItemExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Item
        <ResponseType(GetType(Item))>
        Function PostItem(ByVal item As Item) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Items.Add(item)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = item.ItemID}, item)
        End Function

        ' DELETE: api/Item/5
        <ResponseType(GetType(Item))>
        Function DeleteItem(ByVal id As Integer) As IHttpActionResult
            Dim item As Item = db.Items.Find(id)
            If IsNothing(item) Then
                Return NotFound()
            End If

            db.Items.Remove(item)
            db.SaveChanges()

            Return Ok(item)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ItemExists(ByVal id As Integer) As Boolean
            Return db.Items.Count(Function(e) e.ItemID = id) > 0
        End Function
    End Class
End Namespace