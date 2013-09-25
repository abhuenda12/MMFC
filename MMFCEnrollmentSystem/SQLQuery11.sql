--set back to new based on prefyear prefsem

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
        
        
 --get students who are only enrolled this current year and sem
 SELECT StudentName , StudentType FROM Students 
   -- enrolled in CurYear And CurSem  
   WHERE studentPK IN 
         (  
        	select distinct studentpk from enrollsubjects where 
			   ( yearpk = ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) )
					and 
			   ( sempk = (select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curSem' ) )			    
				    and 
			   (status = 1  )               
        )
   -- not enrolled in previous years and sems
   AND 
   studentPK NOT IN
		(  
        	select distinct studentpk from enrollsubjects where 
			   ( -- those enrolled in previous years
					yearpk <> ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) )
					or 
			   ( -- enrolled same year but different sem meaning previous sem
			    yearpk = ( select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curYear' ) 
			    and
				sempk <> (select top 1 PrefValue FROM PrefTable WHERE PrefName = 'curSem' ) 			   
			   )			    
				and 
			   (status = 1  )               
        )
 ORDER BY StudentName