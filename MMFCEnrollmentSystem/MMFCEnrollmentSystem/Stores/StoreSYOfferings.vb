Public Class StoreSYOfferings

    ''' <summary>
    ''' Get a Class given the semester and year id plus the syoffering id
    ''' </summary>
    ''' <param name="SemPK"></param>
    ''' <param name="YearPK"></param>
    ''' <param name="SYPK"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSYOfferingStudents(ByVal SemPK As Integer, ByVal YearPK As Integer, ByVal SYPK As Integer) As dsRegistrar.ClassListDataTable
        Dim ds As New dsRegistrar.ClassListDataTable
        Dim dt As New dsRegistrarTableAdapters.ClassListTableAdapter
        dt.Fill(ds, YearPK, SemPK, SYPK)
        Return ds
    End Function

    Public Shared Function GetStudentClassSked(ByVal SemPK As Integer, ByVal YearPK As Integer, ByVal StudentPK As Integer) As dsRep.EnrollSubjectsbyStudentSemYrPkDataTable
        Dim ds As New dsRep.EnrollSubjectsbyStudentSemYrPkDataTable
        Dim dt As New dsRepTableAdapters.EnrollSubjectsbyStudentSemYrPkTableAdapter
        dt.Fill(ds, StudentPK, SemPK, YearPK)
        Return ds
    End Function


End Class
