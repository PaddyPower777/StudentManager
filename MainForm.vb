Public Class MainForm

    Public Sub New()
        InitializeComponent()

        allCoursesComboBox.DataSource = CourseForm.CourseBindingSource
        allCoursesComboBox.DisplayMember = "CourseCode"
    End Sub

    Private Sub exitItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StudentDataDataSet.Results' table. You can move, or remove it, as needed.
        Me.ResultsTableAdapter.Fill(Me.StudentDataDataSet.Results)

        'TODO: This line of code loads data into the 'StudentDataDataSet.Student' table. You can move, or remove it, as needed.
        'Me.StudentTableAdapter.Fill(Me.StudentDataDataSet.Student)

        CourseForm.CourseTableAdapter.Fill(CourseForm.StudentDataDataSet.Course)
    End Sub

    Private Sub courseMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles courseMenuItem.Click
        CourseForm.Show()
    End Sub

    Private Sub showDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showDataButton.Click
        Try
            Me.ResultsTableAdapter.FillByTutorID(Me.StudentDataDataSet.Results, tutorIdTextBox.Text)
            Me.StudentTableAdapter.FillByTutorID(Me.StudentDataDataSet.Student, tutorIdTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        tutorIdTextBox.ReadOnly = True
    End Sub

    Private Sub studentMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles studentMenuItem.Click
        StudentBindingSource.EndEdit()
        StudentForm.Show()
    End Sub

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click
        FKResultsStudentBindingSource.EndEdit()
    End Sub

    Private Sub cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel_Button.Click
        FKResultsStudentBindingSource.CancelEdit()
    End Sub

    Private Sub saveMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveMenuItem.Click
        FKResultsStudentBindingSource.EndEdit()
        StudentBindingSource.EndEdit()
        Try
            ResultsTableAdapter.Update(StudentDataDataSet.Results)
            StudentTableAdapter.Update(StudentDataDataSet.Student)
        Catch ex As Exception
            MessageBox.Show("A problem has occurred when updating the database")
        End Try
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        saveMenuItem_Click(sender, e)
    End Sub

    Private Sub clearMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearMenuItem.Click
        saveButton_Click(sender, e)
        StudentDataDataSet.Results.Clear()
        StudentDataDataSet.Student.Clear()
        tutorIdTextBox.ReadOnly = False
        tutorIdTextBox.Clear()
    End Sub

    Private Sub addCourseMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCourseMenuItem.Click
        Dim row As DataRowView
        Try
            FKResultsStudentBindingSource.EndEdit()
            row = CType(FKResultsStudentBindingSource.AddNew(), DataRowView)
            row.Item("CourseCode") = allCoursesComboBox.Text
            FKResultsStudentBindingSource.EndEdit()
        Catch ex As Exception
            FKResultsStudentBindingSource.CancelEdit()
            MessageBox.Show("Course was not added - is the course already on the student's list?")
        End Try
    End Sub

    Private Sub removeCourseMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeCourseMenuItem.Click
        FKResultsStudentBindingSource.RemoveCurrent()
        FKResultsStudentBindingSource.EndEdit()
    End Sub
End Class
