Imports System.Windows.Forms

Public Class CourseForm

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub CourseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StudentDataDataSet.Course' table. You can move, or remove it, as needed.
        Me.CourseTableAdapter.Fill(Me.StudentDataDataSet.Course)
    End Sub
End Class
