Public Class uSummary

    Public Sub LoadSummary()

        txtActiveSem.Text = clsTool.GetCurSem()
        txtActiveSY.Text = clsTool.GetCurYear()

        Dim strSQL As String

        'courses
        strSQL = "SELECT Count(*) FROM Courses"
        txtCourseCount.Text = clsTool.getDBValue(strSQL)

        'subjects
        strSQL = "SELECT Count(*) FROM Subjects WHERE (ISNULL(inactive, 0) <> 1)"
        txtSubjectCount.Text = clsTool.getDBValue(strSQL)

        'sy offering
        strSQL = "SELECT Count(*) FROM SYOffering WHERE sypk =" & clsTool.GetCurYearPK & " AND semesterpk =" & clsTool.GetCurSemPK
        txtCurrentOfferingCount.Text = clsTool.getDBValue(strSQL)


    End Sub

End Class
