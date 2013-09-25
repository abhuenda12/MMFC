select * from Ledger where ledgerpk = 90132

select * from Ledger where studentpk = 4233

select * from Ledger where sypk = 0

--update Ledger set sypk = 38  where ledgerpk = 90132 and studentpk = 4233

select * from Students where StudentName like 'Delostrico%'   -- studentpk = 3988

select * from Ledger where studentpk = 3988

select * from Ledger where linetype = 'RCPT'  and   ledgerdate between '3/1/2012' and '3/31/2012 11:59:59' and sempk = 1 and sypk = 37 --and studentpk = 3988 and ledgerpk = 88436

--update Ledger set sempk = 2 where linetype = 'RCPT' and ledgerdate between '3/1/2012' and '3/31/2012 11:59:59 pm' and studentpk = 3988 and ledgerpk = 88436

	SELECT        a.linetype, a.ref AS LedgerRef, CASE b.trpk WHEN - 1 THEN 'REQUEST' ELSE '' END AS RequestType, 
	ISNULL(c.TRCode, 'OTHERS') AS TranCode, 
							 a.amount AS LedgerAmount,b.quantity, b.unitamount,b.amount AS EnrollSubjectCostLineAmount, ISNULL(a.remarks, '') AS LedgerRemarks,
							  a.ledgerdate, a.IsBackAccountClearing, a.coursepk--, d.CourseID
	FROM            Ledger AS a LEFT OUTER JOIN
							 EnrollSubjectsCost AS b ON a.ref = b.headerpk LEFT OUTER JOIN
							 TRTypes AS c ON b.trpk = c.TRPK --LEFT OUTER JOIN Courses d ON a.coursepk = d.coursepk
	WHERE        (a.studentpk = 3464) AND (a.sempk = 2) AND (a.sypk = 37) AND linetype <> 'RCPT'

select a.*,b.* from EnrollSubjects a join EnrollSubjectscost b 
 on a.enrollpk = b.headerpk --order by b.pk desc
 where studentpk = 80 and yearpk = 37 and sempk = 2

select * from EnrollSubjects where studentpk = 3325 and yearpk = 37 and sempk = 2

select * from Ledger where studentpk = 3325  and sypk = 37 and sempk = 2 and linetype <> 'RCPT'

select studentpk from Students where StudentName like '%llAMAS%'

select * from Ledger order by ledgerdate desc

select * from EnrollSubjectsCost where headerpk = 2119

select * from EnrollSubjectsCost order by pk desc -- last record pk = 42882
select * from EnrollSubjects order by enrollpk desc --  last record pk = 41142

SELECT        students.StudentName, ledgerdate, ref, linetype, balance, sypk, remarks, amount, students.studentpk, sempk, subjectpk, coursepk, IsBackAccountClearing
FROM            Ledger join Students on ledger.studentpk = students.StudentPK 
WHERE        ( linetype = 'TUTOR' )
ORDER BY ledgerdate 

--UPDATE Ledger set linetype = 'TUTORERROR' WHERE linetype = 'TUTOR' AND sempk = 2 and sypk = 37 

SELECT     coursepk
FROM         EnrollSubjects
WHERE     (studentpk = 80) AND (status = 1)
ORDER BY date DESC

