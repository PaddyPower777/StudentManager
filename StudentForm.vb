Imports System.Windows.Forms

Public Class StudentForm

    Private idBinding As Binding
    Private givenNameBinding As Binding
    Private familyNameBinding As Binding
    Private dobBinding As Binding
    Private cityBinding As Binding

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click
        MainForm.StudentBindingSource.EndEdit()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel_Button.Click
        MainForm.StudentBindingSource.CancelEdit()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.setBindings()
    End Sub

    Private Sub setBindings()
        idBinding = New Binding("Text", MainForm.StudentDataDataSet.Student, "ID")
        idTextBox.DataBindings.Add(idBinding)

        givenNameBinding = New Binding("Text", MainForm.StudentDataDataSet.Student, "GivenName")
        givenNameTextBox.DataBindings.Add(givenNameBinding)

        familyNameBinding = New Binding("Text", MainForm.StudentDataDataSet.Student, "FamilyName")
        familyNameTextBox.DataBindings.Add(familyNameBinding)

        dobBinding = New Binding("Text", MainForm.StudentDataDataSet.Student, "DateOfBirth")
        dobTextBox.DataBindings.Add(dobBinding)

        cityBinding = New Binding("Text", MainForm.StudentDataDataSet.Student, "City")
        cityTextBox.DataBindings.Add(cityBinding)
    End Sub
End Class
