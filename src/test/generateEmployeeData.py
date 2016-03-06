#!/usr/bin/python
# -*- coding: utf-8 -*-

import sqlite3 as lite
import sys

con = lite.connect('../jmbde.db')

employees = []

with con:
    
    cur = con.cursor()    
    for i in range(1, 100):
        employees.insert(i, ( " " + str(i), "Tester" + str(i) ))
     
    print employees 
    cur.executemany("INSERT INTO Employee(EmployeeNO, Name) VALUES (?, ?);", employees)
        
    cur.execute("SELECT * FROM Employee")
    rows = cur.fetchall()
    
    for row in rows:
        print row