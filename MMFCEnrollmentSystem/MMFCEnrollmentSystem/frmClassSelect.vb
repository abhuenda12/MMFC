Public Class frmClassSelect
    Public m_Year As Integer
    Public m_Sem As Integer
    Public m_Subject As Integer
    Public m_SubjecDescription As String
    Public Selected As Boolean = False
    Public m_SelectedClass As Integer = -1
    Public m_SYOffering As Integer
    Public m_forSpecial As Boolean = False
    Public m_Closed As Boolean = False

    Public Function LoadClass() As Boolean
        Label1.Text = Me.m_SubjecDescription
        Application.DoEvents()
        Me.SYOfferingSelectTableAdapter.Fill(Me.DsRegistrar.SYOfferingSelect, m_Year, m_Subject, m_Sem)
        If Me.DsRegistrar.SYOfferingSelect.Rows.Count = 0 Then
            MsgBox("No classes offered for this subject." & vbCrLf & _
                   "Configure classes in Management > Current School Year Offering", MsgBoxStyle.Critical, "Error!")
            Return False
        End If

        Return True
    End Function
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        If e.ColumnIndex = 0 Then
            e.Value = clsTool.getResourceName(Me.DsRegistrar.SYOfferingSelect(e.RowIndex).resource)
        End If
        If e.ColumnIndex = 1 Then
            e.Value = clsTool.getTeacherName(Me.DsRegistrar.SYOfferingSelect(e.RowIndex).teacherid)
        End If
        If e.ColumnIndex = 2 Then
            Dim s As String = ""
            Dim r As dsRegistrar.SYOfferingSelectRow = Me.DsRegistrar.SYOfferingSelect(e.RowIndex)
            If r.monday Then s = s & "Mon:" & clsTool.getTime(CDate(r.monfrom)) & "-" & clsTool.getTime(CDate(r.monto)) & "/"
            If r.tuesday Then s = s & "Tue:" & clsTool.getTime(CDate(r.tuesfrom)) & "-" & clsTool.getTime(CDate(r.tuesto)) & "/"
            If r.wednesday Then s = s & "Wed:" & clsTool.getTime(CDate(r.wedfrom)) & "-" & clsTool.getTime(CDate(r.wedto)) & "/"
            If r.thursday Then s = s & "Thu:" & clsTool.getTime(CDate(r.thufrom)) & "-" & clsTool.getTime(CDate(r.thuto)) & "/"
            If r.alternatefriday Then
                If r.friday Then s = s & "Alt-Fri:" & clsTool.getTime(CDate(r.frifrom)) & "-" & clsTool.getTime(CDate(r.frito)) & "/"
            Else
                If r.friday Then s = s & "Fri:" & clsTool.getTime(CDate(r.frifrom)) & "-" & clsTool.getTime(CDate(r.frito)) & "/"
            End If
            If r.saturday Then s = s & "Sat:" & clsTool.getTime(CDate(r.satfrom)) & "-" & clsTool.getTime(CDate(r.satto)) & "/"
            If r.sunday Then s = s & "Sun:" & clsTool.getTime(CDate(r.sunfrom)) & "-" & clsTool.getTime(CDate(r.sunto))
            If s.Substring(s.Length - 1, 1) = "/" Then s = s.Substring(0, s.Length - 1)
            e.Value = s
        End If
        If e.ColumnIndex = 3 Then
            e.Value = Me.DsRegistrar.SYOfferingSelect(e.RowIndex).MinStudents.ToString & "/" & Me.DsRegistrar.SYOfferingSelect(e.RowIndex).MaxStudents.ToString
        End If
        If e.ColumnIndex = 4 Then
            e.Value = CountStudents(Me.DsRegistrar.SYOfferingSelect(e.RowIndex).syofferingpk)
        End If
    End Sub
    Function CountStudents(ByVal sypk As Integer) As Integer
        Dim ds As New dsRegistrar
        Dim dt As New dsRegistrarTableAdapters.EnrollSubjectsCountTableAdapter
        Dim rval As Integer = 0
        dt.Fill(ds.EnrollSubjectsCount, Me.m_Year, Me.m_Sem, sypk)
        If ds.EnrollSubjectsCount.Rows.Count > 0 Then
            rval = ds.EnrollSubjectsCount(0).StudentCount.ToString
        End If
        Return rval
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.DsRegistrar.SYOfferingSelect.Rows.Count = 0 Then MsgBox("Nothing selected!") : Exit Sub
        Dim cMax As Integer = Me.DsRegistrar.SYOfferingSelect(Me.SYOfferingSelectBindingSource.Position).MaxStudents
        Dim cCount As Integer = CountStudents(Me.DsRegistrar.SYOfferingSelect(Me.SYOfferingSelectBindingSource.Position).syofferingpk)
        If Not Me.m_forSpecial Then If cCount >= cMax Then MsgBox("This class is full! To force enroll this student to this class ask management to increase maximum number.") : Exit Sub
        Me.m_SelectedClass = Me.DsRegistrar.SYOfferingSelect(Me.SYOfferingSelectBindingSource.Position).syofferingpk
        If Me.DsRegistrar.SYOfferingSelect(Me.SYOfferingSelectBindingSource.Position).IsclosedNull Then
            Me.m_Closed = False
        Else
            Me.m_Closed = Me.DsRegistrar.SYOfferingSelect(Me.SYOfferingSelectBindingSource.Position).closed
        End If
        Selected = True
        Me.Hide()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class