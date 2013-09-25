Public Class frmClassSelect2
    Public m_SY As Integer = -1
    Public m_SEM As Integer = -1
    Public Selected As Boolean = False
    Public m_SYOfferingPK As Integer = -1
    Public m_Subject As Integer = -1
    Public m_Closed As Boolean

    'benAdded Code to filter subject 11.29


    Private Sub frmClassSelect2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtFilter.Focus()
    End Sub
    Public Sub LoadGrid()
        Me.SYOfferingSelect2TableAdapter.Fill(Me.DsRegistrar.SYOfferingSelect2, Me.m_SY, Me.m_SEM)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.DsRegistrar.SYOfferingSelect2.Rows.Count = 0 Then MsgBox("Nothing Selected!")
        Me.m_SYOfferingPK = Me.DsRegistrar.SYOfferingSelect2(Me.SYOfferingSelect2BindingSource.Position).syofferingpk
        Me.m_Subject = Me.DsRegistrar.SYOfferingSelect2(Me.SYOfferingSelect2BindingSource.Position).subjectpk
        If Me.DsRegistrar.SYOfferingSelect2(Me.SYOfferingSelect2BindingSource.Position).IsclosedNull Then
            Me.m_Closed = False
        Else
            Me.m_Closed = Me.DsRegistrar.SYOfferingSelect2(Me.SYOfferingSelect2BindingSource.Position).closed
        End If
        Me.Selected = True
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        If e.ColumnIndex = 1 Then
            e.Value = clsTool.GetSubjectDescription(Me.DsRegistrar.SYOfferingSelect2(e.RowIndex).subjectpk)
        End If
        If e.ColumnIndex = 2 Then
            e.Value = clsTool.getTeacherName(Me.DsRegistrar.SYOfferingSelect2(e.RowIndex).teacherid)
        End If
        If e.ColumnIndex = 3 Then
            e.Value = clsTool.getResourceName(Me.DsRegistrar.SYOfferingSelect2(e.RowIndex).resource)
        End If
        If e.ColumnIndex = 4 Then
            Dim s As String = ""
            Dim r As dsRegistrar.SYOfferingSelect2Row = Me.DsRegistrar.SYOfferingSelect2(e.RowIndex)
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
        If e.ColumnIndex = 5 Then
            Dim r As dsRegistrar.SYOfferingSelect2Row = Me.DsRegistrar.SYOfferingSelect2(e.RowIndex)
            If r.IsclosedNull Then
                e.Value = "Open"
            Else
                If r.closed Then
                    e.Value = "Closed"
                Else
                    e.Value = "Open"
                End If
            End If
        End If
    End Sub

    REM ben11.29.2007
#Region "Filter"
    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            goFilter()
        End If
    End Sub

    Private Sub goFilter()
        If Me.DsRegistrar.SYOfferingSelect2.Rows.Count <= 0 Then Exit Sub

        Dim filter As String = Me.txtFilter.Text.ToUpper
        Dim hits As Integer = 0
        Dim firsthitrow As Integer = 0
        Dim i As Integer

        For i = 0 To Me.DataGridView1.RowCount - 1
            With Me.DataGridView1.Rows(i)
                If CStr(.Cells(1).Value).ToUpper.Contains(filter) Then
                    hits += 1
                    If hits = 1 Then Me.SYOfferingSelect2BindingSource.Position = i
                Else  'not a hit . make invisible . transfer currency to next row
                    If i = Me.DataGridView1.RowCount - 1 And hits = 0 Then
                        MsgBox("No records meet your filter!")
                        LoadGrid()
                        Exit Sub
                    End If

                    'transfer currency to next row
                    If hits = 0 Then Me.SYOfferingSelect2BindingSource.Position = i + 1

                    .Visible = False
                End If
            End With
        Next
    End Sub
#End Region

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class