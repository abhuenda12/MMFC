Public Class frmSubjectFusionList

    Public m_SubjectPK As Integer

    Public Sub LoadGrid()        

        Me.SYOfferingByFusedSubjectPKTableAdapter.Fill(Me.DsRegistrar.SYOfferingByFusedSubjectPK, m_SubjectPK)

    End Sub

End Class