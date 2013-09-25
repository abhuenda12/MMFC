SELECT  StudentName , StudentType FROM Students WHERE 
        -- studentType NOT IN ( 'OLD' , 'CROSS-ENROLLED')  AND         
        studentPK  IN
        ( -- students that have enroll header records in current year or current sem
		   select distinct studentpk from enrollheader where 
             ( yearpk <> ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) )  
             OR ( yearpk = ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) AND sempk <> (select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curSem'  ) ) 
        ) 
         AND studentPK IN 
         (  -- students that have enroll subject records in current year or current sem
        	select distinct studentpk from enrollsubjects where 
			  ( yearpk <> ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) ) 
			   OR ( yearpk = ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) and sempk <> (select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curSem' ) ) 
			   and status = 1 
        )

-- use sorter value of the sem/sy pks in the enrollsubjects table 
-- above line gives you the sem/sy that is the most current
--  preftable can be change so you can't rely on it to give latest sy/sem

-- TO SET BACK TO NEW 
UPDATE Students SET StudentType = 'NEW'
WHERE StudentPK IN
( -- enrolled in latest current year and sem
	select distinct studentpk from enrollsubjects where yearpk = 31 and sempk = 1
		( yearpk = (SELECT MAX(sorter) FROM EnrollSubjects INNER JOIN SchoolYear ON EnrollSubjects.yearpk = SchoolYear.sypk) ) 
		 AND ( sempk = (SELECT MAX(sorter) FROM EnrollSubjects INNER JOIN Semester ON EnrollSubjects.sempk = Semester.SemPK) ) 
	    and status = 1 
)
AND StudentPK NOT IN
(  -- not enrolled in previous years and sems
   select distinct studentpk from enrollsubjects where 
		( yearpk <> (SELECT MAX(sorter) FROM EnrollSubjects INNER JOIN SchoolYear ON EnrollSubjects.yearpk = SchoolYear.sypk) )
			-- or same year but not same sem 
		 OR ( yearpk = (SELECT MAX(sorter) FROM EnrollSubjects INNER JOIN SchoolYear ON EnrollSubjects.yearpk = SchoolYear.sypk)
				AND sempk <> (SELECT MAX(sorter) FROM EnrollSubjects INNER JOIN Semester ON EnrollSubjects.sempk = Semester.SemPK)
		       ) 
	    and status = 1 
)

SELECT MAX(Semester.sorter) FROM EnrollSubjects INNER JOIN Semester ON EnrollSubjects.sempk = Semester.SemPK
	WHERE -- yearpk is the latest
	   EnrollSubjects.yearpk = (SELECT MAX(sorter) FROM EnrollSubjects INNER JOIN SchoolYear ON EnrollSubjects.yearpk = SchoolYear.sypk)
	   
UPDATE Students SET StudentType = 'OLD'
WHERE studentType NOT IN ( 'OLD' , 'CROSS-ENROLLED')  AND    
StudentPK  IN
(  --  enrolled in previous years and sems
   select distinct studentpk from enrollsubjects where 
		( yearpk <> (SELECT MAX(sorter) FROM EnrollSubjects INNER JOIN SchoolYear ON EnrollSubjects.yearpk = SchoolYear.sypk) )
			-- or same year but not same sem 
		 OR ( yearpk = (SELECT MAX(sorter) FROM EnrollSubjects INNER JOIN SchoolYear ON EnrollSubjects.yearpk = SchoolYear.sypk)
				AND sempk <> (SELECT MAX(sorter) FROM EnrollSubjects INNER JOIN Semester ON EnrollSubjects.sempk = Semester.SemPK)
		       ) 
	    and status = 1 
)

select * from EnrollSubjects where yearpk = 38
select MAX(yearpk) from EnrollSubjects