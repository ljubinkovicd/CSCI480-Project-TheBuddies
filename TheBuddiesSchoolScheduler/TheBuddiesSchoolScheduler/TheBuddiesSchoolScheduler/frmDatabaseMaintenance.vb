Public Class frmDatabaseMaintenance

    Private Sub btnAddClass_Click(sender As Object, e As EventArgs) Handles btnAddClass.Click
        GroupBox1.Visible = True
        GroupBox1.Text = "Add Class"

        Label2.Visible = True
        Label2.Text = "Course Name"
        TextBox1.Visible = True

        Label3.Visible = True
        Label3.Text = "Course Number"
        TextBox2.Visible = True

        Label4.Visible = True
        Label4.Text = "Section Number"
        TextBox3.Visible = True

        Label5.Visible = True
        Label5.Text = "Professor"
        TextBox4.Visible = True

        Label6.Visible = True
        Label6.Text = "Room"
        TextBox5.Visible = True

        Label7.Visible = True
        Label7.Text = "Credit Hours"
        TextBox6.Visible = True

        Label8.Visible = True
        Label8.Text = "Start Time"
        TextBox7.Visible = True

        Label9.Visible = True
        Label9.Text = "End Time"
        TextBox8.Visible = True

        Label10.Visible = True
        Label10.Text = "Days"
        chk1.Visible = True
        chk1.Text = "M"
        chk2.Visible = True
        chk2.Text = "T"
        chk3.Visible = True
        chk3.Text = "W"
        chk4.Visible = True
        chk4.Text = "H"
        chk5.Visible = True
        chk5.Text = "F"
        chk6.Visible = True
        chk6.Text = "Sat"
        chk7.Visible = True
        chk7.Text = "Sun"

    End Sub

    Private Sub btnEditClass_Click(sender As Object, e As EventArgs) Handles btnEditClass.Click
        GroupBox1.Visible = True
        GroupBox1.Text = "Edit Class"

        Label2.Visible = True
        Label2.Text = "Course Name"
        TextBox1.Visible = True

        Label3.Visible = True
        Label3.Text = "Course Number"
        TextBox2.Visible = True

        Label4.Visible = True
        Label4.Text = "Section Number"
        TextBox3.Visible = True

        Label5.Visible = True
        Label5.Text = "Professor"
        TextBox4.Visible = True

        Label6.Visible = True
        Label6.Text = "Room"
        TextBox5.Visible = True

        Label7.Visible = True
        Label7.Text = "Credit Hours"
        TextBox6.Visible = True

        Label8.Visible = True
        Label8.Text = "Start Time"
        TextBox7.Visible = True

        Label9.Visible = True
        Label9.Text = "End Time"
        TextBox8.Visible = True

        Label10.Visible = True
        Label10.Text = "Days"
        chk1.Visible = True
        chk1.Text = "M"
        chk2.Visible = True
        chk2.Text = "T"
        chk3.Visible = True
        chk3.Text = "W"
        chk4.Visible = True
        chk4.Text = "H"
        chk5.Visible = True
        chk5.Text = "F"
        chk6.Visible = True
        chk6.Text = "Sat"
        chk7.Visible = True
        chk7.Text = "Sun"
    End Sub

    Private Sub btnRemoveClass_Click(sender As Object, e As EventArgs) Handles btnRemoveClass.Click
        GroupBox1.Visible = True
        GroupBox1.Text = "Remove Class"

        Label2.Visible = True
        Label2.Text = "Please Enter the Course Name of the Class to Remove"
        TextBox1.Visible = True

        Label3.Visible = False
        TextBox2.Visible = False

        Label4.Visible = False
        TextBox3.Visible = False

        Label5.Visible = False
        TextBox4.Visible = False

        Label6.Visible = False
        TextBox5.Visible = False

        Label7.Visible = False
        TextBox6.Visible = False

        Label8.Visible = False
        TextBox7.Visible = False

        Label9.Visible = False
        TextBox8.Visible = False

        Label10.Visible = False
        chk1.Visible = False
        chk2.Visible = False
        chk3.Visible = False
        chk4.Visible = False
        chk5.Visible = False
        chk6.Visible = False
        chk7.Visible = False

    End Sub

    Private Sub btnAddProfessor_Click(sender As Object, e As EventArgs) Handles btnAddProfessor.Click
        GroupBox1.Visible = True
        GroupBox1.Text = "Add Professor"

        Label2.Visible = True
        Label2.Text = "Professor Name"
        TextBox1.Visible = True

        Label3.Visible = True
        Label3.Text = "ID Number"
        TextBox2.Visible = True

        Label4.Visible = True
        Label4.Text = "Position"
        TextBox3.Visible = True

        Label5.Visible = True
        Label5.Text = "Phone Number"
        TextBox4.Visible = True

        Label6.Visible = True
        Label6.Text = "Location"
        TextBox5.Visible = True

        Label7.Visible = True
        Label7.Text = "Hours Allowed"
        TextBox6.Visible = True

        Label8.Visible = True
        Label8.Text = "Hours Scheduled"
        TextBox7.Visible = True

        Label9.Visible = True
        Label9.Text = "Number of Courses"
        TextBox8.Visible = True

        Label10.Visible = True
        Label10.Text = "Degree(s)"
        chk1.Visible = False
        chk2.Visible = False
        chk3.Visible = False
        chk4.Visible = True
        chk4.Text = "As"
        chk5.Visible = True
        chk5.Text = "Ba"
        chk6.Visible = True
        chk6.Text = "Ma"
        chk7.Visible = True
        chk7.Text = "Dr"
    End Sub

    Private Sub btnEditProfessor_Click(sender As Object, e As EventArgs) Handles btnEditProfessor.Click
        GroupBox1.Visible = True
        GroupBox1.Text = "Edit Professor"

        Label2.Visible = True
        Label2.Text = "Professor Name"
        TextBox1.Visible = True

        Label3.Visible = True
        Label3.Text = "ID Number"
        TextBox2.Visible = True

        Label4.Visible = True
        Label4.Text = "Position"
        TextBox3.Visible = True

        Label5.Visible = True
        Label5.Text = "Phone Number"
        TextBox4.Visible = True

        Label6.Visible = True
        Label6.Text = "Location"
        TextBox5.Visible = True

        Label7.Visible = True
        Label7.Text = "Hours Allowed"
        TextBox6.Visible = True

        Label8.Visible = True
        Label8.Text = "Hours Scheduled"
        TextBox7.Visible = True

        Label9.Visible = True
        Label9.Text = "Number of Courses"
        TextBox8.Visible = True

        Label10.Visible = True
        Label10.Text = "Degree(s)"
        chk1.Visible = False
        chk2.Visible = False
        chk3.Visible = False
        chk4.Visible = True
        chk4.Text = "As"
        chk5.Visible = True
        chk5.Text = "Ba"
        chk6.Visible = True
        chk6.Text = "Ma"
        chk7.Visible = True
        chk7.Text = "Dr"
    End Sub

    Private Sub btnRemoveProfessor_Click(sender As Object, e As EventArgs) Handles btnRemoveProfessor.Click
        GroupBox1.Visible = True
        GroupBox1.Text = "Remove Professor"

        Label2.Visible = True
        Label2.Text = "Please Enter the Name of the Professor to Remove"
        TextBox1.Visible = True

         Label3.Visible = False
        TextBox2.Visible = False

        Label4.Visible = False
        TextBox3.Visible = False

        Label5.Visible = False
        TextBox4.Visible = False

        Label6.Visible = False
        TextBox5.Visible = False

        Label7.Visible = False
        TextBox6.Visible = False

        Label8.Visible = False
        TextBox7.Visible = False

        Label9.Visible = False
        TextBox8.Visible = False

        Label10.Visible = False
        chk1.Visible = False
        chk2.Visible = False
        chk3.Visible = False
        chk4.Visible = False
        chk5.Visible = False
        chk6.Visible = False
        chk7.Visible = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        GroupBox1.Visible = False

        Label2.Visible = False
        TextBox1.Visible = False

        Label3.Visible = False
        TextBox2.Visible = False

        Label4.Visible = False
        TextBox3.Visible = False

        Label5.Visible = False
        TextBox4.Visible = False

        Label6.Visible = False
        TextBox5.Visible = False

        Label7.Visible = False
        TextBox6.Visible = False

        Label8.Visible = False
        TextBox7.Visible = False

        Label9.Visible = False
        TextBox8.Visible = False

        Label10.Visible = False
        chk1.Visible = False
        chk2.Visible = False
        chk3.Visible = False
        chk4.Visible = False
        chk5.Visible = False
        chk6.Visible = False
        chk7.Visible = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmWelcome.Visible = True

        Me.Visible = False
    End Sub
End Class