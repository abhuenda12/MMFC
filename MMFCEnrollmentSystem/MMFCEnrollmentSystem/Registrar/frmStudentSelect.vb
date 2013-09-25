Public Class frmStudentSelect

    Public Selected As Boolean = False
    Public m_StudentPK As Integer = -1
    Public m_StudentName As String = ""
    Public m_StudentType As String = ""

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

   
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.StudentsTableAdapter.Fill(Me.DsRegistrar.Students, "%" & TextBox1.Text & "%")
            If Me.DsRegistrar.Students.Rows.Count = 1 Then goSelect()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        goSelect()
    End Sub

    Private Sub goSelect()

        If Me.DsRegistrar.Students.Rows.Count = 0 Then MsgBox("Nothing selected!") : Exit Sub
        With Me.DsRegistrar.Students(Me.StudentsBindingSource.Position)
            Me.m_StudentPK = .StudentPK
            Me.m_StudentName = .StudentName
            If .IsStudentTypeNull Then .StudentType = "OLD"
            Me.m_StudentType = .StudentType
        End With
        Me.Selected = True
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    '10.28.2011. All charges takes a pseudo-reset starting 2nd sem 2011-2012. 
    Function findBalance(ByVal student As Integer) As Double

        Dim ds As New dsFinance
        Dim dt As New dsFinanceTableAdapters.LedgerbyStudentTableAdapter
        Dim ctr As Integer
        Dim bal As Double = 0
        dt.Fill(ds.LedgerbyStudent, student)
        For ctr = 0 To ds.LedgerbyStudent.Rows.Count - 1

            'test for inclusion of sem sy
            Dim sempk As Integer = ds.LedgerbyStudent(ctr).sempk
            Dim yearpk As Integer = ds.LedgerbyStudent(ctr).sypk

            'dont include if before inclusion
            If Not clsTool.IsSYSemIncludedInLedgerComputations(sempk, yearpk) Then Continue For

            If ds.LedgerbyStudent(ctr).linetype = "RCPT" Then
                bal = bal - ds.LedgerbyStudent(ctr).amount
            ElseIf ds.LedgerbyStudent(ctr).linetype = "RCPT-CANCEL" Then   'Ben provision for cancel OR module 12.15.2008 
                'do nothing. this line should not affect the balance
            Else
                bal = bal + ds.LedgerbyStudent(ctr).amount
            End If
        Next
        Return bal

    End Function

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        REM Take out find balance its eating loading time. Ben. 7.11.2013
        If e.ColumnIndex = 2 Then
            'e.Value = findBalance(Me.DsRegistrar.Students(e.RowIndex).StudentPK)
        End If
    End Sub

    Private Sub frmStudentSelect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Focus()
    End Sub
End Class