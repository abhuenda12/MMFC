Partial Class dsFinance
    Partial Class CollectionBreakdownDataTable

    End Class

    Partial Class LedgerReceiptBreakdownDataTable

        Private Sub LedgerReceiptBreakdownDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.remarks2Column.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class LedgerbyStudentDataTable

    End Class

End Class
